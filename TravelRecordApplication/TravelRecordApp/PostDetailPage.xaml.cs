using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostDetailPage : ContentPage
    {
        Post post = new Post();
        public PostDetailPage(Post selectedData)
        {
            InitializeComponent();
            post = selectedData;

            experienceEntry.Text = selectedData.Experiences;
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            post.Experiences = experienceEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {

                conn.CreateTable<Post>();
                int rows = conn.Update(post); 
                if (rows > 0)
                {
                    DisplayAlert("Succes", "Experience updated successfully!", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be updated!", "Ok");
                }
            }
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {

                conn.CreateTable<Post>(); 
                int rows = conn.Delete(post); 
                if (rows > 0)
                {
                    DisplayAlert("Succes", "Experience deleted successfully!", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience failed to be deleted!", "Ok");
                }
            }
        }
    }
}