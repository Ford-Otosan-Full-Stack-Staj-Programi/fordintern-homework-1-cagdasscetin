using System.ComponentModel.DataAnnotations.Schema;

namespace StaffApi.Data;

public class Staff
{
    public int Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string AddressLine1 { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Province { get; set; }
    [NotMapped]
    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }
}
