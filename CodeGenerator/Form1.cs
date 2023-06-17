using Npgsql;
using System.Globalization;
using static Npgsql.Replication.PgOutput.Messages.RelationMessage;

namespace CodeGenerator
{
    public partial class MainForm : Form
    {
        private string connectstrings = "";
        private bool isConnectionCheckBox = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            try
            {
                string classPath = string.IsNullOrEmpty(classPathTextBox?.Text) ? desktopPath : classPathTextBox?.Text ?? "";
                string namespaceName = string.IsNullOrEmpty(namespaceTextBox?.Text) ? "ClassNameSpace" : namespaceTextBox?.Text ?? "";
                string className = string.IsNullOrEmpty(classNameTextBox?.Text) ? "Info" : classNameTextBox?.Text ?? "";
                string interfaceClass = string.IsNullOrEmpty(interfaceTextBox?.Text) ? "" : ": " + interfaceTextBox?.Text ?? "";
                string createName = string.IsNullOrEmpty(createNameTextBox?.Text) ? "Create" : createNameTextBox?.Text ?? "";
                string readName = string.IsNullOrEmpty(readNameTextBox?.Text) ? "Query" : readNameTextBox?.Text ?? "";
                string deleteName = string.IsNullOrEmpty(updateNameTextBox?.Text) ? "Delete" : updateNameTextBox?.Text ?? "";
                string updateName = string.IsNullOrEmpty(deleteNameTextBox?.Text) ? "Update" : deleteNameTextBox?.Text ?? "";
                string construsts = string.IsNullOrEmpty(construstTextBox?.Text) ? "" : construstTextBox?.Text ?? "";
                string tableName = string.IsNullOrEmpty(tableNameTextBox?.Text) ? "TableName" : tableNameTextBox?.Text ?? "";
                string dbContext = string.IsNullOrEmpty(dbContextTextBox?.Text) ? "dbContext" : dbContextTextBox?.Text ?? "";
                string entityClass = string.IsNullOrEmpty(entityTextBox?.Text) ? "dbClass" : entityTextBox?.Text ?? "";
                connectstrings = string.IsNullOrEmpty(ConnectionTextBox?.Text) ? "" : ConnectionTextBox?.Text ?? "";
                isConnectionCheckBox = connectionCheckBox.Checked;
                string properties = "";
                var isConstructCheckBox = constructCheckBox.Checked;
                var construstList = new List<string>();
                //建構值
                if (isConstructCheckBox)
                {
                    construstList = construsts.Split(',').ToList() ?? new List<string>();
                    if (string.IsNullOrEmpty(dbContextTextBox?.Text) && !string.IsNullOrEmpty(construstTextBox?.Text))
                    {
                        dbContext = $"_{GetLowerCamelCase(construstList[0])}";
                    }
                    //
                    var construstparamList = new List<string>();
                    foreach (var item in construstList)
                    {
                        if (string.IsNullOrEmpty(item)) continue;
                        properties += $"private readonly {item} _{GetLowerCamelCase(item)};" + Environment.NewLine;
                        construstparamList.Add($"{item} {GetLowerCamelCase(item)}");
                    }

                    construsts = $"public {className} ( {string.Join(", ", construstparamList)} ){{" + Environment.NewLine;
                    foreach (var item in construstList)
                    {
                        if (string.IsNullOrEmpty(item)) continue;
                        construsts += $"_{GetLowerCamelCase(item)} = {GetLowerCamelCase(item)};" + Environment.NewLine;
                    }
                    construsts += "     }" + Environment.NewLine;
                }

                // 檢查路徑是否存在，不存在則建立資料夾
                if (!Directory.Exists(classPath))
                    Directory.CreateDirectory(classPath);

                // 產生類別檔案的完整路徑
                string classFilePath = Path.Combine(classPath, className + ".cs");

                // 產生類別內容
                string classContent = $@"
using System.Data;
using Dapper;
using UserManage.Repository.Entity;
using UserManage.Repository.Interface;
using System;

namespace {namespaceName}
{{
    public class {className} {interfaceClass}<{entityClass}>
    {{
        {properties}
        {construsts}

        public bool {createName}({entityClass} {GetLowerCamelCase(entityClass)})
        {{
            string sql = @"" {GetColumnNotNullSetting(tableName, CRUDType.Create)} "";
            return {dbContext}.Execute(sql,{GetLowerCamelCase(entityClass)}) > 0;
        }}

        public IEnumerable<{entityClass}> {readName}All()
        {{
            string sql = @"" {GetColumnNotNullSetting(tableName, CRUDType.Read)} "";
            return {dbContext}.Query<{entityClass}>(sql);
        }}

        public {entityClass} {readName}(object {GetLowerCamelCase(entityClass)})
        {{
            string sql = @""{GetColumnNotNullSetting(tableName, CRUDType.ReadFirst)} "";
            return {dbContext}.QueryFirstOrDefault<{entityClass}>(sql);
        }}

        public bool {deleteName}(object id)
        {{
            string sql = @"" {GetColumnNotNullSetting(tableName, CRUDType.Delete)} "";
            var parameters = new DynamicParameters();
            parameters.Add(""Id"", id, System.Data.DbType.Int32);
            return {dbContext}.Execute(sql, parameters) > 0;
        }}

        public bool {updateName}(object id, {entityClass} {GetLowerCamelCase(entityClass)})
        {{
            string sql = @""{GetColumnNotNullSetting(tableName, CRUDType.Update)}"";
            var parameters = new DynamicParameters({GetLowerCamelCase(entityClass)});
            parameters.Add(""Id"", id, System.Data.DbType.Int32);
            return {dbContext}.Execute(sql, parameters) > 0;
        }}
    }}
}}
";

                // 將類別內容寫入檔案
                File.WriteAllText(classFilePath, classContent);
                MessageBox.Show($"{className}類別已成功產生。");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"錯誤訊息{ex.Message}");
            }

        }


        private string GetLowerCamelCase(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            string[] words = input.Split('_') ?? new string[] { };
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            for (int i = 1; i < words.Length; i++)
            {
                words[i] = textInfo.ToTitleCase(words[i]);
            }

            string result = string.Join("", words);
            result = char.ToLowerInvariant(result[0]) + result.Substring(1);
            return result;
        }

        //把底線分割轉大駝峰
        private static string ConvertToCamelCase(string input)
        {
            string[] words = input.Split('_');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
            }
            return string.Join("", words);
        }

        private string GetColumnNotNullSetting(string tableName, CRUDType crudTyps = CRUDType.Read)
        {
            var result = "";
            if (!isConnectionCheckBox) return result;
            using var connection = new NpgsqlConnection(connectstrings);
            // 開啟連線
            connection.Open();
            string sqlQuery = $@"
           SELECT table_sechma.*,
                  (SELECT 1
                   FROM information_schema.key_column_usage AS kcu
                            JOIN information_schema.table_constraints AS tc ON kcu.constraint_name = tc.constraint_name
                   WHERE kcu.table_name = '{tableName}' -- 指定資料表名稱
                     AND kcu.column_name = table_sechma.column_name -- 指定欄位名稱
                     AND tc.constraint_type = 'PRIMARY KEY' -- 判斷是否為主鍵
                  ) as is_primary_key
            FROM information_schema.columns as table_sechma
            WHERE table_name = '{tableName}'
            ";

            using var command = new NpgsqlCommand(sqlQuery, connection);
            using var reader = command.ExecuteReader();
            var columnList = new List<(string, bool)>();
            while (reader.Read())
            {
                // 讀取資料列中的欄位值
                var column1Name = reader.GetString(reader.GetOrdinal("column_name"));
                var isPrimaryKey = reader.GetValue(reader.GetOrdinal("is_primary_key")) != DBNull.Value;
                columnList.Add((column1Name, isPrimaryKey));
            }

            var splitText = $"{Environment.NewLine},";
            switch (crudTyps)
            {
                case CRUDType.Create:
                    var createCombinedColumes = columnList.Where(x => !x.Item2).Select((column, index) => $" {column.Item1} ").ToArray();
                    var createValueCombinedColumes = columnList.Where(x => !x.Item2).Select((column, index) => $" @{ConvertToCamelCase(column.Item1)} ").ToArray();
                    result += $" INSERT INTO {tableName} " + " ( " + Environment.NewLine;
                    result += $" {string.Join(splitText, createCombinedColumes)} )" + Environment.NewLine;
                    result += " VALUES ( ";
                    result += string.Join(splitText, createValueCombinedColumes) + ") ";
                    break;
                case CRUDType.Read:
                    result += $" SELECT " + Environment.NewLine;
                    result += $" {string.Join(splitText, columnList.Select(q => q.Item1).ToArray())} " + Environment.NewLine;
                    result += $" FROM {tableName} ";
                    break;
                case CRUDType.ReadFirst:
                    var readFirstCombinedColumes = columnList.Where(x => x.Item2).Select((column, index) => @$" {column.Item1} = @{ConvertToCamelCase(column.Item1)} ").ToArray();
                    result += $" SELECT  " + Environment.NewLine;
                    result += $" {string.Join(splitText, columnList.Select(q => q.Item1).ToArray())} " + Environment.NewLine;
                    result += $" FROM {tableName} " + Environment.NewLine;
                    result += " WHERE ";
                    result += string.Join(" AND " + splitText, readFirstCombinedColumes) + " LIMIT 1 ";
                    break;
                case CRUDType.Update:
                    var updateCombinedColumes = columnList.Where(x => !x.Item2).Select((column, index) => @$" {column.Item1} = @{ConvertToCamelCase(column.Item1)} ").ToArray();
                    var updateWhereCombinedColumes = columnList.Where(x => x.Item2).Select((column, index) => @$" {column.Item1} = @{ConvertToCamelCase(column.Item1)}  ").ToArray();
                    result += $" UPDATE {tableName} " + Environment.NewLine;
                    result += " SET ";
                    result += string.Join(splitText, updateCombinedColumes) + Environment.NewLine;
                    result += " WHERE ";
                    result += string.Join(splitText, updateWhereCombinedColumes);
                    break;
                case CRUDType.Delete:
                    var deleteCombinedColumes = columnList.Where(x => x.Item2).Select((column, index) => @$" {column.Item1} = @{ConvertToCamelCase(column.Item1)} ").ToArray();
                    result += $" DELETE {tableName} " + Environment.NewLine;
                    result += $" WHERE " + Environment.NewLine;
                    result += string.Join(splitText, deleteCombinedColumes);
                    break;
                default:
                    break;
            }

            return result;
        }

        private enum CRUDType
        {
            Create = 0,
            Read = 1,
            ReadFirst = 2,
            Update = 3,
            Delete = 4
        }
    }


}