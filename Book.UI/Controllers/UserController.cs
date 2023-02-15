using Book.UI.Models;
using Book.UI.Models.User;
using Book.UI.Services.Interfaces;
using Data.Entities.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace Book.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService service;
        public UserModel user;
        public bool IsSignedIn;
        
        public UserController(IUserService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
            user = new UserModel();
            IsSignedIn = false;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                ViewBag.IsSignedIn = true;
                ViewBag.User = await service.Login(loginModel); ;
            }
            catch(Exception ex)
            {
                Error();
            }

            return View();
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            try
            {
                user = await service.Register(registerModel);
                ViewBag.IsSignedIn = true;
            }
            catch (Exception ex)
            {
                Error();
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            ViewBag.IsSignedIn = false;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
