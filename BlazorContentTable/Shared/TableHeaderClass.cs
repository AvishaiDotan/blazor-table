using Newtonsoft.Json.Linq;

namespace BlazorContentTable.Shared
{
    public class TableHeaderClass
    {
        public string type { get; set; }
        public string value { get; set; }
        public bool isDirectionModalOpen { get; set; }
    }
}