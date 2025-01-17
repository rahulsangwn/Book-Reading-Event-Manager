﻿using System.Web.Mvc;
using System.Web.Security;
using Project.BLL.Processor;
using Project.BLL.UserModel;

namespace Project.Web.Controllers
{
    public class AccountController : Controller
    {
        UserProcessor _process;
        public AccountController()
        {
            _process = new UserProcessor();
        }
        
        /// <summary>
        /// For Login View
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserEntity user)
        {
            if(_process.IsValidUser(user))
            {
                FormsAuthentication.SetAuthCookie(user.Email, user.PersistentLogin);
                return RedirectToAction("Index", "Home");
            } else
            {
                TempData["Fail"] = "true";
                return View();
            }
        }

        /// <summary>
        /// For Logout Action
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        /// <summary>
        /// For SignUp 
        /// </summary>
        /// <returns></returns>
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserEntity user)
        {
            if (!_process.CreateUser(user))
            {
                TempData["already"] = "true";
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}