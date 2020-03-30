using System;
using System.ComponentModel.DataAnnotations;

namespace Corona.Core
{
    public class Patient
    {
        public int Id { get; set; }
        public int Age { get; set; }
        [Required, StringLength(10)]
        public string Name { get; set; }
        [Required]
        public City Location { get; set; }
        [Required]
        public Infected Infected { get; set; }
        [Required]
        public PatientState PatientState { get; set; }
        [Required, StringLength(300)]
        public string Diagnose { get; set; }
        public History History { get; set; }
        public Hospital Hospital { get; set; }
    }
}
