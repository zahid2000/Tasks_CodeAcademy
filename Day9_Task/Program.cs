using System.Diagnostics;
using Day9_Task.Models;
using Day9_Task.Services;

Book book1 = new Book("Harry Potter", "Zahid", 344);
Book book2 = new Book("Harry Potter1", "Yusif", 200);
Book book3 = new Book("Harry Potter2", "Nadir", 300);
Book book4 = new Book("Harry Potter3", "Elcin", 453);
Book book5 = new Book("Harry Potter1", "Yusif", 111);
Book book6 = new Book("Harry Potter2", "Asgar", 500);


Library library = new Library() { };
library.Books = new List<Book>() { book1, book2, book3, book4, book5 };

LibraryService libraryService = new LibraryService(library);

while (true)
{
    Console.WriteLine($"1.Add Book \n2.Find All books by name\n3.Get Book\n4.Remove All Books\n5.Get All Books\n6.Exit");

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
    else if (answer=="5")
    {
        GetAllBooks();
    }
    else if (answer == "6")
    {
        break;
    }
}


void AddBook()
{
    Console.WriteLine("Add Book name");
    string name = Console.ReadLine();
    Console.WriteLine("Add Author name");
    string authorName = Console.ReadLine();
    Console.WriteLine("Add Page count");
    int pageCount = int.Parse(Console.ReadLine());
    Book book = new Book(name, authorName, pageCount);
    libraryService.AddBook(book);
}
void FindAllBooks()
{
    Console.WriteLine("Enter Book's name");
    string name = Console.ReadLine();
    foreach (var item in libraryService.FindAllBooks(b => b.Name == name))
    {
        Console.WriteLine(
            $"Name : {item.Name} AuthorName : {item.AuthorName} PageCount : {item.PageCount} Code : {item.GetCode()}");
    }
}
void GetBook()
{
    Console.WriteLine("Enter book's name");
    string name = Console.ReadLine();
    var item = libraryService.GetBook(b => b.Name == name);
    if (item != null)
    {
        Console.WriteLine($"Name : {item.Name} AuthorName : {item.AuthorName} PageCount : {item.PageCount} Code : {item.GetCode()}");

    }

}
void RemoveAllBooks()
{
    Console.WriteLine("Enter the book's name");
    string name= Console.ReadLine();
    libraryService.RemoveAllBooks(b=>b.Name==name);
}

void GetAllBooks()
{
    var result = libraryService.GetAllBooks();
    foreach (var item in result)
    {
        Console.WriteLine(
            $"Name : {item.Name} AuthorName : {item.AuthorName} PageCount : {item.PageCount} Code : {item.GetCode()}");
    }
}