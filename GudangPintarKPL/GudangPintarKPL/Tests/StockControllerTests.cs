using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using GudangPintar.Controllers;
using GudangPintar.Model;

namespace GudangPintar.Tests;

public class StockControllerTests
{
    private readonly Mock<StockService> _mockService;
    private readonly StockController _controller;

    public StockControllerTests()
    {
        _mockService = new Mock<StockService>();
        _controller = new StockController(_mockService.Object);
    }

    // PARAMETERIZED TEST menggunakan Theory + InlineData
    [Theory]
    [InlineData("Laptop", 5, 100, "Elektronik")]
    [InlineData("Mouse", 10, 50, "Aksesoris")]
    [InlineData("Keyboard", 0, 30, "Aksesoris")]
    [InlineData(null, 1, 10, null)]
    public void GetFiltered_ShouldReturnOk_WithValidParameters(
        string nama, int minStok, int maxStok, string kategori)
    {
        // Act
        var result = _controller.GetFiltered(nama, minStok, maxStok, kategori);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Theory]
    [InlineData(1, 10)]    // ID valid, stok positif
    [InlineData(2, 0)]     // ID valid, stok 0
    [InlineData(99, 5)]    // ID tidak ada
    public void UpdateStock_ShouldReturnAppropriateResponse(int id, int jumlah)
    {
        // Setup mock behavior
        if (id == 99)
            _mockService.Setup(s => s.UpdateStock(id, jumlah)).Returns(false);
        else
            _mockService.Setup(s => s.UpdateStock(id, jumlah)).Returns(true);

        // Act
        var result = _controller.UpdateStock(id, jumlah);

        // Assert
        if (id == 99)
            Assert.IsType<NotFoundObjectResult>(result);
        else
            Assert.IsType<OkObjectResult>(result);
    }
}