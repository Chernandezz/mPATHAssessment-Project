using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{

    [MetadataType(typeof(DoctorMetaData))]
    public partial class Doctor
    {

    }

    public class DoctorMetaData
    {

        [Required]
        [StringLength(50)]
        public string firstName { get; set; }
        [Required]
        [StringLength(50)]
        public string lastName { get; set; }
        [Required]
        public bool active { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string email { get; set; }
    }
}
