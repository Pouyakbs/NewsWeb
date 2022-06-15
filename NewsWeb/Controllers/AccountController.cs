using Microsoft.AspNetCore.Mvc;
using NewsWeb.Core.Contracts;
using NewsWeb.Core.Entities;
using NewsWeb.Infrustructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Controllers
{
    public class AccountController : Controller
    {
        IAuthenticationFacade authenticationFacade;
        public AccountController(IAuthenticationFacade authenticationFacade)
        {
            this.authenticationFacade = authenticationFacade;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAccount(Authentication authentication, string password, string confirmedpass)
        {
            if (password == confirmedpass)
            {
                authenticationFacade.AddAdmin(authentication);
            }
            else
            {
                return RedirectToAction("CreateAccount");
            }
            return RedirectToAction("index", "home");
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Process(string username,string password)
        {
            foreach (var admin in authenticationFacade.GetAuthentications())
            {
                if (admin.Username == username && admin.Password == password)
                {
                    TempData["LoggedIn"] = "True";
                    return RedirectToAction("Index", "News");
                }
                else
                {
                    TempData["LoggedIn"] = "False";
                }
            }
            return RedirectToAction("Login");
        }
        public IActionResult Logout()
        {
            TempData["LoggedIn"] = "False";
            return RedirectToAction("index", "home");
        }
    }
}
