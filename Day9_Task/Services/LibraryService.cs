using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day9_Task.IServices;
using Day9_Task.Models;

namespace Day9_Task.Services
{
    public class LibraryService : ILibraryServices
    {
        private Library _library;

        public LibraryService(Library library)
        {
            _library = library;
        }

        public void AddBook(Book book)
        {
            _library.Books.Add(book);
            Console.WriteLine("Book Added");
        }

        public Book GetBook(Func<Book, bool> predicate)
        {
            Book result = _library.Books.FirstOrDefault(predicate);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public List<Book> GetAllBooks()
        {
            return _library.Books;
        }

        public List<Book> FindAllBooks(Func<Book, bool> predicate)
        {
            List<Book> result=_library.Books.Where(predicate).ToList();
            if (result.Count==0)
            {
                Console.WriteLine("Books doesn't find");
                return null;
            }
            return result;
        }

        public void RemoveAllBooks(Predicate<Book> predicate)
        {
            var result = _library.Books.FindAll(predicate);
            if (result.Count==0)
            {
                Console.WriteLine("Books doesn't found");
            }

            _library.Books.RemoveAll(predicate);

        }
    }
}
