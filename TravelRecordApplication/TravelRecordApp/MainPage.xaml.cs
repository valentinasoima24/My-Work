using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly= typeof(MainPage);

            iconImage.Source = ImageSource.FromResource("TravelRecordApp.Assets.Images.plane.png", assembly);


#if DEBUG
            EmailEntry.Text = "aa@aa.com";
            PasswordEntry.Text = "aa@aa.com";

#endif
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = string.IsNullOrEmpty(EmailEntry.Text); //to see if there is text inside the email entry or not
            bool isPasswordEmpty = string.IsNullOrEmpty(PasswordEntry.Text);
            

            if(isEmailEmpty || isPasswordEmpty)
            {
                await DisplayAlert("Error!", "You didn't complete the email or password fields.", "Cancel"); 
            }
            else
            {
                if(EmailEntry.Text.Contains("@")==false && (EmailEntry.Text.Contains(".") == false))
                {
                    await DisplayAlert("Error!", "The email is not valid.", "Cancel");
                }
                else 
                { 
                    await Navigation.PushAsync(new HomePage()); 
                }

               
            }

        }
    }
}
