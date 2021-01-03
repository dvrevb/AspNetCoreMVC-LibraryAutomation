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
                var yorumlar = _db.Yorum.Include(k => k.User).Include(b => b.Kitap).OrderByDescending(p => p.olusturulmaTarihi).ToListAsync();
                return View(await yorumlar);
            }
            else
            {
                var yorumlar = _db.Yorum.Include(k => k.User).Include(b => b.Kitap).Where(s => s.KitapId == kitapId).OrderByDescending(p => p.olusturulmaTarihi).ToListAsync();
                return View(await yorumlar);
            }

     
        }
    }
}
