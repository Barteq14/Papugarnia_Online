using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            List<Order> ff = new List<Order>();
            var query = _context.Orders.Select(o => o).Where(o=>o.OrderID == id);
            var query2 = _context.Profiles.Select(p => p).Where(p=>p.UserName == this.User.Identity.Name);
            /*foreach(var item in query)
            {
                ff.Add(item);
            }*/

            ViewBag.fname = query2.Select(o => o.FirstName);
            ViewBag.fsurname = query2.Select(o => o.SurName);
            ViewBag.zipcode = query2.Select(o => o.ZipCode);
            ViewBag.city = query2.Select(o => o.City);
            ViewBag.street = query2.Select(o => o.Street);
            ViewBag.number = query2.Select(o => o.Number);
            ViewBag.tname = query.Select(o => o.TicketName);
            ViewBag.price = query.Select(o => o.Price);
            ViewBag.date = query.Select(o => o.date);

            return new Rotativa.AspNetCore.ViewAsPdf("ShowPDF");
        }
    }
}
