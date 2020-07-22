using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RhController.Models;
using RhController.Services;

namespace RhUI.Pages.Proyect.PageOrden
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Orden Orden { get; set; }

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

            Orden = await _context.Ordenes
                .Include(e => e.EmpresaId).FirstOrDefaultAsync(m => m.Id == id);

            if (Orden == null)
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

            Orden = await _context.Ordenes.FindAsync(id);

            if (Orden != null)
            {
                _context.Ordenes.Remove(Orden);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/Proyect/CrearOrden");
        }
    }

}
