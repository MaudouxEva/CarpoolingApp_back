namespace CarpoolingApp.BLL.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Méthode pour enregistrer un user (Register).
        /// Renvoie un token JWT si OK.
        /// </summary>
        string Register(object dto); // on verra qu'on passera un RegisterDTO

        /// <summary>
        /// Méthode pour se logguer. Renvoie un token JWT si OK.
        /// </summary>
        string Login(string email, string password);
    }
}