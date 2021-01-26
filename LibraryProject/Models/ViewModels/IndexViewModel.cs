using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.Models.Books;
using LibraryProject.ViewModels;

namespace LibraryProject.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
