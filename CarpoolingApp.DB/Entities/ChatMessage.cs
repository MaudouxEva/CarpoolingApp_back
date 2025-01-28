namespace CarpoolingApp.DB.Entities;

public class ChatMessage
{
    public int Id { get; set; }
    public int ChatSessionId { get; set; }
    public int Sender { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime SentAt { get; set; }

    // Navigation
    public virtual ChatSession? ChatSession { get; set; }
    public virtual User? SenderUser { get; set; }

}