using Plugin.Geolocator;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();


            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);
            venueListView.ItemsSource = venues;

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                //
                Venue selectedVenue = new Venue();
                if (venueListView.SelectedItem != null)
                    selectedVenue = venueListView.SelectedItem as Venue;

                var firstCategory = selectedVenue.categories.FirstOrDefault();

                Post post = new Post()
                {
                    Experiences = ExperienceEntry.Text,
                    CategoryId = firstCategory.id,
                    CategoryName = firstCategory.name,
                    Address = selectedVenue.location.address,
                    Distance = int.Parse(selectedVenue.location.distance),
                    Latitude = double.Parse(selectedVenue.location.lat),
                    Longitude = double.Parse(selectedVenue.location.lng),
                    VenueName = selectedVenue.name
                    //scrie ce trebue sa faci -_
                };

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {

                    conn.CreateTable<Post>(); //creating table
                    int rows = conn.Insert(post); //inserting into the table //it inserts an integer

                    //one connection at a time with the database so ->

                    //conn.Close(); //if we don'tclose, we might get errors later when trying to access the database again

                    if (rows > 0)
                    {
                        ExperienceEntry.Text = String.Empty;
                        DisplayAlert("Succes", "Experience inserted successfully!", "Ok");
                    }
                    else
                    {
                        DisplayAlert("Failure", "Experience failed to be inserted!", "Ok");
                    }
                }
            }
            catch (NullReferenceException nre)
            {

            }
            catch (Exception exc)
            {

            }


        }
    }
}