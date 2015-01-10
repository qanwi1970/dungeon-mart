using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
