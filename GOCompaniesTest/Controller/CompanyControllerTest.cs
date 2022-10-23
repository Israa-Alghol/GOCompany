using FakeItEasy;
using GOCompanies.Controllers;
using GOCompanies.Models;
using GOCompanies.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GOCompaniesTest.Controller
{
    public class CompanyControllerTest
    {
        //BaseController _controller = A.Fake<BaseController>();

        //private readonly Mock<ICRepo<Company>> _mockRepo;
        //private readonly DbContextOptionsBuilder<CDBContext> _dbcontext;
        //private readonly CompanyController _controller;
        //public CompanyControllerTest()
        //{

        //}
        [Fact]
        public void Should_Pass_GetById()
        {

            // Arrange
            //int Id = 3;
            //string testName = "test name";
            //string testDescription = "test description";
            //var mockRepo = new Mock<ICRepo<Company>>();
            //mockRepo.Setup(repo => repo.GetById(Id))
            //    .ReturnsAsync((BrainstormSession)null);
            //var controller = new IdeasController(mockRepo.Object);

            //// Act
            //var result = await controller.ForSession(testSessionId);

            //// Assert
            //var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            //Assert.Equal(testSessionId, notFoundObjectResult.Value);



            //var _mockRepo = new Mock<ICRepo<Company>>();
            //var _dbcontext = new DbContextOptionsBuilder<CDBContext>();
            //_dbcontext.UseSqlServer("Server=FMS-SW07\\SQLEXPRESS;Database=Compa;Trusted_Connection=True;MultipleActiveResultSets=true");
            //var mockset = new Mock<DbSet<Company>>();
            //var mockContext = new Mock<CDBContext>(_dbcontext);
            ////mockContext.Setup(m => m.Companies).Returns(mockset.Object);
            //mockContext.Setup(x => x.Companies<>("SomeFunctionName", It.IsAny<string>(), It.IsAny<object>())).Returns(Task.FromResult(mockset.Object));
            //using (var context = new CDBContext(_dbcontext.Options))
            //{
            //   var _controller = new CompanyController(_mockRepo.Object, context);
            //    IEnumerable<Company> list = _controller.GetById(id);
            //    Assert.NotNull(list);
            //}


            //_mockRepo.Setup(repo => repo.GetAll())
            //    .Returns(new List<Company>() { new Company(), new Company() });
            //var result = _controller.Index();
            //var viewResult = Assert.IsType<ViewResult>(result);
            //var companies = Assert.IsType<List<Company>>(viewResult.Model);
            //Assert.Equal(2, companies.Count);
        }
    }
}
