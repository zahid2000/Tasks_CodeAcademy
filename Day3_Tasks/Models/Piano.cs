using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Tasks.Models
{
    public class Piano:Instrument
    {
        public override string Sound()
        {
            return "Piano Sound";
        }

        public double Width { get; set; }
        public double Height { get; set; }

        public Piano()
        {
                
        }

        public Piano(string brand,string model,double price,DateTime createdDate,double width,double height):base(brand, model, price, createdDate)
        {
                Width=width;
                Height=height;
        }
    }
}
