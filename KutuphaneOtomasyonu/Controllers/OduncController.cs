using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Controllers
{
    public class OduncController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OduncController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var oduncler = _context.Odunc.Include(k => k.User).Include(k => k.Kitap).ToList();
            return View(oduncler);
        }
        [HttpPost]
        public ActionResult Create(Odunc odunc,int ayirtmaId)
        {
            _context.Odunc.Add(odunc);
            _context.SaveChanges();
            
            //odunc alinma bilgisi kitap tablosunda duzenlenir.
            var kitap = _context.Kitap.Find(odunc.KitapId);
            kitap.OduncDurumu = true;

            //odunc verilince ayirtma tablosundan siliniyor.
            var ayirttilan = _context.Ayirttirilanlar.Find(ayirtmaId);
            _context.Ayirttirilanlar.Remove(ayirttilan);

            _context.SaveChanges();

            return RedirectToAction("Index", "Ayirttirilanlar");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odunc = _context.Odunc.FirstOrDefault(m => m.Id == id);

            if (odunc == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
           
            var odunc = _context.Odunc.Find(Id);
            //odunc alinma bilgisi kitap tablosunda duzenlenir.
            var kitap = _context.Kitap.Find(odunc.KitapId);
            kitap.OduncDurumu = false;
            _context.Odunc.Remove(odunc);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult SureUzat(int Id)
        {
            var odunc = _context.Odunc.Find(Id);
            odunc.gelecegiTarih=odunc.gelecegiTarih.AddDays(15);
            odunc.uzatilabilirMi = false;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
