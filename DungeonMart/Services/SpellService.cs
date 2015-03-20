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
    public class SpellService : ISpellService
    {
        private readonly ISpellRepository _spellRepository;

        public SpellService(ISpellRepository spellRepository)
        {
            _spellRepository = spellRepository;
        }

        public IQueryable<SpellViewModel> GetSpells()
        {
            return _spellRepository.GetAll().Select(SpellMapper.MapEntityToModel).AsQueryable();
        }

        public SpellViewModel GetSpellById(int id)
        {
            return SpellMapper.MapEntityToModel(_spellRepository.GetById(id));
        }

        public SpellViewModel AddSpell(SpellViewModel spell)
        {
            var spellToAdd = SpellMapper.MapModelToEntity(spell);
            spellToAdd.CreatedBy = "TEST";
            spellToAdd.SeedData = false;
            var addedSpell = _spellRepository.Add(spellToAdd);
            return SpellMapper.MapEntityToModel(addedSpell);
        }

        public SpellViewModel UdpateSpell(int id, SpellViewModel spell)
        {
            var originalSpell = _spellRepository.GetById(id);
            SpellMapper.MapModelToEntity(spell, originalSpell);
            originalSpell.ModifiedBy = "TEST";
            var updatedSpell = _spellRepository.Update(originalSpell);
            return SpellMapper.MapEntityToModel(updatedSpell);
        }

        public void DeleteSpell(int id)
        {
            _spellRepository.Delete(id);
        }

        public void SeedSpells(string seedPath)
        {
            var spellMapper = new SpellMapper();
            SpellSeed[] spellArray;
            using (var spellStream = new StreamReader(seedPath + "/spell.json"))
            {
                spellArray = JsonConvert.DeserializeObject<SpellSeed[]>(spellStream.ReadToEnd());
            }
            foreach (var spellSeed in spellArray)
            {
                var spellEntity = _spellRepository.GetById(spellSeed.Id);
                if (spellEntity == null)
                {
                    spellEntity = spellMapper.MapSeedToEntity(spellSeed);
                    spellEntity.CreatedBy = "SeedSpells";
                    spellEntity.SeedData = true;
                    _spellRepository.Add(spellEntity);
                }
                else
                {
                    spellMapper.MapSeedToEntity(spellSeed, spellEntity);
                    spellEntity.ModifiedBy = "SeedSpells";
                    _spellRepository.Update(spellEntity);
                }
            }
        }
    }
}