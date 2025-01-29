namespace CarpoolingApp.BLL.Models;

public class User
{
    public int Id { get; set; }
        
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int InstitutionId { get; set; }

    public bool IsActive { get; set; }

    // Optionnel : si je veux garder les Roles/Requests dans le Model,
    // je pourrais mettre des List<int> par ex. 
    // public List<int> RoleIds { get; set; } = new List<int>();
    // public List<int> RequestIds { get; set; } = new List<int>();
}