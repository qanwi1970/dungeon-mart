using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface ISkillService
    {
        IQueryable<SkillViewModel> GetSkills();
        SkillViewModel GetSkillById(int id);
        SkillViewModel AddSkill(SkillViewModel skill);
        SkillViewModel UdpateSkill(int id, SkillViewModel skill);
        void DeleteSkill(int id);
        void SeedSkills(string seedPath);
    }
}
