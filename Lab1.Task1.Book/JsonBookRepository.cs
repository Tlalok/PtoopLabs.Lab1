using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Lab1.Task1.BookLibrary
{
    public class JsonBookRepository : IBookRepository
    {
        public string Path { get; private set; }

        public JsonBookRepository(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("File path cannot be empty string.", nameof(filePath));
            }
            Path = filePath;
        }

        public IEnumerable<Book> GetBooks()
        {
            if (!File.Exists(Path))
            {
                throw new FileNotFoundException($"File '{Path}' not found.");
            }
            var json = File.ReadAllText(Path);
            var books = JsonConvert.DeserializeObject<List<Book>>(json);
            return books;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            var json = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(Path, json);
        }
    }
}
