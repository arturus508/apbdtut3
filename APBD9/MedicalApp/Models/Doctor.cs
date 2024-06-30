using System.Collections.Generic;

namespace MedicalApp.Models
{
    public class Doctor
    {
        public int IdDoctor { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
