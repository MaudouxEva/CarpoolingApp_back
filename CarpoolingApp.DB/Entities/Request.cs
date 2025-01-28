using Covoiturage.DB.Enums;

namespace CarpoolingApp.DB.Entities;

public class Request
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime DesiredDateTime { get; set; }
    public DateTime CreatedDate { get; set; }
    public int StartingLocation { get; set; }
    public int EndingLocation { get; set; }
    public bool IsRoundTrip { get; set; }
    public RequestStatus Status { get; set; }

    // Navigation
    public virtual User? User { get; set; }
    public virtual Location? StartingLocationNav { get; set; }
    public virtual Location? EndingLocationNav { get; set; }

    public virtual ICollection<ChatSession> ChatSessions { get; set; } = new List<ChatSession>();
}