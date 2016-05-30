using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewLibraryApp.UI.ViewModels.Book
{
    public class BookEditViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Author")]
        [Required]
        public int AuthorId { get; set; }
        public SelectList Authors { get; set; }
    }
}