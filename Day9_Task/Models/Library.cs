namespace Day9_Task.Models;

public class Library
{
    public List<Book> Books { get; set; }


}

public class Order
{
    public int  Id { get; set; }
    public List<Book> Books { get; set; }
    public double Total { get; set; }
    public DateTime Date { get; set; }
   
}