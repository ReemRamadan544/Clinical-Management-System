namespace universty_dental_clinical.DTO.Booking
{
    public class CreateBooking
    {

        public string StudentId { get; set; }
        public string UserId { get; set; }
        public string PatientName { get; set; }
        public string Time { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Status { get; set; }
        public string Diagnose { get; set; }
        public bool Signature { get; set; }
        public string? StudentName { get; set; }



    }
}
