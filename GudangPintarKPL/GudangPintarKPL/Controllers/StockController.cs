using GudangPintar.Controllers;
using GudangPintar.Model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/stock")]
public class StockController : ControllerBase
{
    private readonly StockService s;
    public StockController(StockService s) { this.s = s; }

    [HttpGet] public IActionResult Get() => Ok(s.GetAll());
    [HttpPost] public IActionResult Post(Stock x) { s.Add(x); return Ok(); }
}