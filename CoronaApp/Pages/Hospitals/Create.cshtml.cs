using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Corona.Core;
using Corona.Data;

namespace CoronaApp
{ 
    public class CreateHospitalModel : PageModel
    {
        private readonly Corona.Data.CoronaDbContext _context;

        public CreateHospitalModel(Corona.Data.CoronaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Hospital Hospital { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Hospitals.Add(Hospital);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
