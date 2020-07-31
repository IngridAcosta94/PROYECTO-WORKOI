using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using RhUI.Models;
using RhUI.Models.DB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RhController.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using RhController.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using RhUI.Modelos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Buffers.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace RhUI.Pages.Proyect
{
    public class IndexLoginModel : PageModel
    {
        private readonly IConfiguration configuration;
        public IndexLoginModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        
        public string Message { get; set; }
        public async Task<IActionResult> OnPost()
        {
            var user = configuration.GetSection("SiteUser").Get<SiteUser>();

            if (UserName == user.UserName)
            {
                var passwordHasher = new PasswordHasher<string>();
                
                if (passwordHasher.VerifyHashedPassword(null, user.Password, Password) == PasswordVerificationResult.Success)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, UserName)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToPage("./IndexEmpresa");
                }
            }
            Message = "Invalid attempt";
            return Page();
        }


    }
}