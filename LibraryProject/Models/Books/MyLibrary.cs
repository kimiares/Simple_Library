using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using LibraryProject.Models.Books;

namespace LibraryProject.Models.Books
{

    public class MyLibrary
    {
        [Key]
        public int ItemId {get;set;}
        public Book book {get;set;}

        public string MyLibId{get;set;}


    }
}