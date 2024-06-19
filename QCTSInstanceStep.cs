using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TDAPIOLELib;

namespace QCTest
{
    class QCTSInstanceStep
    {
        private static List<string> testSetfolderList;
        public string Hierarchy { get; }
        public string HierarchyOrder { get; }
        public string StructuralName { get; }
        //folder
        public string CF_ITEM_PATH { get; }
        public string CF_Name { get; }
        public string CF_DESCR { get; }
        //test set
        public int CY_CYCLE_ID { get; }
        public string CY_CYCLE { get; }
        public string CY_OPEN_DATE { get; }
        public string CY_CLOSE_DATE { get; }
        public string CY_STATUS { get; }
        public string CY_DESCRIPTION { get; }
        public string CY_COMMENT { get; }
        public string CY_ATTACHMENT { get; }
        //test instance
        public string TC_TEST_ID { get; }
        public int TC_TEST_ORDER { get; }
        public string TC_NAME { get; }
        public string TC_STATUS { get; }
        public string TC_TESTER_NAME { get; }
        public string TC_EXEC_DATE { get; }
        public string TC_EXEC_TIME { get; }
        public string TC_ATTACHMENT { get; }
        public string TC_Defect_ID { get; } //TC_ITERATIONS,TC_USER_01 
        public string TC_SUBTYPE_ID { get; }
        public string TC_Execution_Comments { get; }//TC_USER_25 
        //last run
        public int RN_TEST_CONFIG_ID { get; }
        public int RN_RUN_ID { get; }
        public string RN_NAME { get; }
        public string RN_EXECUTION_DATE { get; }
        public string RN_EXECUTION_TIME { get; }
        public string RN_HOST { get; }
        public string RN_STATUS { get; }
        public string RN_DURATION { get; }
        public string RN_DRAFT { get; }
        public string RN_ATTACHMENT { get; }
        public string RN_OS_NAME { get; }
        public string RN_OS_SP { get; }
        public string RN_OS_BUILD { get; }
        public string RN_SUBTYPE_ID { get; }
        //RUN_CRITERIA
        public int RCR_ID { get; }
        public string RCR_DESCRIPTION { get; } //Configuration_Description
        //step
        public int ST_ID { get; }
        public string ST_STEP_NAME { get; }
        public string ST_DESCRIPTION { get; }
        public string ST_EXPECTED { get; }
        public string ST_ACTUAL { get; }
        public string ST_EXECUTION_DATE { get; }
        public string ST_EXECUTION_TIME { get; }
        public string ST_STATUS { get; }
        public string ST_DESSTEP_ID { get; }
        public string ST_ATTACHMENT { get; }
        public int ST_STEP_ORDER { get; }//ST_STEP_ORDER

        public QCTSInstanceStep(TestSetFolder oTestSetFolder) 
        {
            this.Hierarchy = oTestSetFolder.Path;
            this.StructuralName= oTestSetFolder.Name;
            this.CF_ITEM_PATH = oTestSetFolder.Path;
            this.CF_Name = oTestSetFolder.Name;
            this.CF_DESCR = oTestSetFolder.Description != null ? oTestSetFolder.Description : "";
        }
        public QCTSInstanceStep(TestSetFolder oTestSetFolder, TestSet oTestSet)
        {
            this.Hierarchy = oTestSetFolder.Path;
            this.StructuralName = oTestSetFolder.Name;//StructuralName
            this.CF_ITEM_PATH = oTestSetFolder.Path;
            this.CF_Name = oTestSetFolder.Name;
            this.CF_DESCR = oTestSetFolder.Description != null ? oTestSetFolder.Description : "";
            if (oTestSet!=null)
            {
                this.StructuralName = oTestSet.Name;//StructuralName
                String CY_OPEN_DATE = oTestSet["CY_OPEN_DATE"] != null ? oTestSet["CY_OPEN_DATE"].ToString() : "";
                String CY_CLOSE_DATE = oTestSet["CY_CLOSE_DATE"] != null ? oTestSet["CY_CLOSE_DATE"].ToString() : "";
                String CY_DESCRIPTION = oTestSet["CY_DESCRIPTION"] != null ? oTestSet["CY_DESCRIPTION"] : "";
                String CY_COMMENT = oTestSet["CY_COMMENT"] != null ? oTestSet["CY_COMMENT"] : "";
                String CY_ATTACHMENT = oTestSet["CY_ATTACHMENT"] != null ? oTestSet["CY_ATTACHMENT"] : "";
                this.CY_CYCLE_ID = oTestSet.ID;
                this.CY_CYCLE = oTestSet.Name;
                this.CY_OPEN_DATE = CY_OPEN_DATE;
                this.CY_CLOSE_DATE = CY_CLOSE_DATE;
                this.CY_STATUS= oTestSet.Status;
                this.CY_DESCRIPTION = CY_DESCRIPTION;
                this.CY_COMMENT = CY_COMMENT;
                this.CY_ATTACHMENT = CY_ATTACHMENT;

            }
        }

        public QCTSInstanceStep(TestSetFolder oTestSetFolder, TestSet oTestSet, TSTest oTSTest, Run oLastRun, RunCriterion oRCR, Step oStep)
        {
            //test set folder
            this.Hierarchy = oTestSetFolder.Path;
            this.HierarchyOrder=oTestSetFolder.Path;
            this.StructuralName = oTestSetFolder.Name;//StructuralName
            this.CF_ITEM_PATH = oTestSetFolder.Path;
            this.CF_Name = oTestSetFolder.Name;
            this.CF_DESCR = oTestSetFolder.Description != null ? oTestSetFolder.Description : "";
            if (oTestSet != null)
            {
                //test set
                this.Hierarchy = oTestSetFolder.Path + @"\" + oTestSet.Name;
                this.HierarchyOrder = oTestSetFolder.Path+ oTestSet.ID.ToString();
                this.StructuralName = oTestSet.Name;//StructuralName
                String CY_OPEN_DATE = oTestSet["CY_OPEN_DATE"] != null ? oTestSet["CY_OPEN_DATE"].ToString() : "";
                String CY_CLOSE_DATE = oTestSet["CY_CLOSE_DATE"] != null ? oTestSet["CY_CLOSE_DATE"].ToString() : "";
                String CY_DESCRIPTION = oTestSet["CY_DESCRIPTION"] != null ? oTestSet["CY_DESCRIPTION"] : "";
                String CY_COMMENT = oTestSet["CY_COMMENT"] != null ? oTestSet["CY_COMMENT"] : "";
                String CY_ATTACHMENT = oTestSet["CY_ATTACHMENT"] != null ? oTestSet["CY_ATTACHMENT"] : "";
                this.CY_CYCLE_ID = oTestSet.ID;
                this.CY_CYCLE = oTestSet.Name;
                this.CY_OPEN_DATE = CY_OPEN_DATE;
                this.CY_CLOSE_DATE = CY_CLOSE_DATE;
                this.CY_STATUS = oTestSet.Status;
                this.CY_DESCRIPTION = CY_DESCRIPTION;
                this.CY_COMMENT = CY_COMMENT;
                this.CY_ATTACHMENT = CY_ATTACHMENT;
                if (oTSTest!=null)
                {
                    //test case instance
                    this.Hierarchy = oTestSetFolder.Path + @"\" + oTestSet.Name + @"\" + oTSTest.Name;
                    this.HierarchyOrder = oTestSetFolder.Path + oTestSet.ID.ToString();
                    this.StructuralName = oTSTest.Name;//StructuralName
                    string TC_TESTER_NAME = oTSTest["TC_TESTER_NAME"] != null ? oTSTest["TC_TESTER_NAME"] : "";
                    string TC_EXEC_DATE = oTSTest["TC_EXEC_DATE"] != null ? oTSTest["TC_EXEC_DATE"].ToString() : "";
                    string TC_EXEC_TIME = oTSTest["TC_EXEC_TIME"] != null ? oTSTest["TC_EXEC_TIME"].ToString() : "";
                    string TC_ATTACHMENT = oTSTest["TC_ATTACHMENT"] != null ? oTSTest["TC_ATTACHMENT"] : "";
                    string TC_ITERATIONS = oTSTest["TC_ITERATIONS"] != null ? oTSTest["TC_ITERATIONS"] : "";
                    string TC_DefectID = oTSTest["TC_USER_01"] != null ? oTSTest["TC_USER_01"] : TC_ITERATIONS;//'Defect ID'
                    string TC_SUBTYPE_ID = oTSTest["TC_SUBTYPE_ID"] != null ? oTSTest["TC_SUBTYPE_ID"] : "";
                    string TC_Execution_Comments = oTSTest["TC_USER_25"] != null ? oTSTest["TC_USER_25"] : "";
                    
                    this.TC_TEST_ID= oTSTest.ID;
                    this.TC_NAME = oTSTest.Name;
                    this.TC_TEST_ORDER= oTSTest["TC_TEST_ORDER"];
                    this.TC_STATUS= oTSTest.Status;
                    this.TC_TESTER_NAME= TC_TESTER_NAME;
                    this.TC_EXEC_DATE = TC_EXEC_DATE;
                    this.TC_EXEC_TIME = TC_EXEC_TIME;
                    this.TC_ATTACHMENT = TC_ATTACHMENT;
                    this.TC_Defect_ID = TC_DefectID; //TC_ITERATIONS,TC_USER_01 
                    this.TC_SUBTYPE_ID = TC_SUBTYPE_ID;
                    this.TC_Execution_Comments = TC_Execution_Comments;//TC_USER_25 
                    if (oLastRun!=null)
                    {
                        //run instance of test case instance
                        int RN_TEST_CONFIG_ID = oLastRun["RN_TEST_CONFIG_ID"] != null ? oLastRun["RN_TEST_CONFIG_ID"] : "";
                        string RN_EXECUTION_DATE = oLastRun["RN_EXECUTION_DATE"] != null ? oLastRun["RN_EXECUTION_DATE"].ToString() : "";
                        string RN_EXECUTION_TIME = oLastRun["RN_EXECUTION_TIME"] != null ? oLastRun["RN_EXECUTION_TIME"].ToString() : "";
                        string RN_HOST = oLastRun["RN_HOST"] != null ? oLastRun["RN_HOST"] : "";

                        string RN_DURATION = oLastRun["RN_DURATION"] != null ? oLastRun["RN_DURATION"].ToString() : "";
                        string RN_DRAFT = oLastRun["RN_DRAFT"] != null ? oLastRun["RN_DRAFT"] : "";

                        string RN_ATTACHMENT = oLastRun["RN_ATTACHMENT"] != null ? oLastRun["RN_ATTACHMENT"] : "";
                        string RN_OS_NAME = oLastRun["RN_OS_NAME"] != null ? oLastRun["RN_OS_NAME"] : "";
                        string RN_OS_SP = oLastRun["RN_OS_SP"] != null ? oLastRun["RN_OS_SP"] : "";
                        string RN_OS_BUILD = oLastRun["RN_OS_BUILD"] != null ? oLastRun["RN_OS_BUILD"] : "";
                        string RN_SUBTYPE_ID = oLastRun["RN_SUBTYPE_ID"] != null ? oLastRun["RN_SUBTYPE_ID"] : "";
                        
                        this.RN_TEST_CONFIG_ID = RN_TEST_CONFIG_ID;
                        this.RN_RUN_ID= oLastRun.ID;
                        this.RN_NAME = oLastRun.Name;
                        this.RN_EXECUTION_DATE= RN_EXECUTION_DATE;
                        this.RN_EXECUTION_TIME= RN_EXECUTION_TIME;
                        this.RN_HOST= RN_HOST;
                        this.RN_STATUS= oLastRun.Status;
                        this.RN_DURATION= RN_DURATION;
                        this.RN_DRAFT= RN_DRAFT;
                        this.RN_ATTACHMENT= RN_ATTACHMENT;
                        this.RN_OS_NAME= RN_OS_NAME;
                        this.RN_OS_SP= RN_OS_SP;
                        this.RN_OS_BUILD= RN_OS_BUILD;
                        this.RN_SUBTYPE_ID= RN_SUBTYPE_ID;
                        if (oRCR!=null)
                        {
                            //run criteria of run instance
                            string RCR_DESCRIPTION = oRCR["RCR_DESCRIPTION"] != null ? oRCR["RCR_DESCRIPTION"] : "";
                            this.RCR_ID= oRCR.ID;
                            this.RCR_DESCRIPTION= RCR_DESCRIPTION;
                        }
                        if (oStep!=null)
                        {
                            //steps of run instance
                            string ST_EXPECTED = oStep["ST_EXPECTED"] != null ? oStep["ST_EXPECTED"] : "";
                            string ST_DESCRIPTION = oStep["ST_DESCRIPTION"] != null ? oStep["ST_DESCRIPTION"] : "";
                            string ST_ACTUAL = oStep["ST_ACTUAL"] != null ? oStep["ST_ACTUAL"] : "";
                            string ST_EXECUTION_DATE = oStep["ST_EXECUTION_DATE"] != null ? oStep["ST_EXECUTION_DATE"].ToString() : "";
                            string ST_EXECUTION_TIME = oStep["ST_EXECUTION_TIME"] != null ? oStep["ST_EXECUTION_TIME"].ToString() : "";
                            string ST_ATTACHMENT = oStep["ST_ATTACHMENT"] != null ? oStep["ST_ATTACHMENT"] : "";
                            string ST_DESSTEP_ID= oStep["ST_DESSTEP_ID"] != null ? oStep["ST_DESSTEP_ID"].ToString() : "";
                            this.ST_ID= oStep.ID;
                            this.ST_STEP_NAME= oStep.Name;
                            this.ST_DESCRIPTION= ST_DESCRIPTION;
                            this.ST_EXPECTED= ST_EXPECTED;
                            this.ST_ACTUAL = ST_ACTUAL;
                            this.ST_EXECUTION_DATE = ST_EXECUTION_DATE;
                            this.ST_EXECUTION_TIME = ST_EXECUTION_TIME;
                            this.ST_STATUS = oStep.Status;
                            this.ST_DESSTEP_ID = ST_DESSTEP_ID;
                            this.ST_ATTACHMENT = ST_ATTACHMENT;
                            this.ST_STEP_ORDER = oStep["ST_STEP_ORDER"];//ST_STEP_ORDER
                        }
                    }
                }
            }
        }

        public void print_TestSetFolder()
        {
            Console.WriteLine("========== Test Set Folder =============");
            string formattedString = String.Format("Hierarchy: {0}, Folder: {1}\n", this.Hierarchy, this.CF_Name);
            Console.WriteLine(formattedString);
        }
        public void print_TestSet()
        {
            Console.WriteLine("========== Test Set =============");
            string formattedString = String.Format("StructuralName: {0}, Folder: {1}, Test Set: {2}, CY_OPEN_DATE: {3}, CY_CLOSE_DATE:{4},CY_STATUS:{5}\n",  this.StructuralName, this.CF_Name, this.CY_CYCLE, this.CY_OPEN_DATE, this.CY_CLOSE_DATE, this.CY_STATUS);
            Console.WriteLine(formattedString);
        }
        public void print_TSTest()
        {
            Console.WriteLine("========== TSTest Instance =============");
            string formattedString = String.Format("StructuralName: {0}, TC_TEST_ID: {1}, TC_NAME: {2}, TC_TEST_ORDER: {3}, TC_STATUS: {4}\n", this.StructuralName, this.TC_TEST_ID, this.TC_NAME, this.TC_TEST_ORDER, this.TC_STATUS);
            Console.WriteLine(formattedString);
        }
        public void print_TSTestRun()
        {
            Console.WriteLine("========== Run Instance in TSTest Instance =============");
            string formattedString = String.Format("StructuralName: {0}, TC_TEST_ID: {1}, TC_NAME: {2}, \nRN_RUN_ID: {3}, RN_NAME: {4}, RN_STATUS: {5}\n", this.StructuralName, this.TC_TEST_ID, this.TC_NAME, this.RN_RUN_ID, this.RN_NAME,this.RN_STATUS);
            Console.WriteLine(formattedString);
        }
        public void print_TSTestRunStep()
        {
            Console.WriteLine("========== Setp in TSTest Instance =============");
            string formattedString = String.Format("StructuralName: {0}, TC_TEST_ID: {1}, TC_NAME: {2}, \nRN_RUN_ID: {3}, RN_NAME: {4}, RN_STATUS: {5}, \nST_ID: {6}, ST_STEP_NAME: {7}, ST_STEP_ORDER: {8}\n", this.StructuralName, this.TC_TEST_ID, this.TC_NAME, this.RN_RUN_ID, this.RN_NAME, this.RN_STATUS, this.ST_ID,this.ST_STEP_NAME,this.ST_STEP_ORDER);
            Console.WriteLine(formattedString);
        }

        //Goal: collect test set folder, test set and test instances with steps into List.
        //argument:ref TDConnection:tdconn,string: QCTestSetPath of TestSet, string: QCTestSetExportPath of export.
        //call functions: RecurTestSetFolder
        //suit for Root, also suit for Root\Dallas\2024-05-28_PI24.2.S4 
        //return: NA
        //useable:Jama Integration and archive
        //origination: Dexis@20240611
        public static void RecurTestSetFolder(TestSetFolder oTestSetFolder, string QCTestSetPath, string QCTestSetExportPath)
        {
            List folderList = oTestSetFolder.SubNodes;
            if (folderList!=null)
            {
                if (folderList.Count == 0)
                {
                    Console.WriteLine("***************************************");
                    Console.WriteLine();

                    List<QCTSInstanceStep> tSInstanceSteps = new List<QCTSInstanceStep>();
                    QCTSInstanceStep tSInstanceStep = null;
                    tSInstanceStep = new QCTSInstanceStep(oTestSetFolder, null, null, null, null, null);
                    tSInstanceStep.print_TestSetFolder();
                    tSInstanceSteps.Add(tSInstanceStep);

                    //test set
                    TestSetFactory oTestSetFactory = oTestSetFolder.TestSetFactory;
                    List oTestSetList = oTestSetFactory.NewList("[force_refresh]");

                    if (oTestSetList.Count >= 1)
                    {
                        //创建文件夹 oTestSetFolder.Name
                        string partFolderPath = oTestSetFolder.Path.Replace(@"Root\", @"\");
                        string fullFoldetPath = QCTestSetExportPath + partFolderPath;
                        FileUtil.createFolder(fullFoldetPath);
                        foreach (TestSet oTestSetTmp in oTestSetList)
                        {
                            tSInstanceStep = new QCTSInstanceStep(oTestSetFolder, oTestSetTmp, null, null, null, null);
                            tSInstanceStep.print_TestSet();
                            tSInstanceSteps.Add(tSInstanceStep);
                            TSTestFactory oTSTestFactory = oTestSetTmp.TSTestFactory;
                            //Test Instance
                            List oTSTestList = oTSTestFactory.NewList("[force_refresh]");

                            if (oTSTestList.Count > 0)
                            {
                                foreach (TSTest oTSTestTmp in oTSTestList)
                                {
                                    if (oTSTestTmp.Name.IndexOf("") >= 0)
                                    {
                                        //Test Instance Step
                                        Run oLastRun = oTSTestTmp.LastRun;
                                        if (oLastRun != null)
                                        {
                                            Console.WriteLine("==========RecurTestSetFolder: TSTest Instance=============");
                                            RunCriterionFactory oRunCriterionFactory = oLastRun.RunCriterionFactory;
                                            if (oRunCriterionFactory == null)
                                            {
                                                setStep(oTestSetFolder, oTestSetTmp, oTSTestTmp, oLastRun, null, tSInstanceSteps, tSInstanceStep);
                                            }
                                            else
                                            {
                                                List RunCriterionList = oRunCriterionFactory.NewList("[force_refresh]");
                                                //RunCriterion oRCR = null;
                                                if (RunCriterionList.Count > 0)
                                                {
                                                    foreach (RunCriterion oRCR in RunCriterionList)
                                                    {
                                                        setStep(oTestSetFolder, oTestSetTmp, oTSTestTmp, oLastRun, oRCR, tSInstanceSteps, tSInstanceStep);
                                                    }
                                                }
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("RecurTestSetFolder：No Test Run.");
                                            tSInstanceStep = new QCTSInstanceStep(oTestSetFolder, oTestSetTmp, oTSTestTmp, null, null, null);
                                            tSInstanceStep.print_TSTest();
                                            tSInstanceSteps.Add(tSInstanceStep);
                                        }

                                    }
                                }
                            }


                        }
                        List<QCTSInstanceStep> tSInstanceSteps_ordered = tSInstanceSteps.OrderBy(a => a.HierarchyOrder).ThenBy(a => a.TC_TEST_ORDER).ThenBy(a => a.ST_STEP_ORDER).ToList();
                        //List<QCTSInstanceStep> tSInstanceSteps_ordered = tSInstanceSteps.OrderBy(a => a.Hierarchy).ThenBy(a => a.TC_TEST_ORDER).ThenBy(a => a.ST_STEP_ORDER).ToList();
                        ExcelUtil.WriteTSInstanceStep(fullFoldetPath, oTestSetFolder.Name + ".xlsx", "Query1", tSInstanceSteps_ordered);
                    }
                    Console.WriteLine();
                    Console.WriteLine("***************************************");

                }
                if (folderList.Count >= 1)
                {
                    foreach (TestSetFolder oFolderTmp in folderList)
                    {
                        RecurTestSetFolder(oFolderTmp, QCTestSetPath, QCTestSetExportPath);
                    }
                }
            }
        }

        private static void setStep(TestSetFolder oTestSetFolder, TestSet oTestSetTmp, TSTest oTSTestTmp, Run oLastRun, RunCriterion oRCR, List<QCTSInstanceStep> tSInstanceSteps, QCTSInstanceStep tSInstanceStep)
        {
            StepFactory oStepFactory = oLastRun.StepFactory;
            List oStepList = oStepFactory.NewList("[force_refresh]");
            if (oStepList.Count > 0)
            {
                //Console.WriteLine("==========Test Setp=============");
                foreach (Step oStep in oStepList)
                {
                    tSInstanceStep = new QCTSInstanceStep(oTestSetFolder, oTestSetTmp, oTSTestTmp, oLastRun, oRCR, oStep);
                    tSInstanceStep.print_TSTestRunStep();
                    tSInstanceSteps.Add(tSInstanceStep);
                }

            }
            else
            {
                Console.WriteLine("RecurTestSetFolder：Has Test Run but No Step.");
                tSInstanceStep = new QCTSInstanceStep(oTestSetFolder, oTestSetTmp, oTSTestTmp, oLastRun, null, null);
                tSInstanceStep.print_TSTestRun();
                tSInstanceSteps.Add(tSInstanceStep);
            }
        }

        ////Goal: collect test set folder, test set and test instances with steps, order them then save into Excel.
        //argument: ref TDConnection:tdconn,string: QCTestSetPath of TestSet, string: QCTestSetExportPath of export.
        //call functions: RecurTestSetFolder
        //suit for Root, also suit for Root\Dallas\2024-05-28_PI24.2.S4 
        //return: NA
        //useable:Jama Integration and archive
        //origination: Dexis@20240611
        public static void DisplayTestSetFolder(ref TDConnection tdconn, string QCTestSetPath, string QCTestSetExportPath)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayTestSetFolder: START");
            Console.WriteLine("***************************************");
            Console.WriteLine();
            string[] singlePaths = QCTestSetPath.Split(';');
            if (singlePaths.Length>0)
            {
                TestSetTreeManager oTestSetTreeManager = tdconn.TestSetTreeManager;
                foreach (string singlePath in singlePaths)
                {
                    if (FileUtil.isNotEmptyStr(singlePath))
                    {
                        TestSetFolder oTestSetFolder = oTestSetTreeManager.get_NodeByPath(singlePath); //QCTestSetPath like @"Root\Dallas\2024-05-28_PI24.2.S4"
                        RecurTestSetFolder(oTestSetFolder, singlePath, QCTestSetExportPath);
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine($"DisplayTestSetFolder: END, used {stopwatch.Elapsed.TotalSeconds:F2}seconds.");
            Console.WriteLine("***************************************");
            Console.WriteLine();
        }

        public static List<List<string>> SearchTestSetFolder(ref TDConnection tdconn, string QCTestSetPath)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("SearchTestSetFolder: START");
            Console.WriteLine("***************************************");
            Console.WriteLine();
            string[] singlePaths = QCTestSetPath.Split(';');
            List<List<string>> result = new List<List<string>>();
            List<string> resultSearchedFolders = new List<string>();
            List<string> FailedSearchedPaths = new List<string>();
            if (singlePaths.Length>0)
            {
                TestSetTreeManager oTestSetTreeManager = tdconn.TestSetTreeManager;
                TestSetFolder oRootFolder = oTestSetTreeManager.Root;
                if (QCTSInstanceStep.testSetfolderList == null || QCTSInstanceStep.testSetfolderList.Count == 0)
                {
                    QCTSInstanceStep.testSetfolderList = new List<string>();
                    getTestSetFolders_Recur(oRootFolder, oRootFolder.Path, QCTSInstanceStep.testSetfolderList);
                }
                List<string> oTestSetfolderList = QCTSInstanceStep.testSetfolderList;
                List<string> searchedList = null;
                foreach (string singleTestSetFolder in singlePaths)
                {
                    if (FileUtil.isNotEmptyStr(singleTestSetFolder))
                    {
                        searchedList = null;
                        if (singleTestSetFolder.Contains("*"))
                        {
                            string[] partTestSetFolderPaths = singleTestSetFolder.Split('*');

                            if (singleTestSetFolder.EndsWith("*"))
                            {
                                //Root\Dallas\2023-10-12_PI23
                                searchedList = oTestSetfolderList.Where(item => item.StartsWith(partTestSetFolderPaths[0])).ToList();
                                QCTSInstanceStep.setSearchedResult(singleTestSetFolder, ref searchedList, ref resultSearchedFolders, ref FailedSearchedPaths);
                            }
                            else
                            {
                                FailedSearchedPaths.Add("Fuzzy Search Format Error: " + singleTestSetFolder);
                                Console.WriteLine("only support one format, string end withs star[*] !");
                            }
                            
                            
                        }
                        else
                        {
                            searchedList = oTestSetfolderList.Where(item => item.Equals(singleTestSetFolder)).ToList();
                            QCTSInstanceStep.setSearchedResult(singleTestSetFolder, ref searchedList, ref resultSearchedFolders, ref FailedSearchedPaths);

                        }
                    }
                    
                }
            }

            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine($"SearchTestSetFolder: END, used {stopwatch.Elapsed.TotalSeconds:F2}seconds.");
            Console.WriteLine("***************************************");
            Console.WriteLine();
            result.Add(resultSearchedFolders);
            result.Add(FailedSearchedPaths);
            return result;
        }

        private static void setSearchedResult(string singleTestSetFolder, ref List<string> searchedList, ref List<string> resultSearchedFolders, ref List<string> FailedSearchedPaths)
        {
            if (searchedList != null && searchedList.Count > 0)
            {
                Console.WriteLine($"============= search matched Nodes[{singleTestSetFolder}] Start============");
                foreach (string searchedFolder in searchedList)
                {
                    Console.WriteLine($"searched matched Node: {searchedFolder}");
                    resultSearchedFolders.Add(searchedFolder);
                }
                Console.WriteLine($"============= search matched Nodes[{singleTestSetFolder}] End============");
            }
            else
            {
                FailedSearchedPaths.Add(singleTestSetFolder);
            }
        }

        public static void getTestSetFolders_Recur(TestSetFolder oTestSetFolder, string QCTestSetPath, List<String> oTestSetfolderList)
        {
            List folderList = oTestSetFolder.SubNodes;
            if (folderList.Count == 0)
            {
                String oTestSetfolder = oTestSetFolder.Path;
                Console.WriteLine(oTestSetfolder);
                oTestSetfolderList.Add(oTestSetfolder);
                //Console.WriteLine();
            }
            if (folderList.Count >= 1)
            {
                foreach (TestSetFolder oFolderTmp in folderList)
                {
                    getTestSetFolders_Recur(oFolderTmp, QCTestSetPath,oTestSetfolderList);
                }
            }

        }


    }
}
