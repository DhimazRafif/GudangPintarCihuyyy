using GudangPintarKPL.Models;
using GudangPintarKPL.Printer;


namespace TestGudangPintar.Printer
{
    [TestClass]
    public sealed class TestTablePrinter
    {
        [TestMethod]
        public void Print_DataAndFormatCorrectly()
        {
            var DummyData = new List<User>
            {
                new User { Id = 1, Username = "Tester", Email = "tester@gmail.com", RoleUser = Role.Admin}
            };

            using var keyboardPalsu = new StringReader("\n");
            Console.SetIn(keyboardPalsu);

            using var monitorPalsu = new StringWriter();
            Console.SetOut(monitorPalsu);

            string judul = "Test Data Akun";

            TablePrinter.Print(DummyData, judul);


            var hasilLayar = monitorPalsu.ToString();

            Assert.IsTrue(hasilLayar.Contains("=== TEST DATA AKUN ==="));

            //Test Header
            Assert.IsTrue(hasilLayar.Contains("ID"));
            Assert.IsTrue(hasilLayar.Contains("Username"));
            Assert.IsTrue(hasilLayar.Contains("Email"));
            Assert.IsTrue(hasilLayar.Contains("Role"));

            //TestIsi
            Assert.IsTrue(hasilLayar.Contains("1"));
            Assert.IsTrue(hasilLayar.Contains("tester"));
            Assert.IsTrue(hasilLayar.Contains("tester@gmail.com"));
            Assert.IsTrue(hasilLayar.Contains("Admin"));

            Assert.IsTrue(hasilLayar.Contains("Tekan ENTER untuk kembali"));
        }
    }
}


