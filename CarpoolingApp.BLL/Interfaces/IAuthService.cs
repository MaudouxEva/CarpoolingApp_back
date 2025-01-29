namespace CarpoolingApp.BLL.Interfaces;

public interface IAuthService
{
    // MODIFICATION ICI: Méthode pour s'inscrire
    void Register(string email, string password, string firstName, string lastName, bool isAdmin);

    // MODIFICATION ICI: Méthode pour se logguer
    string Login(string email, string password);

    // On renvoie un string = le token JWT si c'est OK, sinon on jette une exception
}