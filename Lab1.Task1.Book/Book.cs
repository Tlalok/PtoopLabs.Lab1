using System;

namespace Lab1.Task1.BookLibrary
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        private readonly string author;
        private readonly string title;
        public string Author { get { return author; } }
        public string Title { get { return title; } }
        public int PageCount { get; set; }
        public int YearPublishing { get; set; }
        public string Genre { get; set; }

        public Book(string author, string title, int pageCount, int yearPublishing, string genre)
        {
            this.author = author ?? throw new ArgumentNullException(nameof(author));
            this.title = title ?? throw new ArgumentNullException(nameof(title));
            Genre = genre ?? throw new ArgumentNullException(nameof(genre));
            PageCount = pageCount;
            YearPublishing = yearPublishing;
        }

        public bool Equals(Book other)
        {
            if (other == null)
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            var authorsAreEqual = string.Equals(this.Author, other.Author, StringComparison.InvariantCultureIgnoreCase);
            var titlesAreEqual = string.Equals(this.Title, other.Title, StringComparison.InvariantCultureIgnoreCase);
            if (authorsAreEqual && titlesAreEqual)
            {
                return true;
            }
            return false;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Book);
        }

        public int CompareTo(Book other)
        {
            if (other == null)
            {
                return -1;
            }
            var titleCompareResult = string.Compare(this.Title, other.Title, StringComparison.InvariantCultureIgnoreCase);
            if (titleCompareResult != 0)
            {
                return titleCompareResult;
            }
            return string.Compare(this.Author, other.Author, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Author.GetHashCode() + Title.GetHashCode();
        }
    }
}
