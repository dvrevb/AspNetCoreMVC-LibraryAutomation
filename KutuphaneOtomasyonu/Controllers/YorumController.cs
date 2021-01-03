using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Controllers
{
    public class YorumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YorumController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Yorum yorum)
        {
           _context.Yorum.Add(yorum);
           _context.SaveChanges();
            return RedirectToAction("Details", "Kitap", new { id = yorum.KitapId });
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = _context.Yorum.FirstOrDefault(m => m.Id == id);

            if (yorum == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            var yorum = _context.Yorum.Find(Id);
            _context.Yorum.Remove(yorum);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

    }
}
