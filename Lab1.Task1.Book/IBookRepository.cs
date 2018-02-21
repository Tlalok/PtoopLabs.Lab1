using System.Collections.Generic;

namespace Lab1.Task1.BookLibrary
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        void SaveBooks(IEnumerable<Book> books);
    }
}
