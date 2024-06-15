using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OfficeOpenXml;


namespace QCTest
{
    
    class ExcelUtil
    {
        private ExcelUtil() { }
        static public void WriteExcel(string xlsxName,string sheetName)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add(sheetName);
                worksheet.Cells["A1"].Value = "Hello";
                worksheet.Cells["B1"].Value = "World";
                
                // 保存Excel文件
                var fileInfo = new FileInfo(xlsxName);
                package.SaveAs(fileInfo);
            }

        }

        static public void WriteTSInstanceStep(string xlsxPath,string xlsxName, string sheetName,List<QCTSInstanceStep> tSInstanceSteps)
        {
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("WriteTSInstanceStep: START");
            Console.WriteLine("***************************************");
            Console.WriteLine();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                
                var worksheet = package.Workbook.Worksheets.Add(sheetName);
                if (tSInstanceSteps!=null && tSInstanceSteps.Count>0)
                {
                    int row = 1;
                    worksheet.Cells[row, 1].Value = "Hierarchy";
                    worksheet.Cells[row, 2].Value = "StructuralName";
                    worksheet.Cells[row, 3].Value = "CF_DESCR";
                    worksheet.Cells[row, 4].Value = "CY_CYCLE_ID";
                    worksheet.Cells[row, 5].Value = "CY_CYCLE";
                    worksheet.Cells[row, 6].Value = "CY_OPEN_DATE";
                    worksheet.Cells[row, 7].Value = "CY_CLOSE_DATE";
                    worksheet.Cells[row, 8].Value = "CY_STATUS";
                    worksheet.Cells[row, 9].Value = "CY_DESCRIPTION";
                    worksheet.Cells[row, 10].Value = "CY_COMMENT";

                    worksheet.Cells[row, 11].Value = "CY_ATTACHMENT";
                    worksheet.Cells[row, 12].Value = "TC_TEST_ID";
                    worksheet.Cells[row, 13].Value = "TC_TEST_ORDER";
                    worksheet.Cells[row, 14].Value = "TC_STATUS";
                    worksheet.Cells[row, 15].Value = "TC_TESTER_NAME";
                    worksheet.Cells[row, 16].Value = "TC_EXEC_DATE";
                    worksheet.Cells[row, 17].Value = "TC_EXEC_TIME";
                    worksheet.Cells[row, 18].Value = "TC_ATTACHMENT";
                    worksheet.Cells[row, 19].Value = "Defect ID";
                    worksheet.Cells[row, 20].Value = "TC_SUBTYPE_ID";

                    worksheet.Cells[row, 21].Value = "Execution Comments";
                    worksheet.Cells[row, 22].Value = "RN_TEST_CONFIG_ID";
                    worksheet.Cells[row, 23].Value = "RN_RUN_ID";
                    worksheet.Cells[row, 24].Value = "RN_EXECUTION_DATE";
                    worksheet.Cells[row, 25].Value = "RN_EXECUTION_TIME";
                    worksheet.Cells[row, 26].Value = "RN_HOST";
                    worksheet.Cells[row, 27].Value = "RN_STATUS";
                    worksheet.Cells[row, 28].Value = "RN_DURATION";
                    worksheet.Cells[row, 29].Value = "RN_DRAFT";
                    worksheet.Cells[row, 30].Value = "RN_ATTACHMENT";

                    worksheet.Cells[row, 31].Value = "RN_OS_NAME";
                    worksheet.Cells[row, 32].Value = "RN_OS_SP";
                    worksheet.Cells[row, 33].Value = "RN_OS_BUILD";
                    worksheet.Cells[row, 34].Value = "RN_SUBTYPE_ID";
                    worksheet.Cells[row, 35].Value = "RCR_ID";
                    worksheet.Cells[row, 36].Value = "Configuration Description";
                    worksheet.Cells[row, 37].Value = "ST_ID";
                    worksheet.Cells[row, 38].Value = "ST_STEP_NAME";
                    worksheet.Cells[row, 39].Value = "ST_DESCRIPTION";
                    worksheet.Cells[row, 40].Value = "ST_EXPECTED";
                    worksheet.Cells[row, 41].Value = "ST_ACTUAL";
                    worksheet.Cells[row, 42].Value = "ST_EXECUTION_DATE";
                    worksheet.Cells[row, 43].Value = "ST_EXECUTION_TIME";
                    worksheet.Cells[row, 44].Value = "ST_STATUS";
                    worksheet.Cells[row, 45].Value = "ST_DESSTEP_ID";
                    worksheet.Cells[row, 46].Value = "ST_ATTACHMENT";
                    worksheet.Cells[row, 47].Value = "RN_NAME";
                    for (row = 0; row < tSInstanceSteps.Count; row++)
                    {
                        int rowInc = row + 2;
                        worksheet.Cells[rowInc, 1].Value = tSInstanceSteps.ElementAt(row).Hierarchy;
                        worksheet.Cells[rowInc, 2].Value = tSInstanceSteps.ElementAt(row).StructuralName;
                        worksheet.Cells[rowInc, 3].Value = tSInstanceSteps.ElementAt(row).CF_DESCR;
                        worksheet.Cells[rowInc, 4].Value = tSInstanceSteps.ElementAt(row).CY_CYCLE_ID;
                        worksheet.Cells[rowInc, 5].Value = tSInstanceSteps.ElementAt(row).CY_CYCLE;
                        worksheet.Cells[rowInc, 6].Value = tSInstanceSteps.ElementAt(row).CY_OPEN_DATE;
                        worksheet.Cells[rowInc, 7].Value = tSInstanceSteps.ElementAt(row).CY_CLOSE_DATE;
                        worksheet.Cells[rowInc, 8].Value = tSInstanceSteps.ElementAt(row).CY_STATUS;
                        worksheet.Cells[rowInc, 9].Value = tSInstanceSteps.ElementAt(row).CY_DESCRIPTION;
                        worksheet.Cells[rowInc, 10].Value = tSInstanceSteps.ElementAt(row).CY_COMMENT;

                        worksheet.Cells[rowInc, 11].Value = tSInstanceSteps.ElementAt(row).CY_ATTACHMENT;
                        worksheet.Cells[rowInc, 12].Value = tSInstanceSteps.ElementAt(row).TC_TEST_ID;
                        worksheet.Cells[rowInc, 13].Value = tSInstanceSteps.ElementAt(row).TC_TEST_ORDER;
                        worksheet.Cells[rowInc, 14].Value = tSInstanceSteps.ElementAt(row).TC_STATUS;
                        worksheet.Cells[rowInc, 15].Value = tSInstanceSteps.ElementAt(row).TC_TESTER_NAME;
                        worksheet.Cells[rowInc, 16].Value = tSInstanceSteps.ElementAt(row).TC_EXEC_DATE;
                        worksheet.Cells[rowInc, 17].Value = tSInstanceSteps.ElementAt(row).TC_EXEC_TIME;
                        worksheet.Cells[rowInc, 18].Value = tSInstanceSteps.ElementAt(row).TC_ATTACHMENT;
                        worksheet.Cells[rowInc, 19].Value = tSInstanceSteps.ElementAt(row).TC_Defect_ID;
                        worksheet.Cells[rowInc, 20].Value = tSInstanceSteps.ElementAt(row).TC_SUBTYPE_ID;

                        worksheet.Cells[rowInc, 21].Value = tSInstanceSteps.ElementAt(row).TC_Execution_Comments;
                        worksheet.Cells[rowInc, 22].Value = tSInstanceSteps.ElementAt(row).RN_TEST_CONFIG_ID;
                        worksheet.Cells[rowInc, 23].Value = tSInstanceSteps.ElementAt(row).RN_RUN_ID;
                        worksheet.Cells[rowInc, 24].Value = tSInstanceSteps.ElementAt(row).RN_EXECUTION_DATE;
                        worksheet.Cells[rowInc, 25].Value = tSInstanceSteps.ElementAt(row).RN_EXECUTION_TIME;
                        worksheet.Cells[rowInc, 26].Value = tSInstanceSteps.ElementAt(row).RN_HOST;
                        worksheet.Cells[rowInc, 27].Value = tSInstanceSteps.ElementAt(row).RN_STATUS;
                        worksheet.Cells[rowInc, 28].Value = tSInstanceSteps.ElementAt(row).RN_DURATION;
                        worksheet.Cells[rowInc, 29].Value = tSInstanceSteps.ElementAt(row).RN_DRAFT;
                        worksheet.Cells[rowInc, 30].Value = tSInstanceSteps.ElementAt(row).RN_ATTACHMENT;

                        worksheet.Cells[rowInc, 31].Value = tSInstanceSteps.ElementAt(row).RN_OS_NAME;
                        worksheet.Cells[rowInc, 32].Value = tSInstanceSteps.ElementAt(row).RN_OS_SP;
                        worksheet.Cells[rowInc, 33].Value = tSInstanceSteps.ElementAt(row).RN_OS_BUILD;
                        worksheet.Cells[rowInc, 34].Value = tSInstanceSteps.ElementAt(row).RN_SUBTYPE_ID;
                        worksheet.Cells[rowInc, 35].Value = tSInstanceSteps.ElementAt(row).RCR_ID;
                        worksheet.Cells[rowInc, 36].Value = tSInstanceSteps.ElementAt(row).RCR_DESCRIPTION;
                        worksheet.Cells[rowInc, 37].Value = tSInstanceSteps.ElementAt(row).ST_ID;
                        worksheet.Cells[rowInc, 38].Value = tSInstanceSteps.ElementAt(row).ST_STEP_NAME;
                        worksheet.Cells[rowInc, 39].Value = tSInstanceSteps.ElementAt(row).ST_DESCRIPTION;
                        worksheet.Cells[rowInc, 40].Value = tSInstanceSteps.ElementAt(row).ST_EXPECTED;
                        worksheet.Cells[rowInc, 41].Value = tSInstanceSteps.ElementAt(row).ST_ACTUAL;
                        worksheet.Cells[rowInc, 42].Value = tSInstanceSteps.ElementAt(row).ST_EXECUTION_DATE;
                        worksheet.Cells[rowInc, 43].Value = tSInstanceSteps.ElementAt(row).ST_EXECUTION_TIME;
                        worksheet.Cells[rowInc, 44].Value = tSInstanceSteps.ElementAt(row).ST_STATUS;
                        worksheet.Cells[rowInc, 45].Value = tSInstanceSteps.ElementAt(row).ST_DESSTEP_ID;
                        worksheet.Cells[rowInc, 46].Value = tSInstanceSteps.ElementAt(row).ST_ATTACHMENT; 
                        worksheet.Cells[rowInc, 47].Value = tSInstanceSteps.ElementAt(row).RN_NAME;
                    }
                }

                // 保存Excel文件
                FileUtil.createFolder(xlsxPath);
                FileUtil.createFile(xlsxPath, xlsxName);
                var fileInfo = new FileInfo(xlsxPath+@"\"+xlsxName);
                package.SaveAs(fileInfo);
            }
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("WriteTSInstanceStep: END");
            Console.WriteLine("***************************************");
            Console.WriteLine();

        }
        static public void WriteTestCase(string xlsxPath, string xlsxName, string sheetName, List<QCTestCase> oQCTestCases)
        {
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("WriteTestCase: START");
            Console.WriteLine("***************************************");
            Console.WriteLine();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add(sheetName);
                int row = 1;
                worksheet.Cells[row, 1].Value = "Hierarchy";
                worksheet.Cells[row, 2].Value = "Name";
                worksheet.Cells[row, 3].Value = "Description";
                worksheet.Cells[row, 4].Value = "Verification Case Status";
                worksheet.Cells[row, 5].Value = "Step#";
                worksheet.Cells[row, 6].Value = "Step Action";
                worksheet.Cells[row, 7].Value = "Step Expected Result";
                worksheet.Cells[row, 8].Value = "Step Notes";
                worksheet.Cells[row, 9].Value = "Verification Method";
                worksheet.Cells[row, 10].Value = "Legacy Trace";

                worksheet.Cells[row, 11].Value = "Assigned";
                worksheet.Cells[row, 12].Value = "AL_FATHER_ID";
                worksheet.Cells[row, 13].Value = "Folder_DESCRIPTION";
                worksheet.Cells[row, 14].Value = "TS_RESPONSIBLE";
                worksheet.Cells[row, 15].Value = "TS_ATTACHMENT";
                worksheet.Cells[row, 16].Value = "DS_HAS_PARAMS";
                worksheet.Cells[row, 17].Value = "DS_LINK_TEST";
                worksheet.Cells[row, 18].Value = "AL_VIEW_ORDER";
                for (row = 0; row < oQCTestCases.Count; row++)
                {
                    int rowInc = row + 2;
                    worksheet.Cells[rowInc, 1].Value = oQCTestCases.ElementAt(row).Hierarchy;
                    worksheet.Cells[rowInc, 2].Value = oQCTestCases.ElementAt(row).Name;
                    worksheet.Cells[rowInc, 3].Value = oQCTestCases.ElementAt(row).Description;
                    worksheet.Cells[rowInc, 4].Value = oQCTestCases.ElementAt(row).Verification_Case_Status;
                    worksheet.Cells[rowInc, 5].Value = oQCTestCases.ElementAt(row).DS_STEP_ORDER;
                    worksheet.Cells[rowInc, 6].Value = oQCTestCases.ElementAt(row).Step_Action;
                    worksheet.Cells[rowInc, 7].Value = oQCTestCases.ElementAt(row).Step_Expected_Result;
                    worksheet.Cells[rowInc, 8].Value = oQCTestCases.ElementAt(row).Step_Notes;
                    worksheet.Cells[rowInc, 9].Value = oQCTestCases.ElementAt(row).Verification_Method;
                    worksheet.Cells[rowInc, 10].Value = oQCTestCases.ElementAt(row).Legacy_Trace;

                    worksheet.Cells[rowInc, 11].Value = oQCTestCases.ElementAt(row).Assigned;
                    worksheet.Cells[rowInc, 12].Value = oQCTestCases.ElementAt(row).AL_FATHER_ID;
                    worksheet.Cells[rowInc, 13].Value = oQCTestCases.ElementAt(row).Folder_DESCRIPTION;
                    worksheet.Cells[rowInc, 14].Value = oQCTestCases.ElementAt(row).TS_RESPONSIBLE;
                    worksheet.Cells[rowInc, 15].Value = oQCTestCases.ElementAt(row).TS_ATTACHMENT;
                    worksheet.Cells[rowInc, 16].Value = oQCTestCases.ElementAt(row).DS_HAS_PARAMS;
                    worksheet.Cells[rowInc, 17].Value = oQCTestCases.ElementAt(row).DS_LINK_TEST;
                    worksheet.Cells[rowInc, 18].Value = oQCTestCases.ElementAt(row).AL_VIEW_ORDER;
                }

                // 保存Excel文件
                FileUtil.createFolder(xlsxPath);
                FileUtil.createFile(xlsxPath, xlsxName);
                var fileInfo = new FileInfo(xlsxPath + @"\" + xlsxName);
                package.SaveAs(fileInfo);
            }
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("WriteTestCase: END");
            Console.WriteLine("***************************************");
            Console.WriteLine();

        }

        static public void WriteRequirement(string xlsxPath, string xlsxName, string sheetName, List<QCReq> oQCReqs)
        {
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("WriteRequirement: START");
            Console.WriteLine("***************************************");
            Console.WriteLine();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add(sheetName);
                int row = 1;
                worksheet.Cells[row, 1].Value = "Hierarchy";
                worksheet.Cells[row, 2].Value = "Legacy ID";
                worksheet.Cells[row, 3].Value = "Title";
                worksheet.Cells[row, 4].Value = "Requirement";
                worksheet.Cells[row, 5].Value = "Release Introduced";
                worksheet.Cells[row, 6].Value = "REQ Status";
                worksheet.Cells[row, 7].Value = "Priority";
                worksheet.Cells[row, 8].Value = "Type";
                worksheet.Cells[row, 9].Value = "RQ_ORDER_ID";
                worksheet.Cells[row, 10].Value = "parentId";

                worksheet.Cells[row, 11].Value = "parentTitle";
                worksheet.Cells[row, 12].Value = "FolderOrNot";
                worksheet.Cells[row, 13].Value = "linkTestCases";
                worksheet.Cells[row, 14].Value = "RQ_REQ_STATUS";
                worksheet.Cells[row, 15].Value = "RQ_REQ_PRODUCT";
                worksheet.Cells[row, 16].Value = "RQ_REQ_TYPE";
                worksheet.Cells[row, 17].Value = "RQ_ATTACHMENT";
                for (row = 0; row < oQCReqs.Count; row++)
                {
                    int rowInc = row + 2;
                    worksheet.Cells[rowInc, 1].Value = oQCReqs.ElementAt(row).Hierarchy;
                    worksheet.Cells[rowInc, 2].Value = oQCReqs.ElementAt(row).Legacy_ID;
                    worksheet.Cells[rowInc, 3].Value = oQCReqs.ElementAt(row).Title;
                    worksheet.Cells[rowInc, 4].Value = oQCReqs.ElementAt(row).Requirement;
                    worksheet.Cells[rowInc, 5].Value = oQCReqs.ElementAt(row).Release_Introduced;
                    worksheet.Cells[rowInc, 6].Value = oQCReqs.ElementAt(row).REQ_Status;
                    worksheet.Cells[rowInc, 7].Value = oQCReqs.ElementAt(row).Priority;
                    worksheet.Cells[rowInc, 8].Value = oQCReqs.ElementAt(row).Type;
                    worksheet.Cells[rowInc, 9].Value = oQCReqs.ElementAt(row).RQ_ORDER_ID;
                    worksheet.Cells[rowInc, 10].Value = oQCReqs.ElementAt(row).parentId;

                    worksheet.Cells[rowInc, 11].Value = oQCReqs.ElementAt(row).parentTitle;
                    worksheet.Cells[rowInc, 12].Value = oQCReqs.ElementAt(row).FolderOrNot;
                    worksheet.Cells[rowInc, 13].Value = oQCReqs.ElementAt(row).linkTestCases;
                    worksheet.Cells[rowInc, 14].Value = oQCReqs.ElementAt(row).RQ_REQ_STATUS;
                    worksheet.Cells[rowInc, 15].Value = oQCReqs.ElementAt(row).RQ_REQ_PRODUCT;
                    worksheet.Cells[rowInc, 16].Value = oQCReqs.ElementAt(row).RQ_REQ_TYPE;
                    worksheet.Cells[rowInc, 17].Value = oQCReqs.ElementAt(row).RQ_ATTACHMENT;
                }

                // 保存Excel文件
                FileUtil.createFolder(xlsxPath);
                FileUtil.createFile(xlsxPath, xlsxName);
                var fileInfo = new FileInfo(xlsxPath + @"\" + xlsxName);
                package.SaveAs(fileInfo);
            }
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("WriteRequirement: END");
            Console.WriteLine("***************************************");
            Console.WriteLine();

        }

        static public void WriteTCTrace(string xlsxPath, string xlsxName, string sheetName, List<QCTCTrace> oQCTraces)
        {
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("WriteRequirement: START");
            Console.WriteLine("***************************************");
            Console.WriteLine();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add(sheetName);
                int row = 1;
                worksheet.Cells[row, 1].Value = "QC_ReqID";
                worksheet.Cells[row, 2].Value = "QC_ReqName";
                worksheet.Cells[row, 3].Value = "QC_TCID";
                worksheet.Cells[row, 4].Value = "QC_TCName";
                for (row = 0; row < oQCTraces.Count; row++)
                {
                    int rowInc = row + 2;
                    worksheet.Cells[rowInc, 1].Value = oQCTraces.ElementAt(row).QC_ReqID;
                    worksheet.Cells[rowInc, 2].Value = oQCTraces.ElementAt(row).QC_ReqName;
                    worksheet.Cells[rowInc, 3].Value = oQCTraces.ElementAt(row).QC_TCID;
                    worksheet.Cells[rowInc, 4].Value = oQCTraces.ElementAt(row).QC_TCName;
                }

                // 保存Excel文件
                FileUtil.createFolder(xlsxPath);
                FileUtil.createFile(xlsxPath, xlsxName);
                var fileInfo = new FileInfo(xlsxPath + @"\" + xlsxName);
                package.SaveAs(fileInfo);
            }
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("WriteRequirement: END");
            Console.WriteLine("***************************************");
            Console.WriteLine();

        }

    }
}
