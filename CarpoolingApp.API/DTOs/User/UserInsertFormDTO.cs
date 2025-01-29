namespace CarpoolingApp.BLL.DTOs.User;

public class UserInsertFormDTO
{
    public string FirstName { get; set; } = string.Empty;
        
    public string LastName { get; set; } = string.Empty;
        
    public string Email { get; set; } = string.Empty;

    // Ici, on a besoin du mot de passe en clair
    public string Password { get; set; } = string.Empty;
        
    public int InstitutionId { get; set; }
        
    public bool IsActive { get; set; } = true;
}