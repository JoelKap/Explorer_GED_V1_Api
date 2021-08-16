using Explorer_GED_V1.Dal.Contracts;
using Explorer_GED_V1.Dal.DTO;
using Explorer_GED_V1.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Explorer_GED_V1.Dal.Implementations
{
    public class AgentDal: IAgentDal
    {
        private readonly ExplorerContext _explorerContext;
        public AgentDal(ExplorerContext explorerContext)
        {
            _explorerContext = explorerContext;
        }

        public List<AgentModel> GetAgents()
        {
            var agents = _explorerContext.Agents.ToList();
            var list = new List<AgentModel>();
            for (int i = 0; i < agents.Count; i++)
            {
                list.Add(new AgentModel()
                {
                    AgentCellphone = agents[i].AgentCellphone,
                    AgentAddress = agents[i].AgentAddress,
                    AgentCreatedDate = agents[i].AgentCreatedDate != null ? (DateTime)agents[i].AgentCreatedDate : DateTime.MaxValue,
                    AgentEmail = agents[i].AgentEmail,
                    AgentId = agents[i].AgentId,
                    AgentName = agents[i].AgentName,
                    AgentPhoto = agents[i].AgentPhoto,
                    AgentPostName = agents[i].AgentPostName,
                    AgentSurname = agents[i].AgentSurname,
                    IsAgentActive = (bool)agents[i].IsAgentActive,
                    AgentPassword = agents[i].AgentPassword,
                    UserTypeId = (Guid)agents[i].UserTypeId,
                    UserType = new UserTypeModel()
                    {
                       UserTypeId = (Guid)agents[i].UserTypeId,                       
                        UserType = _explorerContext.UserTypes.FirstOrDefault(x=> x.UserTypeId == agents[i].UserTypeId).UserType1
                    }
                });
            }
            return list;
        }

        public bool CreateAgent(AgentModel request)
        {
            var agentDto = new Agent()
            {
                AgentAddress = request.AgentAddress,
                AgentCellphone = request.AgentCellphone,
                AgentCreatedDate = DateTime.Now,
                AgentEmail = request.AgentEmail,
                AgentId = Guid.NewGuid(),
                AgentName = request.AgentName,
                AgentPassword = request.AgentPassword,
                AgentPhoto = request.AgentPhoto,
                AgentSurname = request.AgentSurname,
                IsAgentActive = request.IsAgentActive,
                AgentPostName = request.AgentPostName,
                UserTypeId  = request.UserTypeId,
            };
            _explorerContext.Agents.Add(agentDto);
            _explorerContext.SaveChanges();
            return true;
        }

        public bool UpdateAgent(AgentModel request)
        {
            var userDto = _explorerContext.Agents.Where(x => x.AgentId == request.AgentId).FirstOrDefault();
            userDto.AgentAddress = request.AgentAddress;
            userDto.AgentCellphone = request.AgentCellphone;
            userDto.AgentCreatedDate = request.AgentCreatedDate;
            userDto.AgentEmail = request.AgentEmail;
            userDto.AgentId = request.AgentId;
            userDto.AgentName = request.AgentName;
            userDto.AgentPassword = request.AgentPassword;
            userDto.AgentPhoto = request.AgentPhoto;
            userDto.AgentPostName = request.AgentPostName;
            userDto.AgentSurname = request.AgentSurname;
            userDto.IsAgentActive = request.IsAgentActive;
            _explorerContext.SaveChanges();
            return true;
        }
    }
}
