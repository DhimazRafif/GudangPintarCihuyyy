namespace GudangPintarKPL.Models
{
    public interface ITablePrint
    {
        string[] getRowData();

        static abstract string[] getHeader();
    }
}
