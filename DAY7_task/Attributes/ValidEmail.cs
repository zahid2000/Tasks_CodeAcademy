using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DAY7_task.Attributes
{
    public class ValidEmail : ValidationAttribute
    {
        public override bool IsValid(object? email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match((string)email);
            return match.Success;
        }
    }
}
