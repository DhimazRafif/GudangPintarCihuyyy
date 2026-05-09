using GudangPintar.Controllers;
using GudangPintar.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;

namespace GudangPintarKPL.Tests;

public class HistoryControllerTests
{
    private readonly Mock<HistoryService> _mockService;
    private readonly HistoryController _controller;

    public HistoryControllerTests()
    {
        _mockService = new Mock<HistoryService>();
        _controller = new HistoryController(_mockService.Object);
    }

    // ========== PARAMETERIZED TEST UNTUK GET BY DATE RANGE ==========
    [Theory]
    [InlineData("2024-01-01", "2024-12-31")]
    [InlineData("2024-06-01", "2024-06-30")]
    [InlineData(null, "2024-12-31")]      // hanya endDate
    [InlineData("2024-01-01", null)]      // hanya startDate
    [InlineData(null, null)]               // kedua null
    public void GetByDateRange_ShouldReturnOk_WhenCalled(DateTime? start, DateTime? end)
    {
        // Arrange
        var expectedHistory = new List<StockHistory>();
        _mockService.Setup(s => s.GetByDateRange(start, end)).Returns(expectedHistory);

        // Act
        var result = _controller.GetByDateRange(start, end);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        _mockService.Verify(s => s.GetByDateRange(start, end), Times.Once);
    }

    // ========== PARAMETERIZED TEST UNTUK GET BY STOCK ID ==========
    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(99)]
    [InlineData(0)]
    public void GetByStockId_ShouldReturnOk_WhenCalled(int stockId)
    {
        // Arrange
        var expectedHistory = new List<StockHistory>();
        _mockService.Setup(s => s.GetByStockId(stockId)).Returns(expectedHistory);

        // Act
        var result = _controller.GetByStockId(stockId);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        _mockService.Verify(s => s.GetByStockId(stockId), Times.Once);
    }

    // ========== TEST UNTUK GET ALL ==========
    [Fact]
    public void Get_ShouldReturnOk_WithListOfHistory()
    {
        // Arrange
        var expectedHistory = new List<StockHistory>();
        _mockService.Setup(s => s.GetAll()).Returns(expectedHistory);

        // Act
        var result = _controller.Get();

        // Assert
        Assert.IsType<OkObjectResult>(result);
        _mockService.Verify(s => s.GetAll(), Times.Once);
    }

    // ========== PARAMETERIZED TEST DENGAN MULTIPLE COMPLEX SCENARIO ==========
    [Theory]
    [MemberData(nameof(GetDateRangeTestData))]
    public void GetByDateRange_ShouldHandleVariousDateScenarios(
        DateTime? start, DateTime? end, bool expectCallService)
    {
        // Arrange
        if (expectCallService)
        {
            _mockService.Setup(s => s.GetByDateRange(start, end))
                        .Returns(new List<StockHistory>());
        }

        // Act
        var result = _controller.GetByDateRange(start, end);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        if (expectCallService)
        {
            _mockService.Verify(s => s.GetByDateRange(start, end), Times.Once);
        }
    }

    // Data provider untuk test scenario
    public static IEnumerable<object[]> GetDateRangeTestData()
    {
        yield return new object[] { DateTime.Now.AddDays(-30), DateTime.Now, true };
        yield return new object[] { null, DateTime.Now, true };
        yield return new object[] { DateTime.Now.AddDays(-30), null, true };
        yield return new object[] { null, null, true };
    }
}