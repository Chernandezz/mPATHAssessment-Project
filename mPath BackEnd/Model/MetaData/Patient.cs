using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    [MetadataType(typeof(PatientMetaData))]
    public partial class Patient
    {
    }

    public class PatientMetaData
    {
        [Required]
        [StringLength(50)]
        public string firstName { get; set; }
        [Required]
        [StringLength(50)]
        public string lastName { get; set; }
        [Required]
        [StringLength(500)]
        public string address { get; set; }
        [Required]
        [StringLength(10)]
        public string phoneNumber { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string email { get; set; }
        public string observations { get; set; }

    }
}
