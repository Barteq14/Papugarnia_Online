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

namespace PapugarniaOnline.Controllers
{
    public class OrdersController : Controller
    {
        private readonly PapugarniaOnlineContext _context;
        private readonly ApplicationDbContext _apcontext;
        public static List<Ticket> tickets = new List<Ticket>();
        public static double AllPrice;
        public static string ticketname;

        // Inject UserManager using dependency injection.
        // Works only if you choose "Individual user accounts" during project creation.

        public OrdersController(PapugarniaOnlineContext context,ApplicationDbContext apcontext)
        {
            _context = context;
            _apcontext = apcontext;
        }
     
        public IActionResult Index(int id)
        {
            AllPrice = 0.0;
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
            List<string> user = new List<string>();
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

            

            order = new Order { Username = user[0], TicketName = ticket[0], Price = price[0], DateTime = DateTime.Now };
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




    }
}
