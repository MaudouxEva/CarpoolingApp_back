namespace CarpoolingApp.BLL.Interfaces;

public interface IJwtManager
{
    string CreateToken(string identifier, string email, string role);
}