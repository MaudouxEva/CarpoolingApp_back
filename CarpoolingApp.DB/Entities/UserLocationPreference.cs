namespace CarpoolingApp.DB.Entities;

public class UserLocationPreference
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int LocationId { get; set; }

    // Navigation
    public virtual User? User { get; set; }
    public virtual Location? Location { get; set; }
}