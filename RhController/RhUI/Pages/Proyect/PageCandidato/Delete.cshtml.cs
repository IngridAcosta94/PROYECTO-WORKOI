using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RhController.Models;
using RhController.Services;

namespace RhUI.Pages.Proyect.PageCandidato
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Candidato Candidato { get; set; }

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

            Candidato = await _context.Candidatos
                .Include(e => e.Orden).FirstOrDefaultAsync(m => m.Id == id);
            Candidato = await _context.Candidatos
                .Include(e => e.Nacionalidad).FirstOrDefaultAsync(m => m.Id == id);

            if (Candidato == null)
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

            Candidato = await _context.Candidatos.FindAsync(id);

            if (Candidato != null)
            {
                _context.Candidatos.Remove(Candidato);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./IndexCandidato");
        }
    }
}
