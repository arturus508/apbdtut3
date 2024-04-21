using System;

namespace VeterinaryClinicApi.Models
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Category { get; set; } = string.Empty; 
        public double Weight { get; set; }
        public string FurColor { get; set; } = string.Empty;
    }

    public class Visit
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string Description { get; set; } = string.Empty; 
        public decimal Price { get; set; }
    }
}
