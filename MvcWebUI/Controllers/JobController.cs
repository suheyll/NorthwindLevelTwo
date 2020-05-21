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
    public class JobController:Controller
    {
        private IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        public IActionResult Index(int id)
        {

            var model = new JobListViewModel();

            if (id > 0)
            {
                model.Jobs.Add(_jobService.GetById(id));
            }
            else { 

            model.Jobs=_jobService.GetAll();

            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            Job job = _jobService.GetById(id);
            _jobService.DeleteFromDb(job);

            return RedirectToAction("Index", "Job");
        }


        public IActionResult Edit(int id)
        {
            var model = new JobListViewModel
            {
                Job= _jobService.GetById(id)
        };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id,string name,string term)
        {
            var model = new JobListViewModel
            {
                Job = _jobService.GetById(id)
            };
            model.Job.Name = name;
            model.Job.Term = term;
            _jobService.UpdateFromDb(model.Job);
            return RedirectToAction("Index", "Job");
        }

    }
}
