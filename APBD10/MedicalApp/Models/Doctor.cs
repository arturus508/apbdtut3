using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MedicalApp.Models;


namespace MedicalApp.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
    }
}
