namespace RoleBaseAccessControl
{
    public class RoleAuth
    {
        static Dictionary<string, (string Password, UserRole Role)> users = new Dictionary<string, (string, UserRole)>
    {
        { "Admin", ("admin123", UserRole.Admin) }
    };

        static int userCount = 0;

        enum UserRole
        {
            Admin,
            Editor,
            Viewer
        }

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
        }

        static void RegisterUser()
        {
            userCount++;
            string username = "User" + userCount;
            Console.Write("Enter password for " + username + ": ");
            string password = Console.ReadLine();

            Console.WriteLine("Select role for this user:");
            Console.WriteLine("1. Viewer");
            Console.WriteLine("2. Editor");
            string roleChoice = Console.ReadLine();
            UserRole userRole = roleChoice == "1" ? UserRole.Viewer : UserRole.Editor;

            if (!users.ContainsKey(username))
            {
                users.Add(username, (password, userRole));
                Console.WriteLine("User registered successfully as: " + username + " with role: " + userRole);
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

            if (users.ContainsKey(username) && users[username].Password == password)
            {
                Console.WriteLine("Login successful! Welcome, " + username);

                UserRole userRole = users[username].Role;
                AccessResource(username, userRole);
            }
            else
            {
                Console.WriteLine("Invalid username or password. Access denied!");
            }
        }

        static void AccessResource(string username, UserRole role)
        {
            Console.WriteLine("\nAttempting to access resource...");

            switch (role)
            {
                case UserRole.Admin:
                    Console.WriteLine($"{username} (Admin): Full access granted.");
                    break;

                case UserRole.Editor:
                    Console.WriteLine($"{username} (Editor): Limited edit access granted.");
                    break;

                case UserRole.Viewer:
                    Console.WriteLine($"{username} (Viewer): Read-only access granted.");
                    break;

                default:
                    Console.WriteLine("Access denied. No valid role assigned.");
                    break;
            }
        }

        private static void Exit()
        {
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }
    }
}
