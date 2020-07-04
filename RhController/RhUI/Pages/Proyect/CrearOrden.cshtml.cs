using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RhController.Models;
using RhController.Services;

namespace RhUI.Pages.Proyect
{
    public class CrearOrdenModel : PageModel
    {


        [BindProperty]
        public Candidato Candidato { get; set; }
        public Orden Orden { get; set; }
        public ReferenciaLab ReferenciaLab { get; set; }


        public IWebHostEnvironment HostEnvironment { get; }

        private readonly IProyecto<Candidato> Candidatorepository;
        private readonly IProyecto<Orden> Ordenrepository;
        private readonly IProyecto<ReferenciaLab> Referenciarepository;

        public  CrearOrdenModel (IProyecto<Candidato> repository, IWebHostEnvironment hostEnvironment)
        {
            this.Candidatorepository = repository;
            HostEnvironment = hostEnvironment;
        }
        public CrearOrdenModel (IProyecto<Orden> repository, IWebHostEnvironment hostEnvironment)
        {
            
            this.Ordenrepository = repository;
            HostEnvironment = hostEnvironment;
        }
        public CrearOrdenModel(IProyecto<ReferenciaLab> repository, IWebHostEnvironment hostEnvironment)
        {

           
            this.Referenciarepository = repository;
            HostEnvironment = hostEnvironment;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var CanId = Candidatorepository.Insert(Candidato);
            var RefId = Referenciarepository.Insert(ReferenciaLab);
            var OrId = Ordenrepository.Insert(Orden);

            return RedirectToPage("/Proyect/RegistrarOrden");

        }

        
    }
}
