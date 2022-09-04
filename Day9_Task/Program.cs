using System.Diagnostics;
using Day9_Task.Models;
using Day9_Task.Services;

Book book1 = new Book("Harry Potter", "Zahid", 150, 344);
Book book2 = new Book("Harry Potter1", "Yusif", 67, 200);
Book book3 = new Book("Harry Potter2", "Nadir", 200, 300);
Book book4 = new Book("Harry Potter3", "Elcin", 112, 453);
Book book5 = new Book("Harry Potter1", "Yusif", 20, 111);
Book book6 = new Book("Harry Potter2", "Asgar", 55, 500);


Library library = new Library() { };
Order order = new Order();
order.Books = new List<Book>(){};
library.Books = new List<Book>() { book1, book2, book3, book4, book5 };

LibraryService libraryService = new LibraryService(library);
OrderService orderService = new OrderService(order);

while (true)
{
    Console.WriteLine($"1.Add Book \n2.Find All books by name\n3.Get Book\n4.Remove All Books\n5.Get All Books\n6.Order Book\n7.GetOrderPrice\n8.Exit");

    string answer = Console.ReadLine();

    if (answer == "1")
    {
        AddBook();
    }
    else if (answer == "2")
    {
        FindAllBooks();
    }
    else if (answer == "3")
    {
        GetBook();
    }
    else if (answer == "4")
    {
        RemoveAllBooks();
    }
    else if (answer == "5")
    {
        GetAllBooks();
    }
    else if (answer == "6")
    {
        OrderBook();
    }
    else if (answer == "7")
    {
        GetOrderPrice();
    }
    else if (answer == "7")
    {
        break;
    }
}


void AddBook()
{
    Console.WriteLine("Enter Book name");
    string name = Console.ReadLine();
    Console.WriteLine("Enter Author name");
    string authorName = Console.ReadLine();
    Console.WriteLine("Enter Book Price");
    double bookPrice = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Enter Page count");
    int pageCount = int.Parse(Console.ReadLine());
    Book book = new Book(name, authorName, bookPrice, pageCount);
    libraryService.AddBook(book);
}
void FindAllBooks()
{
    Console.WriteLine("Enter Book's name");
    string name = Console.ReadLine();
    foreach (var item in libraryService.FindAllBooks(b => b.Name == name))
    {
        Console.WriteLine($"Name : {item.Name} AuthorName : {item.AuthorName} Price:{item.Price}  PageCount : {item.PageCount} Code : {item.GetCode()}");

    }
}
void GetBook()
{
    Console.WriteLine("Enter book's name");
    string name = Console.ReadLine();
    Book item = libraryService.GetBook(b => b.Name == name);
    if (item != null)
    {
        Console.WriteLine($"Name : {item.Name} AuthorName : {item.AuthorName} Price:{item.Price}  PageCount : {item.PageCount} Code : {item.GetCode()}");

    }

}
void RemoveAllBooks()
{
    Console.WriteLine("Enter the book's name");
    string name = Console.ReadLine();
    libraryService.RemoveAllBooks(b => b.Name == name);
}
void GetAllBooks()
{
    var result = libraryService.GetAllBooks();
    foreach (var item in result)
    {
        Console.WriteLine($"Name : {item.Name} AuthorName : {item.AuthorName} Price:{item.Price}  PageCount : {item.PageCount} Code : {item.GetCode()}");

    }
}
void OrderBook()
{
    Console.WriteLine("Enter Book name");
    string name = Console.ReadLine();
    Book item = libraryService.GetBook(b => b.Name == name);
    if (item != null)
    {
        orderService.OrderBook(item);
    }
    else
    {
        Console.WriteLine("This book doesn't find");
    }
}

void GetOrderPrice()
{
    orderService.GetTotalPriceByDiscount();
}