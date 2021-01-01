using KutuphaneOtomasyonu.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.ViewComponents
{

    public class ListYorum : ViewComponent
    {
        private ApplicationDbContext _db;
        public ListYorum(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int? kitapId)
        {



            if (kitapId == null)
            {
                var yorumlar = _db.Yorum.Include(k => k.User).Include(b => b.Kitap).OrderByDescending(p => p.olusturulmaTarihi).Take(5).ToListAsync();
                return View(await yorumlar);
            }
            else
            {
                var yorumlar = _db.Yorum.Include(k => k.User).Include(b => b.Kitap).Where(s => s.KitapId == kitapId).OrderByDescending(p => p.olusturulmaTarihi).ToListAsync();
                return View(await yorumlar);
            }

            //    if (yazarId == null)
            //    {
            //        //var kitaplar = _db.Kitap.ToListAsync();
            //        //return View(await kitaplar);

            //        if (!String.IsNullOrEmpty(searchString))
            //        {
            //            //kitaplar = kitaplar.Where(s => s.EserAdi.Contains(searchString));
            //            var kitaplar = _db.Kitap.Include(k => k.Dil).Include(k => k.Tur).Include(k => k.Yayinevi).Include(k => k.Yazar).Where(s => s.EserAdi.Contains(searchString)).ToListAsync();
            //            return View(await kitaplar);
            //        }
            //        else
            //        {
            //            var kitaplar = _db.Kitap.Include(k => k.Dil).Include(k => k.Tur).Include(k => k.Yayinevi).Include(k => k.Yazar).ToListAsync();
            //            return View(await kitaplar);
            //        }

            //    }
            //    else
            //    {
            //        var kitaplar = _db.Kitap.Include(k => k.Dil).Include(k => k.Tur).Include(k => k.Yayinevi).Include(k => k.Yazar).Where(x => x.YazarId == yazarId).ToListAsync();


            //        // var kitaplar = _db.Kitap.Where(x => x.YazarId == yazarId).ToListAsync();
            //        return View(await kitaplar);
            //    }


            //}
        }


    }
}
