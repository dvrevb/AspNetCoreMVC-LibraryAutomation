using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;

namespace KutuphaneOtomasyonu.Controllers
{
    public class SureliYayinController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SureliYayinController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SureliYayin
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.SureliYayin.Include(s => s.Dil).Include(s => s.Tur).Include(s => s.Yayinevi);
        //    return View(await applicationDbContext.ToListAsync());
        //}


        public IActionResult Index(string searchString)
        {
            TempData["searchString"] = searchString;
            return View();
        }


        // GET: SureliYayin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sureliYayin = await _context.SureliYayin
                .Include(s => s.Dil)
                .Include(s => s.Tur)
                .Include(s => s.Yayinevi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sureliYayin == null)
            {
                return NotFound();
            }

            return View(sureliYayin);
        }

        // GET: SureliYayin/Create
        public IActionResult Create()
        {
            ViewData["DilId"] = new SelectList(_context.Dil, "Id", "Id");
            ViewData["TurId"] = new SelectList(_context.Tur, "Id", "Id");
            ViewData["YayineviId"] = new SelectList(_context.Yayinevi, "Id", "Id");
            return View();
        }

        // POST: SureliYayin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tarih,Id,ISBN,EserAdi,BaskiSayisi,SayfaSayisi,Kapak,Icerik,TurId,YayineviId,DilId")] SureliYayin sureliYayin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sureliYayin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DilId"] = new SelectList(_context.Dil, "Id", "Id", sureliYayin.DilId);
            ViewData["TurId"] = new SelectList(_context.Tur, "Id", "Id", sureliYayin.TurId);
            ViewData["YayineviId"] = new SelectList(_context.Yayinevi, "Id", "Id", sureliYayin.YayineviId);
            return View(sureliYayin);
        }

        // GET: SureliYayin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sureliYayin = await _context.SureliYayin.FindAsync(id);
            if (sureliYayin == null)
            {
                return NotFound();
            }
            ViewData["DilId"] = new SelectList(_context.Dil, "Id", "Id", sureliYayin.DilId);
            ViewData["TurId"] = new SelectList(_context.Tur, "Id", "Id", sureliYayin.TurId);
            ViewData["YayineviId"] = new SelectList(_context.Yayinevi, "Id", "Id", sureliYayin.YayineviId);
            return View(sureliYayin);
        }

        // POST: SureliYayin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tarih,Id,ISBN,EserAdi,BaskiSayisi,SayfaSayisi,Kapak,Icerik,TurId,YayineviId,DilId")] SureliYayin sureliYayin)
        {
            if (id != sureliYayin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sureliYayin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SureliYayinExists(sureliYayin.Id))
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
            ViewData["DilId"] = new SelectList(_context.Dil, "Id", "Id", sureliYayin.DilId);
            ViewData["TurId"] = new SelectList(_context.Tur, "Id", "Id", sureliYayin.TurId);
            ViewData["YayineviId"] = new SelectList(_context.Yayinevi, "Id", "Id", sureliYayin.YayineviId);
            return View(sureliYayin);
        }

        // GET: SureliYayin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sureliYayin = await _context.SureliYayin
                .Include(s => s.Dil)
                .Include(s => s.Tur)
                .Include(s => s.Yayinevi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sureliYayin == null)
            {
                return NotFound();
            }

            return View(sureliYayin);
        }

        // POST: SureliYayin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sureliYayin = await _context.SureliYayin.FindAsync(id);
            _context.SureliYayin.Remove(sureliYayin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SureliYayinExists(int id)
        {
            return _context.SureliYayin.Any(e => e.Id == id);
        }
    }
}
