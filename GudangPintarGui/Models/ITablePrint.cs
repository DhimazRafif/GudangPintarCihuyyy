namespace GudangPintarGui.Models
{
    /// <summary>
    /// Interface untuk class yang bisa ditampilkan sebagai baris tabel.
    /// Setiap implementor wajib menyediakan data baris dan header kolom.
    /// </summary>
    public interface ITablePrint
    {
        string[] GetRowData();
        string[] GetHeader();
    }
}