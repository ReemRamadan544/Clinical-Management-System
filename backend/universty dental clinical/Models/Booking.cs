using universty_dental_clinical.Models.UniversityDentalClinic.Models;

namespace universty_dental_clinical.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string? StudentName { get; set; }
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        public DateTime? UpdationDate { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string? Diagnose { get; set; }
        public bool Signature { get; set; }
        public int? StudentId { get; set; } 
        public virtual Student Student { get; set; }
        public int? UserId { get; set; }
        public List<User> Users { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Admin> Admins { get; set; }



    }
}
