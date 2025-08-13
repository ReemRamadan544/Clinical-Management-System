namespace universty_dental_clinical.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Level { get; set; }
        public string ContactInfo { get; set; }
        public string UniversityEmail { get; set; }
        public string UniversityID { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string? Role { get; set; }
        public int? PatientCount { get; set; } = 0;

        public List<User> Patients { get; set; }
        public List<Booking> Appointments  { get; set; }

    }
}
