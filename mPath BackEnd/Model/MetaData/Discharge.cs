using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    [MetadataType(typeof(DischargeMetaData))]
    public partial class Discharge
    {
    }

    public class DischargeMetaData
    {
        [Required]
        public System.DateTime dischargeDate { get; set; }
        [Required]
        [Range(0, 9999999.99)]
        public decimal amount { get; set; }
        [Required]
        public long doctorId { get; set; }
        [Required]
        public long admissionId { get; set; }
    }
}
