using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            User user = null;

            if (new LoginValidation(username, password, Logger.LogError).ValidateUserInput(ref user))
            {
                Logger.LogActivity("Successful Login");

                Console.WriteLine("Username: " + user.Username);
                Console.WriteLine("User password: " + user.Password);
                Console.WriteLine("User faculty number: " + user.FakNum);
                Console.WriteLine("User Role: " + LoginValidation.currentUserRole);
                Console.WriteLine("Created on: " + user.Created);
                Console.WriteLine("Expire on: " + user.ExpireOn);

                if(user.Role == 1)
                {
                    while(AdminFunctionality() != 0);
                }
            }
        }

        private static int AdminFunctionality()
        {
            Console.WriteLine("Choose one option:\n" +
                "0: Exit\n" +
                "1: Change user role\n" +
                "2: Change expire date\n" +
                "3: Show all users\n" +
                "4: Show logs\n" +
                "5: Show current acitivities");
            Console.Write("Enter: ");
            string ch = Console.ReadLine();

            switch (ch)
            {
                case "0": return 0;
                case "1":
                    SetNewRole();
                    return 1;
                case "2":
                    SetExpireDate();
                    return 2;
                case "3":
                    UserData.ShowUsers();
                    return 3;
                case "4":
                    Logger.ShowLogFile();
                    return 4;
                case "5":
                    ShowCurrentSessionActivities();
                    return 5;
                default: return 0;
            }
        }

        private static void SetNewRole()
        {
            Console.Write("Enter username: ");
            string userName = Console.ReadLine();
            Console.Write("Enter user role: ");
            int userRole = Int32.Parse(Console.ReadLine());
            UserData.AssignUserRole(userName, (UserRoles)userRole);
        }

        private static void SetExpireDate()
        {
            Console.Write("Enter username: ");
            string userName = Console.ReadLine();
            Console.Write("Enter expire date: ");
            DateTime dateTime = DateTime.Parse(Console.ReadLine());
            UserData.SetUserActiveTo(userName, dateTime);
        }

        private static void ShowCurrentSessionActivities()
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<string> currentSessionActivities = Logger.GetCurrentSessionActivities("INFO");
            foreach (string line in currentSessionActivities)
            {
                sb.Append(line + "\n");
            }
            Console.WriteLine(sb);
        }
    }

   
}
