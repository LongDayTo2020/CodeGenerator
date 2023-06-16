using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CodeGenerator
{
    public partial class MainForm : Form
    {
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
                        construsts += $"_{GetLowerCamelCase(item)} = {GetLowerCamelCase(item)}" + Environment.NewLine;
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
using System;

namespace {namespaceName}
{{
    public class {className} {interfaceClass}
    {{
        {properties}
        {construsts}

        public bool {createName}({entityClass} {GetLowerCamelCase(entityClass)})
        {{
            string sql = @"" INSERT INTO {tableName} ()
VALUES ()
""
            return {dbContext}.Excute(sql,{GetLowerCamelCase(entityClass)}) > 0;
        }}

        public IQuery<{entityClass}> {readName}All()
        {{
            string sql = @"" SELECT * FROM {tableName} ""
            return {dbContext}.Query<{entityClass}>(sql);
        }}

        public {entityClass} {readName}()
        {{
            string sql = @"" SELECT TOP 1 * FROM {tableName} ""
            return {dbContext}.QueryFirstOrDefault<{entityClass}>(sql);
        }}

        public void {deleteName}(int id)
        {{
            string sql = @"" DELETE {tableName} WHERE ID = @Id ""
            var parameters = new DynamicParameters();
            parameters.Add(""Id"", id, System.Data.DbType.Int32);
            return {dbContext}.Excute<{entityClass}>(sql, parameters);
        }}

        public bool {updateName}(int id, {entityClass} {GetLowerCamelCase(entityClass)})
        {{
            string sql = @"" Update {tableName} 
SET

WHERE ID = @Id ""
            var parameters = new DynamicParameters({GetLowerCamelCase(entityClass)});
            parameters.Add(""Id"", id, System.Data.DbType.Int32);
            return {dbContext}.Excute<{entityClass}>(sql, parameters) > 0;
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


    }
}