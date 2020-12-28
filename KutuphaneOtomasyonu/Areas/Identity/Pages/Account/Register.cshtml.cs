using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using KutuphaneOtomasyonu.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace KutuphaneOtomasyonu.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<KisiselBilgiler> _signInManager;
        private readonly UserManager<KisiselBilgiler> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<KisiselBilgiler> userManager,
            SignInManager<KisiselBilgiler> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {

            [Required]
            [Display(Name = "Ad")]
            [StringLength(20, MinimumLength = 2, ErrorMessage = "Ad alanı 2-20 karakter arası olmalıdır")]
            public string Ad { get; set; }

            [Required]
            [Display(Name = "Soyad")]
            [StringLength(20, MinimumLength = 2, ErrorMessage = "Soyad alanı 2-20 karakter arası olmalıdır")]
            public string Soyad { get; set; }

            [Required]
            [Display(Name = "Cinsiyet")]
            public Cinsiyet Cinsiyet { get; set; }



            //[Required]
            //[Display(Name = "Telefon Numarası")]
            //[RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$", ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz")]
            //public string TelefonNumarasi { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [Display(Name = "Doğum Tarihi")]
            public DateTime DogumTarihi { get; set; }



            [Required]
            [Display(Name = "Kullanıcı Adı")]
            [StringLength(20, MinimumLength = 2, ErrorMessage = "Kullanıcı adı alanı 2-20 karakter arası olmalıdır")]
            public string KullaniciAdi { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "Parola en az 6, en fazla 100 karakter içermelidir.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Parola")]
            public string Password { get; set; }

            
            [DataType(DataType.Password)]
            [Display(Name = "Parolanızı Onaylayın")]
            [Compare("Password", ErrorMessage = "Parolalar eşleşmiyor")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new KisiselBilgiler {
                    UserName = Input.KullaniciAdi,
                    Email = Input.Email,
                    Ad = Input.Ad,
                    Soyad=Input.Soyad,
                    Cinsiyet=Input.Cinsiyet,
                    DogumTarihi=Input.DogumTarihi,


                
                
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                var addRoleToUser = await _userManager.AddToRoleAsync(user,"user");
                if (result.Succeeded && addRoleToUser.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
