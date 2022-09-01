using System.ComponentModel.Design;
using System.Reflection.Emit;
using System.Security.Cryptography;
using Day8_Tasks.Delegates;
using Day8_Tasks.ILogger;
using Day8_Tasks.Models;
using Day8_Tasks.Services;


UserService userService = new UserService();
ConsoleLogger logger = new ConsoleLogger();
LoggerManager loggerDelegate = new LoggerManager(logger.Log);

Console.WriteLine("Create a Company");
Console.WriteLine("Add Company name");
string companyName = Console.ReadLine();
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine(new String('-', 100));
Console.ResetColor();
Company company = new Company(companyName);
CompanyService companyService = new CompanyService(company);
while (true)
{

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine(new String('-', 100));
    Console.ResetColor();
    Console.WriteLine("\tMenu\n1.Register a user User\n2..Login in a user\n3.See all users in Company \n4.Get one User from Company" +
                      "\n5.Update User's datas\n6.Delete User from Company\n7.Exit");
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine(new String('-', 100));
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine(new String('-', 100));
    Console.ResetColor();
    string answer = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine(new String('-', 100));
    Console.ResetColor();

    if (answer == "1")
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(new String('-', 100));
        Console.ResetColor();
        Register();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(new String('-', 100));
        Console.ResetColor();
    }
    else if (answer == "2")
    {
        if (company.GetUsers().Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
            Console.WriteLine("Does not find any user in database.Firstly,regirter user then login!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
            Console.WriteLine("Login account");
            Login();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
        }

    }
    else if (answer == "3")
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(new String('-', 100));
        Console.ResetColor();
        Console.WriteLine($"All {company.Name} users");
        GetAllUser();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(new String('-', 100));
        Console.ResetColor();
    }
    else if (answer == "4")
    {
       
        Console.WriteLine("Enter user id");
        int id;
        bool result = int.TryParse(Console.ReadLine(), out id);
        if (result)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
            Console.WriteLine($"User info Id {id} ");
            GetUserById(id);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
            Console.WriteLine("Entered  value type must be number type");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
        }
       
        

    }
    else if (answer == "5")
    {
        Console.WriteLine("Enter UserId for  Update");
        int id;
        bool result = int.TryParse(Console.ReadLine(), out id);
        if (result)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
            Console.WriteLine($"Updated Id -> {id} ");
            UpdateUserById(id);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
            Console.WriteLine("Entered  value type must be number type");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
        }
        
    }
    else if (answer == "6")
    {
        Console.WriteLine("Enter UserId for  Delete");
        int id;
        bool result = int.TryParse(Console.ReadLine(), out id);
        if (result)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
            Console.WriteLine($"Deleted Id -> {id} ");
            DeleteById(id);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
            Console.WriteLine("Entered value type must be number type");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new String('-', 100));
            Console.ResetColor();
        }

    }
    else if (answer=="7")
    {
        Console.WriteLine("See you");
        break;
    }

}

void Register()
{
    bool result;
UserName:
    Console.WriteLine("Adi Daxil edin");
    string name = Console.ReadLine();
    result = userService.checkUsername(name);
    if (!result) goto UserName;
    Surname:
    Console.WriteLine("Soyad daxil edin");
    string surname = Console.ReadLine();
    result = userService.checkSurname(surname);
    if (!result) goto Surname;
    UserPassword:
    Console.WriteLine("Password daxil edin");
    string password = Console.ReadLine();
    result = userService.checkPassword(password);
    if (!result) goto UserPassword;
    User user = new User(name, surname, password);
    user.SetPassword(password);
    companyService.Register(user);
}

void Login()
{
    Console.WriteLine("Username daxil edin");
    string LoginUsername = Console.ReadLine();
    Console.WriteLine("Password daxil edin");
    string LoginPassword = Console.ReadLine();
    companyService.Login(LoginUsername, LoginPassword);
}

void GetAllUser()
{
    var users = company.GetUsers();
    foreach (var user in users)
    {
        loggerDelegate.Invoke($"\t\t Id : {user.Id} Name : {user.Name} Surname : {user.Surname}");
    }
}

void GetUserById(int id)
{
    User user = companyService.GetById(id);
    Console.WriteLine($"\t\t Id : {user.Id} Name : {user.Name} Surname : {user.Surname}");
}

void UpdateUserById(int id)
{
    Console.WriteLine("a.Update name\nb.Update surname\nc.Update username\nd.Update email");
    string answer = Console.ReadLine();
    string updateValue;
    if (Equals(answer.ToLower(), "a"))
    {
        Console.WriteLine("Enter the Name");
        updateValue = Console.ReadLine();
        companyService.UpdateName(updateValue,id);
    }
    else if (Equals(answer.ToLower(), "b"))
    {
        Console.WriteLine("Enter the Surname");
        updateValue = Console.ReadLine();
        companyService.UpdateSurname(updateValue, id);
    }
    else if (Equals(answer.ToLower(), "a"))
    {
        Console.WriteLine("Enter the Username");
        updateValue = Console.ReadLine();
        companyService.UpdateUsername(updateValue, id);
    }
    else if (Equals(answer.ToLower(), "a"))
    {
        Console.WriteLine("Enter the Email");
        updateValue = Console.ReadLine();
        companyService.UpdateEmail(updateValue, id);
    }

}

void DeleteById(int id)
{
    var result = companyService.CheckuserExistsById(id);
    if (result)
    {
        Console.WriteLine("Are you sure?Y/N");
        string answer=Console.ReadLine();
        if (Equals(answer.ToLower(),"y"))
        {
            companyService.DeleteUserById(id);
        }else if (Equals(answer.ToLower(), "n"))
        {
            Console.WriteLine("User doesn't deleted");
        }
    }
    else
    {
        Console.WriteLine("User does not exists");
    }
}
