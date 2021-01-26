using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LibraryProject.Models;
using LibraryProject.Models.ApplicationContext;
using LibraryProject.Models.Books;
using Microsoft.EntityFrameworkCore;
using LibraryProject.ViewModels;

namespace LibraryProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
         
        LibraryContext db;

        public HomeController(ILogger<HomeController> logger, LibraryContext _context)
        {
            _logger = logger;
            db = _context;
        }

        

        // add the categories list page
        public async Task<IActionResult> CategoriesToList()
        {

            return View(await db.Categories.ToListAsync());

        }
        
    
        public async Task<IActionResult> Library(int? category, string book, int page = 1, SortState sortOrder = SortState.BookNameAsc)
        {

            //Logging into txt file, Why not?
            _logger.LogInformation($"Library was open in {DateTime.Now}");

           

            //Filtration
            IQueryable<Book> sourceBooks = db.Books.Include(x => x.Category);
            if (category != null && category != 0)
            {
                sourceBooks = sourceBooks.Where(p => p.CategoryId == category);
            }
            if (!String.IsNullOrEmpty(book))
            {
                sourceBooks = sourceBooks.Where(p => p.Name.Contains(book) || p.Author.Contains(book));
            }
            

            //sorting
            switch (sortOrder)
            {
                case SortState.BookNameAsc:
                    sourceBooks = sourceBooks.OrderByDescending(s => s.Name);
                    break;
                case SortState.AuthorAsc:
                    sourceBooks = sourceBooks.OrderBy(s => s.Author);
                    break;
                case SortState.AuthorDesc:
                    sourceBooks = sourceBooks.OrderByDescending(s => s.Author);
                    break;
                case SortState.CategoryAsc:
                    sourceBooks = sourceBooks.OrderBy(s => s.Category.CategoryName);
                    break;
                case SortState.CategoryDesc:
                    sourceBooks = sourceBooks.OrderByDescending(s => s.Category.CategoryName);
                    break;
                default:
                    sourceBooks = sourceBooks.OrderBy(s => s.Name);
                    break;
            }
            //pagination
            int pageSize = 5;
            var count = await sourceBooks.CountAsync();
            var items = await sourceBooks.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            //forming ViewModel
            
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(db.Categories.ToList(),category, book),

                Books = items
                
            };

            return View(viewModel);



            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
    
}
