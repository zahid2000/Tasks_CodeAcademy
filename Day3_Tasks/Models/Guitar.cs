using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Tasks.Models
{
    public class Guitar:Instrument
    {
        public override string Sound()
        {
            return "Guitar Sound";
        }

        public string Type { get; set; } = null!;
        public bool IsString { get; set; }
        public Guitar()
        {

        }

        public Guitar(string brand, string model, double price, DateTime createdDate,string type,bool isString) : base(brand, model, price, createdDate)
        {
            Type=type;
            IsString=isString;
        }
    }
}
