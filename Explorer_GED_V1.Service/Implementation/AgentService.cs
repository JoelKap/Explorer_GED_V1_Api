using Explorer_GED_V1.Dal.Contracts;
using Explorer_GED_V1.Model;
using Explorer_GED_V1.Service.Contracts;
using System.Collections.Generic;

namespace Explorer_GED_V1.Service.Implementation
{
    public class AgentService: IAgentService
    {
        private readonly IAgentDal _agentDal;
        public AgentService(IAgentDal agentDal)
        {
            _agentDal = agentDal;
        }

        public List<AgentModel> GetAgents()
        {
            return _agentDal.GetAgents();
        }

        public bool CreateAgent(AgentModel request)
        {
            return _agentDal.CreateAgent(request);
        }


        public bool UpdateAgent(AgentModel request)
        {
            return _agentDal.UpdateAgent(request);
        }
    }
}
