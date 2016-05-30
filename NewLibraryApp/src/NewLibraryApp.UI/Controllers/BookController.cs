using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewLibraryApp.DataAccess.Model;
using SharpRepository.EfRepository;
using NewLibraryApp.Services;
using NewLibraryApp.UI.ViewModels.Book;

namespace NewLibraryApp.UI.Controllers
{
    public class BookController : Controller
    {
        private NewLibraryDbContext _context;
        private EfRepository<Book> _bookRepository;
        private BookApplicationService _bookService;

        public BookController()
        {
            _context = new NewLibraryDbContext();
            _bookRepository = new EfRepository<Book>(_context);
            _bookService = new BookApplicationService(_bookRepository);
        }

        // GET: Book
        public ActionResult Index()
        {
            //var books = _bookRepository.GetAll();

            //var model = books.Select(b => new BookIndexViewModel()
            //{
            //    Id = b.Id,
            //    ISBN = b.ISBN,
            //    Title = b.Title,
            //    Author = b.Author.FirstName + " " + b.Author.LastName
            //});

            var model = _bookRepository.AsQueryable()
                .Select(b => new BookIndexViewModel()
                {
                    Id = b.Id,
                    ISBN = b.ISBN,
                    Title = b.Title,
                    Author = b.Author.FirstName + " " + b.Author.LastName
                }).ToList();

            return View(model);
        }

        public ActionResult Create()
        {
            var authors = _context.Authors.ToList();
            var model = new BookCreateViewModel()
            {
                Authors = new SelectList(authors, "Id", "LastName")
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(BookCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _bookService.CreateBook(model.ISBN, model.Title, model.AuthorId, model.Description);
                return RedirectToAction("Index");
            }

            var authors = _context.Authors.ToList();
            model.Authors = new SelectList(authors, "Id", "LastName", model.AuthorId);
            return View(model);
        }

        public ActionResult Details(int id)
        {
            //var book = _bookRepository.Get(id);

            //var model = new BookDetailsViewModel()
            //{
            //    Id = book.Id
            //};

            var model = _bookRepository.AsQueryable()
                .Where(b => b.Id == id)
                .Select(b => new BookDetailsViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    Description = b.Description,
                    Author = b.Author.FirstName + " " + b.Author.LastName
                }).FirstOrDefault();

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = _bookRepository.AsQueryable()
                .Where(b => b.Id == id)
                .Select(b => new BookEditViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    AuthorId = b.AuthorId
                }).FirstOrDefault();

            var authors = _context.Authors.ToList();
            model.Authors = new SelectList(authors, "Id", "LastName", model.AuthorId);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, BookEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                _bookService.UpdateBook(id, model.Title, model.AuthorId, model.Description);
                return RedirectToAction("Index");
            }

            var authors = _context.Authors.ToList();
            model.Authors = new SelectList(authors, "Id", "LastName", model.AuthorId);

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var model = _bookRepository.AsQueryable()
                .Where(b => b.Id == id)
                .Select(b => new BookDetailsViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    Description = b.Description,
                    Author = b.Author.FirstName + " " + b.Author.LastName
                }).FirstOrDefault();

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}