using BLL.Entities;
using BLL.Services;
using Common.Repositories;
using DAL.Services;
using Epreuve_WAD24_ASP.NET_MVC.Handlers;
using Epreuve_WAD24_ASP.NET_MVC.Handlers.ActionFilters;
using Epreuve_WAD24_ASP.NET_MVC.Mappers;
using Epreuve_WAD24_ASP.NET_MVC.Models.Jeux;
using Epreuve_WAD24_ASP.NET_MVC.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Epreuve_WAD24_ASP.NET_MVC.Controllers
{
    public class JeuxController : Controller
    {
        private IJeuxRepository<Jeux> _jeuxService;
        private readonly SessionManager _sessionManager;

        public JeuxController(IJeuxRepository<Jeux> jeuxService, SessionManager sessionManager)
        {
            _jeuxService = jeuxService;
            _sessionManager = sessionManager;
        }



        // GET: JeuxController
        public ActionResult Index()
        {
            try
            {
                IEnumerable<JeuxListItems> model = _jeuxService.Get().Select(bll => bll.ToListItem());
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: JeuxController/Details/5
        public ActionResult Details(Guid jeuId)
        {
            try
            {
                JeuxDetails model = _jeuxService.Get(jeuId).ToDetails();
                _sessionManager.AddVisitedJeux(model.jeuId,model.Name);
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: JeuxController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JeuxController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JeuxCreateForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
                Guid id = _jeuxService.Insert(form.ToBLL());
                return RedirectToAction(nameof(Details), new { id });
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



        [HttpGet()]
        public ActionResult GetJeuxByNom()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetJeuxByNom([FromQuery] string nom)
        {
            var jeux = _jeuxService.GetWithNom(nom);
            return Ok(jeux);
        }

        [HttpGet()]
        public ActionResult GetJeuxByTag()
        {
            return View();
        }
        [HttpPost]
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
