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

namespace RhUI.Pages
{
    public class LoginModel : PageModel
    {      /// </summary>  

        private readonly ILogger<LoginModel> _logger;
        public IProyectoRepository repository;

        [BindProperty]
        public Cuenta Cuenta { get; set; }

        public int cont;
        public void OnGet()
        {
        }
        public LoginModel(ILogger<LoginModel> logger, IProyectoRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public IActionResult OnPost()
        {
            cont = repository.InicioSesion(Cuenta);

            return Redirect("/Proyect/PageOrden/IndexOrden/?Id=" + cont);
        }
        








    }
}
