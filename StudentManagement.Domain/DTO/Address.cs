namespace StudentManagement.Domain.DTO
{
    public record Address
    {
        public string FatherName { get; set; }
        public string DoorNumber { get; set; }
        public string Town { get; set; }
        public string District { get; set; }
        public string PinCode { get; set; }
    }
}