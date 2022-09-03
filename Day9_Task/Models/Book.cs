using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_Task.Models;

    public class Book
    {
        private static int _count = 100;

        public Book()
        {
            _count++;

        }


        public Book(string name, string authorName, int pageCount) : this()
        {
            Name = name;
            AuthorName = authorName;
            PageCount = pageCount;
            Code = name.Substring(0, 2).ToUpper() + _count;

        }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }

        private string Code { get; set; }




        public string GetCode()
        {
            return Code;
        }

    }


