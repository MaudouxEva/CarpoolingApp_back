namespace CarpoolingApp.DB.Entities;

public class ChatSession
{
    public int Id { get; set; }
    public int RequestId { get; set; }
    public int DriverId { get; set; }
    public int ApplicantId { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }

    // Navigation
    public virtual Request? Request { get; set; }
    public virtual User? Driver { get; set; }
    public virtual User? Applicant { get; set; }

    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

}