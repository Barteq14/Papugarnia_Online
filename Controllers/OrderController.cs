using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PapugarniaOnline.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //GET BuyTicket
        public IActionResult BuyTicket()
        {
            return View();
        }


    }
}
