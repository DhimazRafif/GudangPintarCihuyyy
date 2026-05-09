using GudangPintar.Controllers;
using GudangPintar.Model;
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

    // PARAMETERIZED: Gunakan DTO/Model sebagai parameter, bukan string individu
    [HttpPost("register")]
    public IActionResult Add([FromBody] RegisterRequest request)
    {
        if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            return BadRequest("Username dan password wajib diisi");

        s.Add(request.Username, request.Email, request.Password, request.Role);
        return Ok(new { message = "User berhasil ditambahkan" });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var result = s.Login(request.Username, request.Password);
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
    public IActionResult Update([FromBody] UpdateUserRequest request)
    {
        s.Update(request.Id, request.Username, request.Email, request.Password, request.Role);
        return Ok(new { message = "User berhasil diupdate" });
    }
}

// DTO Classes ( dalam controller ini, malas mindahin)
public class RegisterRequest
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class UpdateUserRequest
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }

}
