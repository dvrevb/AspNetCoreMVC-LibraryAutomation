using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Controllers
{
   
    public class AyirttirilanlarController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AyirttirilanlarController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var ayirttirilanlar = _context.Ayirttirilanlar.Include(k => k.User).Include(k => k.Kitap).ToList();
            return View(ayirttirilanlar);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Ayirttirilanlar ayirtilan)
        {
            _context.Ayirttirilanlar.Add(ayirtilan);
            _context.SaveChanges();
            return RedirectToAction("Index", "Kitap");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ayirttilan = _context.Ayirttirilanlar.FirstOrDefault(m => m.Id == id);
               
            if (ayirttilan == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            var ayirttilan = _context.Ayirttirilanlar.Find(Id);
            _context.Ayirttirilanlar.Remove(ayirttilan);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
           
        }
       
    }
}
