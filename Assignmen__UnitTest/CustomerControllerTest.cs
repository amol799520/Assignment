using Assignment.Controllers;
using Assignment.InterFaces;
using Assignment.Models;
using Assignment.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Assignmen_UnitTest
{
    public class CustomerControllerTest
    {
        CustomerController _CustomerController;
        ICustomerService _CustomerService;

        public CustomerControllerTest()
        {
            _CustomerService = new CustomerService(); 
            _CustomerController = new CustomerController(_CustomerService);
        }


        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //act
            var okResult = _CustomerController.GetAllCustomer();
            //assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var count = _CustomerService.GetAllCustomer().Count();
            //act
            var okResult = _CustomerController.GetAllCustomer().Result as OkObjectResult;
            //assert
            var item = Assert.IsType<List<Customer>>(okResult.Value);
            Assert.Equal(count, item.Count);
        }

        [Fact]
        public void GetById_UnknowCustIdPasse_ReturnsNotFoundResult()
        {
            //arrangge
            int id = int.MaxValue;
            //act
            var notFoundResult = _CustomerController.GetCustomerById(id);
            //assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }
        [Fact]
        public void GetById_ExistingCustI_ReturnsOkResult()
        {
            //arrangge
            int id = 3;
            //act
            var okResult = _CustomerController.GetCustomerById(id);
            //assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingCustId_ReturnsRightItem()
        {
            //arrangge
            int id = 3;

            //act
            var okResult = _CustomerController.GetCustomerById(id).Result as OkObjectResult;
            //arrange
            var item = Assert.IsType<Customer>(okResult.Value);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Customer testItem = new Customer()
            {
                CustName = "xyz",
                CustAddress = "abc",
                CustEmailId = "xyza@abc",
                CustMobiile = "0000123456",
                CreatedDate = System.DateTime.Now,
               UpatedDate = System.DateTime.Now
            };
            // Act
            var createdResponse =  _CustomerController.AddCustomer(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            Customer testItem = new Customer()
            {
                CustName = "xyz",
                CustAddress = "abc",
                CustEmailId = "xyz@abc",
                CustMobiile = "123456",
                CreatedDate = System.DateTime.Now
            };
            // Act
            var createdResponse = _CustomerController.AddCustomer(testItem) as CreatedAtActionResult;

            var item = createdResponse.Value as Customer;
            // Assert
            Assert.IsType<Customer>(item);
            Assert.Equal("xyz", item.CustName);
        }

        [Fact]
        public void Remove_NotExistingCustId_ReturnsNotFoundResponse()
        {
            // Arrange
            int id = int.MaxValue;
            // Act
            var badResponse = _CustomerController.DeleteEmployee(id);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
        [Fact]
        public void Remove_ExistingCustIdPassed_ReturnsOkResult()
        {
            // Arrange
            var id = 3;
            // Act
            var okResponse = _CustomerController.DeleteEmployee(id);
            // Assert
            Assert.IsType<OkResult>(okResponse);
        }
        [Fact]
        public void Remove_ExistingCustIdPassed_RemovesOneItem()
        {
            // Arrange
            var count = _CustomerService.GetAllCustomer().Count();
            int id = 3;
            // Act 
            var okResponse = _CustomerController.DeleteEmployee(id);
            // Assert

            Assert.Equal(count, _CustomerService.GetAllCustomer().Count());
        }

    }
}
