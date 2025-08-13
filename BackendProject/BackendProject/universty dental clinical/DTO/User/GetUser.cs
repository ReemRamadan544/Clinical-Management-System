namespace universty_dental_clinical.DTO.User
{
    public class GetUser
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ContactInfo { get; set; }
        public string UniversityEmail { get; set; }
        public string UniversityID { get; set; }
        public string password { get; set; }
        public DateTime CreationDate { get; set; }
        public string? MedicalHistory { get; set; }
        public string? DentalHistory { get; set; }
        public string? Complaint { get; set; }
        public string? TreatmentPlan { get; set; }
        public string? Diagnose { get; set; }
        public string? Status { get; set; }
        public string? Procedure { get; set; }
        public string Role { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }


    }
}
