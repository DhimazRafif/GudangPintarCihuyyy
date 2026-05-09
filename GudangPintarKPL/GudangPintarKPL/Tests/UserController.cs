using GudangPintar.Controllers;
using GudangPintarKPL.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GudangPintarKPL.Tests;

public class UserControllerTests
{
    [Theory]
    [InlineData("budi123", "budi@email.com", "pass123", Role.Admin)]
    [InlineData("siti456", "siti@email.com", "pass456", Role.User)]
    [InlineData("admin", "admin@test.com", "admin123", Role.Admin)]
    public void Register_ShouldReturnOk_WhenValidData(
        string username, string email, string password, Role role)
    {
        // Arrange
        var mockService = new Mock<UserService>();
        var controller = new UserController(mockService.Object);
        var request = new RegisterRequest
        {
            Username = username,
            Email = email,
            Password = password,
            Role = role
        };

        // Act
        var result = controller.Add(request);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Theory]
    [InlineData("", "test@email.com", "pass", Role.User)]  // username kosong
    [InlineData("user", "", "pass", Role.User)]            // email kosong
    [InlineData("user", "email@test.com", "", Role.User)]  // password kosong
    public void Register_ShouldReturnBadRequest_WhenInvalidData(
        string username, string email, string password, Role role)
    {
        // Arrange
        var mockService = new Mock<UserService>();
        var controller = new UserController(mockService.Object);
        var request = new RegisterRequest
        {
            Username = username,
            Email = email,
            Password = password,
            Role = role
        };

        // Act
        var result = controller.Add(request);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}