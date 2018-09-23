using System;

namespace QuizUp.Common
{
    /// <summary>
    /// Menu item of Master Page
    /// </summary>
    public class MasterHomeMenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public Type TargetType { get; set; }
    }
}