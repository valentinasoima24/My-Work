using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;
using SQLite;
using TravelRecordApp.Model;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();


            GetLocation();

            GetPosts();
        }

        private void GetPosts()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();

                DisplayOnMap(posts);
            }
        }

        private void DisplayOnMap(List<Post> posts)
        {
            foreach (var post in posts)
            {
                try
                {
                    var pinCoordinates = new Xamarin.Forms.Maps.Position(post.Latitude, post.Longitude);
                    var pin = new Pin()
                    {
                        Position = pinCoordinates,
                        Label = post.VenueName,
                        Address = post.Address,
                        Type = PinType.SavedPin
                    };

                    mainMap.Pins.Add(pin);
                }
                catch(NullReferenceException nre) { }
               catch(Exception exc) { }
            }
        }

        private async void GetLocation()
        {
            var status = await CheckAndRequestLocationPermission();

            if (status == PermissionStatus.Granted)
            {
                var locator = CrossGeolocator.Current;
                if (locator.IsGeolocationEnabled && locator.IsGeolocationAvailable)
                {
                    var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(5));
                    var center = new Position(position.Latitude, position.Longitude);
                    var span = new MapSpan(center, 1, 1);



                    mainMap.MoveToRegion(span);
                }

                //mainMap.IsShowingUser = true;
            }
        }

        //code from the sources he put

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            CenterMap(e.Position.Latitude, e.Position.Longitude);
        }

        private void CenterMap(double latitude, double longitude)
        {
            var center = new Xamarin.Forms.Maps.Position(latitude, longitude);
            MapSpan span = new MapSpan(center, 1, 1);

            mainMap.MoveToRegion(span);
        }

        private async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if(status == PermissionStatus.Granted)
            {
                return status;
            }

            if(status== PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.Android)
            {
                return status;
            }
            

                status =await Permissions.RequestAsync<Permissions.LocationWhenInUse>(); 
            return status;
        }
    }
}