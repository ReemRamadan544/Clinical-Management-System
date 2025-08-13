using Microsoft.EntityFrameworkCore;
using universty_dental_clinical.Models.UniversityDentalClinic.Models;

namespace universty_dental_clinical.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet <Doctor> Doctors { get; set; }
        public DbSet<User> users{ get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Student> Students { get; set; }


    }
}
