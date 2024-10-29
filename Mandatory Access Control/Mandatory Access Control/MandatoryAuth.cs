namespace MandatoryAccessControl
{
    public class MandatoryAuth
    {
        static Dictionary<string, (string Password, SecurityLevel Level)> users = new Dictionary<string, (string, SecurityLevel)>
    {
        { "Admin", ("admin123", SecurityLevel.TopSecret) }
    };

        static int userCount = 0;

        enum SecurityLevel
        {
            Public,
            Secret,
            TopSecret
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

            SecurityLevel userLevel = SecurityLevel.Public;

            if (!users.ContainsKey(username))
            {
                users.Add(username, (password, userLevel));
                Console.WriteLine("User registered successfully as: " + username + " with access level: " + userLevel);
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

                SecurityLevel userLevel = users[username].Level;
                AccessFile(username, userLevel);
            }
            else
            {
                Console.WriteLine("Invalid username or password. Access denied!");
            }
        }

        static void AccessFile(string username, SecurityLevel userLevel)
        {
            string fileName = "SecretFile";
            SecurityLevel fileLevel = SecurityLevel.Secret;

            Console.WriteLine($"\nAttempting to access {fileName} with required access level: {fileLevel}");

            if (userLevel >= fileLevel)
            {
                Console.WriteLine($"{username} granted access to {fileName} with security level {fileLevel}.");
            }
            else
            {
                Console.WriteLine($"{username} does not have the required access level for {fileName}. Access denied.");
            }
        }

        private static void Exit()
        {
            Console.WriteLine("Exiting...");
            Environment.Exit(0);
        }
    }
}
