using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.DomainModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Helpers;
using MvcWebUI.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MvcWebUI.Controllers
{
    public class LoginController:Controller
    {
        private IUserService _userService;
        private ILoginSessionHelper _loginSessionHelper;

        public LoginController(IUserService userService, ILoginSessionHelper loginSessionHelper)
        {
            _userService = userService;
            _loginSessionHelper = loginSessionHelper;
        }


        public IActionResult Index()
        {
            var model = new UserListViewModel()
            {
                
                Users =  _userService.GetAll()


            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(string userName,string password)
        {
            if (_userService.IsloginSuccess(userName, password))
            {
                var user = _userService.GetByUsername(userName);
                var us = _loginSessionHelper.GetUser("user");
                us.User = user;
                //_loginSessionHelper.SetUser("user", us);
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, user.Role),
                };

                var grandmaIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                HttpContext.SignInAsync(userPrincipal);

                TempData.Add("message", userName + " Hosgeldiniz");
                return RedirectToAction("Index", "Product");
            }

            return RedirectToAction("Index", "Home");

        }

      
        public IActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                HttpContext.SignOutAsync("CookieAuthentication");
                TempData.Add("message", " Çıkış işlemi başarılı");
             
            }
            return RedirectToAction("Index", "Home");



            // return RedirectToAction("Index", "Home");
        }

        public bool IsLogin()
        {
            return User.Identity.IsAuthenticated;
        }

        public IActionResult Register()
        {

        
            return View();

        }

        [HttpPost]
        public IActionResult Register(string userName,string password)
        {
       
            User user = new User
            {
                UserName = userName,Password = password,Role = "User"
            };
            _userService.AddUser(user);
            TempData.Add("message", " kayıt işlemi başarılı");
            return RedirectToAction("Index", "Login");

        }

        


    }
}
