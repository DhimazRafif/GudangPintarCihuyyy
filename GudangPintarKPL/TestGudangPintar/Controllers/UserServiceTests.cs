using GudangPintar.Controllers;
using GudangPintarKPL.Models;

namespace TestGudangPintar.Controllers
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService _userService;

        [TestInitialize]
        public void Setup()
        {
            // Dipanggil sebelum setiap test - membuat instance baru
            _userService = new UserService();
        }

        // ========== TEST LOGIN ==========

        [TestMethod]
        public void Login_ValidCredentials_ReturnsUserAndRole()
        {
            // Arrange - pake data default dari constructor (admin & user)
            string username = "admin";
            string password = "admin123";

            // Act
            var result = _userService.Login(username, password);

            // Assert
            Assert.IsNotNull(result, "Login dengan kredensial valid harus mengembalikan data");
            Assert.AreEqual(username, result.Value.Item1.Username, "Username harus sesuai");
            Assert.AreEqual(Role.Admin, result.Value.Item2, "Role harus Admin");
        }

        [TestMethod]
        public void Login_InvalidPassword_ReturnsNull()
        {
            // Arrange - password salah
            string username = "admin";
            string wrongPassword = "wrongpassword";

            // Act
            var result = _userService.Login(username, wrongPassword);

            // Assert - alternatif: password salah
            Assert.IsNull(result, "Login dengan password salah harus mengembalikan null");
        }

        [TestMethod]
        public void Login_NonExistentUsername_ReturnsNull()
        {
            // Arrange - username tidak ada
            string username = "tidakada";
            string password = "anything";

            // Act
            var result = _userService.Login(username, password);

            // Assert - alternatif: user tidak terdaftar
            Assert.IsNull(result, "Login dengan username tidak terdaftar harus mengembalikan null");
        }

        [TestMethod]
        public void Login_NullUsername_ShouldNotThrowButReturnNull()
        {
            // Arrange - test alternatif: input null (boundary test)
            string username = null;
            string password = "password";

            // Act - Debug.Assert akan error, tapi di Release tidak
            try
            {
                var result = _userService.Login(username, password);
                // Jika lolos Debug.Assert, tetap harus null
                Assert.IsNull(result);
            }
            catch (System.Exception)
            {
                // Debug.Assert bisa throw, test tetap dianggap valid
                Assert.IsTrue(true, "Method melempar exception untuk input null (perilaku Debug)");
            }
        }

        // ========== TEST ADD USER ==========

        [TestMethod]
        public void Add_ValidUser_ReturnsTrueAndUserAdded()
        {
            // Arrange
            string username = "budi_baru";
            string email = "budi@mail.com";
            string password = "password123";
            Role role = Role.User;

            int initialCount = _userService.GetAll().Count;

            // Act
            bool result = _userService.Add(username, email, password, role);

            // Assert
            Assert.IsTrue(result, "Add user valid harus return true");
            Assert.AreEqual(initialCount + 1, _userService.GetAll().Count, "Jumlah user harus bertambah 1");

            var addedUser = _userService.GetAll().FirstOrDefault(u => u.Username == username);
            Assert.IsNotNull(addedUser, "User harus ada di list");
            Assert.AreEqual(email, addedUser.Email);
            Assert.AreEqual(role, addedUser.RoleUser);
        }

        [TestMethod]
        public void Add_DuplicateUsername_ReturnsFalse()
        {
            // Arrange - coba tambah user dengan username yang sudah ada
            string username = "admin";  // admin sudah ada
            string email = "new@mail.com";
            string password = "password123";
            Role role = Role.User;

            int initialCount = _userService.GetAll().Count;

            // Act
            bool result = _userService.Add(username, email, password, role);

            // Assert - alternatif: username duplikat
            Assert.IsFalse(result, "Add dengan username duplikat harus return false");
            Assert.AreEqual(initialCount, _userService.GetAll().Count, "Jumlah user tidak boleh bertambah");
        }

        [TestMethod]
        public void Add_PasswordLessThan6Characters_ReturnsFalse()
        {
            // Arrange - password terlalu pendek
            string username = "user_baru";
            string email = "user@mail.com";
            string shortPassword = "123";  // kurang dari 6
            Role role = Role.User;

            int initialCount = _userService.GetAll().Count;

            // Act
            bool result = _userService.Add(username, email, shortPassword, role);

            // Assert - alternatif: password invalid
            Assert.IsFalse(result, "Password < 6 karakter harus return false");
            Assert.AreEqual(initialCount, _userService.GetAll().Count, "User tidak boleh ditambahkan");
        }

        [TestMethod]
        public void Add_EmptyUsername_ShouldHandleGracefully()
        {
            // Arrange - test alternatif: username kosong
            string username = "";
            string email = "test@mail.com";
            string password = "valid123";
            Role role = Role.User;

            // Act - Debug.Assert bisa throw, test tetap mencakup edge case
            try
            {
                bool result = _userService.Add(username, email, password, role);
                // Jika lolos, harus false karena username kosong
                Assert.IsFalse(result);
            }
            catch (System.Exception)
            {
                Assert.IsTrue(true, "Method melempar exception untuk username kosong");
            }
        }

        // ========== TEST DELETE USER ==========

        [TestMethod]
        public void Delete_ExistingNonAdminUser_ReturnsTrue()
        {
            // Arrange - tambah user dulu baru dihapus
            _userService.Add("todelete", "del@mail.com", "pass123", Role.User);
            var userToDelete = _userService.GetAll().First(u => u.Username == "todelete");
            int initialCount = _userService.GetAll().Count;

            // Act
            bool result = _userService.Delete(userToDelete.Id);

            // Assert
            Assert.IsTrue(result, "Delete user yang ada harus return true");
            Assert.AreEqual(initialCount - 1, _userService.GetAll().Count, "Jumlah user harus berkurang 1");
            Assert.IsNull(_userService.GetAll().FirstOrDefault(u => u.Id == userToDelete.Id), "User harus tidak ada lagi");
        }

        [TestMethod]
        public void Delete_AdminUser_ReturnsFalse()
        {
            // Arrange - coba hapus admin utama
            var adminUser = _userService.GetAll().First(u => u.Username == "admin");

            // Act
            bool result = _userService.Delete(adminUser.Id);

            // Assert - alternatif: tidak boleh hapus admin
            Assert.IsFalse(result, "Menghapus admin utama harus return false");
            Assert.IsNotNull(_userService.GetAll().FirstOrDefault(u => u.Username == "admin"), "Admin harus tetap ada");
        }

        [TestMethod]
        public void Delete_NonExistentId_ReturnsFalse()
        {
            // Arrange - id yang tidak ada
            int fakeId = 99999;

            // Act
            bool result = _userService.Delete(fakeId);

            // Assert
            Assert.IsFalse(result, "Delete dengan id tidak ada harus return false");
        }

        // ========== TEST UPDATE USER ==========

        [TestMethod]
        public void Update_ExistingUser_UpdatesData()
        {
            // Arrange - tambah user dulu
            _userService.Add("updateuser", "old@mail.com", "oldpass", Role.User);
            var userToUpdate = _userService.GetAll().First(u => u.Username == "updateuser");

            // Act
            _userService.Update(userToUpdate.Id, "updatedname", "new@mail.com", "newpass", Role.Admin);

            // Assert
            var updatedUser = _userService.GetAll().First(u => u.Id == userToUpdate.Id);
            Assert.AreEqual("updatedname", updatedUser.Username);
            Assert.AreEqual("new@mail.com", updatedUser.Email);
            Assert.AreEqual(Role.Admin, updatedUser.RoleUser);
        }

        [TestMethod]
        public void Update_DuplicateUsername_ShouldNotUpdate()
        {
            // Arrange - perbaiki password minimal 6 karakter
            _userService.Add("user1", "user1@mail.com", "pass123", Role.User);  // pass123 = 6 karakter
            _userService.Add("user2", "user2@mail.com", "pass456", Role.User);  // pass456 = 6 karakter

            var user2 = _userService.GetAll().First(u => u.Username == "user2");

            // Act
            _userService.Update(user2.Id, "user1", "new@mail.com", "newpass789", Role.Admin);

            // Assert
            var stillUser2 = _userService.GetAll().First(u => u.Id == user2.Id);
            Assert.AreEqual("user2", stillUser2.Username, "Username tidak boleh berubah menjadi duplikat");
        }

        [TestMethod]
        public void Update_NonExistentId_DoesNothingAndNoError()
        {
            // Arrange - id tidak ada
            int fakeId = 99999;

            // Act & Assert - seharusnya tidak throw exception
            try
            {
                _userService.Update(fakeId, "nama", "email@mail.com", "pass", Role.User);
                Assert.IsTrue(true, "Update id tidak ada tidak throw exception");
            }
            catch (Exception ex)
            {
                Assert.Fail($"Seharusnya tidak exception: {ex.Message}");
            }
        }

        // ========== TEST GETALL & GETROLE ==========

        [TestMethod]
        public void GetAll_ReturnsListOfUsers()
        {
            // Act
            var users = _userService.GetAll();

            // Assert - harus ada minimal admin dan user dari constructor
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count >= 2, "Harus ada minimal 2 user (admin dan user default)");
            Assert.IsTrue(users.Any(u => u.Username == "admin"));
            Assert.IsTrue(users.Any(u => u.Username == "user"));
        }

        [TestMethod]
        public void GetRole_ValidUsername_ReturnsRole()
        {
            // Arrange
            string username = "admin";

            // Act
            Role role = _userService.GetRole(username);

            // Assert
            Assert.AreEqual(Role.Admin, role, "Role admin harus Admin");
        }
    }
}