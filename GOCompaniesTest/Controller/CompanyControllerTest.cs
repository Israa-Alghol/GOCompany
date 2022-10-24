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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GOCompaniesTest.Controller
{
    public class CompanyControllerTest
    {

        //private Mock<ICRepo<Company>> _mockRepo;
        //private DbContextOptionsBuilder<CDBContext> _dbcontext;
        //private CompanyController _controller;

        [Fact]
        public void Test_Create_GET_ReturnsViewResultNullModel()
        {

            // Arrange
            var _mockRepo = new Mock<ICRepo<Company>>();
            var _dbcontext = new DbContextOptionsBuilder<CDBContext>();
            _dbcontext.UseSqlServer("Server=FMS-SW07\\SQLEXPRESS;Database=Compa;Trusted_Connection=True;MultipleActiveResultSets=true");
            var mockset = new Mock<DbSet<Company>>();
            var mockContext = new Mock<CDBContext>(_dbcontext);
            mockContext.Setup(m => m.Companies).Returns(mockset.Object);
            //mockContext.Setup(x => x.Companies("SomeFunctionName", It.IsAny<string>(), It.IsAny<object>())).Returns(Task.FromResult(mockset.Object));
            using (var context = new CDBContext(_dbcontext.Options))
            {
                var _controller = new CompanyController(_mockRepo.Object, context);
                var result = _controller.Create();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                Assert.Null(viewResult.ViewData.Model);
            }

        }

        [Fact]
        public void Test_Create_POST_InvalidModelState()
        {
            // Arrange
            var c = new Company()
            {
                Id = 5,
                Name = "Test",

            };
            var _mockRepo = new Mock<ICRepo<Company>>();
            _mockRepo.Setup(repo => repo.Add(It.IsAny<Company>()));
            var _dbcontext = new DbContextOptionsBuilder<CDBContext>();
            _dbcontext.UseSqlServer("Server=FMS-SW07\\SQLEXPRESS;Database=Compa;Trusted_Connection=True;MultipleActiveResultSets=true");
            var mockset = new Mock<DbSet<Company>>();
            var mockContext = new Mock<CDBContext>(_dbcontext);

            using (var context = new CDBContext(_dbcontext.Options))
            {
                var _controller = new CompanyController(_mockRepo.Object, context);

                _controller.ModelState.AddModelError("Name", "Name is required");

                // Act
                var result = _controller.Create(c);

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                Assert.Null(viewResult.ViewData.Model);
                _mockRepo.Verify();
            }
        }
        [Fact]
        public void Test_Create_POST_ValidModelState()
        {
            // Arrange
            var c = new Company()
            {
                Id = 4,
                Name = "Test Four",

            };

            var _mockRepo = new Mock<ICRepo<Company>>();
            //_mockRepo.Setup(repo => repo.Add(It.IsAny<Company>()))
                //.Returns(Task.CompletedTask)
               //.Verifiable();
            var _dbcontext = new DbContextOptionsBuilder<CDBContext>();
            _dbcontext.UseSqlServer("Server=FMS-SW07\\SQLEXPRESS;Database=Compa;Trusted_Connection=True;MultipleActiveResultSets=true");
            var mockset = new Mock<DbSet<Company>>();
            var mockContext = new Mock<CDBContext>(_dbcontext);

            using (var context = new CDBContext(_dbcontext.Options))
            {
                var controller = new CompanyController(_mockRepo.Object, context);

                // Act
                var result = controller.Create(c);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Null(redirectToActionResult.ControllerName);
                Assert.Equal("Index", redirectToActionResult.ActionName);
                _mockRepo.Verify();

            }
        }

        [Fact]
        public void Test_Read_GET_ReturnsViewResult_WithAListOfCompanies()
        {
            // Arrange
            var _mockRepo = new Mock<ICRepo<Company>>();
            _mockRepo.Setup(repo => repo.GetAll()).Returns(GetCompaniesData());
            var _dbcontext = new DbContextOptionsBuilder<CDBContext>();
            _dbcontext.UseSqlServer("Server=FMS-SW07\\SQLEXPRESS;Database=Compa;Trusted_Connection=True;MultipleActiveResultSets=true");
            var mockset = new Mock<DbSet<Company>>();
            var mockContext = new Mock<CDBContext>(_dbcontext);

            using (var context = new CDBContext(_dbcontext.Options))
            {
                var _controller = new CompanyController(_mockRepo.Object, context);

                // Act
                var result =  _controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<Company>>(viewResult.ViewData.Model);
                Assert.Equal(3, model.Count());
            }
        }
        private static List<Company> GetCompaniesData()
        {
            var c = new List<Company>();
            c.Add(new Company()
            {
                Id = 1,
                Name = "Test One",

            });
            c.Add(new Company()
            {
                Id = 2,
                Name = "Test Two",
  
            });
            c.Add(new Company()
            {
                Id = 3,
                Name = "Test Three",

            });
            return c;
        }
        [Fact]
        public void Test_Update_GET_ReturnsViewResult_WithSingleRegistration()
        {
            // Arrange
            int testId = 2;
            string testName = "test name";


            var _mockRepo = new Mock<ICRepo<Company>>();
            _mockRepo.Setup(repo => repo.GetById(testId)).Returns(GetTestCompany());
            var _dbcontext = new DbContextOptionsBuilder<CDBContext>();
            _dbcontext.UseSqlServer("Server=FMS-SW07\\SQLEXPRESS;Database=Compa;Trusted_Connection=True;MultipleActiveResultSets=true");
            var mockset = new Mock<DbSet<Company>>();
            var mockContext = new Mock<CDBContext>(_dbcontext);

            using (var context = new CDBContext(_dbcontext.Options))
            {
                var _controller = new CompanyController(_mockRepo.Object, context);

                // Act
                var result = _controller.Edit(testId);

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<Company>(viewResult.ViewData.Model);
                Assert.Equal(testId, model.Id);
                Assert.Equal(testName, model.Name);
            }
        }

        [Fact]
        public void Test_Update_POST_ReturnsViewResult_InValidModelState()
        {
            // Arrange
            int testId = 2;
            Company c = GetTestCompany();

            var _mockRepo = new Mock<ICRepo<Company>>();
            _mockRepo.Setup(repo => repo.GetById(testId)).Returns(GetTestCompany());
            var _dbcontext = new DbContextOptionsBuilder<CDBContext>();
            _dbcontext.UseSqlServer("Server=FMS-SW07\\SQLEXPRESS;Database=Compa;Trusted_Connection=True;MultipleActiveResultSets=true");
            var mockset = new Mock<DbSet<Company>>();
            var mockContext = new Mock<CDBContext>(_dbcontext);

            using (var context = new CDBContext(_dbcontext.Options))
            {
                var _controller = new CompanyController(_mockRepo.Object,context);
                _controller.ModelState.AddModelError("Name", "Name is required");

                // Act
                var result = _controller.Edit(c);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Null(redirectToActionResult.ControllerName);
                Assert.Equal("Index", redirectToActionResult.ActionName);
                _mockRepo.Verify();
            }
        }
        [Fact]
        public void Test_Update_POST_ReturnsViewResult_ValidModelState()
        {
            // Arrange
            int testId = 2;
            var c = new Company()
            {
                Id = 2,
                Name = "Test Two",
            };
            var _mockRepo = new Mock<ICRepo<Company>>();
            _mockRepo.Setup(repo => repo.GetById(testId)).Returns(GetTestCompany());
            var _dbcontext = new DbContextOptionsBuilder<CDBContext>();
            _dbcontext.UseSqlServer("Server=FMS-SW07\\SQLEXPRESS;Database=Compa;Trusted_Connection=True;MultipleActiveResultSets=true");
            var mockset = new Mock<DbSet<Company>>();
            var mockContext = new Mock<CDBContext>(_dbcontext);

            using (var context = new CDBContext(_dbcontext.Options))
            {
                var _controller = new CompanyController(_mockRepo.Object,context);

                //_mockRepo.Setup(repo => repo.Update(It.IsAny<Company>()))
                       //.Returns(Task.CompletedTask)
                       //.Verifiable();

                // Act
                var result = _controller.Edit(c);

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<Company>(viewResult.ViewData.Model);
                Assert.Equal(testId, model.Id);
                Assert.Equal(c.Name, model.Name);

                _mockRepo.Verify();
            }
        }
        private Company GetTestCompany()
        {
            var c = new Company()
            {
                Id = 2,
                Name = "test name",

            };
            return c;
        }

        [Fact]
        public void Test_Delete_POST_ReturnsViewResult_InValidModelState()
        {
            // Arrange
            int testId = 2;

            var _mockRepo = new Mock<ICRepo<Company>>();
            //_mockRepo.Setup(repo => repo.Delete(It.IsAny<int>()))
                   //.Returns(Task.CompletedTask)
                   //.Verifiable();

            var _dbcontext = new DbContextOptionsBuilder<CDBContext>();
            _dbcontext.UseSqlServer("Server=FMS-SW07\\SQLEXPRESS;Database=Compa;Trusted_Connection=True;MultipleActiveResultSets=true");
            var mockset = new Mock<DbSet<Company>>();
            var mockContext = new Mock<CDBContext>(_dbcontext);

            using (var context = new CDBContext(_dbcontext.Options))
            {
                var _controller = new CompanyController(_mockRepo.Object, context);


                // Act
                var result = _controller.Delete(testId);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Null(redirectToActionResult.ControllerName);
                Assert.Equal("Index", redirectToActionResult.ActionName);
                _mockRepo.Verify();
            }
        }
    }
}
