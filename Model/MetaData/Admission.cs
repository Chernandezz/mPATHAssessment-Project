using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    [MetadataType(typeof(AdmissionMetaData))]
    public partial class Admission
    {
    }

    public class AdmissionMetaData
    {
        [Required]
        public System.DateTime admissionDate { get; set; }
        [Required]
        public string diagnosis { get; set; }
        public string observation { get; set; }
        [Required]
        public long doctorId { get; set; }
        [Required]
        public long patientId { get; set; }
    }
}
