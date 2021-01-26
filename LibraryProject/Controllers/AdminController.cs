using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LibraryProject.Models.ApplicationContext;
using LibraryProject.Models.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LibraryProject.Controllers
{
    public class AdminController : Controller
    {

        IWebHostEnvironment webHostEnvironment;
        private readonly ILogger<HomeController> _logger;
        private LibraryContext db;
        List<Category> categories = new List<Category>();
        public AdminController(ILogger<HomeController> logger, LibraryContext _context, IWebHostEnvironment webHost)
        {
            _logger = logger;
            db = _context;
            webHostEnvironment = webHost;

        }

        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult AdminPage()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        [HttpGet]
        
        public ActionResult CreateBook()
        {
            ViewBag.Category = new SelectList(db.Categories, "Id", "CategoryName"); ;
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateBook(Book book)
        {
            if (book.bookFile != null && book.imageFile != null)
            {
                book.bookFilePath = "/Files/Books/" + book.bookFile.FileName;
                book.bookFileName = book.bookFile.FileName;

                using FileStream fileStream = new FileStream(webHostEnvironment.WebRootPath + book.bookFilePath, FileMode.Create);
                await book.bookFile.CopyToAsync(fileStream);

                book.imageFilePath = "/Files/Images/" + book.imageFile.FileName;
                book.imageFileName = book.imageFile.FileName;

                using FileStream imageStream = new FileStream(webHostEnvironment.WebRootPath + book.imageFilePath, FileMode.Create);
                await book.imageFile.CopyToAsync(imageStream);
            }

            Category category = categories.FirstOrDefault(c => c.Id == book.CategoryId);
            db.Books.Add(book);
            await db.SaveChangesAsync();
            return RedirectToAction("AdminPage");
        }

        [HttpGet]
        
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            db.Categories.Add(category);
            await db.SaveChangesAsync();
            return RedirectToAction("AdminPage");
        }



        // GET: Admin/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Book book = await db.Books.FirstOrDefaultAsync(b => b.Id == id);
                if (book != null)
                {
                    return View(book);
                }

            }
            return NotFound();

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Book book)
        {
            db.Books.Update(book);
            await db.SaveChangesAsync();
            return RedirectToAction("AdminPage");
        }


        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id != null)
            {
                Category category = await db.Categories.FirstOrDefaultAsync(b => b.Id == id);
                if (category != null)
                {
                    return View(category);
                }

            }
            return NotFound();

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditCategory(Category category)
        {
            db.Categories.Update(category);
            await db.SaveChangesAsync();
            return RedirectToAction("AdminPage");
        }



        // GET: Admin/Delete/5
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Book book = await db.Books.FirstOrDefaultAsync(b => b.Id == id);
                if (book != null)
                {
                    return View(book);
                }

            }
            return NotFound();

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Book book = await db.Books.FirstOrDefaultAsync(b => b.Id == id);
                db.Books.Remove(book);
                await db.SaveChangesAsync();
                return RedirectToAction("AdminPage");
            }
            return NotFound();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ToList(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Name" : "";
            ViewData["AuthorSortParm"] = sortOrder == "Author" ? "author_desc" : "Author";
            ViewData["SearchByName"] = searchString;

            _logger.LogInformation("");

            var books = from b in db.Books
                        select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Name":
                    books = books.OrderByDescending(s => s.Name);
                    break;
                case "Author":
                    books = books.OrderBy(s => s.Author);
                    break;
                case "author_desc":
                    books = books.OrderByDescending(s => s.Author);
                    break;
                
                default:
                    books = books.OrderBy(s => s.Name);
                    break;
            }

            return View(await books.AsNoTracking().ToListAsync());
        }
        public async Task<IActionResult> CategoriesToList()
        {

            return View(await db.Categories.ToListAsync());

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AllUsersToList()
        {


            return View(await db.Users.ToListAsync());
        }
        [Authorize(Roles = "Admin")]
        
        public FileResult FileOut(int id)
        {
            
            Book book = db.Books.FirstOrDefault(b => b.Id == id);
            string pathtoFile = book.bookFilePath;
            string fileType = "application/fb2";

            string fileName = $"{book.bookFileName}.fb2";
            _logger.LogInformation($"File{fileName} was download in {DateTime.Now}");


            return File(pathtoFile, fileType, fileName);
        }
    }
    
}