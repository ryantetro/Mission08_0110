using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission08_0110.Models;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Mission08_0110.Controllers
{
    public class HomeController : Controller
    {
        private IJobRepository _repo;
        public HomeController(IJobRepository temp)
        {
            _repo = temp;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EnterAJob()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EnterAJob(Job response)
        {
            if (ModelState.IsValid)
            {
                _repo.AddJob(response);
                return View("Confirmation", response);
            }
            else
            {
                return View(response); // Return to the form with validation messages
            }
            
        }

        public IActionResult JobList()
        {
            var jobs = _repo.Jobs
                .OrderBy(x => x.Quadrant)
                .ToList();

            return View(jobs);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Jobs
                .Single(x => x.JobId == id);

            return View("EnterAJob", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Job updated)
        {
            if (ModelState.IsValid)
            {
                _repo.EditJob(updated);
            }

            return RedirectToAction("JobList");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Jobs.Single(x => x.JobId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Job deleted)
        {
            if (ModelState.IsValid)
            {
                _repo.DeleteJob(deleted);
            }

            return RedirectToAction("JobList");
        }

    }
}
