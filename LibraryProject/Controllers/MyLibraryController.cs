
using Microsoft.AspNetCore.Mvc;

using System.Linq;

using LibraryProject.Models.ViewModels;
using LibraryProject.Models.Books;
using LibraryProject.Models.ApplicationContext;

namespace LibraryProject.Controllers
{
    public class MyLibraryController : Controller
    {
        private readonly PersonalLibrary personalLibrary;
        LibraryContext db;

        
        
        public MyLibraryController(PersonalLibrary _personalLibrary, LibraryContext _db )
        {
            personalLibrary=_personalLibrary;
            db=_db;
            
        }


        
        
        public ViewResult PersonalLibrary()
        {
            var items = personalLibrary.GetMyLibraries();
            personalLibrary.myLibraries = items;

            var obj = new PersonalLibraryViewModel
            {
                _personalLibrary = personalLibrary
            };
            
            
            return View(obj);
        }

        public RedirectToActionResult AddToLibrary(int id)
        {
            var item = db.Books.FirstOrDefault(b => b.Id == id);
            if(item!=null)
            {
            personalLibrary.AddToPersonalLibrary(item);
            }
            return RedirectToAction("PersonalLibrary");
        }
        
    }
}
