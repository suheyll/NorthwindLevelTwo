using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class UserCertController:Controller
    {
        private IUserCertService _userCertService;
        private IUserService _userService;
        private ICertService _certService;

        public UserCertController(IUserCertService userCertService, IUserService userService, ICertService certService)
        {
            _userCertService = userCertService;
            _userService = userService;
            _certService = certService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var user = _userService.GetByUsername(userName);
            var userCerts = _userCertService.GetAll(user.Id);


            List<Cert> certs = new List<Cert>();

            foreach (var cert in userCerts)
            {
                var Cert = _certService.GetById(Convert.ToInt32(cert.CertId));
                certs.Add(Cert);
            }

            var model = new UserCertViewModel
            {
                UserCerts = userCerts,
                Certs = certs

            };
            return View(model);

        }
    }
}
