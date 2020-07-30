using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RhController.Models;
using RhController.Services;

namespace RhUI.Pages.Proyect.PageOrden
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Orden Orden { get; set; }
        public IWebHostEnvironment HostEnvironment { get; }

        private readonly IProyecto<Orden> repository;
        private readonly IProyecto<Empresa> Emprepository;
        public IEnumerable<Empresa> EmpresaList { get; set; }

        public CreateModel(IProyecto<Orden> repository, IProyecto<Empresa> Emprepository, IWebHostEnvironment hostEnvironment)
        {
            this.repository = repository;
            HostEnvironment = hostEnvironment;
            this.EmpresaList = Emprepository.GetAll();
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var id = repository.Insert(Orden);

            return RedirectToPage("./Create");

        }

       
    }
}
