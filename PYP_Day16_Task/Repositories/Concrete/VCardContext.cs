using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PYP_Day16_Task.Entities;

namespace PYP_Day16_Task.Repositories.Concrete
{
    public class VCardContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-QBQM5QA\SQLEXPRESS;database=VCards;Trusted_Connection=true;");
            base.OnConfiguring(optionsBuilder);
        }   

        public  DbSet<VCard> VCards { get; set; }

      
    }
}
