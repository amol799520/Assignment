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
    public class MobiileControllerTest
    {
       
        MobileController _MobiileController;
        IMobileService _MobileService;

        public MobiileControllerTest()
        {
            _MobileService = new MobileService();
            _MobiileController = new MobileController(_MobileService);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //act
            var okResult = _MobiileController.GetAllMobile();
            //assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            var count = _MobileService.GetAllMobile().Count();
            //act
            var okResult = _MobiileController.GetAllMobile().Result as OkObjectResult;
            //assert
            var item = Assert.IsType<List<Mobile>>(okResult.Value);
            Assert.Equal(count, item.Count);
        }

        [Fact]  
        public void GetById_UnknowMobileIdPasse_ReturnsNotFoundResult()
        {
            //act
            var notFoundResult = _MobiileController.GetMobileById(int.MaxValue);
            //assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingMobileId_ReturnsOkResult()
        {
            //act
            var okResult = _MobiileController.GetMobileById(3);
            //assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingMobileIdd_ReturnsRightItem()
        {
            //act
            var okResult = _MobiileController.GetMobileById(3).Result as OkObjectResult;
            //arrange
            var item = Assert.IsType<Mobile>(okResult.Value);
        }

       
        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Mobile testItem = new Mobile()
            {
                Name = "apple",
                ActualPrice = 15000,
                CompanyName = "xyz",
                Description = "xxx",
                ImeiNumber = "1234566",
                LauchDate = System.DateTime.Now,
                UpatedDate = System.DateTime.Now,
                CraetedDate = System.DateTime.Now
            };
            // Act
            var createdResponse = _MobiileController.AddMobile(testItem);
            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
           Mobile testItem = new Mobile()
            {
                Name = "apple",
                ActualPrice = 15000,
                CompanyName = "xyz",
                Description = "xxx",
                ImeiNumber = "1234566",
                LauchDate = System.DateTime.Now,
                UpatedDate = System.DateTime.Now,
                CraetedDate = System.DateTime.Now
            };
            // Act
            var createdResponse = _MobiileController.AddMobile(testItem) as CreatedAtActionResult;
            
            var item = createdResponse.Value as Mobile;
            // Assert
            Assert.IsType<Mobile>(item);
            Assert.Equal("apple", item.Name);
        }

        [Fact]
        public void Remove_NotExistingMobileIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            int id = int.MaxValue;
            // Act
            var badResponse = _MobiileController.DeleteMobile(id);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }
        [Fact]
        public void Remove_ExistingMobileIdPassed_ReturnsOkResult()
        {
            // Arrange
            var id =  3;
            // Act
            var okResponse = _MobiileController.DeleteMobile(id); 
            // Assert
            Assert.IsType<OkResult>(okResponse);
        }
        [Fact]
        public void Remove_ExistingMobileIdPassed_RemovesOneItem()
        {
            // Arrange

            int count = _MobileService.GetAllMobile().Count();
            int id = 4;
            // Act
            var okResponse = _MobiileController.DeleteMobile(id);
            // Assert
         
            Assert.Equal(count, _MobileService.GetAllMobile().Count());
        }

    }
}
