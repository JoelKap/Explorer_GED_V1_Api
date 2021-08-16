using Explorer_GED_V1.Model;

namespace Explorer_GED_V1.Service.Contracts
{
    public interface IAuthService
    {
        AgentModel GetUser(string email, string password);
        LoginResponseModel Token(AgentModel user);
    }
}
