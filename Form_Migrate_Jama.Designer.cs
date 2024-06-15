
namespace QCTest
{
    partial class Form_Migrate_Jama
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Migrate_Jama));
            this.comboBox_exports = new System.Windows.Forms.ComboBox();
            this.label_exports = new System.Windows.Forms.Label();
            this.groupBox_basic = new System.Windows.Forms.GroupBox();
            this.checkBox_remember = new System.Windows.Forms.CheckBox();
            this.textBox_URL = new System.Windows.Forms.TextBox();
            this.label_url = new System.Windows.Forms.Label();
            this.button_TestQCConnect = new System.Windows.Forms.Button();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label_password = new System.Windows.Forms.Label();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.label_User = new System.Windows.Forms.Label();
            this.textBox_Domain = new System.Windows.Forms.TextBox();
            this.comboBox_project = new System.Windows.Forms.ComboBox();
            this.label_project = new System.Windows.Forms.Label();
            this.label_Domain = new System.Windows.Forms.Label();
            this.groupBox_QC_TS = new System.Windows.Forms.GroupBox();
            this.button_QC_TestSet_ExportPath = new System.Windows.Forms.Button();
            this.textBox_QC_TestSet_ExportPath = new System.Windows.Forms.TextBox();
            this.label_QC_TestSet_ExportPath = new System.Windows.Forms.Label();
            this.textBox_QC_TestSet_Path = new System.Windows.Forms.TextBox();
            this.label_QC_TestSet_Path = new System.Windows.Forms.Label();
            this.button_Export = new System.Windows.Forms.Button();
            this.groupBox_QC_TC = new System.Windows.Forms.GroupBox();
            this.textBox_QC_TestCase_Sheet = new System.Windows.Forms.TextBox();
            this.label_QC_TestCase_Sheet = new System.Windows.Forms.Label();
            this.textBox_QC_TestCase_Excel = new System.Windows.Forms.TextBox();
            this.label_QC_TestCase_Excel = new System.Windows.Forms.Label();
            this.textBox_QC_TestCase_ExportPath = new System.Windows.Forms.TextBox();
            this.button_QC_TestCase_ExportPath = new System.Windows.Forms.Button();
            this.label_QC_TestCase_ExportPath = new System.Windows.Forms.Label();
            this.label_QC_Req_Path = new System.Windows.Forms.Label();
            this.textBox_QC_Req_Path = new System.Windows.Forms.TextBox();
            this.button_QC_Req_Path = new System.Windows.Forms.Button();
            this.label_QC_Req_Excel = new System.Windows.Forms.Label();
            this.textBox_QC_Req_Excel = new System.Windows.Forms.TextBox();
            this.label_QC_Req_Sheet = new System.Windows.Forms.Label();
            this.textBox_QC_Req_Sheet = new System.Windows.Forms.TextBox();
            this.groupBox_QC_Req = new System.Windows.Forms.GroupBox();
            this.groupBox_QC_TCTrace = new System.Windows.Forms.GroupBox();
            this.textBox_QC_TCTrace_Sheet = new System.Windows.Forms.TextBox();
            this.label_QC_TCTrace_Sheet = new System.Windows.Forms.Label();
            this.textBox_QC_TCTrace_Excel = new System.Windows.Forms.TextBox();
            this.label_QC_TCTrace_Excel = new System.Windows.Forms.Label();
            this.button_QC_TCTrace_Path = new System.Windows.Forms.Button();
            this.textBox_QC_TCTrace_Path = new System.Windows.Forms.TextBox();
            this.label_QC_TCTrace_Path = new System.Windows.Forms.Label();
            this.panel_QCExport = new System.Windows.Forms.Panel();
            this.groupBox_basic.SuspendLayout();
            this.groupBox_QC_TS.SuspendLayout();
            this.groupBox_QC_TC.SuspendLayout();
            this.groupBox_QC_Req.SuspendLayout();
            this.groupBox_QC_TCTrace.SuspendLayout();
            this.panel_QCExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_exports
            // 
            this.comboBox_exports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_exports.FormattingEnabled = true;
            this.comboBox_exports.Items.AddRange(new object[] {
            "QC Requirement",
            "QC Test Plan",
            "QC Test Lab",
            "QC Requirement--Test Case"});
            this.comboBox_exports.Location = new System.Drawing.Point(173, 258);
            this.comboBox_exports.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_exports.Name = "comboBox_exports";
            this.comboBox_exports.Size = new System.Drawing.Size(212, 24);
            this.comboBox_exports.TabIndex = 8;
            this.comboBox_exports.SelectedIndexChanged += new System.EventHandler(this.comboBox_exports_SelectedIndexChanged);
            // 
            // label_exports
            // 
            this.label_exports.AutoSize = true;
            this.label_exports.Location = new System.Drawing.Point(40, 258);
            this.label_exports.Name = "label_exports";
            this.label_exports.Size = new System.Drawing.Size(123, 17);
            this.label_exports.TabIndex = 9;
            this.label_exports.Text = "select export type:";
            // 
            // groupBox_basic
            // 
            this.groupBox_basic.Controls.Add(this.checkBox_remember);
            this.groupBox_basic.Controls.Add(this.textBox_URL);
            this.groupBox_basic.Controls.Add(this.label_url);
            this.groupBox_basic.Controls.Add(this.button_TestQCConnect);
            this.groupBox_basic.Controls.Add(this.textBox_password);
            this.groupBox_basic.Controls.Add(this.label_password);
            this.groupBox_basic.Controls.Add(this.textBox_User);
            this.groupBox_basic.Controls.Add(this.label_User);
            this.groupBox_basic.Controls.Add(this.textBox_Domain);
            this.groupBox_basic.Controls.Add(this.comboBox_project);
            this.groupBox_basic.Controls.Add(this.label_project);
            this.groupBox_basic.Controls.Add(this.label_Domain);
            this.groupBox_basic.Location = new System.Drawing.Point(11, 10);
            this.groupBox_basic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_basic.Name = "groupBox_basic";
            this.groupBox_basic.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_basic.Size = new System.Drawing.Size(800, 215);
            this.groupBox_basic.TabIndex = 10;
            this.groupBox_basic.TabStop = false;
            this.groupBox_basic.Text = "QC Login Basic Information ";
            // 
            // checkBox_remember
            // 
            this.checkBox_remember.AutoSize = true;
            this.checkBox_remember.Location = new System.Drawing.Point(427, 166);
            this.checkBox_remember.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox_remember.Name = "checkBox_remember";
            this.checkBox_remember.Size = new System.Drawing.Size(129, 21);
            this.checkBox_remember.TabIndex = 18;
            this.checkBox_remember.Text = "remember info?";
            this.checkBox_remember.UseVisualStyleBackColor = true;
            // 
            // textBox_URL
            // 
            this.textBox_URL.Location = new System.Drawing.Point(127, 31);
            this.textBox_URL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_URL.Name = "textBox_URL";
            this.textBox_URL.Size = new System.Drawing.Size(452, 22);
            this.textBox_URL.TabIndex = 17;
            this.textBox_URL.Text = "http://denamssvqcent.sds.sybrondental.com:8080/qcbin";
            // 
            // label_url
            // 
            this.label_url.AutoSize = true;
            this.label_url.Location = new System.Drawing.Point(33, 37);
            this.label_url.Name = "label_url";
            this.label_url.Size = new System.Drawing.Size(64, 17);
            this.label_url.TabIndex = 16;
            this.label_url.Text = "QC URL:";
            // 
            // button_TestQCConnect
            // 
            this.button_TestQCConnect.Location = new System.Drawing.Point(608, 155);
            this.button_TestQCConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_TestQCConnect.Name = "button_TestQCConnect";
            this.button_TestQCConnect.Size = new System.Drawing.Size(173, 43);
            this.button_TestQCConnect.TabIndex = 8;
            this.button_TestQCConnect.Text = "Test QC Connection";
            this.button_TestQCConnect.UseVisualStyleBackColor = true;
            this.button_TestQCConnect.Click += new System.EventHandler(this.button_TestQCConnect_Click);
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(427, 123);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(132, 22);
            this.textBox_password.TabIndex = 15;
            this.textBox_password.UseSystemPasswordChar = true;
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(320, 123);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(73, 17);
            this.label_password.TabIndex = 14;
            this.label_password.Text = "Password:";
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(127, 123);
            this.textBox_User.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(132, 22);
            this.textBox_User.TabIndex = 13;
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Location = new System.Drawing.Point(33, 123);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(83, 17);
            this.label_User.TabIndex = 12;
            this.label_User.Text = "User Name:";
            // 
            // textBox_Domain
            // 
            this.textBox_Domain.Location = new System.Drawing.Point(127, 80);
            this.textBox_Domain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Domain.Name = "textBox_Domain";
            this.textBox_Domain.Size = new System.Drawing.Size(132, 22);
            this.textBox_Domain.TabIndex = 9;
            this.textBox_Domain.Text = "ENVISTAQC";
            // 
            // comboBox_project
            // 
            this.comboBox_project.FormattingEnabled = true;
            this.comboBox_project.Items.AddRange(new object[] {
            "Dallas",
            "Nice",
            "Prague"});
            this.comboBox_project.Location = new System.Drawing.Point(427, 80);
            this.comboBox_project.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_project.Name = "comboBox_project";
            this.comboBox_project.Size = new System.Drawing.Size(132, 24);
            this.comboBox_project.TabIndex = 11;
            // 
            // label_project
            // 
            this.label_project.AutoSize = true;
            this.label_project.Location = new System.Drawing.Point(320, 80);
            this.label_project.Name = "label_project";
            this.label_project.Size = new System.Drawing.Size(56, 17);
            this.label_project.TabIndex = 10;
            this.label_project.Text = "Project:";
            // 
            // label_Domain
            // 
            this.label_Domain.AutoSize = true;
            this.label_Domain.Location = new System.Drawing.Point(33, 80);
            this.label_Domain.Name = "label_Domain";
            this.label_Domain.Size = new System.Drawing.Size(60, 17);
            this.label_Domain.TabIndex = 8;
            this.label_Domain.Text = "Domain:";
            // 
            // groupBox_QC_TS
            // 
            this.groupBox_QC_TS.Controls.Add(this.button_QC_TestSet_ExportPath);
            this.groupBox_QC_TS.Controls.Add(this.textBox_QC_TestSet_ExportPath);
            this.groupBox_QC_TS.Controls.Add(this.label_QC_TestSet_ExportPath);
            this.groupBox_QC_TS.Controls.Add(this.textBox_QC_TestSet_Path);
            this.groupBox_QC_TS.Controls.Add(this.label_QC_TestSet_Path);
            this.groupBox_QC_TS.Location = new System.Drawing.Point(11, 631);
            this.groupBox_QC_TS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_QC_TS.Name = "groupBox_QC_TS";
            this.groupBox_QC_TS.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_QC_TS.Size = new System.Drawing.Size(800, 138);
            this.groupBox_QC_TS.TabIndex = 11;
            this.groupBox_QC_TS.TabStop = false;
            this.groupBox_QC_TS.Text = "Export QC Test Lab (Test Sets)";
            // 
            // button_QC_TestSet_ExportPath
            // 
            this.button_QC_TestSet_ExportPath.Location = new System.Drawing.Point(600, 26);
            this.button_QC_TestSet_ExportPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_QC_TestSet_ExportPath.Name = "button_QC_TestSet_ExportPath";
            this.button_QC_TestSet_ExportPath.Size = new System.Drawing.Size(75, 32);
            this.button_QC_TestSet_ExportPath.TabIndex = 4;
            this.button_QC_TestSet_ExportPath.Text = "Browser";
            this.button_QC_TestSet_ExportPath.UseVisualStyleBackColor = true;
            this.button_QC_TestSet_ExportPath.Click += new System.EventHandler(this.button_QC_TestSet_ExportPath_Click);
            // 
            // textBox_QC_TestSet_ExportPath
            // 
            this.textBox_QC_TestSet_ExportPath.Location = new System.Drawing.Point(171, 32);
            this.textBox_QC_TestSet_ExportPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_QC_TestSet_ExportPath.Name = "textBox_QC_TestSet_ExportPath";
            this.textBox_QC_TestSet_ExportPath.Size = new System.Drawing.Size(404, 22);
            this.textBox_QC_TestSet_ExportPath.TabIndex = 3;
            // 
            // label_QC_TestSet_ExportPath
            // 
            this.label_QC_TestSet_ExportPath.AutoSize = true;
            this.label_QC_TestSet_ExportPath.Location = new System.Drawing.Point(33, 31);
            this.label_QC_TestSet_ExportPath.Name = "label_QC_TestSet_ExportPath";
            this.label_QC_TestSet_ExportPath.Size = new System.Drawing.Size(85, 17);
            this.label_QC_TestSet_ExportPath.TabIndex = 2;
            this.label_QC_TestSet_ExportPath.Text = "Export Path:";
            // 
            // textBox_QC_TestSet_Path
            // 
            this.textBox_QC_TestSet_Path.Location = new System.Drawing.Point(171, 68);
            this.textBox_QC_TestSet_Path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_QC_TestSet_Path.Name = "textBox_QC_TestSet_Path";
            this.textBox_QC_TestSet_Path.Size = new System.Drawing.Size(193, 22);
            this.textBox_QC_TestSet_Path.TabIndex = 1;
            // 
            // label_QC_TestSet_Path
            // 
            this.label_QC_TestSet_Path.AutoSize = true;
            this.label_QC_TestSet_Path.Location = new System.Drawing.Point(33, 68);
            this.label_QC_TestSet_Path.Name = "label_QC_TestSet_Path";
            this.label_QC_TestSet_Path.Size = new System.Drawing.Size(133, 17);
            this.label_QC_TestSet_Path.TabIndex = 0;
            this.label_QC_TestSet_Path.Text = "TestSet Path in QC:";
            // 
            // button_Export
            // 
            this.button_Export.Location = new System.Drawing.Point(619, 246);
            this.button_Export.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(173, 43);
            this.button_Export.TabIndex = 5;
            this.button_Export.Text = "Export";
            this.button_Export.UseVisualStyleBackColor = true;
            this.button_Export.Click += new System.EventHandler(this.button_Export_Click);
            // 
            // groupBox_QC_TC
            // 
            this.groupBox_QC_TC.Controls.Add(this.textBox_QC_TestCase_Sheet);
            this.groupBox_QC_TC.Controls.Add(this.label_QC_TestCase_Sheet);
            this.groupBox_QC_TC.Controls.Add(this.textBox_QC_TestCase_Excel);
            this.groupBox_QC_TC.Controls.Add(this.label_QC_TestCase_Excel);
            this.groupBox_QC_TC.Controls.Add(this.textBox_QC_TestCase_ExportPath);
            this.groupBox_QC_TC.Controls.Add(this.button_QC_TestCase_ExportPath);
            this.groupBox_QC_TC.Controls.Add(this.label_QC_TestCase_ExportPath);
            this.groupBox_QC_TC.Location = new System.Drawing.Point(11, 431);
            this.groupBox_QC_TC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_QC_TC.Name = "groupBox_QC_TC";
            this.groupBox_QC_TC.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_QC_TC.Size = new System.Drawing.Size(800, 144);
            this.groupBox_QC_TC.TabIndex = 12;
            this.groupBox_QC_TC.TabStop = false;
            this.groupBox_QC_TC.Text = "Export QC Test Plan (Test Cases)";
            // 
            // textBox_QC_TestCase_Sheet
            // 
            this.textBox_QC_TestCase_Sheet.Location = new System.Drawing.Point(171, 105);
            this.textBox_QC_TestCase_Sheet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_QC_TestCase_Sheet.Name = "textBox_QC_TestCase_Sheet";
            this.textBox_QC_TestCase_Sheet.Size = new System.Drawing.Size(193, 22);
            this.textBox_QC_TestCase_Sheet.TabIndex = 6;
            this.textBox_QC_TestCase_Sheet.Text = "Query1";
            // 
            // label_QC_TestCase_Sheet
            // 
            this.label_QC_TestCase_Sheet.AutoSize = true;
            this.label_QC_TestCase_Sheet.Location = new System.Drawing.Point(33, 105);
            this.label_QC_TestCase_Sheet.Name = "label_QC_TestCase_Sheet";
            this.label_QC_TestCase_Sheet.Size = new System.Drawing.Size(134, 17);
            this.label_QC_TestCase_Sheet.TabIndex = 5;
            this.label_QC_TestCase_Sheet.Text = "Export Sheet Name:";
            // 
            // textBox_QC_TestCase_Excel
            // 
            this.textBox_QC_TestCase_Excel.Location = new System.Drawing.Point(171, 68);
            this.textBox_QC_TestCase_Excel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_QC_TestCase_Excel.Name = "textBox_QC_TestCase_Excel";
            this.textBox_QC_TestCase_Excel.Size = new System.Drawing.Size(193, 22);
            this.textBox_QC_TestCase_Excel.TabIndex = 4;
            this.textBox_QC_TestCase_Excel.Text = "QC_TestCases.xlsx";
            // 
            // label_QC_TestCase_Excel
            // 
            this.label_QC_TestCase_Excel.AutoSize = true;
            this.label_QC_TestCase_Excel.Location = new System.Drawing.Point(33, 68);
            this.label_QC_TestCase_Excel.Name = "label_QC_TestCase_Excel";
            this.label_QC_TestCase_Excel.Size = new System.Drawing.Size(130, 17);
            this.label_QC_TestCase_Excel.TabIndex = 3;
            this.label_QC_TestCase_Excel.Text = "Export Excel Name:";
            // 
            // textBox_QC_TestCase_ExportPath
            // 
            this.textBox_QC_TestCase_ExportPath.Location = new System.Drawing.Point(171, 31);
            this.textBox_QC_TestCase_ExportPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_QC_TestCase_ExportPath.Name = "textBox_QC_TestCase_ExportPath";
            this.textBox_QC_TestCase_ExportPath.Size = new System.Drawing.Size(404, 22);
            this.textBox_QC_TestCase_ExportPath.TabIndex = 1;
            // 
            // button_QC_TestCase_ExportPath
            // 
            this.button_QC_TestCase_ExportPath.Location = new System.Drawing.Point(600, 26);
            this.button_QC_TestCase_ExportPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_QC_TestCase_ExportPath.Name = "button_QC_TestCase_ExportPath";
            this.button_QC_TestCase_ExportPath.Size = new System.Drawing.Size(75, 32);
            this.button_QC_TestCase_ExportPath.TabIndex = 2;
            this.button_QC_TestCase_ExportPath.Text = "Browser";
            this.button_QC_TestCase_ExportPath.UseVisualStyleBackColor = true;
            this.button_QC_TestCase_ExportPath.Click += new System.EventHandler(this.button_QC_TestCase_ExportPath_Click);
            // 
            // label_QC_TestCase_ExportPath
            // 
            this.label_QC_TestCase_ExportPath.AutoSize = true;
            this.label_QC_TestCase_ExportPath.Location = new System.Drawing.Point(33, 31);
            this.label_QC_TestCase_ExportPath.Name = "label_QC_TestCase_ExportPath";
            this.label_QC_TestCase_ExportPath.Size = new System.Drawing.Size(85, 17);
            this.label_QC_TestCase_ExportPath.TabIndex = 0;
            this.label_QC_TestCase_ExportPath.Text = "Export Path:";
            // 
            // label_QC_Req_Path
            // 
            this.label_QC_Req_Path.AutoSize = true;
            this.label_QC_Req_Path.Location = new System.Drawing.Point(33, 31);
            this.label_QC_Req_Path.Name = "label_QC_Req_Path";
            this.label_QC_Req_Path.Size = new System.Drawing.Size(85, 17);
            this.label_QC_Req_Path.TabIndex = 0;
            this.label_QC_Req_Path.Text = "Export Path:";
            // 
            // textBox_QC_Req_Path
            // 
            this.textBox_QC_Req_Path.Location = new System.Drawing.Point(171, 31);
            this.textBox_QC_Req_Path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_QC_Req_Path.Name = "textBox_QC_Req_Path";
            this.textBox_QC_Req_Path.Size = new System.Drawing.Size(404, 22);
            this.textBox_QC_Req_Path.TabIndex = 1;
            // 
            // button_QC_Req_Path
            // 
            this.button_QC_Req_Path.Location = new System.Drawing.Point(600, 26);
            this.button_QC_Req_Path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_QC_Req_Path.Name = "button_QC_Req_Path";
            this.button_QC_Req_Path.Size = new System.Drawing.Size(75, 32);
            this.button_QC_Req_Path.TabIndex = 2;
            this.button_QC_Req_Path.Text = "Browser";
            this.button_QC_Req_Path.UseVisualStyleBackColor = true;
            this.button_QC_Req_Path.Click += new System.EventHandler(this.button_QC_Req_Path_Click);
            // 
            // label_QC_Req_Excel
            // 
            this.label_QC_Req_Excel.AutoSize = true;
            this.label_QC_Req_Excel.Location = new System.Drawing.Point(33, 68);
            this.label_QC_Req_Excel.Name = "label_QC_Req_Excel";
            this.label_QC_Req_Excel.Size = new System.Drawing.Size(130, 17);
            this.label_QC_Req_Excel.TabIndex = 3;
            this.label_QC_Req_Excel.Text = "Export Excel Name:";
            // 
            // textBox_QC_Req_Excel
            // 
            this.textBox_QC_Req_Excel.Location = new System.Drawing.Point(171, 68);
            this.textBox_QC_Req_Excel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_QC_Req_Excel.Name = "textBox_QC_Req_Excel";
            this.textBox_QC_Req_Excel.Size = new System.Drawing.Size(193, 22);
            this.textBox_QC_Req_Excel.TabIndex = 4;
            this.textBox_QC_Req_Excel.Text = "QC_Req.xlsx";
            // 
            // label_QC_Req_Sheet
            // 
            this.label_QC_Req_Sheet.AutoSize = true;
            this.label_QC_Req_Sheet.Location = new System.Drawing.Point(33, 105);
            this.label_QC_Req_Sheet.Name = "label_QC_Req_Sheet";
            this.label_QC_Req_Sheet.Size = new System.Drawing.Size(134, 17);
            this.label_QC_Req_Sheet.TabIndex = 5;
            this.label_QC_Req_Sheet.Text = "Export Sheet Name:";
            // 
            // textBox_QC_Req_Sheet
            // 
            this.textBox_QC_Req_Sheet.Location = new System.Drawing.Point(171, 105);
            this.textBox_QC_Req_Sheet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_QC_Req_Sheet.Name = "textBox_QC_Req_Sheet";
            this.textBox_QC_Req_Sheet.Size = new System.Drawing.Size(193, 22);
            this.textBox_QC_Req_Sheet.TabIndex = 6;
            this.textBox_QC_Req_Sheet.Text = "Query1";
            // 
            // groupBox_QC_Req
            // 
            this.groupBox_QC_Req.Controls.Add(this.textBox_QC_Req_Sheet);
            this.groupBox_QC_Req.Controls.Add(this.label_QC_Req_Sheet);
            this.groupBox_QC_Req.Controls.Add(this.textBox_QC_Req_Excel);
            this.groupBox_QC_Req.Controls.Add(this.label_QC_Req_Excel);
            this.groupBox_QC_Req.Controls.Add(this.button_QC_Req_Path);
            this.groupBox_QC_Req.Controls.Add(this.textBox_QC_Req_Path);
            this.groupBox_QC_Req.Controls.Add(this.label_QC_Req_Path);
            this.groupBox_QC_Req.Location = new System.Drawing.Point(5, 289);
            this.groupBox_QC_Req.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_QC_Req.Name = "groupBox_QC_Req";
            this.groupBox_QC_Req.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_QC_Req.Size = new System.Drawing.Size(800, 144);
            this.groupBox_QC_Req.TabIndex = 13;
            this.groupBox_QC_Req.TabStop = false;
            this.groupBox_QC_Req.Text = "Export QC Requirements";
            // 
            // groupBox_QC_TCTrace
            // 
            this.groupBox_QC_TCTrace.Controls.Add(this.textBox_QC_TCTrace_Sheet);
            this.groupBox_QC_TCTrace.Controls.Add(this.label_QC_TCTrace_Sheet);
            this.groupBox_QC_TCTrace.Controls.Add(this.textBox_QC_TCTrace_Excel);
            this.groupBox_QC_TCTrace.Controls.Add(this.label_QC_TCTrace_Excel);
            this.groupBox_QC_TCTrace.Controls.Add(this.button_QC_TCTrace_Path);
            this.groupBox_QC_TCTrace.Controls.Add(this.textBox_QC_TCTrace_Path);
            this.groupBox_QC_TCTrace.Controls.Add(this.label_QC_TCTrace_Path);
            this.groupBox_QC_TCTrace.Location = new System.Drawing.Point(11, 775);
            this.groupBox_QC_TCTrace.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox_QC_TCTrace.Name = "groupBox_QC_TCTrace";
            this.groupBox_QC_TCTrace.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_QC_TCTrace.Size = new System.Drawing.Size(800, 144);
            this.groupBox_QC_TCTrace.TabIndex = 7;
            this.groupBox_QC_TCTrace.TabStop = false;
            this.groupBox_QC_TCTrace.Text = "Export QC Relationship of Requirement and Test Case";
            // 
            // textBox_QC_TCTrace_Sheet
            // 
            this.textBox_QC_TCTrace_Sheet.Location = new System.Drawing.Point(171, 105);
            this.textBox_QC_TCTrace_Sheet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_QC_TCTrace_Sheet.Name = "textBox_QC_TCTrace_Sheet";
            this.textBox_QC_TCTrace_Sheet.Size = new System.Drawing.Size(193, 22);
            this.textBox_QC_TCTrace_Sheet.TabIndex = 8;
            this.textBox_QC_TCTrace_Sheet.Text = "Query1";
            // 
            // label_QC_TCTrace_Sheet
            // 
            this.label_QC_TCTrace_Sheet.AutoSize = true;
            this.label_QC_TCTrace_Sheet.Location = new System.Drawing.Point(33, 105);
            this.label_QC_TCTrace_Sheet.Name = "label_QC_TCTrace_Sheet";
            this.label_QC_TCTrace_Sheet.Size = new System.Drawing.Size(134, 17);
            this.label_QC_TCTrace_Sheet.TabIndex = 7;
            this.label_QC_TCTrace_Sheet.Text = "Export Sheet Name:";
            // 
            // textBox_QC_TCTrace_Excel
            // 
            this.textBox_QC_TCTrace_Excel.Location = new System.Drawing.Point(171, 68);
            this.textBox_QC_TCTrace_Excel.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_QC_TCTrace_Excel.Name = "textBox_QC_TCTrace_Excel";
            this.textBox_QC_TCTrace_Excel.Size = new System.Drawing.Size(193, 22);
            this.textBox_QC_TCTrace_Excel.TabIndex = 4;
            this.textBox_QC_TCTrace_Excel.Text = "QC_TCTrace.xlsx";
            // 
            // label_QC_TCTrace_Excel
            // 
            this.label_QC_TCTrace_Excel.AutoSize = true;
            this.label_QC_TCTrace_Excel.Location = new System.Drawing.Point(33, 68);
            this.label_QC_TCTrace_Excel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_QC_TCTrace_Excel.Name = "label_QC_TCTrace_Excel";
            this.label_QC_TCTrace_Excel.Size = new System.Drawing.Size(130, 17);
            this.label_QC_TCTrace_Excel.TabIndex = 3;
            this.label_QC_TCTrace_Excel.Text = "Export Excel Name:";
            // 
            // button_QC_TCTrace_Path
            // 
            this.button_QC_TCTrace_Path.Location = new System.Drawing.Point(600, 26);
            this.button_QC_TCTrace_Path.Margin = new System.Windows.Forms.Padding(4);
            this.button_QC_TCTrace_Path.Name = "button_QC_TCTrace_Path";
            this.button_QC_TCTrace_Path.Size = new System.Drawing.Size(75, 32);
            this.button_QC_TCTrace_Path.TabIndex = 2;
            this.button_QC_TCTrace_Path.Text = "Browser";
            this.button_QC_TCTrace_Path.UseVisualStyleBackColor = true;
            this.button_QC_TCTrace_Path.Click += new System.EventHandler(this.button_QC_TCTrace_Path_Click);
            // 
            // textBox_QC_TCTrace_Path
            // 
            this.textBox_QC_TCTrace_Path.Location = new System.Drawing.Point(171, 31);
            this.textBox_QC_TCTrace_Path.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_QC_TCTrace_Path.Name = "textBox_QC_TCTrace_Path";
            this.textBox_QC_TCTrace_Path.Size = new System.Drawing.Size(404, 22);
            this.textBox_QC_TCTrace_Path.TabIndex = 1;
            // 
            // label_QC_TCTrace_Path
            // 
            this.label_QC_TCTrace_Path.AutoSize = true;
            this.label_QC_TCTrace_Path.Location = new System.Drawing.Point(33, 31);
            this.label_QC_TCTrace_Path.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_QC_TCTrace_Path.Name = "label_QC_TCTrace_Path";
            this.label_QC_TCTrace_Path.Size = new System.Drawing.Size(85, 17);
            this.label_QC_TCTrace_Path.TabIndex = 0;
            this.label_QC_TCTrace_Path.Text = "Export Path:";
            // 
            // panel_QCExport
            // 
            this.panel_QCExport.Controls.Add(this.button_Export);
            this.panel_QCExport.Controls.Add(this.groupBox_QC_TCTrace);
            this.panel_QCExport.Controls.Add(this.groupBox_QC_TS);
            this.panel_QCExport.Controls.Add(this.groupBox_basic);
            this.panel_QCExport.Controls.Add(this.groupBox_QC_TC);
            this.panel_QCExport.Controls.Add(this.groupBox_QC_Req);
            this.panel_QCExport.Controls.Add(this.comboBox_exports);
            this.panel_QCExport.Controls.Add(this.label_exports);
            this.panel_QCExport.Location = new System.Drawing.Point(3, 2);
            this.panel_QCExport.Margin = new System.Windows.Forms.Padding(4);
            this.panel_QCExport.Name = "panel_QCExport";
            this.panel_QCExport.Size = new System.Drawing.Size(827, 928);
            this.panel_QCExport.TabIndex = 7;
            // 
            // Form_Migrate_Jama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 937);
            this.Controls.Add(this.panel_QCExport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form_Migrate_Jama";
            this.Text = "Migrate Jama - QC Export Excel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Migrate_Jama_FormClosed);
            this.Load += new System.EventHandler(this.Form_Migrate_Jama_Load);
            this.groupBox_basic.ResumeLayout(false);
            this.groupBox_basic.PerformLayout();
            this.groupBox_QC_TS.ResumeLayout(false);
            this.groupBox_QC_TS.PerformLayout();
            this.groupBox_QC_TC.ResumeLayout(false);
            this.groupBox_QC_TC.PerformLayout();
            this.groupBox_QC_Req.ResumeLayout(false);
            this.groupBox_QC_Req.PerformLayout();
            this.groupBox_QC_TCTrace.ResumeLayout(false);
            this.groupBox_QC_TCTrace.PerformLayout();
            this.panel_QCExport.ResumeLayout(false);
            this.panel_QCExport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox_exports;
        private System.Windows.Forms.Label label_exports;
        private System.Windows.Forms.GroupBox groupBox_basic;
        private System.Windows.Forms.Button button_TestQCConnect;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.TextBox textBox_Domain;
        private System.Windows.Forms.ComboBox comboBox_project;
        private System.Windows.Forms.Label label_project;
        private System.Windows.Forms.Label label_Domain;
        private System.Windows.Forms.GroupBox groupBox_QC_TS;
        private System.Windows.Forms.Label label_QC_TestSet_Path;
        private System.Windows.Forms.Label label_QC_TestSet_ExportPath;
        private System.Windows.Forms.TextBox textBox_QC_TestSet_Path;
        private System.Windows.Forms.Button button_QC_TestSet_ExportPath;
        private System.Windows.Forms.TextBox textBox_QC_TestSet_ExportPath;
        private System.Windows.Forms.Button button_Export;
        private System.Windows.Forms.GroupBox groupBox_QC_TC;
        private System.Windows.Forms.Label label_QC_TestCase_ExportPath;
        private System.Windows.Forms.Label label_QC_TestCase_Excel;
        private System.Windows.Forms.Button button_QC_TestCase_ExportPath;
        private System.Windows.Forms.TextBox textBox_QC_TestCase_ExportPath;
        private System.Windows.Forms.Label label_QC_TestCase_Sheet;
        private System.Windows.Forms.TextBox textBox_QC_TestCase_Excel;
        private System.Windows.Forms.TextBox textBox_QC_TestCase_Sheet;
        private System.Windows.Forms.Label label_QC_Req_Path;
        private System.Windows.Forms.TextBox textBox_QC_Req_Path;
        private System.Windows.Forms.Button button_QC_Req_Path;
        private System.Windows.Forms.Label label_QC_Req_Excel;
        private System.Windows.Forms.TextBox textBox_QC_Req_Excel;
        private System.Windows.Forms.Label label_QC_Req_Sheet;
        private System.Windows.Forms.TextBox textBox_QC_Req_Sheet;
        private System.Windows.Forms.GroupBox groupBox_QC_Req;
        private System.Windows.Forms.TextBox textBox_URL;
        private System.Windows.Forms.Label label_url;
        private System.Windows.Forms.CheckBox checkBox_remember;
        private System.Windows.Forms.GroupBox groupBox_QC_TCTrace;
        private System.Windows.Forms.TextBox textBox_QC_TCTrace_Excel;
        private System.Windows.Forms.Label label_QC_TCTrace_Excel;
        private System.Windows.Forms.Button button_QC_TCTrace_Path;
        private System.Windows.Forms.TextBox textBox_QC_TCTrace_Path;
        private System.Windows.Forms.Label label_QC_TCTrace_Path;
        private System.Windows.Forms.Panel panel_QCExport;
        private System.Windows.Forms.TextBox textBox_QC_TCTrace_Sheet;
        private System.Windows.Forms.Label label_QC_TCTrace_Sheet;
    }
}