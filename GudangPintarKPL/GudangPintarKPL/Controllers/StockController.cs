using GudangPintar.Controllers;
using GudangPintar.Model;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    private readonly StockService s;

    public StockController(StockService s)
    {
        this.s = s;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(s.GetAll());
    }

    [HttpPost("add")]
    public IActionResult Add(
        string namaBarang,
        Category kategori,
        int jumlah,
        double harga)
    {
        var stock = new Stock(
            namaBarang,
            kategori,
            jumlah,
            harga,
            null
        );

        bool berhasil = s.Add(stock);

        if (!berhasil)
        {
            return BadRequest(new
            {
                message = "Gagal menambahkan barang"
            });
        }

        return Ok(new
        {
            message = "Barang berhasil ditambahkan"
        });
    }

    [HttpDelete("{nama}")]
    public IActionResult Delete(string nama)
    {
        bool berhasil = s.Delete(nama);

        if (!berhasil)
        {
            return NotFound(new
            {
                message = "Barang tidak ditemukan"
            });
        }

        return Ok(new
        {
            message = "Barang berhasil dihapus"
        });
    }
}