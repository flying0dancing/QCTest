using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TDAPIOLELib;

namespace QCTest
{
    class QCTCTrace
    {
        public string QC_ReqID { get; set; }
        public string QC_ReqName { get; set; }
        public string QC_TCID { get; set; }
        public string QC_TCName { get; set; }

        public QCTCTrace(Recordset oRecordset)
        {
            this.QC_ReqID = oRecordset[0];
            this.QC_ReqName = oRecordset[1];
            this.QC_TCID = oRecordset[2];
            this.QC_TCName = oRecordset[3];
        }
        public static void DisplayTCTrace(ref TDConnection tdconn, string ExportPath, string ExcelName, string ExcelSheetName,string sql)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayTCTrace: START");
            Console.WriteLine("***************************************");
            Console.WriteLine();
            Command oCommand = tdconn.Command;
            oCommand.CommandText = sql;//QCSQL.SQL_QC_TCTrace
            Recordset oRecordset = oCommand.Execute();
            if (oRecordset.EOR.Equals(oRecordset.BOR) && oRecordset.Position == 0)
            {
                Console.WriteLine("DisplayTestCases:No records.");
            }
            else
            {
                List<QCTCTrace> oQCTCTraces = new List<QCTCTrace>();
                QCTCTrace oQCTCTrace = null;
                oRecordset.First();
                for (int i = 1; i <= oRecordset.RecordCount; i++)
                {
                    oQCTCTrace = new QCTCTrace(oRecordset);
                    oQCTCTraces.Add(oQCTCTrace);
                    oRecordset.Next();
                }
                
                ExcelUtil.WriteTCTrace(ExportPath, ExcelName, ExcelSheetName, oQCTCTraces);

            }

            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine($"DisplayTCTrace: END, used {stopwatch.Elapsed.TotalSeconds:F2}seconds.");
            Console.WriteLine("***************************************");
            Console.WriteLine();
        }
    }
}
