using System.Web.Mvc;
using DungeonMart.Models;
using DungeonMart.Services.Interfaces;

namespace DungeonMart.Controllers
{
    public class ClassesController : Controller
    {
        private readonly ICharacterClassService _characterClassService;

        public ClassesController(ICharacterClassService characterClassService)
        {
            _characterClassService = characterClassService;
        }

        // GET: Classes
        public ActionResult Index()
        {
            var classes = _characterClassService.GetClasses();
            return View(classes);
        }

        // GET: Classes/Details/5
        public ActionResult Details(int id)
        {
            var characterClass = _characterClassService.GetClassById(id);
            return View(characterClass);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            var model = new CharacterClass();
            return View(model);
        }

        // POST: Classes/Create
        [HttpPost]
        public ActionResult Create(CharacterClass characterClass)
        {
            try
            {
                _characterClassService.AddClass(characterClass);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(characterClass);
            }
        }

        // GET: Classes/Edit/5
        public ActionResult Edit(int id)
        {
            var characterClass = _characterClassService.GetClassById(id);
            return View(characterClass);
        }

        // POST: Classes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CharacterClass characterClass)
        {
            try
            {
                _characterClassService.UpdateClass(id, characterClass);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(characterClass);
            }
        }

        // GET: Classes/Delete/5
        public ActionResult Delete(int id)
        {
            var characterClass = _characterClassService.GetClassById(id);
            return View(characterClass);
        }

        // POST: Classes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CharacterClass characterClass)
        {
            try
            {
                _characterClassService.DeleteClass(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(characterClass);
            }
        }
    }
}
