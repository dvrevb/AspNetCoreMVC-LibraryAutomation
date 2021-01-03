using KutuphaneOtomasyonu.Data;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KutuphaneOtomasyonu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost]
        public IActionResult CultureManagement(string culture,string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires=DateTimeOffset.Now.AddDays(30) } );

            return LocalRedirect(returnUrl);
        }


        public IActionResult Index()
        {
            var sonKitap = _db.Kitap.Include(k => k.Dil).Include(k => k.Tur).Include(k => k.Yayinevi).Include(k => k.Yazar).OrderByDescending(p => p.Id).Take(1).ToList();
            foreach (var item in sonKitap)
            {
                ViewBag.sonKitapKapak = item.Kapak;
                ViewBag.sonKitapId = item.Id;
            }
            var sonSureliYayin = _db.SureliYayin.Include(s => s.Dil).Include(s => s.Tur).Include(s => s.Yayinevi).OrderByDescending(p => p.Id).Take(1);
            foreach (var item in sonSureliYayin)
            {
                ViewBag.sonSureliYayinKapak = item.Kapak;
                ViewBag.sonSureliYayinId = item.Id;
            }

            
            return View();
        }
        public IActionResult Ara(string SearchString,string Secim)
        {
            if (Secim=="Kitap")
            {
                return RedirectToAction("Index","Kitap",new { SearchString=SearchString});
            }
            else
            {
                return RedirectToAction("Index", "SureliYayin", new { SearchString = SearchString });
            }         
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
