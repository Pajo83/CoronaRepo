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
    public class IndexModel : PageModel
    {
        private readonly Corona.Data.CoronaDbContext _context;

        public IndexModel(Corona.Data.CoronaDbContext context)
        {
            _context = context;
        }

        public IList<Patient> Patients { get;set; }

        public async Task OnGetAsync()
        {
            Patients = await _context.Patients.ToListAsync();
        }
    }
}
