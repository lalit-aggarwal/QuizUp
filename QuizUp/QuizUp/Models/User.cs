namespace QuizUp.Models
{
    /// <summary>
    /// Represents user in database
    /// </summary>
    public class User
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ProfileImage { get; set; }

        public bool IsLoggedIn { get; set; }

        public int QuizAttempts { get; set; }
    }
}
