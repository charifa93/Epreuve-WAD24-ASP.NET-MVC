using BLL.Entities;
using Common.Repositories;
using Epreuve_WAD24_ASP.NET_MVC.Handlers;
using Epreuve_WAD24_ASP.NET_MVC.Handlers.ActionFilters;
using Epreuve_WAD24_ASP.NET_MVC.Mappers;
using Epreuve_WAD24_ASP.NET_MVC.Models.Emprunt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Epreuve_WAD24_ASP.NET_MVC.Controllers
{
    public class EmpruntController : Controller
    {
        private readonly IEmpruntRepository<Emprunt> _empruntRepository;
        private readonly SessionManager _sessionManager;

        public EmpruntController(IEmpruntRepository<Emprunt> empruntRepository, SessionManager sessionManager)
        {
            _empruntRepository = empruntRepository;
            _sessionManager = sessionManager;
        }



        // GET: HomeController1
        public ActionResult Index()
        {
           return View();
        }

        [HttpGet]
        public ActionResult Get10Top()
        {
            try
            {
                IEnumerable<EmpruntListItem10> model = _empruntRepository.GetTop10Emprunts().Select(bll => bll.ToListEmprunt10());
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }


        }
        

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpruntCreateForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
                _empruntRepository.Insert(form.ToBLL());
                return RedirectToAction("Index", "Emprunt");
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Emprunt");
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
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

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
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
    }
}
