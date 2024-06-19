using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
//using Mercury.TD.Client.Ota.QC9;
using TDAPIOLELib;

namespace QCTest
{
    class QCReq
    {
        public string Hierarchy { get; set; }
        public string Legacy_ID { get; set; }
        public string Title { get; set; }
        public string Requirement { get; set; }
        public string Release_Introduced { get; set; }
        public string REQ_Status { get; set; }
        public string Priority { get; set; }
        public string Type { get; set; }
        public string RQ_ORDER_ID { get; set; }
        public string parentId { get; set; }
        public string parentTitle { get; set; }
        public string FolderOrNot { get; set; }
        public string linkTestCases { get; set; }
        public string RQ_REQ_STATUS { get; set; }
        public string RQ_REQ_PRODUCT { get; set; }
        public string RQ_REQ_TYPE { get; set; }
        public string RQ_ATTACHMENT { get; set; }

        public QCReq(Recordset oRecordset)
        {
            this.Hierarchy = oRecordset[0];
            this.Legacy_ID = oRecordset[1];
            this.Title = oRecordset[2];
            this.Requirement = oRecordset[3];
            this.Release_Introduced = oRecordset[4];
            this.REQ_Status = oRecordset[5];
            this.Priority = oRecordset[6];
            this.Type = oRecordset[7];
            this.RQ_ORDER_ID = oRecordset[8];
            this.parentId = oRecordset[9];
            this.parentTitle = oRecordset[10];

            this.FolderOrNot = oRecordset[11];
            this.linkTestCases = oRecordset[12];
            this.RQ_REQ_STATUS = oRecordset[13];
            this.RQ_REQ_PRODUCT = oRecordset[14];
            this.RQ_REQ_TYPE = oRecordset[15];
            this.RQ_ATTACHMENT = oRecordset[16];
        }

        public static void DisplayRequirements(ref TDConnection tdconn, string ExportPath, string ExcelName, string ExcelSheetName)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine("DisplayRequirements: START");
            Console.WriteLine("***************************************");
            Console.WriteLine();
            Command oCommand = tdconn.Command;
            oCommand.CommandText = QCSQL.SQL_QC_Req;
            Recordset oRecordset = oCommand.Execute();
            if (oRecordset.EOR.Equals(oRecordset.BOR) && oRecordset.Position == 0)
            {
                Console.WriteLine("DisplayTestCases:No records.");
            }
            else
            {
                List<QCReq> oQCReqs = new List<QCReq>();
                QCReq oQCReq = null;
                oRecordset.First();
                for (int i = 1; i <= oRecordset.RecordCount; i++)
                {
                    oQCReq = new QCReq(oRecordset);
                    oQCReqs.Add(oQCReq);
                    oRecordset.Next();
                }
                List<QCReq> oQCReqs_Ordered = oQCReqs.OrderBy(a => a.Hierarchy).ThenBy(a => a.RQ_ORDER_ID).ToList();
                ExcelUtil.WriteRequirement(ExportPath, ExcelName, ExcelSheetName, oQCReqs_Ordered);

            }

            stopwatch.Stop();
            Console.WriteLine();
            Console.WriteLine("***************************************");
            Console.WriteLine($"DisplayRequirements: END, used {stopwatch.Elapsed.TotalSeconds:F2}seconds.");
            Console.WriteLine("***************************************");
            Console.WriteLine();
        }


    }
}
