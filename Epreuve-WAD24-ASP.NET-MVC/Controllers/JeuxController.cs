using BLL.Entities;
using BLL.Services;
using Common.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Epreuve_WAD24_ASP.NET_MVC.Controllers
{
    public class JeuxController : Controller
    {
        private IJeuxRepository<Jeux> _jeuxService;

        public JeuxController(IJeuxRepository<Jeux> jeuxService)
        {
            _jeuxService = jeuxService;
        }

        // GET: JeuxController
        public ActionResult Index()
        {
            return View();
        }

        // GET: JeuxController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JeuxController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JeuxController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JeuxController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JeuxController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JeuxController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JeuxController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("search")]
        public IActionResult GetJeuxByNom([FromQuery] string nom)
        {
            var jeux = _jeuxService.GetWithNom(nom);
            return Ok(jeux);
        }

        [HttpGet("search")]
        public IActionResult SearchJeuxByTag([FromQuery] Guid tagId)
        {
            if (tagId == Guid.Empty)
            {
                return BadRequest(new { message = "Le tagId ne peut pas être vide." });
            }

            var jeux = _jeuxService.GetWithTag(tagId);
            return Ok(jeux);
        }

    }
}
