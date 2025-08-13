namespace universty_dental_clinical.DTO.Booking
{
    public class UpdatedBooking
    {
        public int StudentId { get; set; }
        public string PatientName { get; set; }
        public DateTime? UpdationDate { get; set; }
        public string Time { get; set; }
        public string Status { get; set; } 
        public string Diagnose { get; set; }
    }
}
