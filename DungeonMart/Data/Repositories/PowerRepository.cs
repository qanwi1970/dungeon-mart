using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    public class PowerRepository : Repository<Power>, IPowerRepository
    {
        public PowerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
