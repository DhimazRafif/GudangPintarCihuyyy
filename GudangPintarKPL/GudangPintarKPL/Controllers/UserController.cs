using GudangPintar.Controllers;
using GudangPintarKPL.Controllers; 
using GudangPintarKPL.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using static UserController;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService s;
    public UserController(UserService s) 
    { 
        this.s = s; 
    }
    public class RegisterDto
    {
        [Required(ErrorMessage = "Username wajib diisi")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email wajib diisi")]
        [EmailAddress(ErrorMessage = "Format email tidak valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password wajib diisi")]
        [MinLength(6, ErrorMessage = "Password minimal 6 karakter")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role wajib ditentukan")]
        public Role Role { get; set; }
    }
    public class UpdateUserDto
    {
        [Required(ErrorMessage = "Username wajib diisi")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email wajib diisi")]
        [EmailAddress(ErrorMessage = "Format email tidak valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password wajib diisi")]
        [MinLength(6, ErrorMessage = "Password minimal 6 karakter")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role wajib ditentukan")]
        public Role Role { get; set; }
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(s.GetAll());

    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        var result = s.Login(username, password);
        if (result == null) return Unauthorized(new { message = "Username atau password salah" });
        return Ok(result);
    }

    [HttpPost("register")]
    public IActionResult Add([FromBody] RegisterDto registerDto)
    {
        bool isAdded = s.Add(registerDto.Username, registerDto.Email, registerDto.Password, registerDto.Role);
        if (!isAdded)
        {
            return BadRequest(new { message = "Gagal menambahkan user. Username mungkin sudah digunakan atau password kurang dari 6 karakter." });
        }
        return Ok(new { message = "User berhasil ditambahkan" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool isDeleted = s.Delete(id);
        if (!isDeleted)
        {
            return BadRequest(new { message = "Gagal menghapus user. ID tidak ditemukan atau mencoba menghapus admin utama." });
        }
        return Ok(new { message = "User berhasil dihapus" });
    }

    [HttpPut("update/{id}")]
    public IActionResult Update(int id, [FromBody] UpdateUserDto updateDto)
    {
        var existingUser = s.GetAll().FirstOrDefault(x => x.Id == id);
        if (existingUser == null)
        {
            return NotFound(new { message = $"User dengan ID {id} tidak ditemukan!" });
        }
        bool isUsernameTaken = s.GetAll().Any(x => x.Username == updateDto.Username && x.Id != id);
        if (isUsernameTaken)
        {
            return BadRequest(new { message = "Username sudah digunakan oleh user lain!" });
        }
        s.Update(id, updateDto.Username, updateDto.Email, updateDto.Password, updateDto.Role);
        return Ok(new { message = "User berhasil diupdate" });
    }
}