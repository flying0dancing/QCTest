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
        

        private void button_QC_Req_Path_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog OpenFolderDialog = new FolderBrowserDialog();
            OpenFolderDialog.ShowNewFolderButton = false;
            OpenFolderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

            if (OpenFolderDialog.ShowDialog() == DialogResult.OK)
            {
                if (OpenFolderDialog.SelectedPath != null)
                { textBox_QCExport_Path.Text = OpenFolderDialog.SelectedPath.ToString(); }
            }
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            if (comboBox_exports.SelectedItem!=null)
            {
                this.tdconn = this.tdconn==null?connectQCConnection(false):this.tdconn;
                if (this.tdconn!=null)
                {
                    string QCExportPath = FileUtil.isNotEmptyStr(textBox_QCExport_Path.Text) ? textBox_QCExport_Path.Text.Trim() : "";
                    string QCExcelName = FileUtil.isNotEmptyStr(textBox_QCExport_Excel.Text) ? textBox_QCExport_Excel.Text.Trim() : "";
                    string QCExcelSheetName = FileUtil.isNotEmptyStr(textBox_QCExport_Sheet.Text) ? textBox_QCExport_Sheet.Text.Trim() : "";
                    string QCTestSetPath = QCExcelName;
                    string selected_export_type = comboBox_exports.SelectedItem.ToString();
                    
                    if (FileUtil.isNotEmptyStr(QCExportPath) && FileUtil.isNotEmptyStr(QCExcelName) && FileUtil.isNotEmptyStr(QCExcelSheetName))
                    {
                        Stopwatch stopwatch = new Stopwatch();
                        stopwatch.Start();
                        panel_QCExport.Enabled = false;
                        try
                        {
                            if (selected_export_type.Equals("QC Requirement"))
                            {
                                Console.WriteLine("========== QC Requirement ==========\n");
                                QCReq.DisplayRequirements(ref this.tdconn, QCExportPath, QCExcelName, QCExcelSheetName);
                            }
                            else if (selected_export_type.Equals("QC Test Plan"))
                            {
                                Console.WriteLine("========== QC Test Plan ==========\n");
                                QCTestCase.DisplayTestCases(ref this.tdconn, QCExportPath, QCExcelName, QCExcelSheetName);

                            }
                            else if (selected_export_type.Equals("QC Test Lab"))
                            {
                                Console.WriteLine("========== QC Test Lab ==========\n");
                                //QCTSInstanceStep.DisplayTestSetFolder(ref this.tdconn, QCTestSetPath, QCExportPath);
                                List<List<string>> searchResults= QCTSInstanceStep.SearchTestSetFolder(ref this.tdconn, QCTestSetPath);
                                List<string> resultSearchedFolders = searchResults.ElementAt(0);
                                List<string> resultNOtSearched = searchResults.ElementAt(1);
                                if (resultNOtSearched.Count > 0)
                                {
                                    string str=string.Join("\n", resultNOtSearched);
                                    MessageBox.Show($"please check export information! \nSome paths are not searched:\n{str}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    foreach (string searchedFolder in resultSearchedFolders)
                                    {
                                        Console.WriteLine($"searched Node Path: {searchedFolder}");
                                        QCTSInstanceStep.DisplayTestSetFolder(ref this.tdconn, searchedFolder, QCExportPath);
                                    }
                                }

                            }
                            else if (selected_export_type.Equals("QC Requirement--Test Case"))
                            {
                                Console.WriteLine("========== QC Requirement--Test Case ==========\n");
                                QCTCTrace.DisplayTCTrace(ref this.tdconn, QCExportPath, QCExcelName, QCExcelSheetName);
                            }
                        }
                        catch (Exception ex)
                        {
                            panel_QCExport.Enabled = true;
                            MessageBox.Show($"Connection tested Fail!\n\n{ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                        panel_QCExport.Enabled = true;
                        stopwatch.Stop();
                        MessageBox.Show($"Export used {stopwatch.Elapsed.TotalSeconds:F2} seconds.");
                    }
                    else
                    {
                        MessageBox.Show("please input export information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //disconnect QCConnection in FormClosed function;
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
           //Point location= new Point(11, 260);
            if (selected_export_type.Equals("QC Requirement"))
            {
                //MessageBox.Show("QC Requirement");
                groupBox_QCExport.Show();
                groupBox_QCExport.Text = "Export QC Requirements";
                //excel
                label_QCExport_Excel.Text = "Export Excel Name:";
                textBox_QCExport_Excel.Text = "QC_Req.xlsx";
                textBox_QCExport_Excel.Width = textBox_QCExport_Path.Width / 2;
                //sheet
                label_QCExport_Sheet.Show();
                textBox_QCExport_Sheet.Text = "Query1";
                textBox_QCExport_Sheet.Show();

            }
            else if (selected_export_type.Equals("QC Test Plan"))
            {
                //MessageBox.Show("QC Test Plan");
                groupBox_QCExport.Show();
                groupBox_QCExport.Text = "Export QC Test Plan (Test Cases)";
                //excel
                label_QCExport_Excel.Text = "Export Excel Name:";
                textBox_QCExport_Excel.Text = "QC_TestCases.xlsx";
                textBox_QCExport_Excel.Width = textBox_QCExport_Path.Width / 2;
                //sheet
                label_QCExport_Sheet.Show();
                textBox_QCExport_Sheet.Text = "Query1";
                textBox_QCExport_Sheet.Show();
            }
            else if (selected_export_type.Equals("QC Test Lab"))
            {
                //MessageBox.Show("QC Test Lab");
                groupBox_QCExport.Show();
                groupBox_QCExport.Text = "Export QC Test Lab (Test Sets)";
                //excel
                label_QCExport_Excel.Text = "TestSet Path in QC:";
                textBox_QCExport_Excel.Text = "root";
                textBox_QCExport_Excel.Width = textBox_QCExport_Path.Width;
                //sheet
                label_QCExport_Sheet.Hide();
                textBox_QCExport_Sheet.Text = "Query1";//avoid user make it empty in other export type
                textBox_QCExport_Sheet.Hide();
            }
            else if (selected_export_type.Equals("QC Requirement--Test Case"))
            {
                //MessageBox.Show("QC Requirement--Test Case");
                groupBox_QCExport.Show();
                groupBox_QCExport.Text = "Export QC Relationship of Requirement and Test Case";
                //excel
                label_QCExport_Excel.Text = "Export Excel Name:";
                textBox_QCExport_Excel.Text = "QC_TCTrace.xlsx";
                textBox_QCExport_Excel.Width = textBox_QCExport_Path.Width / 2;
                //sheet
                label_QCExport_Sheet.Show();
                textBox_QCExport_Sheet.Text = "Query1";
                textBox_QCExport_Sheet.Show();

            }

        }

        

        private void button_TestQCConnect_Click(object sender, EventArgs e)
        {
            this.tdconn = this.tdconn==null?connectQCConnection(true): this.tdconn;

            //disconnect QCConnection in FormClosed function;
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
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;

            this.Location = new Point(screenWidth / 2 - formWidth / 2, screenHeight / 2 - formHeight / 2);
            
            groupBox_QCExport.Hide();
            
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

        
    }
}
