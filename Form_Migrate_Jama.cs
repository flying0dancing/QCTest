using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TDAPIOLELib;

namespace QCTest
{
    public partial class Form_Migrate_Jama : Form
    {
        public Form_Migrate_Jama()
        {
            InitializeComponent();
        }
        private TDConnection tdconn=null;
        private void button_QC_TestSet_ExportPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog OpenFolderDialog = new FolderBrowserDialog();
            
            OpenFolderDialog.ShowNewFolderButton = false;
            OpenFolderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            if (OpenFolderDialog.ShowDialog() == DialogResult.OK)
            {
                if (OpenFolderDialog.SelectedPath != null)
                { textBox_QC_TestSet_ExportPath.Text = OpenFolderDialog.SelectedPath.ToString(); }
            }
        }

        private void button_QC_TestCase_ExportPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog OpenFolderDialog = new FolderBrowserDialog();
            OpenFolderDialog.ShowNewFolderButton = false;
            OpenFolderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            if (OpenFolderDialog.ShowDialog() == DialogResult.OK)
            {
                if (OpenFolderDialog.SelectedPath != null)
                { textBox_QC_TestCase_ExportPath.Text = OpenFolderDialog.SelectedPath.ToString(); }
            }
        }

        private void button_QC_Req_Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog OpenFolderDialog = new FolderBrowserDialog();
            OpenFolderDialog.ShowNewFolderButton = false;
            OpenFolderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            if (OpenFolderDialog.ShowDialog() == DialogResult.OK)
            {
                if (OpenFolderDialog.SelectedPath != null)
                { textBox_QC_Req_Path.Text = OpenFolderDialog.SelectedPath.ToString(); }
            }
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            if (comboBox_exports.SelectedItem!=null)
            {
                this.tdconn = this.tdconn==null?connectQCConnection(false):this.tdconn;
                if (this.tdconn!=null)
                {
                    string selected_export_type = comboBox_exports.SelectedItem.ToString();
                    if (selected_export_type.Equals("QC Requirement"))
                    {
                        panel_QCExport.Enabled = false;
                        string QCExportPath = FileUtil.isNotEmptyStr(textBox_QC_Req_Path.Text) ? textBox_QC_Req_Path.Text.Trim() : "";
                        string QCExcelName = FileUtil.isNotEmptyStr(textBox_QC_Req_Excel.Text) ? textBox_QC_Req_Excel.Text.Trim() : "";
                        string QCExcelSheetName = FileUtil.isNotEmptyStr(textBox_QC_Req_Sheet.Text) ? textBox_QC_Req_Sheet.Text.Trim() : "";

                        if (FileUtil.isNotEmptyStr(QCExportPath) &&  FileUtil.isNotEmptyStr(QCExcelName) && FileUtil.isNotEmptyStr(QCExcelSheetName))
                        {
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            QCReq.DisplayRequirements(ref this.tdconn, QCExportPath, QCExcelName, QCExcelSheetName);
                            stopwatch.Stop();
                            MessageBox.Show($"Export used {stopwatch.Elapsed.TotalSeconds:F2} seconds.");
                        }
                        else
                        {
                            MessageBox.Show("please input export information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        panel_QCExport.Enabled = true;

                    }
                    else if (selected_export_type.Equals("QC Test Plan"))
                    {
                        Console.WriteLine("========== QC Test Plan ==========\n");
                        panel_QCExport.Enabled = false;
                        string QCTestCaseExportPath = FileUtil.isNotEmptyStr(textBox_QC_TestCase_ExportPath.Text) ? textBox_QC_TestCase_ExportPath.Text.Trim() : "";
                        string QCTestCaseExcelName = FileUtil.isNotEmptyStr(textBox_QC_TestCase_Excel.Text) ? textBox_QC_TestCase_Excel.Text.Trim() : "";
                        string QCTestCaseExcelSheetName = FileUtil.isNotEmptyStr(textBox_QC_TestCase_Sheet.Text) ? textBox_QC_TestCase_Sheet.Text.Trim() : "";
                        
                        if (FileUtil.isNotEmptyStr(QCTestCaseExportPath) && FileUtil.isNotEmptyStr(QCTestCaseExcelName) && FileUtil.isNotEmptyStr(QCTestCaseExcelSheetName))
                        {
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            QCTestCase.DisplayTestCases(ref this.tdconn, QCTestCaseExportPath, QCTestCaseExcelName, QCTestCaseExcelSheetName);
                            stopwatch.Stop();
                            MessageBox.Show($"Export used {stopwatch.Elapsed.TotalSeconds:F2} seconds.");
                        }
                        else
                        {
                            MessageBox.Show("please input export information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        panel_QCExport.Enabled = true;
                    }
                    else if (selected_export_type.Equals("QC Test Lab"))
                    {
                        Console.WriteLine("QC Test Lab");
                        panel_QCExport.Enabled = false;
                        string QCTestSetPath = FileUtil.isNotEmptyStr(textBox_QC_TestSet_Path.Text) ? textBox_QC_TestSet_Path.Text.Trim() : "";
                        string QCTestSetExportPath = FileUtil.isNotEmptyStr(textBox_QC_TestSet_ExportPath.Text) ? textBox_QC_TestSet_ExportPath.Text.Trim() : "";
                        if (FileUtil.isNotEmptyStr(QCTestSetPath) && FileUtil.isNotEmptyStr(QCTestSetExportPath))
                        {
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            QCTSInstanceStep.DisplayTestSetFolder(ref this.tdconn, QCTestSetPath, QCTestSetExportPath);
                            stopwatch.Stop();
                            MessageBox.Show($"Export used {stopwatch.Elapsed.TotalSeconds:F2} seconds.");
                        }
                        else
                        {
                            MessageBox.Show("please input export information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        panel_QCExport.Enabled = true;
                    }
                    else if (selected_export_type.Equals("QC Requirement--Test Case"))
                    {
                        Console.WriteLine("========== QC Requirement--Test Case ==========\n");
                        panel_QCExport.Enabled = false;
                        string QCTCTraceExportPath = FileUtil.isNotEmptyStr(textBox_QC_TCTrace_Path.Text) ? textBox_QC_TCTrace_Path.Text.Trim() : "";
                        string QCTCTraceExcelName = FileUtil.isNotEmptyStr(textBox_QC_TCTrace_Excel.Text) ? textBox_QC_TCTrace_Excel.Text.Trim() : "";
                        string QCTCTraceExcelSheetName = FileUtil.isNotEmptyStr(textBox_QC_TestCase_Sheet.Text) ? textBox_QC_TestCase_Sheet.Text.Trim() : "";

                        if (FileUtil.isNotEmptyStr(QCTCTraceExportPath) && FileUtil.isNotEmptyStr(QCTCTraceExcelName) && FileUtil.isNotEmptyStr(QCTCTraceExcelSheetName))
                        {
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            QCTCTrace.DisplayTCTrace(ref this.tdconn, QCTCTraceExportPath, QCTCTraceExcelName, QCTCTraceExcelSheetName);
                            stopwatch.Stop();
                            MessageBox.Show($"Export used {stopwatch.Elapsed.TotalSeconds:F2} seconds.");
                        }
                        else
                        {
                            MessageBox.Show("please input export information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        panel_QCExport.Enabled = true;
                    }

                    //disconnectQCConnection in form_closed function.
                }
                
            }
            else
            {
                MessageBox.Show("Please select export type.");
            }

        }


        private void comboBox_exports_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_export_type = comboBox_exports.SelectedItem.ToString();
            Point location= new Point(11, 260);
            if (selected_export_type.Equals("QC Requirement"))
            {
                //MessageBox.Show("QC Requirement");
                groupBox_QC_Req.Show();
                groupBox_QC_Req.Location = location;
                groupBox_QC_TC.Hide();
                groupBox_QC_TS.Hide();
                groupBox_QC_TCTrace.Hide();
            }
            else if (selected_export_type.Equals("QC Test Plan"))
            {
                //MessageBox.Show("QC Test Plan");
                groupBox_QC_Req.Hide();
                groupBox_QC_TC.Show();
                groupBox_QC_TC.Location = location;
                groupBox_QC_TS.Hide();
                groupBox_QC_TCTrace.Hide();
            }
            else if (selected_export_type.Equals("QC Test Lab"))
            {
                //MessageBox.Show("QC Test Lab");
                groupBox_QC_Req.Hide();
                groupBox_QC_TC.Hide();
                groupBox_QC_TS.Show();
                groupBox_QC_TS.Location = location;
                groupBox_QC_TCTrace.Hide();
                
            }
            else if (selected_export_type.Equals("QC Requirement--Test Case"))
            {
                //MessageBox.Show("QC Requirement--Test Case");
                groupBox_QC_Req.Hide();
                groupBox_QC_TC.Hide();
                groupBox_QC_TS.Hide();
                groupBox_QC_TCTrace.Show();
                groupBox_QC_TCTrace.Location = location;

            }


        }

        

        private void button_TestQCConnect_Click(object sender, EventArgs e)
        {
            this.tdconn = this.tdconn==null?connectQCConnection(true): this.tdconn;
            //disconnectQCConnection();
        }

        private TDConnection connectQCConnection(bool showMsgBox)
        {
            TDConnection tdconn = null;
            bool flag = false;
            string strServerURL = "http://denamssvqcent.sds.sybrondental.com:8080/qcbin";
            string strDomainName = "ENVISTAQC";
            string strProjectName = "";
            string username = "";
            string pwd = "";
            if (FileUtil.isNotEmptyStr(textBox_URL.Text))
            {
                strServerURL = textBox_URL.Text.ToString();
                if (FileUtil.isNotEmptyStr(textBox_Domain.Text))
                {
                    strDomainName = textBox_Domain.Text.ToString();
                    if (comboBox_project.SelectedItem != null)
                    {
                        strProjectName = comboBox_project.SelectedItem.ToString();
                        if (FileUtil.isNotEmptyStr(textBox_User.Text))
                        {
                            username = textBox_User.Text;
                            if (FileUtil.isNotEmptyStr(textBox_password.Text))
                            {
                                pwd = textBox_password.Text;
                                tdconn = new TDConnection();
                                try
                                {
                                    tdconn.InitConnectionEx(strServerURL);
                                    tdconn.ConnectProjectEx(strDomainName, strProjectName, username, pwd);
                                    if (tdconn.LoggedIn == true)
                                    {
                                        if (tdconn.Connected == true)
                                        {
                                            flag = true;
                                            if (showMsgBox)
                                            {
                                                MessageBox.Show("Connection tested OK!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please check connection information or contact admin!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            
                                        }
                                        
                                    }
                                    else
                                    {
                                        
                                        MessageBox.Show("Please check login information or contact admin!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                                       
                                    }
                                    if (!flag)
                                    {
                                        tdconn.DisconnectProject();
                                        tdconn.Logout();
                                        tdconn.ReleaseConnection();
                                        tdconn = null;
                                    }
                                    
                                }
                                catch (Exception ex)
                                    {
                                        MessageBox.Show($"Connection tested Fail!\n\n{ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        tdconn = null;
                                }
                            }
                        }
                    }
                }
            }
            return tdconn;
        }

        private void disconnectQCConnection()
        {
            if (this.tdconn != null)
            {
                this.tdconn.DisconnectProject();
                this.tdconn.Logout();
                this.tdconn.ReleaseConnection();
                this.tdconn = null;
            }
        }

        private void Form_Migrate_Jama_Load(object sender, EventArgs e)
        {
            Height = 500;
            panel_QCExport.Height = 500;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;

            this.Location = new Point(screenWidth / 2 - formWidth / 2, screenHeight / 2 - formHeight / 2);
            
            groupBox_QC_Req.Hide();
            groupBox_QC_TC.Hide();
            groupBox_QC_TS.Hide();
            groupBox_QC_TCTrace.Hide();
            
            if (Properties.Settings.Default.RememberMe)
            {
                checkBox_remember.Checked = true;
                textBox_URL.Text = Properties.Settings.Default.QCServerURL;
                textBox_Domain.Text = Properties.Settings.Default.QCDomain;
                textBox_User.Text = Properties.Settings.Default.QCUser;
                textBox_password.Text = Properties.Settings.Default.QCPassword;
                //MessageBox.Show($"property:{Properties.Settings.Default.QCProject}");
                if (existedInComboBox(comboBox_project, Properties.Settings.Default.QCProject))
                {
                    //MessageBox.Show("existed");
                    comboBox_project.SelectedItem = Properties.Settings.Default.QCProject;
                }
                else
                {
                    if (FileUtil.isNotEmptyStr(Properties.Settings.Default.QCProject))
                    {
                        comboBox_project.Items.Add(Properties.Settings.Default.QCProject);
                        comboBox_project.SelectedText = Properties.Settings.Default.QCProject;
                    }
                }

            }
            else
            {
                comboBox_project.SelectedItem = "Dallas";
            }

        }

        private bool existedInComboBox(ComboBox comboBox,string value) {
            bool exists = false;
            if (FileUtil.isNotEmptyStr(value))
            {
                // 假设comboBox是你的ComboBox控件，value是你要检查的值
                exists = comboBox.Items.Cast<object>().Any(item => item.ToString() == value);
            }
            
            return exists;
        }
        private void Form_Migrate_Jama_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (checkBox_remember.Checked)
            {
                Properties.Settings.Default.RememberMe = true;
                Properties.Settings.Default.QCServerURL = textBox_URL.Text;
                Properties.Settings.Default.QCDomain = textBox_Domain.Text;
                Properties.Settings.Default.QCProject = comboBox_project.SelectedItem == null ? (comboBox_project.Text == null ? "" : comboBox_project.Text) : comboBox_project.SelectedItem.ToString();
                Properties.Settings.Default.QCUser = textBox_User.Text;
                Properties.Settings.Default.QCPassword = textBox_password.Text;
            }
            else
            {
                Properties.Settings.Default.RememberMe = false;
                Properties.Settings.Default.QCServerURL = "http://denamssvqcent.sds.sybrondental.com:8080/qcbin";
                Properties.Settings.Default.QCDomain = "";
                Properties.Settings.Default.QCProject = "";
                Properties.Settings.Default.QCUser = "";
                Properties.Settings.Default.QCPassword = "";
            }
            Properties.Settings.Default.Save();
            disconnectQCConnection();

        }

        private void button_QC_TCTrace_Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog OpenFolderDialog = new FolderBrowserDialog();

            OpenFolderDialog.ShowNewFolderButton = false;
            OpenFolderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            if (OpenFolderDialog.ShowDialog() == DialogResult.OK)
            {
                if (OpenFolderDialog.SelectedPath != null)
                { textBox_QC_TCTrace_Path.Text = OpenFolderDialog.SelectedPath.ToString(); }
            }
        }
    }
}
