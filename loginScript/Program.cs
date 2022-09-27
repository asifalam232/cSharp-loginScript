
using System.Collections;
using loginScript;

internal class Program
{

    private static List<UserInfo> users = new List<UserInfo>();

    private static void Main(string[] args)
    {
        //UserInfo user1 = new UserInfo("user1", "password1");
        UserInfo user1 = new UserInfo("user1", "password1");
        users.Add(user1);
        UserInfo user2 = new UserInfo("user2", "password2");
        users.Add(user2);
        MenuScreen();
        string? userInput = Console.ReadLine();

        switch (userInput)
        {
            case "1":
                RegisterUser();
                break;
            case "2":
                login();
                break;
            case "3":
                getAllusers();
                break;
        }
    }

    private static void login()
    {
        Console.WriteLine("Enter the correct username and password to login");
        int attempt = 0;
        bool authenticated = false;

        while (attempt < 3)
        {
            Console.WriteLine("Enter your username: ");
            string otherUserName = Console.ReadLine();
            if (string.IsNullOrEmpty(otherUserName))
            {
                Console.WriteLine("Please enter a correct username.");
            }
            else
            {
                Console.WriteLine("Enter your password: ");
                string otherPassword = Console.ReadLine();
                foreach (var user in users)
                {
                    if (user.getUserName().Equals(otherUserName) && user.getPassword().Equals(otherPassword))
                    {
                        Console.WriteLine("You have successfully logged in");
                        authenticated = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Access not authorised");
                        attempt++;
                    }
                }
            }
            break;
        }
        if (attempt == 3)
        {
            Console.WriteLine("\"Three incorrect attempts. You have been banned.");

        }
    }

    private static void getAllusers()
    {
        Console.WriteLine("****Registered users");
        foreach (var user in users)
        {
            Console.WriteLine(user.getUserName());
        }
    }

    private static void MenuScreen()
    {
        Console.WriteLine("WelCome to my loginScript");
        Console.WriteLine("Please choose from the following options: ");
        Console.WriteLine("1. Register new User ");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. View Users");
    }

    private static void RegisterUser()
    {
        Console.WriteLine("Enter the following details to register an Account");
        string userName = stringValidation("username: ");
        string password = stringValidation("password: ");

        UserInfo user = new UserInfo(userName, password);
        users.Add(user);
        Console.WriteLine($"{userName} has registered");
    }

    public static string stringValidation (string message)
    {
        bool isString = false;
        string stringInput = null;

        while (!isString)
        {
            Console.Write(message);
            stringInput = Console.ReadLine();
            try
            {
                Int32.Parse(stringInput);
                Console.WriteLine("You entered a Number. Please try again. ");
            }
            catch (Exception ex)
            {
                isString = true;
            }
        }
        return stringInput;
    }
}