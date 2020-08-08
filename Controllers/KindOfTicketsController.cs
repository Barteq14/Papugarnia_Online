using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PapugarniaOnline.DAL;
using PapugarniaOnline.Models;

namespace PapugarniaOnline.Controllers
{
    public class KindOfTicketsController : Controller
    {
        private readonly PapugarniaOnlineContext _context;

        public KindOfTicketsController(PapugarniaOnlineContext context)
        {
            _context = context;
        }

        // GET: KindOfTickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.KindOfTickets.ToListAsync());
        }

        // GET: KindOfTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindOfTicket = await _context.KindOfTickets
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kindOfTicket == null)
            {
                return NotFound();
            }

            return View(kindOfTicket);
        }

        // GET: KindOfTickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KindOfTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] KindOfTicket kindOfTicket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kindOfTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kindOfTicket);
        }

        // GET: KindOfTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindOfTicket = await _context.KindOfTickets.FindAsync(id);
            if (kindOfTicket == null)
            {
                return NotFound();
            }
            return View(kindOfTicket);
        }

        // POST: KindOfTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] KindOfTicket kindOfTicket)
        {
            if (id != kindOfTicket.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kindOfTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KindOfTicketExists(kindOfTicket.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kindOfTicket);
        }

        // GET: KindOfTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindOfTicket = await _context.KindOfTickets
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kindOfTicket == null)
            {
                return NotFound();
            }

            return View(kindOfTicket);
        }

        // POST: KindOfTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kindOfTicket = await _context.KindOfTickets.FindAsync(id);
            _context.KindOfTickets.Remove(kindOfTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KindOfTicketExists(int id)
        {
            return _context.KindOfTickets.Any(e => e.ID == id);
        }
    }
}
