using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corona.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoronaApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Corona.Data.CoronaDbContext _context;
        public IList<Patient> Patients { get; set; }
        public int totalPatients;
        public int totalInfected;
        public int totalDead;
        public int totalNotInfected;

        public IndexModel(ILogger<IndexModel> logger, Corona.Data.CoronaDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Patients = _context.Patients.ToArray();

            totalPatients = Patients.Count();

            totalInfected = 0;
            totalDead = 0;
            for (int i = 0; i < totalPatients; i++)
            {
                if (Patients[i].Infected == Infected.Yes)
                {
                    totalInfected++;

                    if (Patients[i].PatientState == PatientState.Dead)
                    {
                        totalDead++;
                    }
                }
            }

            totalNotInfected = totalPatients - totalInfected;
        }
    }
}
