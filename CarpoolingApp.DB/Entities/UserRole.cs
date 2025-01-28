namespace CarpoolingApp.DB.Entities;

public class UserRole
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }

    // Navigation
    public virtual User? User { get; set; }
    public virtual Role? Role { get; set; }
}