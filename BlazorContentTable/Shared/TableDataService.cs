
using Newtonsoft.Json;
using static BlazorContentTable.Shared.services.TableDataService;

namespace BlazorContentTable.Shared.services
{
    public class TableDataService
    {
        public TableData tableData { get;set; }

        public TableData GetTableData()
        {
            string json =
            "{" +
            "  \"tableHeader\": [" +
            "    {" +
            "      \"type\": \"text\"," +
            "      \"value\": \"Username\"," +
            "      \"isDirectionModalOpen\": false" +
            "    }," +
            "    {" +
            "      \"type\": \"checkbox\"," +
            "      \"value\": \"Signed\"," +
            "      \"isDirectionModalOpen\": false" +
            "    }," +
            "    {" +
            "      \"type\": \"date\"," +
            "      \"value\": \"Created\"," +
            "      \"isDirectionModalOpen\": false" +
            "    }," +
            "    {" +
            "      \"type\": \"number\"," +
            "      \"value\": \"Age\"," +
            "      \"isDirectionModalOpen\": false" +
            "    }" +
            "  ]," +
            "  \"tableBody\": [" +
            "    {" +
            "      \"id\": 1," +
            "      \"Username\": \"Avi Cohen\"," +
            "      \"Signed\": true," +
            "      \"Created\": \"2018-07-22\"," +
            "      \"Age\": 0" +
            "    }," +
            "    {" +
            "      \"id\": 2," +
            "      \"Username\": \"Sarah Levi\"," +
            "      \"Signed\": false," +
            "      \"Created\": \"2020-03-15\"," +
            "      \"Age\": 28" +
            "    }," +
            "    {" +
            "      \"id\": 3," +
            "      \"Username\": \"David Mizrachi\"," +
            "      \"Signed\": false," +
            "      \"Created\": \"2021-12-31\"," +
            "      \"Age\": 40" +
            "    }" +
            "  ]" +
            "}";
            TableData tableData = JsonConvert.DeserializeObject<TableData>(json);
            this.tableData = tableData;
            return tableData;
        }

        public List<string> GetHeaders()
        {
            List<string> result = new List<string>();

            foreach (TableHeaderClass header in this.tableData.tableHeader)
            {
                result.Add(header.value);
            }
            return result;
        }

        public TableData addNewColumn(int columnIdx, string type)
        {

            Random rand = new Random();
            int randomNumber = rand.Next();
            string propName = "_" + randomNumber.ToString();

            TableHeaderClass newHeader = new TableHeaderClass();
            newHeader.type = type;
            newHeader.value = propName;

            this.tableData.tableHeader.Insert(columnIdx, newHeader);

            dynamic customValue = getCustomValue(type);

            foreach (var item in this.tableData.tableBody)
            {
                item[propName] = customValue;
            }

            return this.tableData;
        }

        public TableData applyRowAction(string type, int rowIdx)
        {
            if (type == "add") return addNewRow(rowIdx);
            if (type == "delete") return deleteRow(rowIdx);
            if (type == "duplicate") return duplicateRow(rowIdx);
            return this.tableData;
        }

        public TableData addNewRow(int rowIdx)
        {

            var rand = new Random();
            var newRow = new Dictionary<string, dynamic>();

            foreach (var header in this.tableData.tableHeader)
            {

                newRow["id"] = rand.Next();
                switch (header.type)
                {
                    case "text":
                        newRow[header.value] = "_";
                        break;
                    case "checkbox":
                        newRow[header.value] = false;
                        break;
                    case "date":
                        newRow[header.value] = (int)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                        break;
                    case "number":
                        newRow[header.value] = 0;
                        break;
                    default:
                        newRow[header.value] = null;
                        break;
                }
            }

            this.tableData.tableBody.Insert(rowIdx, newRow);
            return this.tableData;
        }

        public TableData deleteRow(int rowIdx)
        {
            this.tableData.tableBody.RemoveAt(rowIdx);
            return this.tableData;
        }

        public TableData duplicateRow(int rowIdx)
        {
            this.tableData.tableBody.Insert(rowIdx, tableData.tableBody[rowIdx]);
            return this.tableData;
        }

        public dynamic getCustomValue(string type)
        {
            if (type == "text") return "";
            else if (type == "number") return 0;
            else if (type == "checkbox") return false;
            else return 1244249;
        }

        public TableData updateData(string header, int idx, dynamic data)
        {

            if (header == "header")
            {

                string prevPropName = this.tableData.tableHeader[idx].value;
                this.tableData.tableHeader[idx].value = data;

                foreach (var row in this.tableData.tableBody)
                {
                    dynamic prevPropValue = row[prevPropName];
                    row.Remove(prevPropName);
                    row.Add(data, prevPropValue);
                }
            }
            else
            {
                this.tableData.tableBody[idx][header] = data;

            }

            return this.tableData;

        }

        public TableData SortData(string key, bool isDesc)
        {

            dynamic value = this.tableData.tableBody[0][key];
            Type type = value.GetType();

            List<Dictionary<string, dynamic>> sortedList;

            switch (type.Name)
            {
                case "Number":
                    sortedList = this.tableData.tableBody.OrderBy(x => x[key]).ToList();
                    break;
                case "String":
                    sortedList = this.tableData.tableBody.OrderBy(x => x[key]).ToList();
                    break;
                case "Boolean":
                    sortedList = this.tableData.tableBody.OrderBy(x => x[key]).ToList();
                    break;
                default:
                    throw new Exception("Unexpected type: " + type);
            }

            if (isDesc)
            {
                sortedList.Reverse();
            }

            this.tableData.tableBody = sortedList;

            return this.tableData;
        }


    }
}
