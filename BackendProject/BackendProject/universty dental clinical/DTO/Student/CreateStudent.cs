namespace universty_dental_clinical.DTO.Student
{
    public class CreateStudent
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public string UniversityID { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }

    public class UpdateStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string ContactInfo { get; set; }
        public string UniversityEmail { get; set; }
        public string UniversityID { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
    }
}
