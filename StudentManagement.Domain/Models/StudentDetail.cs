namespace StudentManagement.Api.Models;

public record StudentDetail
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public long? RollNumber { get; set; }

    public string? DateOfBirth { get; set; }

    public string? Class { get; set; }

    public string? BloodGroup { get; set; }

    public string? Address { get; set; }
}