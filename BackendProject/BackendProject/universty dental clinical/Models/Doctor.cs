namespace universty_dental_clinical.Models
{
    namespace UniversityDentalClinic.Models
    {
        public class Doctor
        {
       
            
            public int Id { get; set; }
            public string Name { get; set; }
            public string UniversityEmail { get; set; }
            public string UniversityID { get; set; }
            public string PhoneNumber { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
            public DateTime CreationDate { get; set; } = DateTime.Now;
            public List<User> patients { get; set; }

        }
    }

}
