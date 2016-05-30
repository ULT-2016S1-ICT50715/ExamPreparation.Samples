using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewLibraryApp.DataAccess.Model
{
    public class Borrow
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BookdId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnedDate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Book Book { get; set; }
    }
}
