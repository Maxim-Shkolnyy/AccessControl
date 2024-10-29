namespace DiscretionaryAccessControl
{
    public class DiscretionaryAuth
    {
        static Dictionary<string, string> users = new Dictionary<string, string>
    {
        { "Admin", "admin123" }
    };

        static int userCount = 0;

        public static void Auth()
        {
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Register new user");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    RegisterUser();
                }
                else if (choice == "2")
                {
                    Login();
                }
                else if (choice == "3")
                {
                    Exit();
                }
                else
                {
                    Console.WriteLine("Invalid option. Please choose again.");
                }
            }

            static void RegisterUser()
            {
                userCount++;
                string username = "User" + userCount;
                Console.Write("Enter password for " + username + ": ");
                string password = Console.ReadLine();

                if (!users.ContainsKey(username))
                {
                    users.Add(username, password);
                    Console.WriteLine("User registered successfully as: " + username);
                }
                else
                {
                    Console.WriteLine("User already exists!");
                }
            }

            static void Login()
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();
                bool isAdmin = false;

                if (users.ContainsKey(username) && users[username] == password)
                {
                    if (username.StartsWith("Admin"))
                    {
                        isAdmin = true;

                        Console.WriteLine("Login successful! Welcome, " + username);

                        AccessFile(username, isAdmin);
                    }
                    else
                    {
                        isAdmin = false;

                        Console.WriteLine("Login successful! Welcome, " + username);

                        AccessFile(username, isAdmin);
                    }


                }
                else
                {
                    Console.WriteLine("Invalid username or password. Access denied!");
                }
            }

            static void AccessFile(string username, bool isAdmin)
            {
                if (isAdmin == true)
                {
                    Console.WriteLine("Admin access granted. Welcome to admin page. ");
                }
                else
                {
                    Console.WriteLine("Access granted to the user page for " + username);
                }
            }
        }

        private static void Exit()
        {
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }
    }
}
