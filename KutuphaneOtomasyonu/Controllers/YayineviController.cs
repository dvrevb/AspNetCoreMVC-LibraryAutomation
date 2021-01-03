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
    [Authorize(Roles ="Admin")]
    public class YayineviController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YayineviController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yayinevi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yayinevi.ToListAsync());
        }

        

        // GET: Yayinevi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yayinevi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad")] Yayinevi yayinevi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yayinevi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yayinevi);
        }

        // GET: Yayinevi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yayinevi = await _context.Yayinevi.FindAsync(id);
            if (yayinevi == null)
            {
                return NotFound();
            }
            return View(yayinevi);
        }

        // POST: Yayinevi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad")] Yayinevi yayinevi)
        {
            if (id != yayinevi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yayinevi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YayineviExists(yayinevi.Id))
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
            return View(yayinevi);
        }

        // GET: Yayinevi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yayinevi = await _context.Yayinevi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (yayinevi == null)
            {
                return NotFound();
            }

            return View(yayinevi);
        }

        // POST: Yayinevi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yayinevi = await _context.Yayinevi.FindAsync(id);
            _context.Yayinevi.Remove(yayinevi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YayineviExists(int id)
        {
            return _context.Yayinevi.Any(e => e.Id == id);
        }
    }
}
