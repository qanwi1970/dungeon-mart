using System.Web.Mvc;
using DungeonMart.Data.DAL;
using DungeonMart.Data.Repositories;
using DungeonMart.Models;
using DungeonMart.Services;
using DungeonMart.Services.Interfaces;
using Microsoft.AspNet.Identity;

namespace DungeonMart.Controllers
{
    [Authorize]
    public class ClassesController : Controller
    {
        private readonly ICharacterClassService _characterClassService;

        public ClassesController()
            : this(new CharacterClassService(new CharacterClassRepository(new DungeonMartContext())))
        {
        }

        public ClassesController(ICharacterClassService characterClassService)
        {
            _characterClassService = characterClassService;
        }

        [AllowAnonymous]
        // GET: Classes
        public ActionResult Index()
        {
            var classes = _characterClassService.GetClasses();
            return View(classes);
        }

        [AllowAnonymous]
        // GET: Classes/Details/5
        public ActionResult Details(int id)
        {
            var characterClass = _characterClassService.GetClassById(id);
            return View(characterClass);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            var model = new CharacterClassViewModel();
            return View(model);
        }

        // POST: Classes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterClassViewModel characterClass)
        {
            try
            {
                _characterClassService.AddClass(characterClass, User.Identity.GetUserId());

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
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CharacterClassViewModel characterClass)
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
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CharacterClassViewModel characterClass)
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
