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
    public class IndexHospitalModel : PageModel
    {
        private readonly Corona.Data.CoronaDbContext _context;

        public IndexHospitalModel(Corona.Data.CoronaDbContext context)
        {
            _context = context;
        }

        public IList<Hospital> Hospital { get;set; }

        public async Task OnGetAsync()
        {
            Hospital = await _context.Hospitals.ToListAsync();
        }
    }
}
