using System.Linq;
using DungeonMart.Models;

namespace DungeonMart.Services.Interfaces
{
    public interface ISkillService
    {
        IQueryable<Skill> GetSkills();
        Skill GetSkillById(int id);
        Skill AddSkill(Skill skill);
        Skill UdpateSkill(int id, Skill skill);
        void DeleteSkill(int id);
        void SeedSkills(string seedPath);
    }
}
