using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewLibraryApp.UI.ViewModels.Book
{
    public class BookIndexViewModel
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}