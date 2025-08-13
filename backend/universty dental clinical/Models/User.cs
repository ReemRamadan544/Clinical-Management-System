namespace universty_dental_clinical.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ContactInfo { get; set; }
        public string UniversityEmail { get; set; }
        public string UniversityID { get; set; }
        public string Password { get; set; }
        public string? MedicalHistory { get; set; } 
        public string? Diagnose { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string? UpdationDate { get; set; }
        public string?  Role{ get; set;}
        public string? StudentName { get; set; }
        public string? Status { get; set; }
        public string? DentalHistory { get; set; }
        public string? Complaint { get; set; }
        public string? TreatmentPlan { get; set; }
        public string? Procedure { get; set; }
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }


    }
}
