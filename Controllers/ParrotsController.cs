using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PapugarniaOnline.DAL;
using PapugarniaOnline.Models;

namespace PapugarniaOnline.Controllers
{
    public class ParrotsController : Controller
    {
        private readonly PapugarniaOnlineContext _context;

        public ParrotsController(PapugarniaOnlineContext context)
        {
            _context = context;
        }

        // GET: Parrots
        public async Task<IActionResult> Index()
        {
            var papugarniaOnlineContext = _context.Parrots.Include(p => p.KindOfParrot);
            return View(await papugarniaOnlineContext.ToListAsync());
        }

        // GET: Parrots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parrot = await _context.Parrots
                .Include(p => p.KindOfParrot)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (parrot == null)
            {
                return NotFound();
            }

            return View(parrot);
        }
        [Authorize]
        // GET: Parrots/Create
        public IActionResult Create()
        {
            ViewData["KindID"] = new SelectList(_context.KindOfParrots, "ID", "Name");
            return View();
        }

        // POST: Parrots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Quantity,TypeDescription,KindID")] Parrot parrot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parrot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KindID"] = new SelectList(_context.KindOfParrots, "ID", "Name", parrot.KindID);
            return View(parrot);
        }
        [Authorize]
        // GET: Parrots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parrot = await _context.Parrots.FindAsync(id);
            if (parrot == null)
            {
                return NotFound();
            }
            ViewData["KindID"] = new SelectList(_context.KindOfParrots, "ID", "Name", parrot.KindID);
            return View(parrot);
        }

        // POST: Parrots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Quantity,TypeDescription,KindID")] Parrot parrot)
        {
            if (id != parrot.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parrot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParrotExists(parrot.ID))
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
            ViewData["KindID"] = new SelectList(_context.KindOfParrots, "ID", "Name", parrot.KindID);
            return View(parrot);
        }
        [Authorize]
        // GET: Parrots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parrot = await _context.Parrots
                .Include(p => p.KindOfParrot)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (parrot == null)
            {
                return NotFound();
            }

            return View(parrot);
        }
        [Authorize]
        // POST: Parrots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parrot = await _context.Parrots.FindAsync(id);
            _context.Parrots.Remove(parrot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize]
        private bool ParrotExists(int id)
        {
            return _context.Parrots.Any(e => e.ID == id);
        }

        public IActionResult Gallery()
        {
            return View();
        }
   
    }
}
