using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface IDomainService
    {
        IQueryable<Domain> GetDomains();
        Domain GetDomainById(int id);
        Domain AddDomain(Domain domain);
        Domain UpdateDomain(int id, Domain domain);
        void DeleteDomain(int id);
        void SeedDomain(string seedPath);
    }
}
