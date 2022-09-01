using System.Text.RegularExpressions;
using Day8_Tasks.Delegates;
using Day8_Tasks.ILogger;
using Day8_Tasks.Services;

namespace Day8_Tasks.Models;

public class Company
{
    public Company()
    {
            
    }

    public Company( string name)
    {
            Name=name;
    }
    public string Name { get; set; }
    private List<User> Users = new List<User>();

    public void AddUser(User user)
    {
        Users.Add(user);
    }

    public void DeleteUser(User user)
    {
        Users.Remove(user);
    }
    public List<User> GetUsers() => Users;
}