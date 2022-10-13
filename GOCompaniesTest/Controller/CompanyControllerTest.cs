using GOCompanies.Controllers;
using GOCompanies.Models;
using GOCompanies.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GOCompaniesTest.Controller
{
    public class CompanyControllerTest
    {
        private readonly Mock<ICRepo<Company>> _mockRepo;
        private readonly Mock<CDBContext> _dbcontext;
        private readonly CompanyController _controller;
        public CompanyControllerTest()
        {
            _mockRepo = new Mock<ICRepo<Company>>();
            _dbcontext = new Mock<CDBContext>();
            _controller = new CompanyController(_mockRepo.Object,_dbcontext.Object);

        }
        [Fact]
        public void Index_ActionExecutes_ReturnsExactNumberOfCompanies()
        {
            _mockRepo.Setup(repo => repo.GetAll())
                .Returns(new List<Company>() { new Company(), new Company() });
            var result = _controller.Index();
            var viewResult = Assert.IsType<ViewResult>(result);
            var companies = Assert.IsType<List<Company>>(viewResult.Model);
            Assert.Equal(2, companies.Count);
        }
    }
}
