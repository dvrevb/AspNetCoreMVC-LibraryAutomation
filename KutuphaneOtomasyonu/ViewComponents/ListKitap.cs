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
                    //kitaplar = kitaplar.Where(s => s.EserAdi.Contains(searchString));
                    var kitaplar = _db.Kitap.Include(k => k.Dil).Include(k => k.Tur).Include(k => k.Yayinevi).Include(k => k.Yazar).Where(s=>s.EserAdi.Contains(searchString)).ToListAsync();
                    return View(await kitaplar);
                }
                else
                {
                    var kitaplar = _db.Kitap.Include(k => k.Dil).Include(k => k.Tur).Include(k => k.Yayinevi).Include(k => k.Yazar).ToListAsync();
                    return View(await kitaplar);
                }
               
            }
            else
            {
                var kitaplar = _db.Kitap.Include(k => k.Dil).Include(k => k.Tur).Include(k => k.Yayinevi).Include(k => k.Yazar).Where(x => x.YazarId == yazarId).ToListAsync();


               // var kitaplar = _db.Kitap.Where(x => x.YazarId == yazarId).ToListAsync();
                return View(await kitaplar);
            }


        }


//        public async Task<IViewComponentResult> InvokeAsync()
//        {
//            var kitaplar = from m in _db.Kitap
//                           select m;

//            if (!String.IsNullOrEmpty(searchString))
//            {
//                kitaplar = kitaplar.Where(s => s.EserAdi.Contains(searchString));
//            }
//            return View(await kitaplar.ToListAsync());

//        }
    }
}
