using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MedicalApp.Models;
using Microsoft.AspNetCore.Identity;

namespace MedicalApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
