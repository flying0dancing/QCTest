using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TDAPIOLELib;

namespace QCTest
{
    class QCTestCase
    {
        public string Hierarchy { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string Verification_Case_Status { get; set; } //Verification Case Status
        public string DS_STEP_ORDER { get; set; } //Step#
        public string Step_Action { get; set; }
        public string Step_Expected_Result { get; set; }
        
        public string Step_Notes { get; set; } //Step Notes
        public string Verification_Method { get; set; } //Verification Method
        public string Legacy_Trace { get; set; } //Legacy Trace
        public string Assigned { get; set; } //Assigned
        public string AL_FATHER_ID { get; set; } //AL_FATHER_ID
        public string Folder_DESCRIPTION { get; set; }
        public string TS_RESPONSIBLE { get; set; }
        public string TS_ATTACHMENT { get; set; } //Folder_DESCRIPTION
        public string DS_HAS_PARAMS { get; set; } //DS_HAS_PARAMS DS_LINK_TEST AL_VIEW_ORDER
        public string DS_LINK_TEST { get; set; }
        public string AL_VIEW_ORDER { get; set; }

        public QCTestCase(Recordset oRecordset )
        {
            this.Hierarchy = oRecordset[0];
            this.Name = oRecordset[1];
            this.Description = oRecordset[2];
            this.Verification_Case_Status = oRecordset[3];
            this.DS_STEP_ORDER = oRecordset[4];//Step#
            this.Step_Action = oRecordset[5];
            this.Step_Expected_Result = oRecordset[6];
            this.Step_Notes = oRecordset[7];
            this.Verification_Method = oRecordset[8];
            this.Legacy_Trace = oRecordset[9];
            this.Assigned= oRecordset[10];

            this.AL_FATHER_ID = oRecordset[11];
            this.Folder_DESCRIPTION = oRecordset[12];
            this.TS_RESPONSIBLE = oRecordset[13];
            this.TS_ATTACHMENT = oRecordset[14];
            this.DS_HAS_PARAMS = oRecordset[15];
            this.DS_LINK_TEST = oRecordset[16];
            this.AL_VIEW_ORDER = oRecordset[17];
        }

        public static void DisplayTestCases(ref TDConnection tdconn, string QCTestCaseExportPath, string QCTestCaseExcelName, string QCTestCaseExcelSheetName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayTestCases: START");
            Console.WriteLine("***************************************");
            Console.WriteLine();
            Command oCommand = tdconn.Command;
            oCommand.CommandText = QCSQL.SQL_QC_TestCases;
            Recordset oRecordset = oCommand.Execute();
            if (oRecordset.EOR.Equals(oRecordset.BOR) && oRecordset.Position == 0)
            {
                Console.WriteLine("DisplayTestCases:No records.");
            }
            else
            {
                List<QCTestCase> oQCTestCases = new List<QCTestCase>();
                QCTestCase oQCTestCase = null;
                oRecordset.First();
                for (int i = 1; i <= oRecordset.RecordCount; i++)
                {
                    oQCTestCase = new QCTestCase(oRecordset);
                    oQCTestCases.Add(oQCTestCase);
                    oRecordset.Next();
                }
                List<QCTestCase> oQCTestCases_Ordered = oQCTestCases.OrderBy(a => a.Hierarchy).ThenBy(a => a.Name).ThenBy(a => a.DS_STEP_ORDER).ToList();
                ExcelUtil.WriteTestCase(QCTestCaseExportPath, QCTestCaseExcelName, QCTestCaseExcelSheetName, oQCTestCases_Ordered);

            }

            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine($"DisplayTestCases: END, used {stopwatch.Elapsed.TotalSeconds:F2}seconds.");
            Console.WriteLine("***************************************");
            Console.WriteLine();
        }

    }
}
