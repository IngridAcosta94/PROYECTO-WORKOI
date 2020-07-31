using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RhController.Models;
using RhController.Services;

namespace RhUI.Pages.Proyect.PageReferencia
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public ReferenciaLab ReferenciaLab { get; set; }

        private readonly AppDBContext _context;
        public DeleteModel(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReferenciaLab = await _context.Referencias
                .Include(e => e.Candidato).FirstOrDefaultAsync(m => m.Id == id);

            if (ReferenciaLab == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReferenciaLab = await _context.Referencias.FindAsync(id);

            if (ReferenciaLab != null)
            {
                _context.Referencias.Remove(ReferenciaLab);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Proyect/CrearOrden");
        }
    }
}
