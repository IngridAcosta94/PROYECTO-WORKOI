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
    public class EditModel : PageModel
    {
        private readonly AppDBContext _context;

        public EditModel(AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ReferenciaLab ReferenciaLab { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ReferenciaLab = await _context.Referencias
                .Include(e => e.Id).FirstOrDefaultAsync(m => m.Id == id);

            if (ReferenciaLab == null)
            {
                return NotFound();
            }

            ViewData["Id"] = new SelectList(_context.Referencias, "Id", "Nombre");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ReferenciaLab).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReferenciaExists(ReferenciaLab.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReferenciaExists(int id)
        {
            return _context.Referencias.Any(e => e.Id == id);
        }

        public void OnGet()
        {
        }
    }
}
