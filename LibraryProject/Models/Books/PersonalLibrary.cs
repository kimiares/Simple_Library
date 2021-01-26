using LibraryProject.Models.ApplicationContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryProject.Models.Books
{
    public class PersonalLibrary
    {

        private readonly LibraryContext db;
        public PersonalLibrary (LibraryContext libraryContext)
        {
            db = libraryContext;
        }

        public string MyLibId { get; set; }
        public List<MyLibrary> myLibraries { get; set; }

        public static PersonalLibrary GetLibrary(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = serviceProvider.GetService<LibraryContext>();
            string myLibId = session.GetString("Id") ?? Guid.NewGuid().ToString();
            session.SetString("Id",myLibId );

            return new PersonalLibrary(context) {MyLibId=myLibId};
        }  
        public void AddToPersonalLibrary(Book book)
        {
            
            
            db.PersonalLibraries.Add(new MyLibrary{MyLibId=MyLibId, book=book});
            db.SaveChanges();

        }
        public List<MyLibrary> GetMyLibraries()
        {
            
            return db.PersonalLibraries.Where(l => l.MyLibId==MyLibId).Include(b=>b.book).ToList();   
            
        }
        

    }
}
