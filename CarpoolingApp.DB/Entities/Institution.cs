namespace CarpoolingApp.DB.Entities;

public class Institution
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int LocationId { get; set; }
    public bool IsActive { get; set; }

    // Navigation
    public virtual Location? Location { get; set; }
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}