using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GoHireNow.Models;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Collections.Generic;
using GoHireNow.Controllers;
using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace GoHireNow.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            JobDetailService jobDetailController = new JobDetailService();
            ViewBag.JobTitleModel = jobDetailController.getJobTitle();

            return View();
        }

        public IActionResult HireMaE()
        {
            string strPathAndQuery = HttpContext.Request.Path;
            int index = strPathAndQuery.LastIndexOf('/');
            string UserUniqueId = strPathAndQuery.Substring(index + 1);
            ProfileWorkerService profileWorkerService = new ProfileWorkerService();
            ViewBag.ProfileWorkerModel = profileWorkerService.GetProfileWorker(UserUniqueId);

            //Related Workers

            RelatedWorkersService relatedWorkersService = new RelatedWorkersService();
            ViewBag.RelatedWorkersModel = relatedWorkersService.GetRelatedWorkers(UserUniqueId,"4");

            return View();
        }

        public IActionResult HireVirtualAssistant(string id)
        { 
            string strPathAndQuery = HttpContext.Request.Path;
            string queryString = HttpContext.Request.QueryString.Value;
            int index = strPathAndQuery.LastIndexOf('/');
            int newIndex = strPathAndQuery.LastIndexOf('?');
            int lastIndex = queryString.LastIndexOf('=');
            string pageIndex = "";

            if (!String.IsNullOrEmpty(queryString))
            {
                pageIndex = queryString.Substring(lastIndex + 1);
            }

            SkillsService SkillsService = new SkillsService();
            ViewBag.Skills = SkillsService.GetSkills();
            DetailsWorkerService detailsWorkerService = new DetailsWorkerService();                                
            
            ViewBag.DetaisWorkerModel = detailsWorkerService.GetDetailsWorker(id, pageIndex);
            ViewBag.URL = strPathAndQuery;

            if (TempData.ContainsKey("search"))
            {
                string search = TempData["search"] as string;
                ViewBag.DetaisWorkerModel = JsonConvert.DeserializeObject<DetailsWorkerModel>(search);
                ViewBag.PageIndex = TempData["pageindex"] as string;

                //TempData.Keep("search");
            }
            else
            {
                ViewBag.PageIndex = pageIndex;
            }

            return View();
        }

        [HttpPost]
        public bool Search(string sendingString, string page)
        {
            TempData["search"] = sendingString;
            TempData["pageindex"] = page;
            return true;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
