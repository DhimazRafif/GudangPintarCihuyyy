namespace GudangPintarGui.ControllerGui
{
    // Interface untuk Command Pattern yang digunakan untuk operasi CRUD pada data barang.
    public interface ICommand
    {
        bool Execute(out string message);
    }
}