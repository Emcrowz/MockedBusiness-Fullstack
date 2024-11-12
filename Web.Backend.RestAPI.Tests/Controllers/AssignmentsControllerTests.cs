//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using Shouldly;
//using Web.Backend.Domain.DTO.Education;
//using Web.Backend.Domain.Repositories.Contracts;
//using Web.Backend.RestAPI.Controllers;

//namespace Web.Backend.RestAPI.Tests.Controllers;

//public class AssignmentsControllerTests
//{
//    private readonly Mock<IAssignmentsRepository> _repository;
//    private readonly AssignmentsController _controller;

//    public AssignmentsControllerTests()
//    {
//        _repository = new();
//        _controller = new(_repository.Object);
//    }

//    [Fact]
//    public async Task Get_GetAssignmentAsync_Returns_Ok_All_Items()
//    {
//        // Act
//        var methodResult = await _controller.GetAssignmentAsync();

//        // Assert
//        var response = Assert.IsType<ActionResult<IEnumerable<AssignmentReadDto>>>(methodResult);
//    }

//    [Fact]
//    public async Task Get_GetAssignmentAsync_Returns_Ok_Item()
//    {
//        // Assert
//        string reqId = Guid.NewGuid().ToString();

//        // Act
//        var methodResult = await _controller.GetAssignmentAsync(reqId);

//        // Assert
//        var response = Assert.IsType<ActionResult<AssignmentReadDto>>(methodResult);
//    }
//}
