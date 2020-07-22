using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RhController.Models;
using RhController.Services;

namespace RhUI.Pages.Proyect.PageEmpresa
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Empresa Empresa { get; set; }
        // public Cuenta Cuenta { get; set; }
        public IWebHostEnvironment HostEnvironment { get; }

        private readonly IProyecto<Empresa> repository;
        private readonly IProyecto<Perfil> Perfilrepository;

        public IEnumerable<Perfil> PerfilList { get; set; }
        public CreateModel(IProyecto<Empresa> repository, IProyecto<Perfil> Perfilrepository, IWebHostEnvironment hostEnvironment)
        {
            this.repository = repository;
            HostEnvironment = hostEnvironment;
            this.PerfilList = Perfilrepository.GetAll();

        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var id = repository.Insert(Empresa);
            // var Cuentaid = Cuentarepository.Insert(Cuenta);


            return RedirectToPage("./Create");

        }
    }
}
