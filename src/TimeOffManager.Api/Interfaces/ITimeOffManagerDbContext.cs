using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TimeOffManager.Api.Models;

namespace TimeOffManager.Api.Interfaces
{
    public interface ITimeOffManagerDbContext
    {
        DbSet<Employee> Employees { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
