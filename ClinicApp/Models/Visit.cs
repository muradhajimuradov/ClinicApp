using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClinicApp.Models
{
    public enum VisitType
    {
        Primary = 1,
        Secondary = 2
    }
    [Table("Visits")]
    public class Visit
    {
        [Key]
        public int Id { get; set; }
        public DateTime? VisitTime { get; set; }
        public VisitType VisitType { get; set; }
        [MaxLength(2000)]
        public string Diagnosis { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient {get;set;}

    }
}
