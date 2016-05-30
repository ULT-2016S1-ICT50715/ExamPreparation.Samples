using NewLibraryApp.DataAccess.Model;
using SharpRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibraryApp.Services
{
    public class BookApplicationService
    {
        private IRepository<Book> _bookRepository;

        public BookApplicationService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void CreateBook(string isbn, string title, int authorId, string description)
        {
            var book = new Book()
            {
                ISBN = isbn,
                Title = title,
                AuthorId = authorId,
                Description = description
            };

            _bookRepository.Add(book);
        }

        public void UpdateBook(int bookId, string title, int authorId, string description)
        {
            var book = _bookRepository.Get(bookId);

            book.Title = title;
            book.AuthorId = authorId;
            book.Description = description;

            _bookRepository.Update(book);
        }

        public void DeleteBook(int bookId)
        {
            //_bookRepository.Delete(bookId);

            var book = _bookRepository.Get(bookId);
            _bookRepository.Delete(book);
        }
    }
}
