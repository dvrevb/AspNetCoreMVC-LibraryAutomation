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
        public async Task<IViewComponentResult> InvokeAsync(int yazarId)
        {
            var kitaplar = _db.Kitap.Where(x => x.YazarId == yazarId).ToListAsync(); ;
            return View(await kitaplar);
        }
    }
}
