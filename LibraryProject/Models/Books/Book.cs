using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LibraryProject.Models.Books
{
    public class Book
    {
        public int Id { get; set; }
        [Display(Name ="Название книги")]
        public string Name { get; set; }
        [Display(Name = "Автор")]
        public string Author { get; set; }
        
        [Display(Name = "Краткое описание")]
        public string Description { get; set; }
        // Adding photo/book file. That's real govnocode.
        public string bookFileName { get; set; }
        public string bookFilePath { get; set; }

        public string imageFileName { get; set; }
        public string imageFilePath { get; set; }

        [NotMapped]
        public IFormFile bookFile { get; set; }
        [NotMapped]
        public IFormFile imageFile { get; set; }


        public int CategoryId { get; set; }
       
        public Category Category { get; set; }

    }
}
