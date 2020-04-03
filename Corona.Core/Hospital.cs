using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Corona.Core
{
    public class Hospital
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string HospitalName { get; set; }

        public List<Patient> Patients = new List<Patient>();

    }
}
