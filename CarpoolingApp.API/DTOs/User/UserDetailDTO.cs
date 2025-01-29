namespace CarpoolingApp.BLL.DTOs.User;

public class UserDetailDTO
{
    public int Id { get; set; }
        
    public string FullName { get; set; } = string.Empty;
        
    public string Email { get; set; } = string.Empty;
        
    public bool IsActive { get; set; }

    public string InstitutionName { get; set; } = string.Empty;

    // Exemple : si je veux la liste de requests terminées, 
    // ou juste la liste d'IDs
    public List<int> RequestIds { get; set; } = new List<int>();

    // etc. on peut rajouter tes préférences, roles, etc.
    public List<int> RoleIds { get; set; } = new List<int>();
}