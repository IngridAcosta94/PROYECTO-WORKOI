using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RhController.Models;
using RhController.Services;

namespace RhUI.Pages.Proyect.PageCandidato
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Candidato Candidato { get; set; }

        public IEnumerable<Orden> OrdenList { get; set; }

        public IWebHostEnvironment HostEnvironment { get; }

        private readonly IProyecto<Candidato> repository;
        private readonly IProyecto<Orden> Ordenrepository;


        public CreateModel(IProyecto<Candidato> repository, IProyecto<Orden> Ordenrepository, IWebHostEnvironment hostEnvironment)
        {
            this.repository = repository;
            HostEnvironment = hostEnvironment;
            this.OrdenList = Ordenrepository.GetAll();
        }


        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var CanId = repository.Insert(Candidato);


            return RedirectToPage("/Proyect/RegistrarCandidato");

        }

    }
}
