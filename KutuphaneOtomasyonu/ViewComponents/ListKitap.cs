using KutuphaneOtomasyonu.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.ViewComponents
{
    public class ListKitap:ViewComponent
    {
        private ApplicationDbContext _db;
        public ListKitap(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? yazarId,string searchString)
        {
            
            
            if (yazarId == null)
            {
                //var kitaplar = _db.Kitap.ToListAsync();
                //return View(await kitaplar);
               
                if (!String.IsNullOrEmpty(searchString))
                {
                    var kitaplar = _db.Kitap.Include(k => k.Dil).Include(k => k.Tur).Include(k => k.Yayinevi).Include(k => k.Yazar).Include(k=>k.Raf).Where(s=>s.EserAdi.Contains(searchString)).ToListAsync();
                    return View(await kitaplar);
                }
                else
                {
                    var kitaplar = _db.Kitap.Include(k => k.Dil).Include(k => k.Tur).Include(k => k.Yayinevi).Include(k => k.Yazar).Include(k => k.Raf).ToListAsync();
                    return View(await kitaplar);
                }
               
            }
            else
            {
                var kitaplar = _db.Kitap.Include(k => k.Dil).Include(k => k.Tur).Include(k => k.Yayinevi).Include(k=>k.Raf).Include(k => k.Yazar).Include(k => k.Raf).Where(x => x.YazarId == yazarId).ToListAsync();
                return View(await kitaplar);
            }
        }
    }
}
