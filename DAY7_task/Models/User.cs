using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAY7_task.Attributes;

namespace DAY7_task.Models
{
    public class User
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [ValidEmail]
        public string Email { get; set; }
        [ValidPassword]
        public string Password { get; set; }
    }
}
