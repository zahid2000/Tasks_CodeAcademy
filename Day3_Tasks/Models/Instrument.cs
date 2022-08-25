using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Tasks.Models
{
    public abstract class Instrument
    {
       
        public string Brand { get; set; } = null!;
        public string Model { get; set; }=null!;
        public double Price { get; set; }
       
        public DateTime CreatedDate { get; set; }
        public abstract string Sound();
        public Instrument()
        {

        }

        public Instrument(string brand, string model, double price, DateTime createdDate)
        {
            Brand = brand;
            Model = model;
            Price = price;
            CreatedDate = createdDate;
        }

    }
}
