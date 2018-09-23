using Newtonsoft.Json;
using QuizUp.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuizUp.Services
{
    public class FacebookService
    {
        public FacebookProfile FacebookProfile { get; set; }

        private static FacebookService _instance;

        private FacebookService() { }

        internal static FacebookService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FacebookService();
                }

                return _instance;
            }
        }
        public async Task GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl =
                "https://graph.facebook.com/v3.1/me/?fields=name,picture,work,website,religion,location,locale,link,cover,age_range,birthday,devices,email,first_name,last_name,gender,hometown,is_verified,languages&access_token="
                + accessToken;

            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);

            FacebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);
        }
    }
}
