using System;

namespace UserLogin
{
    public class User
    {
        public System.Int32 UserId 
        { get; set; }
        public string Username
        { get; set; }

        public string Password
        { get; set; }

        public string FakNum
        { get; set; }

        public int Role
        { get; set; }

        public DateTime Created
        { get; set; }

        public DateTime? ExpireOn
        { get; set; }

        public User()
        {
           
        }
    }
}
