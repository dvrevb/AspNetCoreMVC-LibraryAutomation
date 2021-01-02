using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
        [HttpPost]
        public ActionResult Create(Odunc odunc,int ayirtmaId)
        {
            //ClaimsPrincipal currentUser = this.User;
            //var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
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
    }
}
