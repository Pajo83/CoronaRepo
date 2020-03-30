using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Corona.Core;
using Corona.Data;

namespace CoronaApp
{
    public class DeleteHospitaleModel : PageModel
    {
        private readonly Corona.Data.CoronaDbContext _context;

        public DeleteHospitaleModel(Corona.Data.CoronaDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hospital Hospital { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hospital = await _context.Hospitals.FirstOrDefaultAsync(m => m.Id == id);

            if (Hospital == null)
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

            Hospital = await _context.Hospitals.FindAsync(id);

            if (Hospital != null)
            {
                _context.Hospitals.Remove(Hospital);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
