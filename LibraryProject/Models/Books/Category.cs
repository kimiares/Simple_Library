using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Models.Books
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Book> Books { get; set; }
    }
}
