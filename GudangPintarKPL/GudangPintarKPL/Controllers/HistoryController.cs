using GudangPintar.Controllers;
using GudangPintar.Model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/history")]
public class HistoryController : ControllerBase
{
    private readonly HistoryService s;
    public HistoryController(HistoryService s) { this.s = s; }

    [HttpGet] 
    public IActionResult Get() => Ok(s.GetAll());

    // PARAMETERIZED: Filter history by date range
    [HttpGet("byrange")]
    public IActionResult GetByDateRange(
        [FromQuery] DateTime? startDate,
        [FromQuery] DateTime? endDate)
    {
        var result = s.GetByDateRange(startDate, endDate);
        return Ok(result);
    }

    // PARAMETERIZED: Filter by stock id
    [HttpGet("bystock/{stockId}")]
    public IActionResult GetByStockId(int stockId)
    {
        var result = s.GetByStockId(stockId);
        return Ok(result);
    }
}
