using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hahn.ApplicatonProcess.December2020.Web.Models;using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Data.Resource;

namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicantService applicantService;
        private readonly IMapper mapper;

        public HomeController(/* ILogger<HomeController> logger */IApplicantService applicantService, IMapper mapper)
        {
            this.applicantService = applicantService;
            this.mapper = mapper;
            //_logger = logger;
        }

        public IActionResult Get(int id)
        {
            if (id < 1)
                return BadRequest("Invalid Id");

            ApplicantResource applicantResource = new();
            var applicant = applicantService.GetApplicant(id);
            if (applicant == null)
                return NotFound();
            
            applicantResource = mapper.Map<ApplicantResource>(applicant);

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
