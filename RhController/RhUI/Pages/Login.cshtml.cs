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


namespace RhUI.Pages
{
    public class LoginModel : PageModel
    {      /// </summary>  
        [BindProperty]
        public LoginViewModels LoginModels { get; set; }

        private readonly PROYECTOWORKContext databaseManager;

        public LoginModel(PROYECTOWORKContext databaseManagerContext)
        {
            try
            {
                // Settings.  
                this.databaseManager = databaseManagerContext;
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }
        }











        public IActionResult OnGet()
        {
            try
            {
                // Verification.  
                if (this.User.Identity.IsAuthenticated)
                {
                    // Home Page.  
                    return this.RedirectToPage("/Proyect/Index");
                }
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info.  
            return this.Page();
        }

        
        public async Task<IActionResult> OnPostLogIn()
        {
            try
            {
                // Verification.  
                if (ModelState.IsValid)
                {
                    // Initialization.  
                    var loginInfo = await this.databaseManager.LoginByUsernamePasswordAsync(this.LoginModels.Username, this.LoginModels.Password);

                    // Verification.  
                    if (loginInfo != null && loginInfo.Count() > 0)
                    {
                        // Initialization.  
                        var logindetails = loginInfo.First();

                        // Login In.  
                        await this.SignInUser(logindetails.username, false);

                        // Info.  
                        return this.RedirectToPage("/Home/Index");
                    }
                    else
                    {
                        // Setting.  
                        ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Info  
                Console.Write(ex);
            }

            // Info.  
            return this.Page();
        }


        private async Task SignInUser(string username, bool isPersistent)
        {
            // Initialization.  
            var claims = new List<Claim>();

            try
            {
                // Setting  
                claims.Add(new Claim(ClaimTypes.Name, username));
                var claimIdenties = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimPrincipal = new ClaimsPrincipal(claimIdenties);
                var authenticationManager = Request.HttpContext;

                // Sign In.  
                await authenticationManager.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, new AuthenticationProperties() { IsPersistent = isPersistent });
            }
            catch (Exception ex)
            {
                // Info  
                throw ex;
            }
        }


    }
}
