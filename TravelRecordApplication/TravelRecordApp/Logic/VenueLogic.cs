using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;

namespace TravelRecordApp.Logic
{
    public class VenueLogic
    {
        public async static Task<List<Venue>> GetVenues(double latitude, double longitude)
        {
            List<Venue> venues = new List<Venue>();

            var url = "https://api.foursquare.com/v2/venues/search?ll=40.7,-74&client_id=PCN4IR53LJI1MB3HJ2HLDQUPD2IHAUM3GFSHKDGO5WL4SKHS&client_secret=OQS1HWAUXTHQPV2XIUXYMGESZUPAJ0YOLOAMTMVGN5DIV1SE&v=20220623";// VenueRoot.GenerateURL(latitude, longitude);

            using (HttpClient client = new HttpClient())
            {
               var response= await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                var venueRoot= JsonConvert.DeserializeObject<VenueRoot>(json);

                venues=venueRoot.response.venues as List<Venue>;
            }

                return venues;
        }
    }
}
