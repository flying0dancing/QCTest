using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Windows.Forms;
//using Mercury.TD.Client.Ota.QC9;
using TDAPIOLELib;

namespace QCTest
{
    
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Migrate_Jama());
            
        }

        static void main_inner()
        {
            string strServerURL = ConfigurationManager.AppSettings["QCserverURL"].ToString();
            string strDomainName = ConfigurationManager.AppSettings["QCdomainName"].ToString();
            string strProjectName = ConfigurationManager.AppSettings["QCprojectName"].ToString();
            string username = ConfigurationManager.AppSettings["username"].ToString();
            string pwd = ConfigurationManager.AppSettings["userpassword"].ToString();

            //declare an object of TDConnection
            TDConnection tdconn = new TDConnection();
            tdconn.InitConnectionEx(strServerURL);
            tdconn.ConnectProjectEx(strDomainName, strProjectName, username, pwd);

            //DisplayEffortTC(ref tdconn, strReleaseFolder, strReleaseNo);//invalid

            //DisplayFields(ref tdconn);
            //DisplayTestInstances(ref tdconn); //invalid
            //TotalofTestInstances(ref tdconn, @"Root\MAS\v2.20.0;Root\MAS\v2.20.0\Cycle4; ;Root\MAS\v2.21.0;");//invalid
            //DisplayCountofReqsTests(ref tdconn, strReleaseFolder, strReleaseNo);//invalid

            //TotalofReqsTests(ref tdconn, ConfigurationManager.AppSettings["QCReleaseFullPaths"].ToString());
            string QCTestCaseExportPath = ConfigurationManager.AppSettings["QC_TestCase_ExportPath"].ToString();
            string QCTestCaseExcelName = ConfigurationManager.AppSettings["QC_TestCase_Excel"].ToString();
            string QCTestCaseExcelSheetName = ConfigurationManager.AppSettings["QC_TestCase_Sheet"].ToString();
            QCTestCase.DisplayTestCases(ref tdconn, QCTestCaseExportPath, QCTestCaseExcelName, QCTestCaseExcelSheetName);

            string QCTestSetPath = ConfigurationManager.AppSettings["QC_TestSet_Path"].ToString();
            string QCTestSetExportPath = ConfigurationManager.AppSettings["QC_TestSet_ExportPath"].ToString();

            QCTSInstanceStep.DisplayTestSetFolder(ref tdconn, QCTestSetPath, QCTestSetExportPath);
            //TotalofTSTest(ref tdconn, ConfigurationManager.AppSettings["QCTSTestFullPaths"].ToString());
            //DrawTSTestGraph(ref tdconn, ConfigurationManager.AppSettings["RectangleChartForTSTest_Path"].ToString(), ConfigurationManager.AppSettings["RectangleChartForTSTest_SavedLocation"].ToString());
            //DrawTestGraph(ref tdconn, ConfigurationManager.AppSettings["RectangleChartForItem_Product"].ToString(), ConfigurationManager.AppSettings["RectangleChartForItem_Release"].ToString(), ConfigurationManager.AppSettings["RectangleChartForItem_SavedLocation"].ToString());


            Console.ReadLine();
            tdconn.DisconnectProject();
            tdconn.Logout();
            tdconn.ReleaseConnection();
            tdconn = null;
        }
        static void DisplayEffortTC(ref TDConnection tdconn, string strProduct, string strRelease)
        {
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayEffortTC: START");
            Console.WriteLine("***************************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayEffortTC: Product[{0}],Release[{1}]", strProduct, strRelease);
            Console.WriteLine("***************************************");
            Console.WriteLine();

            TreeManager oTreeManager = tdconn.TreeManager;
            SubjectNode oSubjectNode = oTreeManager.get_NodeByPath(@"Subject\" + strProduct);
            int count = 0;
            float effort = 0;
            RecursiveSubjectNodeTree(oSubjectNode, strRelease, ref count, ref effort);
            Console.WriteLine("Total Test Cases: "+count);
            Console.WriteLine("Total TC Design Effort(H): " + effort);

            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayEffortTC: END");
            Console.WriteLine("***************************************");
            Console.WriteLine();

        }

        static void RecursiveSubjectNodeTree(SubjectNode oSubjectNode, string strRelease, ref int count, ref float effort)
        {
            if (oSubjectNode.Count != 0)
            {
                List SubjectNodeList = oSubjectNode.NewList();
                foreach (SubjectNode ChildNodeTmp in SubjectNodeList)
                {
                    //Console.WriteLine(ChildNodeTmp.Path);
                    RecursiveSubjectNodeTree(ChildNodeTmp, strRelease, ref count, ref effort);
                }
            }
            else
            {
                TestFactory oTestFactory = oSubjectNode.TestFactory;
                List TestFactoryList = oTestFactory.NewList("");
                
                foreach (Test oTestTmp in TestFactoryList)
                {
                    //Console.WriteLine(oTestTmp["TS_USER_11"]);//04. Release No
                    if (oTestTmp["TS_USER_11"] == strRelease)
                    {
                        count++;
                        if ((string)oTestTmp["TS_USER_13"]!=null)
                        {
                            effort += float.Parse((string)oTestTmp["TS_USER_13"]);
                        }
                        
                    }
                }
               
            }
        }

        //Goal: display total amount of searched product and release
        //argument:product name,release no.
        //use one function:CountofReqsTests
        //suit for releases\Product\release, not suit for releases\Product\...\release 
        //return: NA
        //useable:NA
        static void DisplayCountofReqsTests(ref TDConnection tdconn, string strProduct, string strRelease)
        {
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayCountofReqsTests: START");
            Console.WriteLine("***************************************");
            Console.WriteLine();

            ReleaseFolderFactory oReleaseFolderFactory = tdconn.ReleaseFolderFactory;
            TDFilter oTDFilter = oReleaseFolderFactory.Filter;
            oTDFilter["RF_NAME"] = strProduct;
            List ReleaseFolderList = oTDFilter.NewList();
            foreach (ReleaseFolder oReleaseFolderTmp in ReleaseFolderList)
            {
                //Console.WriteLine(oReleaseFolderTmp.Name);
                ReleaseFactory oReleaseFactory = oReleaseFolderTmp.ReleaseFactory;
                oTDFilter = oReleaseFactory.Filter;
                oTDFilter["REL_NAME"] = strRelease;
                List ReleaseList = oTDFilter.NewList();
                foreach (Release oReleaseTmp in ReleaseList)
                {
                    //Console.WriteLine(oReleaseTmp.Name);
                    CycleFactory oCycleFactory = oReleaseTmp.CycleFactory;
                    List CycleList = oCycleFactory.NewList("");
                    foreach (Cycle oCycleTmp in CycleList)
                    {
                        //Console.WriteLine(oCycleTmp.Name);
                        string str_Rel_Path = @"Releases\" + oReleaseFolderTmp.Name + @"\" + oReleaseTmp.Name + @"\" + oCycleTmp.Name;
                        Console.WriteLine(str_Rel_Path);
                        CountofReqsTests(ref tdconn, str_Rel_Path,"cycle");
                    }
                }
            }


            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayCountofReqsTests: END");
            Console.WriteLine("***************************************");
            Console.WriteLine();

        }

        //Goal: display total req,test,effort of searched many fullpathes of release
        //argument:fullpath.
        //call functions:NA
        //suit for releases\Product\release, also suit for releases\Product\...\release 
        //return: NA
        //useable:QA statistics
        static void CountofReqsTests(ref TDConnection tdconn, string strPath,string CycleName)
        {
            //string ProductName = string.Empty, ReleaseNo = string.Empty, CycleNo = string.Empty;
            string[] str_RelCyclePath = strPath.Split(';');
            foreach (string strRelCyclePath in str_RelCyclePath)
            {
                if (strRelCyclePath!=null)
                {
                    ReqFactory oReqFactory = tdconn.ReqFactory;
                    HierarchyFilter oHierarchyFilter = oReqFactory.Filter;
                    oHierarchyFilter.KeepHierarchical = false;
                    //oHierarchyFilter["RQ_TARGET_ID"]
                    if (CycleName!=string.Empty)
                    {
                        oHierarchyFilter["RQ_TARGET_RCYC"] = "^" + strRelCyclePath + "^";
                    }
                    else
                    {
                        oHierarchyFilter["RQ_TARGET_REL"] = "^" + strRelCyclePath + "^";
                    }
                    
                    List ReqList = oHierarchyFilter.NewList();
                    //string[] arrProdRelCyl=strRelCyclePath.Split('\\');
                    //CycleNo = arrProdRelCyl[arrProdRelCyl.Length - 1];
                    //ReleaseNo = arrProdRelCyl[arrProdRelCyl.Length - 2];
                    //ProductName = arrProdRelCyl[1];
                    //if (arrProdRelCyl[2]!=ReleaseNo)
                    //{
                    //    for (int i = 2; i < arrProdRelCyl.Length-2; i++)
                    //    {
                    //        ProductName = ProductName+"\\"+arrProdRelCyl[i];
                    //    }
                    //}
                    if (ReqList.Count>0)
                    {
                        int TestCaseCount = 0, ReqCoveredCount = 0;
                        int ReqFeatureCount = 0, ReqDefectCount = 0; int ReqInvalidCount = 0;
                        float TestCaseDesigneffort = 0;
                        foreach (Req oReqTmp in ReqList)
                        {
                           
                            if (oReqTmp.HasCoverage)
                            {
                                List TestCaseList = oReqTmp.GetCoverList(false);
                                TestCaseCount += TestCaseList.Count;
                                float eachTestCaseDesigneffort = 0;
                                foreach (Test oTestTmp in TestCaseList)
                                {
                                    if ((string)oTestTmp["TS_USER_13"] != null) { TestCaseDesigneffort += float.Parse(oTestTmp["TS_USER_13"]); eachTestCaseDesigneffort += float.Parse(oTestTmp["TS_USER_13"]); }
                                }
                                Console.WriteLine(oReqTmp.Name +" case:"+ TestCaseList.Count + " hrs: " + eachTestCaseDesigneffort);//for testing@2016/5/5
                                ReqCoveredCount++;
                            }
                            else { if (oReqTmp.Status == "N/A") { ReqInvalidCount++; } }
                            if (oReqTmp.Name.StartsWith("f", true, null) && oReqTmp.Status != "N/A") { ReqFeatureCount++; }
                            if (oReqTmp.Name.StartsWith("d", true, null) && oReqTmp.Status != "N/A") { ReqDefectCount++; }

                        }
                        //Console.WriteLine(ProductName + " " + ReleaseNo + " " + CycleNo);
                        Console.WriteLine();
                        Console.Write("- {0,-7} Feature {2} | Defect {3}", CycleName,ReqList.Count, ReqFeatureCount, ReqDefectCount);
                        if (ReqInvalidCount > 0) { Console.Write(" | NA {0}", ReqInvalidCount); }
                        Console.WriteLine("\tTest:{0} Coverage:{1:P} Effort:{2:#.##}", TestCaseCount, (ReqList.Count != 0) ? (float)ReqCoveredCount / (float)ReqList.Count : 0, TestCaseDesigneffort);

                    }
                   
                }
            }
           
        }

        //Goal: display total req,test,effort of searched many fullpathes of release
        //argument:ref TDConnection:tdconn,string: many fullpathes of release.
        //call functions:CountofReqsTests
        //suit for releases\Product\release, also suit for releases\Product\...\release 
        //return: NA
        //useable:QA statistics
        static void TotalofReqsTests(ref TDConnection tdconn, string strPath)
        {
            string[] str_RelPath = strPath.Split(';');
            string strProductName = string.Empty, strReleaseNo = string.Empty, strCycleNo = string.Empty;
            Console.WriteLine("\nTesting Scope and Test Case Design Status");
            foreach (string strRelPath in str_RelPath)
            {
                if (strRelPath == null) { continue; }
                if (strRelPath.Trim() == "") { continue; }
                string[] arrProdRel = strRelPath.Split('\\');
                strReleaseNo = arrProdRel[arrProdRel.Length - 1];
                strProductName = arrProdRel[1];
                ReleaseFolderFactory oReleaseFolderFactory = tdconn.ReleaseFolderFactory;
                TDFilter oTDFilter = oReleaseFolderFactory.Filter;
                oTDFilter["RF_NAME"] = strProductName;
                List ReleaseFolderList = oTDFilter.NewList();
                //Console.WriteLine(ReleaseFolderList.Count);
                if (ReleaseFolderList.Count>=1)
                {
                    for (int i = 2; i < arrProdRel.Length - 1; i++)
                    {
                        oReleaseFolderFactory = ReleaseFolderList[1].ReleaseFolderFactory;
                        List ReleaseFolderTmp = oReleaseFolderFactory.NewList("");
                        //Console.WriteLine(ReleaseFolderTmp[1].Name+" "+ReleaseFolderTmp.Count);
                        if (ReleaseFolderTmp.Count <= 0) { break; }
                        strProductName = strProductName + " " + ReleaseFolderTmp[1].Name;
                        oTDFilter = oReleaseFolderFactory.Filter;
                        oTDFilter["RF_NAME"] = arrProdRel[i];
                        ReleaseFolderList = oTDFilter.NewList();

                    }

                    foreach (ReleaseFolder oReleaseFolderTmp in ReleaseFolderList)
                    {
                        ReleaseFactory oReleaseFactory = oReleaseFolderTmp.ReleaseFactory;
                        oTDFilter = oReleaseFactory.Filter;
                        oTDFilter["REL_NAME"] = strReleaseNo;
                        List ReleaseList = oTDFilter.NewList();
                        foreach (Release oReleaseTmp in ReleaseList)
                        {
                            Console.WriteLine();
                            Console.WriteLine(strProductName + " " + oReleaseTmp.Name);
                            CountofReqsTests(ref tdconn, strRelPath, string.Empty);
                            Console.WriteLine();
                            CycleFactory oCycleFactory = oReleaseTmp.CycleFactory;
                            List CycleList = oCycleFactory.NewList("");
                            if (CycleList.Count >= 1)
                            {
                                foreach (Cycle oCycleTmp in CycleList)
                                {
                                    //Console.WriteLine("- "+oCycleTmp.Name);
                                    string str_Rel_Path = strRelPath + @"\" + oCycleTmp.Name;
                                    //Console.WriteLine(str_Rel_Path);
                                    CountofReqsTests(ref tdconn, str_Rel_Path, oCycleTmp.Name);
                                }
                            }
                            else { CountofReqsTests(ref tdconn, strRelPath, string.Empty); }
                        }

                    }
                } 
            }

        }


        static void DisplayTestCases_lombardrisk(ref TDConnection tdconn)
        {
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayTestCases: START");
            Console.WriteLine("***************************************");
            Console.WriteLine();
       
            TreeManager oTreeManager = tdconn.TreeManager;
            SubjectNode oSubjectNode = oTreeManager.get_NodeByPath(@"Subject\MAS\BA35");
            TestFactory oTestFactory = oSubjectNode.TestFactory;
            List TestFactoryList = oTestFactory.NewList("");
            List TestFactoryFieldsList=oTestFactory.Fields;
            foreach (Test oTestTmp in TestFactoryList)
            {
                Console.WriteLine((string)oTestTmp["TS_USER_10"]);//10.Ontime ID
                Console.WriteLine((string)oTestTmp["TS_USER_13"]);//TC Design Effort(H)
                Console.WriteLine(oTestTmp["TS_USER_01"]);//08. Product
                Console.WriteLine(oTestTmp["TS_USER_02"]);//09. Return
                Console.WriteLine(oTestTmp["TS_USER_11"]);//04. Release No
                Console.WriteLine(oTestTmp["TS_STATUS"]);//07. Case Status
            }

            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayTestCases: END");
            Console.WriteLine("***************************************");
            Console.WriteLine();

        }


        
        static void DisplayTestInstances(ref TDConnection tdconn)
        {
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayTestInstances: START");
            Console.WriteLine("***************************************");
            Console.WriteLine();

            TestSetTreeManager oTestSetTreeManager = tdconn.TestSetTreeManager;
            TestSetFolder oTestSetFolder = oTestSetTreeManager.get_NodeByPath(@"Root\Dallas\2018-11-30_3.2.0.3 (Internal)");
            
            
            TestSetFactory oTestSetFactory = oTestSetFolder.TestSetFactory;
            List TestSetList = oTestSetFactory.NewList("");
            if (TestSetList.Count>=1)
            {
                foreach (TestSet oTestTmp in TestSetList)
                {
                    TSTestFactory oTSTestFactory = oTestTmp.TSTestFactory;
                    List TSTestList = oTSTestFactory.NewList("");
                    foreach (TSTest oTSTestTmp in TSTestList)
                    {
                        if (oTSTestTmp.Name.IndexOf("") >= 0)
                        {

                            Console.WriteLine(oTSTestTmp.ID);
                            Console.WriteLine(oTSTestTmp.Name);
                            Console.WriteLine(oTSTestTmp.TestName);
                            //Console.WriteLine((string)oTSTestTmp["TS_USER_10"]);//10.Ontime ID
                            Console.WriteLine(oTSTestTmp.Status);
                            //if ((string)oTSTestTmp["TC_USER_03"]!=null) { Console.WriteLine(float.Parse((string)oTSTestTmp["TC_USER_03"])); }//Run Effort Amount(H)
                            TestSet oTestSet = oTSTestTmp.TestSet;
                            TestSetFolder oTestSetFolderTMP = oTestSet.TestSetFolder;
                            Console.WriteLine(oTestSetFolderTMP.Name);

                        }

                    }
                } 
            }
           

            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayTestInstances: END");
            Console.WriteLine("***************************************");
            Console.WriteLine();
        }

        static void TotalofTestInstances(ref TDConnection tdconn,string strPath)
        {
            
            string[] arr_TestsetFolder_Path = strPath.Split(';');
            foreach (string str_TestsetFolder_Path in arr_TestsetFolder_Path)
            {
                if (str_TestsetFolder_Path == null) { continue; }
                if (str_TestsetFolder_Path.Trim() == "") { continue; }

                float TestCaseExecuteeffort = 0;
                int TSFailedCount = 0, TSNoRunCount = 0, TSTestCount = 0;

                    TestSetFactory oTestSetFactory = tdconn.TestSetFactory;
                    TDFilter oTDFilter = oTestSetFactory.Filter;
                    oTDFilter["CY_FOLDER_ID"] = "^" + str_TestsetFolder_Path + "^";
                    List TestSetList = oTDFilter.NewList();

                    //TSTestFactory oTSTestFactory = tdconn.TSTestFactory;
                    //TDFilter oTSTestFTDFilter=oTSTestFactory.Filter;
                    //oTSTestFTDFilter.SetXFilter("TSTEST-TESTSET", true, oTestSetTDFilter.Text);
                    //List TSTestList = oTSTestFTDFilter.NewList();
                    //Console.WriteLine(TSTestList.Count);
                    if (TestSetList.Count>=1)
                    {
                        foreach (TestSet oTestSetTmp in TestSetList)
                        {
                            //Console.WriteLine(oTestSetTmp.Name);
                            TSTestFactory oTSTestFactory = oTestSetTmp.TSTestFactory;
                            List TSTestList = oTSTestFactory.NewList("");
                            if (TSTestList.Count>=1)
                            {
                                TSTestCount += TSTestList.Count;
                                foreach (TSTest oTSTestTmp in TSTestList)
                                {
                                    //Console.WriteLine("Ontime ID: "+(string)oTSTestTmp["TS_USER_10"]);//10.Ontime ID
                                    //Console.WriteLine("Status: " + oTSTestTmp.Status);
                                    //if ((string)oTSTestTmp["TC_USER_03"]!=null) { Console.WriteLine("Run Effort Amount(H): "+float.Parse((string)oTSTestTmp["TC_USER_03"])); }//Run Effort Amount(H)
                                    //TestSetFolder oTestSetFolderTMP = oTestSetTmp.TestSetFolder;
                                    //Console.WriteLine("TestSetFolder: "+oTestSetFolderTMP.Name);
                                    if (oTSTestTmp.Status.Equals("failed",StringComparison.CurrentCultureIgnoreCase)){ TSFailedCount++;}
                                    if (oTSTestTmp.Status.Equals("No Run", StringComparison.CurrentCultureIgnoreCase) || oTSTestTmp.Status.Equals("Not Completed", StringComparison.CurrentCultureIgnoreCase)) { TSNoRunCount++; }
                                    if ((string)oTSTestTmp["TC_USER_03"] != null) { TestCaseExecuteeffort += float.Parse((string)oTSTestTmp["TC_USER_03"]); }//Run Effort Amount(H)
                                } 
                            }
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("path:{0,-20}", str_TestsetFolder_Path);
                    Console.WriteLine("TSTestCount:{1},Fail Ratio:{2:P},Progress:{3:P},Effort:{4}", str_TestsetFolder_Path, TSTestCount, (float)TSFailedCount / (float)TSTestCount, (TSTestCount - TSNoRunCount) / TSTestCount, TestCaseExecuteeffort);
            }
          
        }

        static void TotalofTSTest(ref TDConnection tdconn, string strPath)
        {
            Console.WriteLine("\nTesting Execution");
            string[] arr_TestsetFolder_Path = strPath.Split(';');
            foreach (string str_TestsetFolder_Path in arr_TestsetFolder_Path)
            {
                if (str_TestsetFolder_Path == null) { continue; }
                if (str_TestsetFolder_Path.Trim() == "") { continue; }

                float TestCaseExecuteeffort = 0;
                int TSFailedCount = 0, TSNoRunCount = 0, TSTestCount = 0;

                TestSetFactory oTestSetFactory = tdconn.TestSetFactory;
                TDFilter oTDFilter = oTestSetFactory.Filter;
                oTDFilter["CY_FOLDER_ID"] = "^" + str_TestsetFolder_Path + "^";
                List TestSetList = oTDFilter.NewList();

                TSTestFactory oTSTestFactory = tdconn.TSTestFactory;
                TDFilter oTSTestFTDFilter = oTSTestFactory.Filter;
                oTSTestFTDFilter.SetXFilter("TSTEST-TESTSET", true, oTDFilter.Text);
                List TSTestList = oTSTestFTDFilter.NewList();
                TSTestCount = TSTestList.Count;
                if (TSTestList.Count >= 1)
                {
                    foreach (TSTest oTSTestTmp in TSTestList)
                    {
                        if (oTSTestTmp["TC_STATUS"].Equals("failed", StringComparison.CurrentCultureIgnoreCase)) { TSFailedCount++; }
                        if (oTSTestTmp["TC_STATUS"].Equals("No Run", StringComparison.CurrentCultureIgnoreCase) || oTSTestTmp["TC_STATUS"].Equals("Not Completed", StringComparison.CurrentCultureIgnoreCase)) { TSNoRunCount++; }
                        if ((string)oTSTestTmp["TC_USER_03"] != null) { TestCaseExecuteeffort += float.Parse((string)oTSTestTmp["TC_USER_03"]); }//Run Effort Amount(H)
                    }
                }
                Console.WriteLine();
                Console.Write("{0}", str_TestsetFolder_Path.Replace(@"Root\",string.Empty));
                Console.WriteLine("\tTotal:{0} Fail Ratio:{1:P} Progress:{2:P} Effort:{3:#.##}", TSTestCount, (float)TSFailedCount / (float)TSTestCount, (float)(TSTestCount - TSNoRunCount) / (float)TSTestCount, TestCaseExecuteeffort);
            }

        }


        static void DrawTestGraph(ref TDConnection tdconn, string strReleaseFolder, string strReleaseNo, string strImageName)
        {
            TestFactory oTestFactory = tdconn.TestFactory;
            TDFilter oTDFilter = oTestFactory.Filter;
            oTDFilter["TS_USER_01"] = strReleaseFolder; //08. Product
            oTDFilter["TS_USER_11"] = strReleaseNo; //04. Release No
            oTDFilter.Order["TS_USER_01"] = 0;
            oTDFilter.Order["TS_USER_11"] = 1;
            Graph oGraph = oTestFactory.BuildSummaryGraph("TS_USER_10", "TS_STATUS", "", 0, oTDFilter, true, true);
            
            if (oGraph.ColCount<=0)
            {
                Console.WriteLine("no data filtered.");
            }
            else
            {
                //Console.WriteLine("ColCount: {0},RowCount:{1},GraphTotal:{2},MaxValue:{3}", oGraph.ColCount, oGraph.RowCount, oGraph.GraphTotal, oGraph.MaxValue);
                string strformat = "{0,-15}";
                Console.Write(strformat, "");
                for (int col = 0; col < oGraph.ColCount; col++)
                {
                    Console.Write(strformat, oGraph.ColName[col]);
                }
                Console.WriteLine(strformat, "<Total>");

                for (int row = 0; row < oGraph.RowCount; row++)
                {
                    Console.Write(strformat, oGraph.RowName[row]);
                    for (int col = 0; col < oGraph.ColCount; col++)
                    {
                        Console.Write(strformat, oGraph.Data[col, row]);
                    }
                    Console.WriteLine(strformat, oGraph.RowTotal[row]);
                }

                Console.Write(strformat, "<Total>");
                for (int col = 0; col < oGraph.ColCount; col++)
                {
                    Console.Write(strformat, oGraph.ColTotal[col]);
                }
                Console.WriteLine(strformat, oGraph.GraphTotal);

                Bitmap oBitmap = GenerateRectangleChart.RectangleChart(ref oGraph, "Test Summary Graph (" + strReleaseFolder + "." + strReleaseNo+")", "10.Ontime ID", "Sum of Tests");
                oBitmap.Save(strImageName, System.Drawing.Imaging.ImageFormat.Png);
            }
   
        }

        static void DrawTSTestGraph(ref TDConnection tdconn, string strTestsetFolderPath, string strImageName)
        {
            TestSetFactory oTestSetFactory = tdconn.TestSetFactory;
            TDFilter oTestSetTDFilter = oTestSetFactory.Filter;
            oTestSetTDFilter["CY_FOLDER_ID"] = "^" + strTestsetFolderPath + "^";
            List TestSetList = oTestSetTDFilter.NewList();

            Graph oGraph = oTestSetFactory.BuildSummaryGraph(-1, "TS_USER_10", "TC_STATUS", "", 0, oTestSetTDFilter, true, true);
            Console.WriteLine();
            if (oGraph.ColCount <= 0)
            {
                Console.WriteLine("no data filtered.");
            }
            else
            {
                //Console.WriteLine("ColCount: {0},RowCount:{1},GraphTotal:{2},MaxValue:{3}", oGraph.ColCount, oGraph.RowCount, oGraph.GraphTotal, oGraph.MaxValue);
                string strformat = "{0,-15}";
                Console.Write(strformat, "");
                for (int col = 0; col < oGraph.ColCount; col++)
                {
                    Console.Write(strformat, oGraph.ColName[col]);
                }
                Console.WriteLine(strformat, "<Total>");

                for (int row = 0; row < oGraph.RowCount; row++)
                {
                    Console.Write(strformat, oGraph.RowName[row]);
                    for (int col = 0; col < oGraph.ColCount; col++)
                    {
                        Console.Write(strformat, oGraph.Data[col, row]);
                    }
                    Console.WriteLine(strformat, oGraph.RowTotal[row]);
                }

                Console.Write(strformat, "<Total>");
                for (int col = 0; col < oGraph.ColCount; col++)
                {
                    Console.Write(strformat, oGraph.ColTotal[col]);
                }
                Console.WriteLine(strformat, oGraph.GraphTotal);

                Bitmap oBitmap = GenerateRectangleChart.RectangleChart(ref oGraph, "Test Instances Summary Graph (" + strTestsetFolderPath+")", "10.Ontime ID", "Sum of Tests Instances");
                oBitmap.Save(strImageName, System.Drawing.Imaging.ImageFormat.Png);

            }
           
        }



        static void DisplayFields(ref TDConnection tdconn)
        {
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayFields: START");
            Console.WriteLine("***************************************");
            Console.WriteLine();
            
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayTestCases: Display Test's Fields");
            Console.WriteLine("***************************************");
            Console.WriteLine();
            Customization oCustomization = tdconn.Customization;
            CustomizationFields oCustomizationFields = oCustomization.Fields;
            List CustomizationFieldList = oCustomizationFields.Fields["TESTCYCL"];
            foreach (CustomizationField oFieldTmp in CustomizationFieldList)
            {
                if (oFieldTmp.UserLabel!="")
                {
                    Console.WriteLine("ColumnName: " + oFieldTmp.ColumnName);
                    Console.WriteLine("ColumnType: " + oFieldTmp.ColumnType);
                    Console.WriteLine("UserColumnType: " + oFieldTmp.UserColumnType);
                    Console.WriteLine("IsSearchable: " + oFieldTmp.IsSearchable);
                    Console.WriteLine("UserLabel: " + oFieldTmp.UserLabel);
                    Console.WriteLine("TableName: " + oFieldTmp.TableName);
                    Console.WriteLine("List: " + oFieldTmp.List);
                    Console.WriteLine();
                }

            }
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayFields: Display All Fields");
            Console.WriteLine("***************************************");
            Console.WriteLine();
            //Customization oCustomization = tdconn.Customization;
            //CustomizationFields oCustomizationFields = oCustomization.Fields;
            //List 
            CustomizationFieldList = oCustomizationFields.Fields[""];
            foreach (CustomizationField oFieldTmp in CustomizationFieldList)
            {
                if (oFieldTmp.UserLabel.IndexOf("Run Effort") >= 0)
                {
                    Console.WriteLine(" ColumnName: " + oFieldTmp.ColumnName);
                    Console.WriteLine(" ColumnType: " + oFieldTmp.ColumnType);
                    Console.WriteLine(" UserColumnType: " + oFieldTmp.UserColumnType);
                    //Console.WriteLine(" IsSearchable: " + oFieldTmp.IsSearchable);
                    Console.WriteLine(" UserLabel: " + oFieldTmp.UserLabel);
                    Console.WriteLine(" TableName: " + oFieldTmp.TableName);
                    Console.WriteLine(" List: " + oFieldTmp.List);
                    //Console.WriteLine();
                }

            }

            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayFields: END");
            Console.WriteLine("***************************************");
            Console.WriteLine();
        }

        static void DisplayList(ref TDConnection tdconn)
        {
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayList: START");
            Console.WriteLine("***************************************");
            Console.WriteLine();

            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayList: Display Status List");
            Console.WriteLine("***************************************");
            Console.WriteLine();
            Customization oCustomization = tdconn.Customization;
            CustomizationLists oCustomizationLists = oCustomization.Lists;
            if (oCustomizationLists.get_IsListExist("Status"))
            {
                CustomizationList oCustomizationList = (CustomizationList)oCustomizationLists.List["Status"];
                CustomizationListNode oCustomizationListNodeRoot = oCustomizationList.RootNode;
                Console.WriteLine("CustomizationList Name: " + oCustomizationList.Name);
                Console.WriteLine("CustomizationListNode Root: " + oCustomizationListNodeRoot.Name);
                List CustomizationListNodeList = oCustomizationListNodeRoot.Children;
                foreach (CustomizationListNode oListNodeTmp in CustomizationListNodeList)
                {
                    Console.WriteLine("Status : " + oListNodeTmp.Name);
                }


            }
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayList: END");
            Console.WriteLine("***************************************");
            Console.WriteLine();
        }

        //failed to add
        static void AddReleaseAndCycles(ref TDConnection tdconn)
        {
            //create a release and target cycle 
            int iReleaseCycleCount = 3;
            string strReleaseNo = "2.21.0";
            string strReleaseFolder = "MAS";
            string strTestSetReleaseFd = "v2.21.0";
            int iTestSetCycleFdCount = 4;
            ReleaseFolder oReleaseFolder = null;
            ReleaseFolderFactory oReleaseFolderFc = tdconn.ReleaseFolderFactory;
            ReleaseFolder oReleaseFolderRt = oReleaseFolderFc.Root;
            ReleaseFolderFactory oReleaseFolderRtFc = oReleaseFolderRt.ReleaseFolderFactory;
            List ReleaseFdList = oReleaseFolderRtFc.NewList("[force_refresh]");
            foreach (ReleaseFolder tmpRelFd in ReleaseFdList)
            {
                Console.WriteLine(tmpRelFd.Name + "====" + tmpRelFd.ID);
                if (tmpRelFd.Name == strReleaseFolder)
                {
                    oReleaseFolder = tmpRelFd;
                    break;
                }
            }
            //Console.ReadLine();

            ReleaseFactory oReleaseFc = oReleaseFolder.ReleaseFactory;
            List ReleaseNoList = oReleaseFc.NewList("");
            foreach (Release tmpR in ReleaseNoList)
            {

                Console.WriteLine(tmpR.Name);
                if (tmpR.Name == strReleaseNo)
                {
                    Console.WriteLine("{0} already exist release no. {1}!!!", strReleaseFolder, tmpR.Name);
                    strReleaseNo = "";
                    break;
                }

            }

            if (strReleaseNo != "")
            {
                Release oReleaseNewOne = oReleaseFc.AddItem(null);

                oReleaseNewOne.Name = strReleaseNo;

                oReleaseNewOne.Post();

                CycleFactory oCycleFc = oReleaseNewOne.CycleFactory;
                for (int i = 1; i <= iReleaseCycleCount; i++)
                {
                    Cycle oCycleNewOne = oCycleFc.AddItem(null);
                    oCycleNewOne.Name = "Cycle" + i;
                    oCycleNewOne.Post();
                }
            }

            //create a testset folder and related cycle folders
            TestSetTreeManager TestSetTr = tdconn.TestSetTreeManager;
            TestSetFolder TestSetProductFd = TestSetTr.get_NodeByPath("Root\\" + strReleaseFolder);
            List TestSetReleaseFdList = TestSetProductFd.NewList();
            foreach (TestSetFolder TmpTestSetFd in TestSetReleaseFdList)
            {
                Console.WriteLine(TmpTestSetFd.Name);
                if (TmpTestSetFd.Name == strTestSetReleaseFd)
                {
                    Console.WriteLine("{0} already exist release no. {1}!!!", strReleaseFolder, strTestSetReleaseFd);
                    strTestSetReleaseFd = "";
                    break;
                }
            }

            if (strTestSetReleaseFd != "")
            {
                TestSetFolder TestSetReleaseFdNewOne = (TestSetFolder)TestSetProductFd.AddNode(strTestSetReleaseFd);
                TestSetReleaseFdNewOne.Post();
                TestSetFactory TestSetFcNewone = null;
                TestSet TestSetNewone = null;
                for (int i = 1; i <= iTestSetCycleFdCount; i++)
                {
                    TestSetFolder TestSetFdNewOne = (TestSetFolder)TestSetReleaseFdNewOne.AddNode("Cycle" + i);
                    TestSetFdNewOne.TargetCycle = "Releases" + "\\" + strReleaseFolder + "\\" + strReleaseNo + "\\Cycle" + i;
                    TestSetFdNewOne.Post();
                    TestSetFcNewone = TestSetFdNewOne.TestSetFactory;
                    if (i == 1)
                    {
                        TestSetNewone = TestSetFcNewone.AddItem("Smoke Testing");
                        TestSetNewone.Post();

                        TestSetNewone = TestSetFcNewone.AddItem("Feature Verification");
                        TestSetNewone.Post();
                    }
                    else
                    {
                        TestSetNewone = TestSetFcNewone.AddItem("Regression Testing");
                        TestSetNewone.Post();
                    }
                }
            }
        }
    }
}
