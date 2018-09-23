using Newtonsoft.Json;

namespace QuizUp.Models
{
    /// <summary>
    /// Profile of user from Facebook
    /// </summary>
    public class FacebookProfile
    {
        public string Name { get; set; }
        public Picture Picture { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        public string Id { get; set; }
    }

    /// <summary>
    /// Profile Image from facebook
    /// </summary>
    public class Picture
    {
        public Data Data { get; set; }
    }

    /// <summary>
    /// Actual url of user profile from facebook
    /// </summary>
    public class Data
    {
        public string Url { get; set; }
    }
}
