using Explorer_GED_V1.Dal.Contracts;
using Explorer_GED_V1.Dal.DTO;
using Explorer_GED_V1.Model;
using System;
using System.Linq;

namespace Explorer_GED_V1.Dal.Implementations
{
    public class AuthDal : IAuthDal
    {
        private readonly ExplorerContext _explorerContext;
        public AuthDal(ExplorerContext explorerContext)
        {
            _explorerContext = explorerContext;
        }



        public AgentModel GetUser(string cell, string password)
        {
            var agentDto = _explorerContext.Agents.Where(x => x.AgentCellphone == cell && x.AgentPassword == password).FirstOrDefault();
            
            var user = new AgentModel()
            {
                AgentCellphone = agentDto.AgentCellphone,
                AgentAddress = agentDto.AgentAddress,
                AgentCreatedDate = agentDto.AgentCreatedDate != null ? (DateTime)agentDto.AgentCreatedDate : DateTime.MaxValue,
                AgentEmail = agentDto.AgentEmail,
                AgentId = agentDto.AgentId,
                AgentName = agentDto.AgentName,
                AgentPhoto = agentDto.AgentPhoto,
                AgentPostName = agentDto.AgentPostName,
                AgentSurname = agentDto.AgentSurname,
                IsAgentActive = (bool)agentDto.IsAgentActive,
                AgentPassword = agentDto.AgentPassword,
                UserType = new UserTypeModel()
                {
                    UserTypeId = (Guid)agentDto.UserTypeId,
                    UserType = _explorerContext.UserTypes.FirstOrDefault(x => x.UserTypeId == agentDto.UserTypeId).UserType1
                }
            };
            return user;
        }
    }
}
