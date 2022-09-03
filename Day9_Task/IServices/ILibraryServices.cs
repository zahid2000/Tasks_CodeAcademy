using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day9_Task.Models;

namespace Day9_Task.IServices
{
    public interface ILibraryServices
    {

        void AddBook(Book book);
        Book GetBook(Func<Book,bool> predicate);
        public List<Book> GetAllBooks();
        List<Book> FindAllBooks(Func<Book, bool> predicate);
        void RemoveAllBooks(Predicate<Book> predicate);
    }
}
