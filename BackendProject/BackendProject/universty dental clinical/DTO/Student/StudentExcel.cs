namespace universty_dental_clinical.DTO.Student
{
    public class StudentExcel
    {
        public class CreateStudent
        {
            public string Name { get; set; }
            
            public string UniversityID { get; set; }
            public string Password { get; set; }
            public string? Role { get; set; }
        }
    }
}
