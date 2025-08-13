namespace universty_dental_clinical.DTO.User
{
    public class Loginst
    {
        public string UniversityEmail { get; set; }
        public string Password { get; set; }
    }

    public class LoginStudent
    {
        public string UniversityId { get; set; }
        public string Password { get; set; }
    }
}
