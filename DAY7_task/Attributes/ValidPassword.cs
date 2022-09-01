using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DAY7_task.Attributes
{
    public class ValidPassword : ValidationAttribute
    {
        public override bool IsValid(object? password)
        {
            return checkPassword((string)password); 
                  
        }
        bool checkPassword(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }
            else if (!Char.IsUpper(password[0]))
            {
                return false;
            }
            else
            {
                Regex regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-zA-Z]).*$");
                Match match = regex.Match(password);
                return match.Success;
            }
        }
    }
}
