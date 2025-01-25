using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class AdmissionVMR
    {
        public long id { get; set; }
        public DateTime admissionDate { get; set; }
        public string diagnosis { get; set; }
        public string observation { get; set; }
        public long doctorId { get; set; }
        public long patientId { get; set; }

        public string patientName { get; set; }
    }
}
