using AutoMapper;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.December2020.Web.Controllers;
using Hahn.ApplicatonProcess.December2020.Web.MappingProfile;
using Hahn.ApplicatonProcess.December2020.Web.Models.Resource;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Hahn.ApplicatonProcess.December2020.Test
{
    public class HomeControllerTest
    {
        private IMapper mapper;
        private readonly HomeController controller;
        private Mock<IApplicantService> applicantService;

        public HomeControllerTest()
        {
            applicantService = new Mock<IApplicantService>();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Mapping());
            });
            mapper = mockMapper.CreateMapper();
            controller = new HomeController(applicantService.Object, mapper);
        }

        [Fact]
        public void Get_WhenValidObjectPassed_ReturnsOkResult()
        {
            int id = 1;

            //act
            var expectedResult = controller.Get(id);
            var result = Assert.IsType<OkObjectResult>(expectedResult);

            //assert
            Assert.True(result.StatusCode == StatusCodes.Status200OK);
        }

        [Fact]
        public void Get_WhenValidObjectPassed_ReturnsOkResultOfTypeApplicantResource()
        {
            int id = 1;
            var expectedResult = controller.Get(id);
            
            Assert.IsType<OkObjectResult>(expectedResult);
            var okobjectResult = expectedResult as OkObjectResult;
            
            Assert.IsType<ApplicantResource>(okobjectResult.Value);
        }

        [Fact]
        public void Get_IfZeroIsPassedAsId_ReturnsBadRequest()
        {
            var result = controller.Get(0);

            var objectResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.True(StatusCodes.Status400BadRequest == objectResult.StatusCode);
        }
    }
}
