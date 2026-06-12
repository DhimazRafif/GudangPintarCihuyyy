namespace GudangPintarKPL.Models
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableHeaderAttribute:Attribute
    {
        public string[] Headers { get; }

        public TableHeaderAttribute(params string[] headers)
        {
            Headers = headers;
        }
    }
}
