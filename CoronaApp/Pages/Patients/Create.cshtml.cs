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
    public class CreateModel : PageModel
    {
        private readonly Corona.Data.CoronaDbContext _context;
        private readonly IHtmlHelper _htmlHelper;
        public IEnumerable<SelectListItem> Locations { get; set; }
        public IEnumerable<SelectListItem> Infected { get; set; }
        public IEnumerable<SelectListItem> PatientState { get; set; }

        public SelectList Hospitals;

        public CreateModel(Corona.Data.CoronaDbContext context, IHtmlHelper htmlHelper)
        {
            _context = context;
            _htmlHelper = htmlHelper;
        }

        public IActionResult OnGet()
        {
            Locations = _htmlHelper.GetEnumSelectList<City>();
            Infected = _htmlHelper.GetEnumSelectList<Infected>();
            PatientState = _htmlHelper.GetEnumSelectList<PatientState>();
            var list = new List<SelectListItem>();
            var items = from n in _context.Hospitals
                        select new SelectListItem
                        {
                            Text = n.HospitalName,
                            Value = n.Id.ToString()
                        };
            //*Add your items to List
            foreach (var item in items)
                list.Add(item);

            var hospitals = _context.Hospitals.Select(o => new { ID = o.Id, Name = o.HospitalName });

            Hospitals = new SelectList(hospitals, "ID", "Name");
            return Page();
        }

      

        [BindProperty]
        public Patient Patient { get; set; }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Patients.Add(Patient);
            await _context.SaveChangesAsync();


            return RedirectToPage("./Index");
        }
    }
}
