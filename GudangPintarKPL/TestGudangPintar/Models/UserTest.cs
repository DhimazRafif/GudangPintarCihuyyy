using GudangPintarKPL.Models;

namespace TestGudangPintar.Models
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void GetHeader_MengembalikanArrayKolomYangBenar()
        {
            // Arrange
            string[] expected = { "ID", "Username", "Email", "Role" };

            // Act
            string[] actual = User.getHeader();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetHeader_MemilikiJumlahKolom4()
        {
            // Act
            string[] header = User.getHeader();

            // Assert
            Assert.AreEqual(4, header.Length);
        }

        [TestMethod]
        public void GetRowData_MengembalikanDataUserDalamArray()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Username = "budi",
                Email = "budi@mail.com",
                RoleUser = Role.Admin
            };
            string[] expected = { "1", "budi", "budi@mail.com", "Admin" };

            // Act
            string[] actual = user.getRowData();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetRowData_SetelahPropertiDiubah_ArrayBerubah()
        {
            // Arrange
            var user = new User
            {
                Id = 2,
                Username = "ani",
                Email = "ani@mail.com",
                RoleUser = Role.User
            };

            // Act
            user.Username = "ani_updated";
            user.Email = "ani@baru.com";
            string[] actual = user.getRowData();

            // Assert
            Assert.AreEqual("ani_updated", actual[1]);
            Assert.AreEqual("ani@baru.com", actual[2]);
        }

        [TestMethod]
        public void GetRowData_IdNegatif_TetapBekerja()
        {
            // Arrange
            var user = new User
            {
                Id = -1,
                Username = "negatif",
                Email = "negatif@mail.com",
                RoleUser = Role.User
            };

            // Act
            string[] actual = user.getRowData();

            // Assert - Tidak error walau ID negatif
            Assert.AreEqual("-1", actual[0]);
        }
    }
}