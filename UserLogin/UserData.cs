using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin
{
    static public class UserData
    {
        static public List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        static private List<User> _testUsers;

        static private void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>
                {
                    new User
                    {
                        Username = "vanyok_st",
                        Password = "12345",
                        FakNum = "123219015",
                        Role = 1,
                        Created = DateTime.Now,
                        ExpireOn = DateTime.MaxValue
                    },
                    new User
                    {
                        Username = "GenaMorar",
                        Password = "password",
                        FakNum = "123220018",
                        Role = 4,
                        Created = DateTime.Now,
                        ExpireOn = DateTime.MaxValue
                    },
                    new User
                    {
                        Username = "Nikita",
                        Password = "password",
                        FakNum = "123219013",
                        Role = 4,
                        Created = DateTime.Now,
                        ExpireOn = DateTime.MaxValue
                    },
                };
            }
        }

        static public User IsUserPassCorrect(string UserName, string Password)
        {
            UserContext context = new UserContext();

            User user = (from u in context.Users
                          where u.Username.Equals(UserName) && u.Password.Equals(Password)
                          select u).DefaultIfEmpty(null).First();

            return user;
        }

        static public void SetUserActiveTo(string UserName, DateTime date)
        {
            foreach(User user in TestUsers)
            {
                if (user.Username.Equals(UserName))
                {
                    user.ExpireOn = date;
                    Logger.LogActivity("Expire date has been changed for " + UserName);
                }
            }
        }

        static public void AssignUserRole(string UserName, UserRoles userRole)
        {
            UserContext context = new UserContext();

            User usr =
            (from u in context.Users
             where u.Username.Equals(UserName)
             select u).First();

            usr.Role = (int) userRole;
            Logger.LogActivity("Role has been changed for " + UserName);

            context.SaveChanges();
        }

        static public void ShowUsers()
        {
            foreach(User user in TestUsers)
            {
                Console.WriteLine("Username: " + user.Username);
                Console.WriteLine("User password: " + user.Password);
                Console.WriteLine("User faculty number: " + user.FakNum);
                Console.WriteLine("User Role: " + (UserRoles)user.Role);
                Console.WriteLine("Created on: " + user.Created);
                Console.WriteLine("Expire on: " + user.ExpireOn);
            }
        }
    }
}
