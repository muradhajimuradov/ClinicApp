using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ClinicApp.Models
{
    public enum Gender
    {
        [Description("Male")]
        Male = 1,
        [Description("Female")]
        Female = 2
    }
    [Table("Patients")]
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        [MaxLength(1000)]
        public string Address { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
