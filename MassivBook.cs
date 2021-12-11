using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba12
{
    class MassivBook
    {
        private List<Book> books;
        public MassivBook(List<Book> books)
        {
            this.books = books;
        }
        public List<Book> SortName()
        {
            return books.OrderBy(book => book.Name).ToList();
        }
        public List<Book> SortAuthor()
        {
            return books.OrderBy(book => book.Author).ToList();
        }
        public List<Book> SortPublisher()
        {
            return books.OrderBy(book => book.Publisher).ToList();
        }
    }
}
