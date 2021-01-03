using KutuphaneOtomasyonu.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.ViewComponents
{
    public class ListSureliYayin : ViewComponent
    {
        private ApplicationDbContext _db;
        public ListSureliYayin(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync(string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                var sureliYayinlar = _db.SureliYayin.Include(s => s.Dil).Include(s => s.Tur).Include(s => s.Yayinevi).Include(k => k.Raf).Where(s => s.EserAdi.Contains(searchString)).ToListAsync();
                return View(await sureliYayinlar);
            }
            else
            {
                var sureliYayinlar = _db.SureliYayin.Include(s => s.Dil).Include(s => s.Tur).Include(s => s.Yayinevi).Include(k => k.Raf).ToListAsync();
                return View(await sureliYayinlar);
            }
        }
    }
}