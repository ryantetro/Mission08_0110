using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission08_0110.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Mission08_0110.Controllers
{
    // Inherits from the Controller base class provided by ASP.NET Core.
    public class HomeController : Controller
    {
        private IJobRepository _repo;
        // Constructor to initialize the controller with a job repository instance.
        public HomeController(IJobRepository temp)
        {
            _repo = temp;
        }
        // Action method for the default index view.
        public IActionResult Index()
        {
            return View();
        }
        // HTTP GET action method to display a form for entering a new job.

        [HttpGet]
        public IActionResult EnterAJob()
        {
            ViewBag.Categories = new SelectList(_repo.GetAllCategories(), "CategoryId", "Name");
            return View();
        }

        // HTTP POST action method to handle form submission for adding a new job.

        [HttpPost]
        public IActionResult EnterAJob(Job response)
        {
            //if (ModelState.IsValid)
            //{
                _repo.AddJob(response);
                return RedirectToAction("JobList");
            //}
            //else
            //{
                //ViewBag.Categories = new SelectList(_repo.GetAllCategories(), "CategoryId", "Name");
                //return View(response);
            //}

        }
        // Action method to display a list of jobs.
        public IActionResult JobList()
        {
            var jobs = _repo.Jobs
                .OrderBy(x => x.Quadrant)
                .ToList();

            return View(jobs);
        }

        // HTTP GET action method to display a form for editing a job.

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Jobs
                .Single(x => x.JobId == id);

            ViewBag.Categories = new SelectList(_repo.GetAllCategories(), "CategoryId", "Name");

            return View("EnterAJob", recordToEdit);
        }
        // HTTP POST action method to handle form submission for editing a job.

        [HttpPost]
        public IActionResult Edit(Job updated)
        {
            //if (ModelState.IsValid)
            //{
                _repo.EditJob(updated);

            //}

            return RedirectToAction("JobList");
        }

        // HTTP GET action method to display a confirmation page before deleting a job.

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Jobs.SingleOrDefault(x => x.JobId == id);

            if (recordToDelete == null)
            {
                return NotFound(); // Or handle the case where the job does not exist
            }

            return View(recordToDelete);
        }
        // HTTP POST action method to handle deletion of a job.
        [HttpPost]
        public IActionResult Delete(Job deletedJob)
        {
            //if (!ModelState.IsValid)
            //{
            //    // Debug: Inspect ModelState errors
            //    var errors = ModelState.Values.SelectMany(v => v.Errors);
            //    foreach (var error in errors)
            //    {
            //        // Log or debug the error messages
            //        Debug.WriteLine(error.ErrorMessage);
            //    }

            //    // Handle invalid model state
            //    return View(deletedJob);
            //}

            // Continue with deletion logic if model state is valid
            _repo.DeleteJob(deletedJob);
            
            return RedirectToAction("JobList");
        }



    }

}
