﻿using BLL.Entities;
using Common.Repositories;
using Epreuve_WAD24_ASP.NET_MVC.Mappers;
using Epreuve_WAD24_ASP.NET_MVC.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Epreuve_WAD24_ASP.NET_MVC.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository<BLL.Entities.Utilisateur> _userService;

        public UserController(IUserRepository<Utilisateur> userService)
        {
            _userService = userService;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(Guid id)
        {
            try
            {
                UserDetails model = _userService.Get(id).ToDetails();
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreateForm form)
        {
            try
            {
                
                if (!ModelState.IsValid) throw new ArgumentException();
                Guid UtilisateurId = _userService.Insert(form.ToBLL());
                return RedirectToAction(nameof(Details), new { id = UtilisateurId });
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(Guid id)
        {
            try
            {
                UserEditForm model = _userService.Get(id).ToEditForm();
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, UserEditForm form)
        {
            try
            {
                if (!ModelState.IsValid) throw new ArgumentException(nameof(form));
                _userService.Update(id, form.ToBLL());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Edit), new { id = id });
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(Guid id)
        {
            try
            {
                UserDelete model = _userService.Get(id).ToDelete();
                return View(model);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, UserDelete form)
        {
            try
            {
                _userService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Delete), new { id = id });
            }
        }
    }
}
