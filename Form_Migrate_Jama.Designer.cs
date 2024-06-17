
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
            this.button_Export = new System.Windows.Forms.Button();
            this.label_QCExport_Path = new System.Windows.Forms.Label();
            this.textBox_QCExport_Path = new System.Windows.Forms.TextBox();
            this.button_QCExport_Path = new System.Windows.Forms.Button();
            this.label_QCExport_Excel = new System.Windows.Forms.Label();
            this.textBox_QCExport_Excel = new System.Windows.Forms.TextBox();
            this.label_QCExport_Sheet = new System.Windows.Forms.Label();
            this.textBox_QCExport_Sheet = new System.Windows.Forms.TextBox();
            this.groupBox_QCExport = new System.Windows.Forms.GroupBox();
            this.panel_QCExport = new System.Windows.Forms.Panel();
            this.groupBox_basic.SuspendLayout();
            this.groupBox_QCExport.SuspendLayout();
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
            this.comboBox_exports.Location = new System.Drawing.Point(173, 252);
            this.comboBox_exports.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox_exports.Name = "comboBox_exports";
            this.comboBox_exports.Size = new System.Drawing.Size(212, 24);
            this.comboBox_exports.TabIndex = 8;
            this.comboBox_exports.SelectedIndexChanged += new System.EventHandler(this.comboBox_exports_SelectedIndexChanged);
            // 
            // label_exports
            // 
            this.label_exports.AutoSize = true;
            this.label_exports.Location = new System.Drawing.Point(40, 252);
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
            this.groupBox_basic.Location = new System.Drawing.Point(10, 10);
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
            // button_Export
            // 
            this.button_Export.Location = new System.Drawing.Point(619, 240);
            this.button_Export.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(173, 43);
            this.button_Export.TabIndex = 5;
            this.button_Export.Text = "Export";
            this.button_Export.UseVisualStyleBackColor = true;
            this.button_Export.Click += new System.EventHandler(this.button_Export_Click);
            // 
            // label_QCExport_Path
            // 
            this.label_QCExport_Path.AutoSize = true;
            this.label_QCExport_Path.Location = new System.Drawing.Point(33, 31);
            this.label_QCExport_Path.Name = "label_QCExport_Path";
            this.label_QCExport_Path.Size = new System.Drawing.Size(85, 17);
            this.label_QCExport_Path.TabIndex = 0;
            this.label_QCExport_Path.Text = "Export Path:";
            // 
            // textBox_QCExport_Path
            // 
            this.textBox_QCExport_Path.Location = new System.Drawing.Point(171, 31);
            this.textBox_QCExport_Path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_QCExport_Path.Name = "textBox_QCExport_Path";
            this.textBox_QCExport_Path.Size = new System.Drawing.Size(404, 22);
            this.textBox_QCExport_Path.TabIndex = 1;
            // 
            // button_QCExport_Path
            // 
            this.button_QCExport_Path.Location = new System.Drawing.Point(600, 26);
            this.button_QCExport_Path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_QCExport_Path.Name = "button_QCExport_Path";
            this.button_QCExport_Path.Size = new System.Drawing.Size(75, 32);
            this.button_QCExport_Path.TabIndex = 2;
            this.button_QCExport_Path.Text = "Browser";
            this.button_QCExport_Path.UseVisualStyleBackColor = true;
            this.button_QCExport_Path.Click += new System.EventHandler(this.button_QC_Req_Path_Click);
            // 
            // label_QCExport_Excel
            // 
            this.label_QCExport_Excel.AutoSize = true;
            this.label_QCExport_Excel.Location = new System.Drawing.Point(33, 68);
            this.label_QCExport_Excel.Name = "label_QCExport_Excel";
            this.label_QCExport_Excel.Size = new System.Drawing.Size(130, 17);
            this.label_QCExport_Excel.TabIndex = 3;
            this.label_QCExport_Excel.Text = "Export Excel Name:";
            // 
            // textBox_QCExport_Excel
            // 
            this.textBox_QCExport_Excel.Location = new System.Drawing.Point(171, 68);
            this.textBox_QCExport_Excel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_QCExport_Excel.Name = "textBox_QCExport_Excel";
            this.textBox_QCExport_Excel.Size = new System.Drawing.Size(193, 22);
            this.textBox_QCExport_Excel.TabIndex = 4;
            this.textBox_QCExport_Excel.Text = "QC_Req.xlsx";
            // 
            // label_QCExport_Sheet
            // 
            this.label_QCExport_Sheet.AutoSize = true;
            this.label_QCExport_Sheet.Location = new System.Drawing.Point(33, 105);
            this.label_QCExport_Sheet.Name = "label_QCExport_Sheet";
            this.label_QCExport_Sheet.Size = new System.Drawing.Size(134, 17);
            this.label_QCExport_Sheet.TabIndex = 5;
            this.label_QCExport_Sheet.Text = "Export Sheet Name:";
            // 
            // textBox_QCExport_Sheet
            // 
            this.textBox_QCExport_Sheet.Location = new System.Drawing.Point(171, 105);
            this.textBox_QCExport_Sheet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_QCExport_Sheet.Name = "textBox_QCExport_Sheet";
            this.textBox_QCExport_Sheet.Size = new System.Drawing.Size(193, 22);
            this.textBox_QCExport_Sheet.TabIndex = 6;
            this.textBox_QCExport_Sheet.Text = "Query1";
            // 
            // groupBox_QCExport
            // 
            this.groupBox_QCExport.Controls.Add(this.textBox_QCExport_Sheet);
            this.groupBox_QCExport.Controls.Add(this.label_QCExport_Sheet);
            this.groupBox_QCExport.Controls.Add(this.textBox_QCExport_Excel);
            this.groupBox_QCExport.Controls.Add(this.label_QCExport_Excel);
            this.groupBox_QCExport.Controls.Add(this.button_QCExport_Path);
            this.groupBox_QCExport.Controls.Add(this.textBox_QCExport_Path);
            this.groupBox_QCExport.Controls.Add(this.label_QCExport_Path);
            this.groupBox_QCExport.Location = new System.Drawing.Point(10, 290);
            this.groupBox_QCExport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_QCExport.Name = "groupBox_QCExport";
            this.groupBox_QCExport.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_QCExport.Size = new System.Drawing.Size(800, 144);
            this.groupBox_QCExport.TabIndex = 13;
            this.groupBox_QCExport.TabStop = false;
            this.groupBox_QCExport.Text = "Export QC Requirements";
            // 
            // panel_QCExport
            // 
            this.panel_QCExport.Controls.Add(this.button_Export);
            this.panel_QCExport.Controls.Add(this.groupBox_basic);
            this.panel_QCExport.Controls.Add(this.groupBox_QCExport);
            this.panel_QCExport.Controls.Add(this.comboBox_exports);
            this.panel_QCExport.Controls.Add(this.label_exports);
            this.panel_QCExport.Location = new System.Drawing.Point(3, 2);
            this.panel_QCExport.Margin = new System.Windows.Forms.Padding(4);
            this.panel_QCExport.Name = "panel_QCExport";
            this.panel_QCExport.Size = new System.Drawing.Size(827, 444);
            this.panel_QCExport.TabIndex = 7;
            // 
            // Form_Migrate_Jama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 453);
            this.Controls.Add(this.panel_QCExport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form_Migrate_Jama";
            this.Text = "Migrate Jama - QC Excel Report";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Migrate_Jama_FormClosed);
            this.Load += new System.EventHandler(this.Form_Migrate_Jama_Load);
            this.groupBox_basic.ResumeLayout(false);
            this.groupBox_basic.PerformLayout();
            this.groupBox_QCExport.ResumeLayout(false);
            this.groupBox_QCExport.PerformLayout();
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
        private System.Windows.Forms.Button button_Export;
        private System.Windows.Forms.Label label_QCExport_Path;
        private System.Windows.Forms.TextBox textBox_QCExport_Path;
        private System.Windows.Forms.Button button_QCExport_Path;
        private System.Windows.Forms.Label label_QCExport_Excel;
        private System.Windows.Forms.TextBox textBox_QCExport_Excel;
        private System.Windows.Forms.Label label_QCExport_Sheet;
        private System.Windows.Forms.TextBox textBox_QCExport_Sheet;
        private System.Windows.Forms.GroupBox groupBox_QCExport;
        private System.Windows.Forms.TextBox textBox_URL;
        private System.Windows.Forms.Label label_url;
        private System.Windows.Forms.CheckBox checkBox_remember;
        private System.Windows.Forms.Panel panel_QCExport;
    }
}