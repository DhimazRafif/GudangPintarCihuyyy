using GudangPintar.Controllers;
using GudangPintar.Model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/history")]
public class HistoryController : ControllerBase
{
    private readonly HistoryService s;
    public HistoryController(HistoryService s) { this.s = s; }

    [HttpGet] public IActionResult Get() => Ok(s.GetAll());
}