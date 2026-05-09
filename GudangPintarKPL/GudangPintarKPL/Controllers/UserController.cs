using GudangPintar.Controllers;
using GudangPintarKPL.Controllers; 
using GudangPintarKPL.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService s;
    public UserController(UserService s) { this.s = s; }

    [HttpGet]
    public IActionResult GetAll() => Ok(s.GetAll());

    [HttpPost("register")]
    public IActionResult Add(string username, string email, string password, Role role)
    {
        s.Add(username, email, password, role);
        return Ok(new { message = "User berhasil ditambahkan" });
    }

    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        var result = s.Login(username, password);
        if (result == null) return Unauthorized("Username atau password salah");
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        s.Delete(id);
        return Ok(new { message = "User berhasil dihapus" });
    }
    [HttpPost("update")]
    public IActionResult Update(int id, string username, string email, string password, Role role)
    {
        s.Update(id, username, email, password, role);
        return Ok(new { message = "User berhasil diupdate" });
    }
}