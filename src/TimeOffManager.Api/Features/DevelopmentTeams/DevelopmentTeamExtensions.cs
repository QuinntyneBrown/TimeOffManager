using System.Linq;
using TimeOffManager.Api.Models;

namespace TimeOffManager.Api.Features
{
    public static class DevelopmentTeamExtensions
    {
        public static DevelopmentTeamDto ToDto(this DevelopmentTeam developmentTeam)
        {
            return new ()
            {
                DevelopmentTeamId = developmentTeam.DevelopmentTeamId,
                AgileMethodology = developmentTeam.AgileMethodology,
                Hiring = developmentTeam.Hiring,
                Employees = developmentTeam.Employees.Select(x => x.ToDto()).ToList()
            };
        }        
    }
}
