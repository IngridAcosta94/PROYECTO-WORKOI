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

namespace RhUI.Pages.Proyect.PageReferencia
{
    public class IndexReferenciaModel : PageModel
    {
        private readonly AppDBContext _context;

        public IndexReferenciaModel(AppDBContext context)
        {
            _context = context;
        }



        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList BuscarReferencia { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Referenciass { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Candidatoss { get; set; }



        public IList<ReferenciaLab> Referencia { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Referencias
                                            orderby m.Candidato.Nombre
                                            select m.Candidato.Nombre;

            var Ref = from m in _context.Referencias
                       select m;



            if (!string.IsNullOrEmpty(Candidatoss))
            {
                Ref = Ref.Where(x => x.Candidato.Nombre == Candidatoss);
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                Ref = Ref.Where(s => s.Nombre.Contains(SearchString));
            }



            BuscarReferencia = new SelectList(await genreQuery.Distinct().ToListAsync());
            Referencia = await Ref.Include(l => l.Candidato).ToListAsync();

        }
    }
}
