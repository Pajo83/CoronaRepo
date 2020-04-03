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
    public class DetailsModel : PageModel
    {
        private readonly Corona.Data.CoronaDbContext _context;

        public DetailsModel(Corona.Data.CoronaDbContext context)
        {
            _context = context;
        }

        public Patient Patient { get; set; }
        public Hospital Hospital { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patients.FirstOrDefaultAsync(m => m.Id == id);
            Hospital = await _context.Hospitals.FirstOrDefaultAsync(m => m.Id == Patient.HospitalId);
           
            if (Patient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
