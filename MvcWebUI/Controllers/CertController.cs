using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
    public class CertController:Controller
    {
        private ICertService _certService;

        public CertController(ICertService certService)
        {
            _certService = certService;
        }

        public IActionResult Index()
        {
            var model = new CertListViewModel
            {
                Certs = _certService.GetAll()
            };
            return View(model);
        }

        public IActionResult Edit(int id)
        {
           var model = new CertListViewModel
           {
               Cert = _certService.GetById(id)
           };
           return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id,string name,string details)
        {
            Cert cert = new Cert
            {
                Id =id,
                Name = name,
                Details = details
               
            };
            _certService.UpdateFromDb(cert);
            return RedirectToAction("Index","Cert");
        }
    }
}
