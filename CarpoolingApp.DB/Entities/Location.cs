namespace CarpoolingApp.DB.Entities;

public class Location
{
    public int Id { get; set; }
    public string City { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;

    // Navigation properties
    public virtual ICollection<Institution> Institutions { get; set; } = new List<Institution>();
    public virtual ICollection<UserLocationPreference> UserLocationPreferences { get; set; } = new List<UserLocationPreference>();

    // Si je veux gérer la relation "Request" → startingLocation et endingLocation
    // je distingue les deux collections pour clarifier :
    public virtual ICollection<Request> RequestsAsStarting { get; set; } = new List<Request>();
    public virtual ICollection<Request> RequestsAsEnding { get; set; } = new List<Request>();
}