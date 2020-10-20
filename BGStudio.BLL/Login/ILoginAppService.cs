using BGStudio.App.Models;

namespace BGStudio.BLL.Login
{
    public interface ILoginAppService
    {
        string GenerateJwt(AccountERD accountErd);
        AccountERD AuthenticateUser(string email, string password);
    }
}