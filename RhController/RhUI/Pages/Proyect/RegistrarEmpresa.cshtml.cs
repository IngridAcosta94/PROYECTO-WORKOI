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
    public class RegistrarEmpresaModel : PageModel
    {
        [BindProperty]
       public Empresa Empresa { get; set; }
       public IWebHostEnvironment HostEnvironment { get; }

       private readonly IProyecto<Empresa> repository;

        public RegistrarEmpresaModel(IProyecto<Empresa> repository, IWebHostEnvironment hostEnvironment)


        {

            this.repository = repository;
            HostEnvironment = hostEnvironment;
        
        
        
        
        }


        public IActionResult OnPost()

        {

            if (!ModelState.IsValid)
                return Page();
            var id = repository.Insert(Empresa);

            return RedirectToPage("/Proyect/RegistrarEmpresa");

        }

        public void OnGet()
        {
        }


    }



   
    
}
