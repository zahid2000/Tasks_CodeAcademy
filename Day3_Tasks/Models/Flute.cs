using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Tasks.Models
{
    public class Flute:Instrument
    {
        public override string Sound()
        {
            return "Flute Sound";
        }

        public double FluteLong{ get; set; }
        public Flute()
        {

        }

        public Flute(string brand, string model, double price, DateTime createdDate, double fluteLong) : base(brand, model, price, createdDate)
        {
           FluteLong=fluteLong;
        }
    }
}
