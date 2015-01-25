using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Models;

namespace DungeonMart.Data.Repositories
{
    internal class EquipmentRepository : Repository<EquipmentEntity>, IEquipmentRepository
    {
        public EquipmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
