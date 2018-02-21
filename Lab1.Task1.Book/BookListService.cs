using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab1.Task1.BookLibrary
{
    public class BookListService
    {
        private readonly IBookRepository repository;
        private List<Book> books;
        public BookListService(IBookRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            try
            {
                books = repository.GetBooks().ToList();
            }
            catch (FileNotFoundException)
            {
                books = new List<Book>();
                repository.SaveBooks(books);
            }
        }

        public List<Book> GetBooks()
        {
            return new List<Book>(books);
        }

        public void AddBook(Book toAdd)
        {
            if (toAdd == null)
            {
                throw new ArgumentNullException(nameof(toAdd));
            }
            if (books.Contains(toAdd))
            {
                throw new ArgumentException("List already contains this book.", nameof(toAdd));
            }
            books.Add(toAdd);
        }

        public void RemoveBook(Book toRemove)
        {
            if (toRemove == null)
            {
                throw new ArgumentNullException(nameof(toRemove));
            }
            if (!books.Contains(toRemove))
            {
                throw new ArgumentException("List does not contain this book.", nameof(toRemove));
            }
            books.Remove(toRemove);
        }

        public Book FindBook(Predicate<Book> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }
            return books.Find(match);
        }

        public void SortBooks()
        {
            books.Sort();
        }

        public void SortBooks(Comparison<Book> comparison)
        {
            if (comparison == null)
            {
                throw new ArgumentNullException(nameof(comparison));
            }
            books.Sort(comparison);
        }

        public void SaveBooks()
        {
            repository.SaveBooks(books);
        }
    }
}
