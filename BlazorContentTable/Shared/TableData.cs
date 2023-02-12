using static BlazorContentTable.Shared.TableHeader;

namespace BlazorContentTable.Shared
{
    public class TableData
    {
        public List<TableHeaderClass> tableHeader { get; set; }
        public List<TableContent> tableContent { get; set; }
    }
}