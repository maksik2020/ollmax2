using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1,"ISBN 1234-12245 0","D. Knuth","Art of Programming","lorem ipsum lorem ipsum lorem ipsum lorem ipsum", 7.19m),
            new Book(2,"ISBN 1234-12246 0","M. Fowler","Refactoring","lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum", 12.45m),
            new Book(3,"ISBN 1234-12247 0","B. Kernighan, D.Ritchie","C Programming language","lorem ipsum lorem", 14.98m),
        };

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId
                             select book;
            return foundBooks.ToArray();
        }

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

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }
    }
}
