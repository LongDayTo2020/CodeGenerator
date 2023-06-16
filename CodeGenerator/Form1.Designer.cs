namespace CodeGenerator
{
    partial class MainForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            classNameTextBox = new TextBox();
            classPathTextBox = new TextBox();
            createNameTextBox = new TextBox();
            readNameTextBox = new TextBox();
            updateNameTextBox = new TextBox();
            deleteNameTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            generateButton = new Button();
            namespaceTextBox = new TextBox();
            classGroupBox = new GroupBox();
            interfaceTextBox = new TextBox();
            label8 = new Label();
            CRUDBox = new GroupBox();
            groupBox1 = new GroupBox();
            constructCheckBox = new CheckBox();
            groupBox2 = new GroupBox();
            entityTextBox = new TextBox();
            label20 = new Label();
            dbContextTextBox = new TextBox();
            label19 = new Label();
            tableNameTextBox = new TextBox();
            label18 = new Label();
            construstTextBox = new TextBox();
            label9 = new Label();
            groupBox3 = new GroupBox();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            classGroupBox.SuspendLayout();
            CRUDBox.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // classNameTextBox
            // 
            classNameTextBox.Location = new Point(33, 48);
            classNameTextBox.Name = "classNameTextBox";
            classNameTextBox.Size = new Size(272, 23);
            classNameTextBox.TabIndex = 0;
            // 
            // classPathTextBox
            // 
            classPathTextBox.Location = new Point(612, 38);
            classPathTextBox.Name = "classPathTextBox";
            classPathTextBox.Size = new Size(272, 23);
            classPathTextBox.TabIndex = 1;
            // 
            // createNameTextBox
            // 
            createNameTextBox.Location = new Point(12, 40);
            createNameTextBox.Name = "createNameTextBox";
            createNameTextBox.Size = new Size(272, 23);
            createNameTextBox.TabIndex = 2;
            // 
            // readNameTextBox
            // 
            readNameTextBox.Location = new Point(12, 90);
            readNameTextBox.Name = "readNameTextBox";
            readNameTextBox.Size = new Size(272, 23);
            readNameTextBox.TabIndex = 3;
            // 
            // updateNameTextBox
            // 
            updateNameTextBox.Location = new Point(12, 140);
            updateNameTextBox.Name = "updateNameTextBox";
            updateNameTextBox.Size = new Size(272, 23);
            updateNameTextBox.TabIndex = 4;
            // 
            // deleteNameTextBox
            // 
            deleteNameTextBox.Location = new Point(12, 190);
            deleteNameTextBox.Name = "deleteNameTextBox";
            deleteNameTextBox.Size = new Size(272, 23);
            deleteNameTextBox.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 30);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 6;
            label1.Text = "Class Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(612, 20);
            label2.Name = "label2";
            label2.Size = new Size(66, 15);
            label2.TabIndex = 7;
            label2.Text = "Class Path:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 24);
            label3.Name = "label3";
            label3.Size = new Size(134, 15);
            label3.TabIndex = 8;
            label3.Text = "Create Method Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 70);
            label4.Name = "label4";
            label4.Size = new Size(127, 15);
            label4.TabIndex = 9;
            label4.Text = "Read Method Name:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 120);
            label5.Name = "label5";
            label5.Size = new Size(140, 15);
            label5.TabIndex = 10;
            label5.Text = "Update Method Name:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 170);
            label6.Name = "label6";
            label6.Size = new Size(134, 15);
            label6.TabIndex = 11;
            label6.Text = "Delete Method Name:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(334, 30);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 14;
            label7.Text = "Namespace:";
            // 
            // generateButton
            // 
            generateButton.Location = new Point(23, 184);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(128, 33);
            generateButton.TabIndex = 12;
            generateButton.Text = "產生Class";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // namespaceTextBox
            // 
            namespaceTextBox.Location = new Point(334, 48);
            namespaceTextBox.Name = "namespaceTextBox";
            namespaceTextBox.Size = new Size(272, 23);
            namespaceTextBox.TabIndex = 13;
            // 
            // classGroupBox
            // 
            classGroupBox.Controls.Add(interfaceTextBox);
            classGroupBox.Controls.Add(label8);
            classGroupBox.Controls.Add(classPathTextBox);
            classGroupBox.Controls.Add(label2);
            classGroupBox.Location = new Point(21, 10);
            classGroupBox.Name = "classGroupBox";
            classGroupBox.Size = new Size(1209, 82);
            classGroupBox.TabIndex = 15;
            classGroupBox.TabStop = false;
            classGroupBox.Text = "ClassGroup";
            // 
            // interfaceTextBox
            // 
            interfaceTextBox.Location = new Point(915, 38);
            interfaceTextBox.Name = "interfaceTextBox";
            interfaceTextBox.Size = new Size(272, 23);
            interfaceTextBox.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(915, 20);
            label8.Name = "label8";
            label8.Size = new Size(59, 15);
            label8.TabIndex = 9;
            label8.Text = "Interface:";
            // 
            // CRUDBox
            // 
            CRUDBox.Controls.Add(createNameTextBox);
            CRUDBox.Controls.Add(label3);
            CRUDBox.Controls.Add(readNameTextBox);
            CRUDBox.Controls.Add(label6);
            CRUDBox.Controls.Add(label4);
            CRUDBox.Controls.Add(label5);
            CRUDBox.Controls.Add(updateNameTextBox);
            CRUDBox.Controls.Add(deleteNameTextBox);
            CRUDBox.Location = new Point(21, 108);
            CRUDBox.Name = "CRUDBox";
            CRUDBox.Size = new Size(301, 237);
            CRUDBox.TabIndex = 16;
            CRUDBox.TabStop = false;
            CRUDBox.Text = "CRUD Group";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(constructCheckBox);
            groupBox1.Controls.Add(generateButton);
            groupBox1.Location = new Point(936, 108);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(283, 237);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Set Group";
            // 
            // constructCheckBox
            // 
            constructCheckBox.Checked = true;
            constructCheckBox.CheckState = CheckState.Checked;
            constructCheckBox.Location = new Point(23, 42);
            constructCheckBox.Name = "constructCheckBox";
            constructCheckBox.Size = new Size(119, 19);
            constructCheckBox.TabIndex = 0;
            constructCheckBox.Text = "Create Construct";
            constructCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(entityTextBox);
            groupBox2.Controls.Add(label20);
            groupBox2.Controls.Add(dbContextTextBox);
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(tableNameTextBox);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(construstTextBox);
            groupBox2.Controls.Add(label9);
            groupBox2.Location = new Point(334, 108);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(286, 237);
            groupBox2.TabIndex = 18;
            groupBox2.TabStop = false;
            groupBox2.Text = "Other Settings";
            // 
            // entityTextBox
            // 
            entityTextBox.Location = new Point(8, 190);
            entityTextBox.Name = "entityTextBox";
            entityTextBox.Size = new Size(272, 23);
            entityTextBox.TabIndex = 17;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(6, 170);
            label20.Name = "label20";
            label20.Size = new Size(72, 15);
            label20.TabIndex = 18;
            label20.Text = "Entity Class:";
            // 
            // dbContextTextBox
            // 
            dbContextTextBox.Location = new Point(8, 140);
            dbContextTextBox.Name = "dbContextTextBox";
            dbContextTextBox.Size = new Size(272, 23);
            dbContextTextBox.TabIndex = 15;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(6, 120);
            label19.Name = "label19";
            label19.Size = new Size(73, 15);
            label19.TabIndex = 16;
            label19.Text = "DB Context:";
            // 
            // tableNameTextBox
            // 
            tableNameTextBox.Location = new Point(8, 90);
            tableNameTextBox.Name = "tableNameTextBox";
            tableNameTextBox.Size = new Size(272, 23);
            tableNameTextBox.TabIndex = 13;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(6, 70);
            label18.Name = "label18";
            label18.Size = new Size(80, 15);
            label18.TabIndex = 14;
            label18.Text = "Table Name:";
            // 
            // construstTextBox
            // 
            construstTextBox.Location = new Point(8, 42);
            construstTextBox.Name = "construstTextBox";
            construstTextBox.Size = new Size(272, 23);
            construstTextBox.TabIndex = 12;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 24);
            label9.Name = "label9";
            label9.Size = new Size(63, 15);
            label9.TabIndex = 12;
            label9.Text = "Construct:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label17);
            groupBox3.Controls.Add(label16);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label10);
            groupBox3.Location = new Point(633, 108);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(287, 237);
            groupBox3.TabIndex = 19;
            groupBox3.TabStop = false;
            groupBox3.Text = "說明";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ForeColor = Color.Red;
            label17.Location = new Point(38, 155);
            label17.Name = "label17";
            label17.Size = new Size(146, 15);
            label17.TabIndex = 6;
            label17.Text = "*Update預設名稱Update";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = Color.Red;
            label16.Location = new Point(38, 135);
            label16.Name = "label16";
            label16.Size = new Size(124, 15);
            label16.TabIndex = 5;
            label16.Text = "*Read預設名稱Query";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = Color.Red;
            label15.Location = new Point(38, 175);
            label15.Name = "label15";
            label15.Size = new Size(134, 15);
            label15.TabIndex = 4;
            label15.Text = "*Delete預設名稱Delete";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = Color.Red;
            label14.Location = new Point(38, 115);
            label14.Name = "label14";
            label14.Size = new Size(134, 15);
            label14.TabIndex = 3;
            label14.Text = "*Create預設名稱Create";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = Color.Red;
            label13.Location = new Point(38, 95);
            label13.Name = "label13";
            label13.Size = new Size(140, 15);
            label13.TabIndex = 2;
            label13.Text = "*Class Path預設桌面路徑";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = Color.Red;
            label12.Location = new Point(38, 75);
            label12.Name = "label12";
            label12.Size = new Size(173, 15);
            label12.TabIndex = 2;
            label12.Text = "*Construct參數可以用逗號隔開";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = Color.Red;
            label11.Location = new Point(38, 55);
            label11.Name = "label11";
            label11.Size = new Size(202, 15);
            label11.TabIndex = 1;
            label11.Text = "*Namespace預設ClassNameSpace";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Red;
            label10.Location = new Point(38, 35);
            label10.Name = "label10";
            label10.Size = new Size(86, 15);
            label10.TabIndex = 0;
            label10.Text = "*Class預設Info";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 366);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label7);
            Controls.Add(namespaceTextBox);
            Controls.Add(label1);
            Controls.Add(classNameTextBox);
            Controls.Add(classGroupBox);
            Controls.Add(CRUDBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Code Generator";
            classGroupBox.ResumeLayout(false);
            classGroupBox.PerformLayout();
            CRUDBox.ResumeLayout(false);
            CRUDBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox classNameTextBox;
        private TextBox classPathTextBox;
        private TextBox createNameTextBox;
        private TextBox readNameTextBox;
        private TextBox updateNameTextBox;
        private TextBox deleteNameTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button generateButton;
        private Label label7;
        private TextBox namespaceTextBox;
        private GroupBox classGroupBox;
        private GroupBox CRUDBox;
        private GroupBox groupBox1;
        private CheckBox constructCheckBox;
        private TextBox interfaceTextBox;
        private Label label8;
        private GroupBox groupBox2;
        private TextBox construstTextBox;
        private Label label9;
        private GroupBox groupBox3;
        private Label label10;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private TextBox entityTextBox;
        private Label label20;
        private TextBox dbContextTextBox;
        private Label label19;
        private TextBox tableNameTextBox;
        private Label label18;
    }
}