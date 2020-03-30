using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Corona.Core
{
    public class History
    {
        public int Id { get; set; }
        [Required]
        public string DiagnosisHistory { get; set; }
    }
}
