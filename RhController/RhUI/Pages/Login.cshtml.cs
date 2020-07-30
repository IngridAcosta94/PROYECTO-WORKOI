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

namespace RhUI.Pages
{
    public class LoginModel : PageModel
    {      /// </summary>  
        private readonly AppDBContext _context;

        public LoginModel(AppDBContext context)
        {
            _context = context;
        }



        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList BuscarCuenta { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Cuentass { get; set; }


        public Cuenta Cuenta { get; set; }

        public void OnGet()
        {
            Cuenta = new Cuenta();
        }

        public IActionResult OnPost()
        {
            var _cuenta = login(Cuenta.Usuario, Cuenta.Contrase�a);
            if (_cuenta == null)
            {
                return RedirectToPage("./Error");
            }
            else
            {
                HttpContext.Session.SetString("Nombre", _cuenta.Usuario);
                return RedirectToPage("Index", _cuenta.Contrase�a);
            }
        }
         private Cuenta login(string usuario, string contrase�a)
        {
            var cuentas = _context.Cuentas.SingleOrDefault(a => a.Usuario.Equals(usuario));
            if (cuentas != null)
            {
                if (BCrypt.Net.BCrypt.Verify(contrase�a, cuentas.Contrase�a))
                {
                    
                    return cuentas;
                }
            }
            return null;
        }

    }
}
