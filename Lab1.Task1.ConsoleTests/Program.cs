using Lab1.Task1.BookLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab1.Task1.ConsoleTests
{
    class Program
    {
        private const string fileName = "books.json";

        static void Main(string[] args)
        {
            var bookRepository = new JsonBookRepository(fileName);
            var bookService = new BookListService(bookRepository);
            Console.WriteLine("Исходный список книг:");

            PrintListBooks(bookService.GetBooks());

            var book = new Book("Льюис Кэрролл", "Алиса в Стране чудес", 237, 1865, "Сказка");
            Console.WriteLine("Пытаемся добавить книгу");
            PrintBook(book);
            try
            {
                bookService.AddBook(book);
                Console.WriteLine("Книга успешно добавлена");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: {0}\n", e.Message);
            }

            Console.WriteLine("Пытаемся удалить книгу");
            try
            {
                bookService.RemoveBook(book);
                Console.WriteLine("Книга успешно удалена");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: {0}\n", e.Message);
            }
            Console.WriteLine();

            Console.WriteLine("Сохраняем список в файл и читаем из него");
            bookService.SaveBooks();
            PrintListBooks(bookRepository.GetBooks().ToList());

            Console.WriteLine("Снова пытаемся удалить книгу");
            try
            {
                bookService.RemoveBook(book);
                Console.WriteLine("Книга успешно удалена");
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: {0}\n", e.Message);
            }

            Console.WriteLine("Пытаемся найти удаленную книгу по названию \"Алиса в Стране чудес\"");
            Book seaarchResult = bookService.FindBook(b => b.Title == "Алиса в Стране чудес");
            if (seaarchResult == null)
            {
                Console.WriteLine("Книга не найдена");
            }
            else
            {
                Console.WriteLine("Книга найдена");
                PrintBook(seaarchResult);
            }
            Console.WriteLine();

            Console.WriteLine("Добавляем удаленную книгу и свнова пытаеся ее найти");
            bookService.AddBook(book);
            seaarchResult = bookService.FindBook(b => b.Title == "Алиса в Стране чудес");
            if (seaarchResult == null)
            {
                Console.WriteLine("Книга не найдена");
            }
            else
            {
                Console.WriteLine("Книга найдена\n");
                PrintBook(seaarchResult);
            }
            bookService.SaveBooks();
            Console.WriteLine();
            Console.WriteLine("Полученный список");
            PrintListBooks(bookRepository.GetBooks().ToList());

            Console.WriteLine("Сортировка книг по автору");
            bookService.SortBooks((a, b) => string.Compare(a.Author, b.Author));
            bookService.SaveBooks();
            PrintListBooks(bookRepository.GetBooks().ToList());

            Console.WriteLine("Сортировка книг по названию");
            bookService.SortBooks((a, b) => string.Compare(a.Title, b.Title));
            bookService.SaveBooks();
            PrintListBooks(bookRepository.GetBooks().ToList());
            MakeTestFile(fileName);
            Console.ReadKey();
        }

        private static void MakeTestFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            var bookService = new BookListService(new JsonBookRepository(path));
            var toAdd = new Book("Антуан де Сент-Экзюпери", "Маленький принц", 54, 1943, "Сказка");
            bookService.AddBook(toAdd);
            toAdd = new Book("Макс Фрай", "Лабиринт Менина", 316, 2003, "Фэнтези");
            bookService.AddBook(toAdd);
            toAdd = new Book("Льюис Кэрролл", "Алиса в Стране чудес", 237, 1865, "Сказка");
            bookService.AddBook(toAdd);
            toAdd = new Book("Виталий Зыков", "Безымянный раб", 609, 2004, "Фэнтези");
            bookService.AddBook(toAdd);
            bookService.SaveBooks();
        }

        private static void PrintListBooks(IEnumerable<Book> listBooks)
        {
            var i = 1;
            foreach (var book in listBooks)
            {
                Console.WriteLine("Книга {0}", i++);
                PrintBook(book);
            }
        }

        private static void PrintBook(Book book)
        {
            Console.WriteLine(" Автор: {0} \n Название: {1} \n Количество страниц: {2} \n Год публикации: {3} \n Жанр: {4} \n",
                    book.Author, book.Title, book.PageCount, book.YearPublishing, book.Genre);
        }
    }
}
