using GudangPintar.Controllers;
using GudangPintarKPL.Controllers; 
using GudangPintarKPL.Models;
using Microsoft.AspNetCore.Mvc;
using static UserController;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService s;
    public UserController(UserService s) { this.s = s; }

    // DTO untuk Register, Login, dan Update
    public class RegisterDTO
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
    public class LoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class UpdateDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(s.GetAll());

    [HttpPost("register")]
    public IActionResult Add([FromBody] RegisterDTO dto)
    {
        s.Add(dto.Username, dto.Email, dto.Password, dto.Role);
        return Ok(new { message = "User berhasil ditambahkan" });
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO dto)
    {
        var result = s.Login(dto.Username, dto.Password);
        if (result == null) return Unauthorized("Username atau password salah");
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        s.Delete(id);
        return Ok(new { message = "User berhasil dihapus" });
    }
    [HttpPut("update/{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateDTO dto)
    {
        if (id <= 0) return BadRequest(new { message = "Id tidak valid" });

        var existing = s.GetAll().FirstOrDefault(u => u.Id == id);
        if (existing == null) return NotFound(new { message = "User tidak ditemukan" });

        s.Update(id, dto.Username, dto.Email, dto.Password, dto.Role);

        var updated = s.GetAll().FirstOrDefault(u => u.Id == id);
        return Ok(new { message = "User berhasil diupdate", user = updated });
    }
}