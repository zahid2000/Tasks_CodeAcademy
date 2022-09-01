
using DAY7_task.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

User user = new User
{
    Name = "zahid",
    Email = "zad",
    Password = "password",
};
void isValid<T>(T entity)
{
    foreach (PropertyInfo info in entity.GetType().GetProperties())
    {
        ValidationAttribute[] a = ValidationAttribute.GetCustomAttributes();
        foreach (Attribute item in a)
        {
            
        }
        Console.WriteLine("a");
    }
}

isValid(user);