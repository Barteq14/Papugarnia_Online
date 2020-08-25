using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using PapugarniaOnline.DAL;
using PapugarniaOnline.Data;
using PapugarniaOnline.Models;
using Rotativa;
using Rotativa.AspNetCore;

namespace PapugarniaOnline.Controllers
{
    public class OrdersController : Controller
    {
        private readonly PapugarniaOnlineContext _context;
        private readonly ApplicationDbContext _apcontext;
        public static List<Ticket> tickets = new List<Ticket>();
        public static double AllPrice;
        public static double AllPrice2;
        public static string ticketname;
        public static List<string> user = new List<string>();
        public static List<Order> orders = new List<Order>();

        // Inject UserManager using dependency injection.
        // Works only if you choose "Individual user accounts" during project creation.

        public OrdersController(PapugarniaOnlineContext context,ApplicationDbContext apcontext)
        {
            _context = context;
            _apcontext = apcontext;
        }
     
        public IActionResult Index(int id)
        {
           
            var query = _context.Tickets.Select(t => t).Where(t => t.ID == id);
            foreach(var item in query)
            {
                ticketname = ticketname + " " + item.TicketName;
                AllPrice = AllPrice + item.Price;
                tickets.Add(item);
            }

            if(tickets.Count < 1)
            {
                ViewBag.IsEmpty = "Koszyk jest pusty.";
                return View();
            }else
            {
                ViewBag.IsEmpty = "ok";
             
                ViewBag.ALLPRICE = AllPrice;
            }
                

            return View(tickets);
        }
        public IActionResult BuyTicket()
        {
            
            List<string> ticket = new List<string>();
            List<double> price = new List<double>();
            Order order = null;

            var username = _apcontext.Users.Where(u => u.UserName == this.User.Identity.Name).Select(u => u.UserName);

            foreach (var item in username)
            {
                user.Add(item);
            }
            
            
            foreach (var item in tickets)
            {
                ticket.Add(ticketname);
                price.Add(AllPrice);
            }

            

            order = new Order { Username = user[0], TicketName = ticket[0], Price = price[0], date  = DateTime.Now };
            _context.Orders.Add(order);
            _context.SaveChanges();

            tickets.Clear();
            AllPrice = 0.0;
            ticketname = "";
            
            return View();
        }

        public IActionResult DeleteTicket(int id)
        {
            foreach(var item in tickets.ToList())
            {
                if(item.ID == id)
                {
                    tickets.Remove(item);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult OrderHistory()
        {
            orders.Clear();
            var username = _apcontext.Users.Where(u => u.UserName == this.User.Identity.Name).Select(u => u.UserName);

            foreach (var item in username)
            {
                user.Add(item);
            }

            var query = _context.Orders.Select(o => o).Where(o => o.Username == user[0]);
            foreach (var item in query)
            {
                orders.Add(item);
            }

            if (orders.Count==0)
            {
                ViewBag.Error = "Nie złożyłeś jeszcze żadnego zamówienia";
                return View();
            }
            else
            {
                ViewBag.Error = "ok";
            }
         
            return View(orders);
        }

        public IActionResult DeleteOrder(int id)
        {
            foreach (var item in orders.ToList())
            {
                if (item.OrderID == id)
                {
                    orders.Remove(item);
                    _context.Orders.Remove(item);
                }
            }
            _context.SaveChanges();
            orders.Clear();
            return RedirectToAction(nameof(OrderHistory));
        }

        public ActionResult ShowPDF(int id)
        {
            Random rnd = new Random();
            int FactureNumber;
            DateTime dt;

            IList<Order> orders = new List<Order>();
            List<Profile> profiles = new List<Profile>();

            var getOrders = _context.Orders.Select(o => o).Where(o=>o.OrderID == id);
            var getProfiles = _context.Profiles.Select(p => p).Where(p=>p.UserName == this.User.Identity.Name);

            foreach(var item in getOrders)
            {
                orders.Add(item);
            }      

            foreach (var itemm in getProfiles)
            {
                profiles.Add(itemm);
            }
            
            foreach(var x in orders)
            {
                AllPrice2 += x.Price;
            }

            FactureNumber = rnd.Next(1, 99999999);
            TempData["fn"] = FactureNumber;
            dt = DateTime.Now;
            TempData["data"] = dt;
            ViewData["price"] = AllPrice2;
            ViewData["order"] = orders;
            AllPrice2 = 0.0;
            return new Rotativa.AspNetCore.ViewAsPdf("ShowPDF",profiles,ViewData);
        }
    }
}
