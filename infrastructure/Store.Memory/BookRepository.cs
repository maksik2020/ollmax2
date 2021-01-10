using System;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1,"ISBN 1234-12245 0","D. Knuth","Art of Programming"),
            new Book(2,"ISBN 1234-12246 0","M. Fowler","Refactoring"),
            new Book(3,"ISBN 1234-12247 0","B. Kernighan, D.Ritchie","C Programming language"),
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn)
                .ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query)
            || book.Title.Contains(query))
                .ToArray();
        }
    }
}
