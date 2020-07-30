using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RhController.Models;
using RhController.Services;

namespace RhUI.Pages.Proyect.PageCandidato
{
    public class IndexCandidatoModel : PageModel
    {
        private readonly AppDBContext _context;

        public IndexCandidatoModel(AppDBContext context)
        {
            _context = context;
        }



        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList BuscarCandidato { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Candidatoss { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Ordeness { get; set; }

     

        public IList<Candidato> Candidato { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Candidatos
                                            orderby m.Orden.PuestoSolicitado
                                            select m.Orden.PuestoSolicitado;

            var Cand = from m in _context.Candidatos
                      select m;


            if (!string.IsNullOrEmpty(SearchString))
            {
                Cand = Cand.Where(s => s.Nombre.Contains(SearchString));
            }




            BuscarCandidato = new SelectList(await genreQuery.Distinct().ToListAsync());
            Candidato = await Cand.Include(l => l.Orden).ToListAsync();
            Candidato = await Cand.Include(l => l.Nacionalidad).ToListAsync();
        }
    }
}
