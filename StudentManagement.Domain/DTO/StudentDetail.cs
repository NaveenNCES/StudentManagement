namespace StudentManagement.Domain.DTO
{
    public record StudentDetail
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string RollNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Class { get; set; }
        public string BloodGroup { get; set; }
        public Address Address { get; set; }
    }
}