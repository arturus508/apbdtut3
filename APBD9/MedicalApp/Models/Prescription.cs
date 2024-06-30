using System;
using System.Collections.Generic;
using MedicalApp.Models;


namespace MedicalApp.Models
{
    public class Prescription
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public Doctor Doctor { get; set; } = new Doctor(); 
        public Patient Patient { get; set; } = new Patient();  
        public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } = new List<PrescriptionMedicament>();  
    }
}
