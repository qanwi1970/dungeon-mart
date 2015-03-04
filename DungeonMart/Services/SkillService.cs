using System.IO;
using System.Linq;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.SrdSeed;
using DungeonMart.Mappers;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;
using Newtonsoft.Json;

namespace DungeonMart.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public IQueryable<Skill> GetSkills()
        {
            return _skillRepository.GetAll().Select(SkillMapper.MapEntityToModel).AsQueryable();
        }

        public Skill GetSkillById(int id)
        {
            return SkillMapper.MapEntityToModel(_skillRepository.GetById(id));
        }

        public Skill AddSkill(Skill skill)
        {
            var skillToAdd = SkillMapper.MapModelToEntity(skill);
            skillToAdd.CreatedBy = "TEST";
            var addedSkill = _skillRepository.Add(skillToAdd);
            return SkillMapper.MapEntityToModel(addedSkill);
        }

        public Skill UdpateSkill(int id, Skill skill)
        {
            var skillToUpdate = _skillRepository.GetById(id);
            SkillMapper.MapModelToEntity(skill, skillToUpdate);
            skillToUpdate.ModifiedBy = "TEST";
            var updatedSkill = _skillRepository.Update(skillToUpdate);
            return SkillMapper.MapEntityToModel(updatedSkill);
        }

        public void DeleteSkill(int id)
        {
            _skillRepository.Delete(id);
        }

        public void SeedSkills(string seedPath)
        {
            SkillSeed[] skillArray;
            using (var skillStream = new StreamReader(seedPath + "/skill.json"))
            {
                skillArray = JsonConvert.DeserializeObject<SkillSeed[]>(skillStream.ReadToEnd());
            }
            foreach (var skillSeed in skillArray)
            {
                var skillEntity = _skillRepository.GetById(skillSeed.Id);
                if (skillEntity == null)
                {
                    skillEntity = SkillMapper.MapSeedToEntity(skillSeed);
                    skillEntity.CreatedBy = "SeedSkills";
                    _skillRepository.Add(skillEntity);
                }
                else
                {
                    SkillMapper.MapSeedToEntity(skillSeed, skillEntity);
                    skillEntity.ModifiedBy = "SeedSkills";
                    _skillRepository.Update(skillEntity);
                }
            }
        }
    }
}