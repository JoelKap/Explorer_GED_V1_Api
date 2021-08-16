using Explorer_GED_V1.Model;
using System.Collections.Generic;

namespace Explorer_GED_V1.Dal.Contracts
{
    public interface IAgentDal
    {
        List<AgentModel> GetAgents();
        bool CreateAgent(AgentModel request);
        bool UpdateAgent(AgentModel request);
    }
}
