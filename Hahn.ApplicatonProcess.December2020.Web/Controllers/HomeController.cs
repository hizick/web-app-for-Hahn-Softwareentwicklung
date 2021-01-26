using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hahn.ApplicatonProcess.December2020.Web.Models;
using Hahn.ApplicatonProcess.December2020.Web.Models.Resource;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicantService applicantService;

        public HomeController(/* ILogger<HomeController> logger */IApplicantService applicantService)
        {
            this.applicantService = applicantService;
            //_logger = logger;
        }

        public IActionResult Get(int id)
        {
            if (id < 1)
                return BadRequest("Invalid Id");

            ApplicantResource applicantResource = new();
            //applicantResource = applicantService.GetApplicant(id);


            return Ok(applicantResource);
        }

        public IActionResult Privacy()
        {
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return Ok(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
