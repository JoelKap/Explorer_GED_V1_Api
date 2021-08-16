using Explorer_GED_V1.Model;
using System.Collections.Generic;

namespace Explorer_GED_V1.Service.Contracts
{
    public  interface IAgentService
    {
        List<AgentModel> GetAgents(); 
        bool CreateAgent(AgentModel request);
        bool UpdateAgent(AgentModel request);
    }
}
