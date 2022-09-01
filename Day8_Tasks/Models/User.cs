namespace Day8_Tasks.Models;

public class User
{
    private static int _id = 0;
    public User()
    {
        _id++;
        Id = _id;
    }
    public User(string name, string surname, string password) : this()
    {
        Name = name;
        Surname = surname;
        Password = password;
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    private string? Username;
    private string? Email;

    private string? Password { get; set; }
    public void SetUserName(string userName)
    {
        Username = userName;
    }
    public void SetEmail(string email)
    {
        Email = email;
    }
    public void SetPassword(string password)
    {
        Password = password;
    }

    public string GetUsername() => Username;
    public string GetEmail() => Email;
    public string GetPassword() => Password;
}