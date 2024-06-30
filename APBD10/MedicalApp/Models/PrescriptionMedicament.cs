using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalApp.Models
{
    public class PrescriptionMedicament
    {
        [Key, Column(Order = 0)]
        public int PrescriptionId { get; set; }
        [Key, Column(Order = 1)]
        public int MedicamentId { get; set; }
        public string Dose { get; set; }
        public string Details { get; set; }

        public Prescription Prescription { get; set; }
        public Medicament Medicament { get; set; }
    }
}
