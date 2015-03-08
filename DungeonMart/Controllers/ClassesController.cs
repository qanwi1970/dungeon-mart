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
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Classes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Classes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Classes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Classes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
