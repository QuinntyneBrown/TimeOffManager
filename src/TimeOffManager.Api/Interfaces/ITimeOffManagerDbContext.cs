using TimeOffManager.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace TimeOffManager.Api.Interfaces
{
    public interface ITimeOffManagerDbContext
    {
        DbSet<Employee> Employees { get; }
        DbSet<DevelopmentTeam> DevelopmentTeams { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
