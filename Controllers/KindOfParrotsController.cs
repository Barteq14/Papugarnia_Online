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
    public class KindOfParrotsController : Controller
    {
        private readonly PapugarniaOnlineContext _context;

        public KindOfParrotsController(PapugarniaOnlineContext context)
        {
            _context = context;
        }

        // GET: KindOfParrots
        public async Task<IActionResult> Index()
        {
            return View(await _context.KindOfParrots.ToListAsync());
        }

        // GET: KindOfParrots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindOfParrot = await _context.KindOfParrots
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kindOfParrot == null)
            {
                return NotFound();
            }

            return View(kindOfParrot);
        }

        // GET: KindOfParrots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KindOfParrots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] KindOfParrot kindOfParrot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kindOfParrot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kindOfParrot);
        }

        // GET: KindOfParrots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindOfParrot = await _context.KindOfParrots.FindAsync(id);
            if (kindOfParrot == null)
            {
                return NotFound();
            }
            return View(kindOfParrot);
        }

        // POST: KindOfParrots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] KindOfParrot kindOfParrot)
        {
            if (id != kindOfParrot.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kindOfParrot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KindOfParrotExists(kindOfParrot.ID))
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
            return View(kindOfParrot);
        }

        // GET: KindOfParrots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindOfParrot = await _context.KindOfParrots
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kindOfParrot == null)
            {
                return NotFound();
            }

            return View(kindOfParrot);
        }

        // POST: KindOfParrots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kindOfParrot = await _context.KindOfParrots.FindAsync(id);
            _context.KindOfParrots.Remove(kindOfParrot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KindOfParrotExists(int id)
        {
            return _context.KindOfParrots.Any(e => e.ID == id);
        }
    }
}
