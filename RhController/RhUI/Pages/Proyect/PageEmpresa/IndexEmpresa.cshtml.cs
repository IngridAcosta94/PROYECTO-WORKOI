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

namespace RhUI.Pages.Proyect.PageEmpresa
{
    public class IndexEmpresaModel : PageModel
    {
        private readonly AppDBContext _context;

        public IndexEmpresaModel( AppDBContext context)
        {
            _context = context;
        }



        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList BuscarEmpresa { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Empresass { get; set; }
        public string Perfiless { get; set; }


        public IList<Empresa> Empresa { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<int> genreQuery = from m in _context.Empresas
                                            orderby m.Id
                                            select m.Id;

            var Emp = from m in _context.Empresas
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                Emp = Emp.Where(s => s.Nombre.Contains(SearchString));
            }

            BuscarEmpresa = new SelectList(await genreQuery.Distinct().ToListAsync());
            Empresa = await Emp.Include(l => l.Perfil).ToListAsync();
        }
    }
}
