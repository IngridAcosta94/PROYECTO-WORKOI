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
    public class RegistrarCandidatoModel : PageModel
    {
        [BindProperty]
        public Candidato Candidato { get; set; }



        public IWebHostEnvironment HostEnvironment { get; }

        private readonly IProyecto<Candidato> Candidatorepository;


        public RegistrarCandidatoModel(IProyecto<Candidato> repository, IWebHostEnvironment hostEnvironment)
        {
            this.Candidatorepository = repository;
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


            return RedirectToPage("/Proyect/RegistrarOrden");

        }
        





    }
}
