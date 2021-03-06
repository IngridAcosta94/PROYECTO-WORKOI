using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RhController.Models;
using RhController.Services;

namespace RhUI.Pages.Proyect.PageReferencia
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public ReferenciaLab Referencia { get; set; }
        public IWebHostEnvironment HostEnvironment { get; }

        private readonly IProyecto<ReferenciaLab> repository;
        private readonly IProyecto<Candidato> Candrepository;
        private readonly IProyecto<Puesto> Puestorepository;
        public IEnumerable<Candidato> CandidatoList { get; set; }
        public IEnumerable<Puesto> PuestoList { get; set; }

        public CreateModel(IProyecto<ReferenciaLab> repository, IProyecto<Candidato> Candrepository, IProyecto<Puesto> Puestorepository, IWebHostEnvironment hostEnvironment)
        {
            this.repository = repository;
            this.CandidatoList = Candrepository.GetAll();
            this.PuestoList = Puestorepository.GetAll();
            HostEnvironment = hostEnvironment;
        }

      
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var id = repository.Insert(Referencia);

            return RedirectToPage("./Create");

        }

    }
}
