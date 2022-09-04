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


    public Book(string name, string authorName, double price, int pageCount) : this()
    {
        Name = name;
        AuthorName = authorName;
        PageCount = pageCount;
        Price = price;
        Code = CreateCode(name);

    }
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public int PageCount { get; set; }
    public double Price { get; set; }
    private string Code { get; set; }




    public string GetCode()
    {
        return Code;
    }

    private string CreateCode(string code)
    {
        var str = code.Split(" ");
        StringBuilder resultCode = new StringBuilder();
        if (str.Length > 0)
        {
            foreach (var item in str)
            {
                resultCode.Append(item.Substring(0, 1));
            }

            resultCode.Append($"-{_count}");
            return resultCode.ToString();
        }
        return code.Substring(0, 1).ToUpper() + _count;
    }

}


