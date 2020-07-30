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

namespace RhUI.Pages.Proyect.PageOrden
{
    public class IndexOrdenModel : PageModel
    {
        private readonly AppDBContext _context;

        public IndexOrdenModel(AppDBContext context)
        {
            _context = context;
        }



        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList BuscarOrden { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Ordeness { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Empresass { get; set; }


        public IList<Orden> Orden { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Ordenes
                                         orderby m.Empresa.Nombre
                                         select m.Empresa.Nombre;

            var Ord = from m in _context.Ordenes
                      select m;

            if (!string.IsNullOrEmpty(Empresass))
            {
                Ord = Ord.Where(x => x.Empresa.Nombre == Empresass);
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                Ord = Ord.Where(s => s.PuestoSolicitado.Contains(SearchString));
            }
           

            BuscarOrden = new SelectList(await genreQuery.Distinct().ToListAsync());
            Orden = await Ord.Include(l => l.Empresa).ToListAsync();

        }
    }
}
