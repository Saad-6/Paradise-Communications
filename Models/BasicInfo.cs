namespace Paradise.Models
{
    public class BasicInfo
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public double? ZipCode { get; set; }
        public DateTime? DateOfSubmission { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
