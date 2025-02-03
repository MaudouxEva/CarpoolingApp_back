namespace CarpoolingApp.API.DTOs
{
    public class RegisterDTO
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        // InstitutionName ou InstitutionId?
        // MODIFICATION ICI: on va utiliser InstitutionId
        public int InstitutionId { get; set; }

        // On peut préciser "IsAdmin" si on veut choisir le role
        public bool IsAdmin { get; set; } = false;
    }
}