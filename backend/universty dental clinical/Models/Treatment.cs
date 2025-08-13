namespace universty_dental_clinical.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public int Duration { get; set; }
    }
}
