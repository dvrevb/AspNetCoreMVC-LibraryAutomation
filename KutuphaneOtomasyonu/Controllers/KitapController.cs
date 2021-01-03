using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using System.Security.Claims;

namespace KutuphaneOtomasyonu.Controllers
{
    public class KitapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitapController(ApplicationDbContext context)
        {
            _context = context;
        }

    

        public IActionResult Index(string searchString)
        {
            TempData["searchString"]= searchString;
            return View();
        }

        // GET: Kitap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var kitap = await _context.Kitap
                .Include(k => k.Dil)
                .Include(k => k.Tur)
                .Include(k => k.Yayinevi)
                .Include(k => k.Yazar)
                .Include(k=>k.Raf)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        // GET: Kitap/Create
        public IActionResult Create()
        {
            ViewData["DilId"] = new SelectList(_context.Dil, "Id", "DilAd");
            ViewData["TurId"] = new SelectList(_context.Tur, "Id", "TurAd");
            ViewData["YayineviId"] = new SelectList(_context.Yayinevi, "Id", "Ad");
            ViewData["YazarId"] = new SelectList(_context.Yazar, "Id", "AdSoyad");
            ViewData["RafId"] = new SelectList(_context.Raf, "Id", "RafNo");
            return View();
        }

        // POST: Kitap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YazarId,OduncDurumu,Id,ISBN,EserAdi,BaskiSayisi,SayfaSayisi,Kapak,Icerik,TurId,YayineviId,DilId,RafId")] Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DilId"] = new SelectList(_context.Dil, "Id", "DilAd", kitap.DilId);
            ViewData["TurId"] = new SelectList(_context.Tur, "Id", "TurAd", kitap.TurId);
            ViewData["YayineviId"] = new SelectList(_context.Yayinevi, "Id", "Ad", kitap.YayineviId);
            ViewData["YazarId"] = new SelectList(_context.Yazar, "Id", "AdSoyad", kitap.YazarId);
            ViewData["RafId"] = new SelectList(_context.Raf, "Id", "RafNo",kitap.RafId);
            return View(kitap);
        }

        // GET: Kitap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitap.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }
            ViewData["DilId"] = new SelectList(_context.Dil, "Id", "Id", kitap.DilId);
            ViewData["TurId"] = new SelectList(_context.Tur, "Id", "Id", kitap.TurId);
            ViewData["YayineviId"] = new SelectList(_context.Yayinevi, "Id", "Id", kitap.YayineviId);
            ViewData["YazarId"] = new SelectList(_context.Yazar, "Id", "Id", kitap.YazarId);
            ViewData["RafId"] = new SelectList(_context.Raf, "Id", "RafNo", kitap.RafId);
            return View(kitap);
        }

        // POST: Kitap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YazarId,OduncDurumu,Id,ISBN,EserAdi,BaskiSayisi,SayfaSayisi,Kapak,Icerik,TurId,YayineviId,DilId,RafId")] Kitap kitap)
        {
            if (id != kitap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitapExists(kitap.Id))
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
            ViewData["DilId"] = new SelectList(_context.Dil, "Id", "Id", kitap.DilId);
            ViewData["TurId"] = new SelectList(_context.Tur, "Id", "Id", kitap.TurId);
            ViewData["YayineviId"] = new SelectList(_context.Yayinevi, "Id", "Id", kitap.YayineviId);
            ViewData["YazarId"] = new SelectList(_context.Yazar, "Id", "Id", kitap.YazarId);
            ViewData["RafId"] = new SelectList(_context.Raf, "Id", "RafNo", kitap.RafId);
            return View(kitap);
        }

        // GET: Kitap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kitap = await _context.Kitap
                .Include(k => k.Dil)
                .Include(k => k.Tur)
                .Include(k => k.Yayinevi)
                .Include(k => k.Yazar)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }

        // POST: Kitap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kitap = await _context.Kitap.FindAsync(id);
            _context.Kitap.Remove(kitap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitapExists(int id)
        {
            return _context.Kitap.Any(e => e.Id == id);
        }
    }
}



