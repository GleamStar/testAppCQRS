using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Services.Contracts;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace UnitTests
{
    public class ClassesControllerTest
    {
        private Mock<IClassesService> _classesService;
        private ClassesContoller _controller;

        [SetUp]
        protected void SetUp()
        {
            _classesService = new Mock<IClassesService>();
            _controller = new ClassesContoller(_classesService.Object);
        }

        [Test]
        public async Task GetClasses_ShouldSuccess()
        {
            // Arrange
            var responseResult = new List<ClassDto>()
            {
                new ClassDto()
                {
                    ClassId = Guid.NewGuid(),
                    Location = "test",
                    Name = "test",
                    Teacher ="test"
                }
            };
            _classesService.Setup(x => x.GetClassesAsync()).ReturnsAsync(responseResult);

            // Act
            var result = await _controller.GetClasses();

            // Assert

            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var classes = okResult.Value.Should().BeAssignableTo<IEnumerable<ClassDto>>().Subject;

            classes.Count().Should().Be(1);
        }

        [Test]
        public async Task CreateStudent_ShouldSucceded()
        {
            // Arrange
            var responseResult = Guid.NewGuid();
            var upsertDto = new UpsertClassDto()
            {
                Location = "test",
                Name = "test",
                Teacher = "Mr Jones"
            };
            _classesService.Setup(x => x.AddClassAsync(It.IsAny<UpsertClassDto>())).ReturnsAsync(responseResult);

            // Act
            var result = await _controller.CreateClass(upsertDto);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var guid = okResult.Value.Should().BeAssignableTo<Guid>().Subject;
            NUnit.Framework.Assert.AreEqual(responseResult, guid);
        }
    }
}
