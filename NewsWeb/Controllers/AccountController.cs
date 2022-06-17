using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsWeb.Core.Contracts;
using NewsWeb.Core.Entities;
using NewsWeb.Infrustructure.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Controllers
{
    public class AccountController : Controller
    {
        IAuthenticationFacade authenticationFacade;
        IUserAuthenticationFacade userAuthenticationFacade;
        private readonly IWebHostEnvironment webHostEnvironment;
        public AccountController(IAuthenticationFacade authenticationFacade, IUserAuthenticationFacade userAuthenticationFacade, IWebHostEnvironment webHostEnvironment)
        {
            this.authenticationFacade = authenticationFacade;
            this.userAuthenticationFacade = userAuthenticationFacade;
            this.webHostEnvironment = webHostEnvironment;
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
        public IActionResult CreateAccount(AdminAuthentication authentication, string password, string confirmedpass)
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
        public IActionResult CreateUserAccount()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUserAccount(UserAuthentication model, string password, string confirmedpass)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                UserAuthentication authentication = new UserAuthentication
                {
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password,
                    Firstname = model.Firstname,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    Description = model.Description,
                    ProfileImage = uniqueFileName,
                };
                if (password == confirmedpass)
                {
                    userAuthenticationFacade.AddUser(authentication);
                }
                else
                {
                    return RedirectToAction("CreateUserAccount");
                }
            }
            return RedirectToAction("UserProfile", "Account");
        }
        private string UploadedFile(UserAuthentication authentication)
        {
            string uniqueFileName = null;

            if (authentication.Images != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, $"img/users");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + authentication.Images.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    authentication.Images.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Process(string username,string password,int id)
        {
            foreach (var admin in authenticationFacade.GetAuthentications())
            {
                foreach (var user in userAuthenticationFacade.GetAuthentications())
                {
                    if (admin.Username == username && admin.Password == password)
                    {
                        TempData["LoggedIn"] = "True";
                        return RedirectToAction("Index", "News");
                    }
                    else if (user.Username == username && user.Password == password)
                    {
                        TempData["UserLoggedIn"] = "True";
                        return Redirect($"/Account/UserProfile/{user.UsernameId}");
                    }
                    else
                    {
                        TempData["LoggedIn"] = "False";
                        TempData["UserLoggedIn"] = "False";
                    }
                }
                
            }
            return RedirectToAction("Login");
        }
        public IActionResult UserProfile(int id)
        {
            ViewBag.Data = userAuthenticationFacade.UserProfile(id);
            var validate = TempData.Peek("UserLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                return View(id);
            }
        }
        public IActionResult Delete(int id)
        {
            var validate = TempData.Peek("UserLoggedIn");
            if (validate == null || validate.ToString() == "False")
            {
                return RedirectToAction("login", "Account");
            }
            else
            {
                userAuthenticationFacade.DeleteUser(id);
                return RedirectToAction("index");
            }
        }
        public IActionResult Logout()
        {
            TempData["LoggedIn"] = "False";
            TempData["UserLoggedIn"] = "False";
            return RedirectToAction("index", "home");
        }
    }
}
