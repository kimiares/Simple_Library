using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.Models.Books;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryProject.Models
{
    public class FilterViewModel
    {

        public FilterViewModel(List<Category> categories, int? category, string book)
        {
            categories.Insert(0, new Category { CategoryName = "Все", Id = 0 });
            Categories = new SelectList(categories, "Id", "CategoryName", category);
            SelectedCategory = category;
            SelectedBook = book;
           
        }
        public SelectList Categories { get; set; } // список компаний
        public int? SelectedCategory { get; private set; }   // выбранная компания
        public string SelectedBook { get; private set; }    // введенное имя
        
    }
    
}
