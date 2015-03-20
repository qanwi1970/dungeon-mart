using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface IDomainService
    {
        IQueryable<DomainViewModel> GetDomains();
        DomainViewModel GetDomainById(int id);
        DomainViewModel AddDomain(DomainViewModel domain);
        DomainViewModel UpdateDomain(int id, DomainViewModel domain);
        void DeleteDomain(int id);
        void SeedDomain(string seedPath);
    }
}
