using System;
using MedicalApp.Models;

namespace MedicalApp.Models
{
    public class PrescriptionMedicament
    {
        public int IdMedicament { get; set; }
        public int IdPrescription { get; set; }
        public Medicament Medicament { get; set; } = new Medicament(); 
        public Prescription Prescription { get; set; } = new Prescription(); 
        public int Dose { get; set; }
        public string Details { get; set; } = string.Empty; 
    }
}
