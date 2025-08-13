using universty_dental_clinical.Models.UniversityDentalClinic.Models;

namespace universty_dental_clinical.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UniversityEmail { get; set; }
        public string UniversityID { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<User> Users { get; set; }
        public List<Doctor> doctors { get; set; }


    }
}
