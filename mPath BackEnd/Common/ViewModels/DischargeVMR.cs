using System;

namespace Common.ViewModels
{
    public class DischargeVMR
    {
        public long id { get; set; }
        public DateTime dischargeDate { get; set; } 
        public string treatment { get; set; } 
        public decimal amount { get; set; } 
        public long doctorId { get; set; } 
        public long admissionId { get; set; } 
        public string doctorName { get; set; } 
        public string patientName { get; set; } 
    }
}
