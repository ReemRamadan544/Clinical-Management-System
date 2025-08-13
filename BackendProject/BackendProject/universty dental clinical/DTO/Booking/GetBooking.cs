namespace universty_dental_clinical.DTO.Booking
{
    public class GetBooking
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string Date { get; set; } 
        public string Time { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Status { get; set; } 
        public string Diagnose { get; set; }
        public bool Signature { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }
}
