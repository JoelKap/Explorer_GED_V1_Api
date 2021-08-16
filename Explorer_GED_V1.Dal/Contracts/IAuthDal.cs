using Explorer_GED_V1.Model;

namespace Explorer_GED_V1.Dal.Contracts
{
    public  interface IAuthDal
    {
        AgentModel GetUser(string cell, string password);
    }
}
