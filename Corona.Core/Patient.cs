using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        //public int HistoryId { get; set; }toq e drugo a ova bese a predhodni ustvari ne cek  :D ova mozit zasega da se zakomentirat i da se pustit us edna migracija
        //public History History { get; set; }

        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
    }
}
