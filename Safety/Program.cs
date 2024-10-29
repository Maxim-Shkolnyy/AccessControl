
namespace Safety;

internal class Program
{
    static Dictionary<string, string> users = new Dictionary<string, string>
    {
        { "Admin", "admin123" }
    };

    static int userCount = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the System");

        while (true)
        {
            Console.WriteLine("\nChoose access control policy:");
            Console.WriteLine("1. Discretionary Access Control");
            Console.WriteLine("2. Mandatory Access Control");
            Console.WriteLine("3. Role Base Access Control");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                DiscretionaryAccessControl.DiscretionaryAuth.Auth();
            }
            else if (choice == "2")
            {
                MandatoryAccessControl.MandatoryAuth.Auth();
            }
            else if (choice == "3")
            {
                RoleBaseAccessControl.RoleAuth.Auth();
            }
            else
            {
                Console.WriteLine("Invalid option. Please choose again.");
            }
        }
    }
}
