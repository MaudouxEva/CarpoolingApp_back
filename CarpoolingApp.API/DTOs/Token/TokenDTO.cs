namespace CarpoolingApp.API.DTOs.Token;

public class TokenDTO(string token, UserDTO user)
{
    public string Token { get; set; } = token;
    public UserDTO User { get; set; } = user;
}