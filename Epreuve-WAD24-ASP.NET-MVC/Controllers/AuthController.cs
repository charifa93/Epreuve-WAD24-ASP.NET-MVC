using BLL.Entities;
using Common.Repositories;
using Epreuve_WAD24_ASP.NET_MVC.Handlers;
using Epreuve_WAD24_ASP.NET_MVC.Handlers.ActionFilters;
using Epreuve_WAD24_ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Epreuve_WAD24_ASP.NET_MVC.Controllers
{
    public class AuthController : Controller
    {
        private IUserRepository<BLL.Entities.Utilisateur> _userService;
        private SessionManager _sessionManager;

        public AuthController(
            IUserRepository<Utilisateur> userService,
            SessionManager sessionManager
            )
        {
            _userService = userService;
            _sessionManager = sessionManager;
        }

        // GET: AuthController
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthLoginForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
                Guid id = _userService.CheckPassword(form.Email, form.MotDePasse);
                //C'est ici que nous définirons la variable de session
                Utilisateur user = _userService.Get(id);

                ConnectedUser sessionUser = new ConnectedUser()
                {
                    UtilisateurId = user.UtilisateurId,
                    Email = user.Email,
                    DateCreation = DateTime.Now
                };
                _sessionManager.Login(sessionUser);
                return RedirectToAction("Details", "User", new { id = id });
            }
            catch (Exception)
            {
                return View();
            }
        }

        
        public IActionResult Logout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logout(IFormCollection form)
        {
            try
            {
                _sessionManager.Logout();
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
