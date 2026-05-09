using GudangPintar.Controllers;
using GudangPintar.Model;
using GudangPintarKPL.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/stock")]
public class StockController : ControllerBase
{
    private readonly StockService s;
    public StockController(StockService s) { this.s = s; }

    [HttpGet] public IActionResult Get() => Ok(s.GetAll());
    [HttpPost] public IActionResult Post(Stock x) { s.Add(x); return Ok(); }

    // PARAMETERIZED QUERY: GET dengan filter
    [HttpGet("filter")]
    public IActionResult GetFiltered(
        [FromQuery] string? nama = null,
        [FromQuery] int? minStok = null,
        [FromQuery] int? maxStok = null,
        [FromQuery] string? kategori = null)
    {
        // Parameterized: gunakan object anonymous atau DTO
        var parameters = new { Nama = nama, MinStok = minStok, MaxStok = maxStok, Kategori = kategori };
        var result = s.GetFiltered(parameters);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post(Stock x) { s.Add(x); return Ok(); }

    // PARAMETERIZED QUERY: Update stok dengan parameter aman
    [HttpPut("updatestock/{id}")]
    public IActionResult UpdateStock(int id, [FromBody] int jumlah)
    {
        if (jumlah < 0) return BadRequest("Jumlah tidak boleh negatif");
        var result = s.UpdateStock(id, jumlah);
        return result ? Ok("Stok berhasil diupdate") : NotFound("Stock tidak ditemukan");
    }

}