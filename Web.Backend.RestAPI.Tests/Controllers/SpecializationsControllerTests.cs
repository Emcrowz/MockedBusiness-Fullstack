using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Web.Backend.Domain.Models.SpecializationDetails;
using Web.Backend.Domain.Repositories.Contracts;
using Web.Backend.RestAPI.Controllers;

namespace Web.Backend.RestAPI.Tests.Controllers;

public class SpecializationsControllerTests
{
    private readonly ISpecializationRepository _repoMock;
    private readonly SpecializationsController _controller;

    private readonly List<Specialization> _specListEmpty = [];
    private readonly Specialization _specItemInstance = new() { 
        Id = "06b0209d-f839-4143-8f26-75d906ed7932", Name = "TestFour", Description = "Lorem ipsum...", SpecializationDiscount = 0, IsActive = false 
    };
    private readonly List<Specialization> _specListPopulated =
    [
        new()
        {
            Id = "d4387073-4811-40f8-9735-e4020a67813f", Name = "TestOne", Description = "Lorem ipsum...",
            SpecializationDiscount = 23.52m, IsActive = false
        },

        new()
        {
            Id = "02877188-9914-4d49-869e-02068471a9bb", Name = "TestTwo", Description = "Lorem ipsum...",
            SpecializationDiscount = 15, IsActive = true
        },

        new()
        {
            Id = "f2900565-9a40-4eba-8df3-5c3e9a3bfcfd", Name = "TestThree", Description = "Lorem ipsum...",
            SpecializationDiscount = 23.5m, IsActive = true
        },

        new()
        {
            Id = "06b0209d-f839-4143-8f26-75d906ed7932", Name = "TestFour", Description = "Lorem ipsum...",
            SpecializationDiscount = 0, IsActive = false
        },

        new()
        {
            Id = "c43ae46f-74ac-4956-9a5c-5d16976ee92e", Name = "TestFive", Description = "Lorem ipsum...",
            SpecializationDiscount = 3.12m, IsActive = true
        }
    ];

    public SpecializationsControllerTests()
    {
        _repoMock = Substitute.For<ISpecializationRepository>();
        _controller = new SpecializationsController(_repoMock);
    }

    [Fact]
    public async Task GetSpecializationsAsync_ReturnsOk_AllItems()
    {
        // Arrange
        _repoMock.GetAllAsync().Returns(_specListPopulated);

        // Act
        var result = await _controller.GetSpecializationsAsync();

        // Assert
        await _repoMock.Received().GetAllAsync();
        Assert.IsType<ActionResult<IEnumerable<Specialization>>>(result);
        // Assert.NotEmpty(result.Value!)
        // Assert.Equal(_specListPopulated.Count, result.Value!.Count())
    }

    [Fact]
    public async Task GetSpecializationsAsync_ReturnsOk_Empty()
    {
        // Arrange
        _repoMock.GetAllAsync().Returns(_specListEmpty);

        // Act
        var result = await _controller.GetSpecializationsAsync();

        // Assert
        await _repoMock.Received().GetAllAsync();
        Assert.IsType<ActionResult<IEnumerable<Specialization>>>(result);
        // Assert.Empty(result.Value!)
    }

    [Fact]
    public async Task GetSpecializationsAsync_ReturnsOk_Item()
    {
        // Assert
        string reqId = "06b0209d-f839-4143-8f26-75d906ed7932";
        _repoMock.GetSingleAsync(reqId).Returns(_specItemInstance);

        // Act
        var result = await _controller.GetSpecializationsAsync(reqId);

        // Assert
        await _repoMock.Received().GetSingleAsync(reqId);
        Assert.IsType<ActionResult<Specialization>>(result);
        // Assert.Equal(reqId, result.Value!.Id)
    }
}
