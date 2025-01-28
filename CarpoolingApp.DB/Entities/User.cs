namespace CarpoolingApp.DB.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public int InstitutionId { get; set; }
    public bool IsActive { get; set; }

    // Navigation
    public virtual Institution? Institution { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public virtual ICollection<UserLocationPreference> UserLocationPreferences { get; set; } = new List<UserLocationPreference>();
    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    // Pour la ChatSession (driver/applicant)
    public virtual ICollection<ChatSession> ChatSessionsAsDriver { get; set; } = new List<ChatSession>();
    public virtual ICollection<ChatSession> ChatSessionsAsApplicant { get; set; } = new List<ChatSession>();

    // Pour ChatMessage (si on veut un lien direct vers l’émetteur)
    public virtual ICollection<ChatMessage> ChatMessagesSent { get; set; } = new List<ChatMessage>();

}