using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Corona.Core;
using Corona.Data;

namespace CoronaApp
{
    public class EditModel : PageModel
    {
        private readonly Corona.Data.CoronaDbContext _context;
        private readonly IHtmlHelper _htmlHelper;
        public IEnumerable<SelectListItem> Locations { get; set; }
        public IEnumerable<SelectListItem> Infected { get; set; }
        public IEnumerable<SelectListItem> PatientState { get; set; }
        public Hospital Hospital { get; set; }

        public SelectList Hospitals;
        public EditModel(Corona.Data.CoronaDbContext context, IHtmlHelper htmlHelper)
        {
            _context = context;
            _htmlHelper = htmlHelper;
        }

        [BindProperty]
        public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _context.Patients.FirstOrDefaultAsync(m => m.Id == id);

            if (Patient == null)
            {
                return NotFound();
            }


            Locations = _htmlHelper.GetEnumSelectList<City>();
            Infected = _htmlHelper.GetEnumSelectList<Infected>();
            PatientState = _htmlHelper.GetEnumSelectList<PatientState>();
            Hospitals = new SelectList(_context.Hospitals.ToList(), "Id", "HospitalName", Patient.Hospital);
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Locations = _htmlHelper.GetEnumSelectList<City>();
            Infected = _htmlHelper.GetEnumSelectList<Infected>();
            PatientState = _htmlHelper.GetEnumSelectList<PatientState>();
            Hospitals = new SelectList(_context.Hospitals.ToList(), "Id", "HospitalName", Patient.Hospital);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(Patient.Id))
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

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}
