using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Authorization;

namespace KutuphaneOtomasyonu.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RafController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RafController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Raf
        public async Task<IActionResult> Index()
        {
            return View(await _context.Raf.ToListAsync());
        }

       

        // GET: Raf/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Raf/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RafNo")] Raf raf)
        {
            if (ModelState.IsValid)
            {
                _context.Add(raf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raf);
        }

        // GET: Raf/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raf = await _context.Raf.FindAsync(id);
            if (raf == null)
            {
                return NotFound();
            }
            return View(raf);
        }

        // POST: Raf/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RafNo")] Raf raf)
        {
            if (id != raf.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RafExists(raf.Id))
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
            return View(raf);
        }

        // GET: Raf/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raf = await _context.Raf
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raf == null)
            {
                return NotFound();
            }

            return View(raf);
        }

        // POST: Raf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var raf = await _context.Raf.FindAsync(id);
            _context.Raf.Remove(raf);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RafExists(int id)
        {
            return _context.Raf.Any(e => e.Id == id);
        }
    }
}
