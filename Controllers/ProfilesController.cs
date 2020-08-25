using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.WebPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PapugarniaOnline.DAL;
using PapugarniaOnline.Data;
using PapugarniaOnline.Models;
using Rotativa;


namespace PapugarniaOnline.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly PapugarniaOnlineContext _context;
        private readonly ApplicationDbContext _apcontext;
        
        public static string name2;
        public static string surname2, city2, street2, number2, zipcode2;
      
        // Inject UserManager using dependency injection.
        // Works only if you choose "Individual user accounts" during project creation.

        public ProfilesController(PapugarniaOnlineContext context, ApplicationDbContext apcontext)
        {
            _context = context;
            _apcontext = apcontext;
        }
        [Authorize]
        public IActionResult Index()
        {

            var data = _context.Profiles.Select(p => p).Where(p => p.UserName == this.User.Identity.Name);

            foreach (var item2 in data)
            {
                name2 = item2.FirstName;
                surname2 = item2.SurName;
                city2 = item2.City;
                street2 = item2.Street;
                number2 = item2.Number;
                zipcode2 = item2.ZipCode;
            }

            if (name2 != null)
            {
                ViewBag.Data = "Uzupełniłeś już swoje dane wcześniej.";
                ViewBag.name = name2;
                ViewBag.surname = surname2;
                ViewBag.city = city2;
                ViewBag.street = street2;
                ViewBag.number = number2;
                ViewBag.zipcode = zipcode2;
                return View();
            }
            else
            {
                ViewBag.Data = "ok";
            }

            return View();
        }
        [Authorize]
        public IActionResult ReadForm(string name, string surname, string zipcode ,string city, string street, string number)
        {
            List<string> user = new List<string>();
            var username = _apcontext.Users.Where(u => u.UserName == this.User.Identity.Name).Select(u => u.UserName);

            foreach (var item in username)
            {
                user.Add(item);
            }

            Profile profile = null;
            profile = new Profile { UserName = user[0],  FirstName = name, SurName= surname, ZipCode = zipcode, City= city, Street = street, Number = number};
            _context.Profiles.Add(profile);
            _context.SaveChanges();

            return View();
        }
    }
}
