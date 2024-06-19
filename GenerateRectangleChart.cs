using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
//using Mercury.TD.Client.Ota.QC9;
using TDAPIOLELib;

namespace QCTest
{
    class GenerateRectangleChart
    {
        public static Bitmap RectangleChart(ref Graph oGraph, string chartTitle, string chartXName,string chartYName)
        {
            int Bitmapwidth = 1050, Bitmapheight = 750;
            float AxisMarginLeft = 60, AxisMarginUp = 100, AxisYLen = 500,AxisXLen=800;
            Bitmap oBitmap = new Bitmap(Bitmapwidth, Bitmapheight);
            Font oFont_Title = new Font("Segoe UI",11);
            Font oFont_Chart = new Font("Segoe UI",10);
            PointF oPointF_Title = new PointF(Bitmapwidth / 3, 50);
            PointF oPointF_AxisStart = new PointF(AxisMarginLeft, AxisMarginUp + AxisYLen);
            PointF oPointF_AxisX = new PointF(AxisMarginLeft + AxisXLen, AxisMarginUp + AxisYLen);
            PointF oPointF_AxisY = new PointF(AxisMarginLeft, AxisMarginUp);
            float pieces = 3;
            float eachRowWidth=AxisXLen/oGraph.RowCount;
            float eachColWidth = AxisYLen / (oGraph.MaxValue + 1);
           
            try
            {
                StringFormat oStringFormat = new StringFormat(StringFormatFlags.DirectionVertical);
                oStringFormat.Alignment = StringAlignment.Near;
                oStringFormat.LineAlignment = StringAlignment.Center;

                StringFormat oStringFormatY = new StringFormat(StringFormatFlags.DirectionRightToLeft);
                oStringFormatY.Alignment = StringAlignment.Near;
                oStringFormatY.LineAlignment = StringAlignment.Center;

                StringFormat oStringFormatRowTotal = new StringFormat();
                oStringFormatRowTotal.Alignment = StringAlignment.Center;
                oStringFormatRowTotal.LineAlignment = StringAlignment.Far;

                Graphics oGraphics = Graphics.FromImage(oBitmap);
                oGraphics.Clear(Color.WhiteSmoke);
                oGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                oGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                oGraphics.CompositingQuality = CompositingQuality.HighQuality;
                oGraphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;

                oGraphics.DrawString(chartTitle, oFont_Title, Brushes.Blue, oPointF_Title);//Title
                oGraphics.DrawLine(Pens.Black, oPointF_AxisStart, oPointF_AxisX);//x-axis
                oGraphics.DrawLine(Pens.Black, oPointF_AxisStart, oPointF_AxisY);//y-axis
                oGraphics.DrawString(chartXName, oFont_Chart, Brushes.Black, new PointF(Bitmapwidth / 3, Bitmapheight - 30));//Name(x-axis)
                oGraphics.DrawString(chartYName, oFont_Chart, Brushes.Black, new PointF(10, Bitmapheight / 3), oStringFormat);//Name(y-axis)
               
                //draw Axis-Y
                for (int i = 1; i <=oGraph.MaxValue; i++)
                {
                    oGraphics.DrawLine(Pens.Black, new PointF(AxisMarginLeft, AxisMarginUp + AxisYLen - eachColWidth * i), new PointF(AxisMarginLeft - 5, AxisMarginUp + AxisYLen - eachColWidth * i));
                    oGraphics.DrawString(i.ToString(), oFont_Chart, Brushes.Black, new PointF(AxisMarginLeft - 5, AxisMarginUp + AxisYLen - eachColWidth * i), oStringFormatY);
                }
                for (int i = 0; i < oGraph.RowCount; i++)
                {
                    //draw Axis-X
                    oGraphics.DrawLine(Pens.Black, new PointF(AxisMarginLeft + eachRowWidth * (i + 1), AxisMarginUp + AxisYLen), new PointF(AxisMarginLeft + eachRowWidth * (i + 1), AxisMarginUp + AxisYLen - 5));
                    oGraphics.DrawString(oGraph.RowName[i], oFont_Chart, Brushes.Black, new PointF(AxisMarginLeft + eachRowWidth * (0.5F + i), AxisMarginUp + AxisYLen), oStringFormat);
                    //draw chart
                    int existHeightBy = 0;
                    for (int j = 0; j < oGraph.ColCount; j++)
                    {
                        oGraphics.DrawRectangle(new Pen(GetColor(oGraph.ColName[j])), AxisMarginLeft + eachRowWidth * (1 / pieces + i), AxisMarginUp + AxisYLen - eachColWidth * (oGraph.Data[j, i] + existHeightBy), eachRowWidth / pieces, eachColWidth * oGraph.Data[j, i]);
                        oGraphics.FillRectangle(new SolidBrush(GetColor(oGraph.ColName[j])), AxisMarginLeft + eachRowWidth * (1 / pieces + i), AxisMarginUp + AxisYLen - eachColWidth * (oGraph.Data[j, i]+existHeightBy), eachRowWidth / pieces, eachColWidth * oGraph.Data[j, i]);
                        existHeightBy += oGraph.Data[j, i];
                    }
                    oGraphics.DrawString(oGraph.RowTotal[i].ToString(), oFont_Chart, Brushes.Black, new PointF(AxisMarginLeft + eachRowWidth * (0.5F + i), AxisMarginUp + AxisYLen - eachColWidth * oGraph.RowTotal[i]), oStringFormatRowTotal);
                }
                //draw color sample
                for (int j = 0; j < oGraph.ColCount; j++)
                {
                    oGraphics.FillRectangle(new SolidBrush(GetColor(oGraph.ColName[j])), AxisMarginLeft + AxisXLen, AxisMarginUp + 12.5F * j, 20, 10);
                    oGraphics.DrawString(oGraph.ColName[j]+" ["+string.Format("{0:P}",(float)oGraph.ColTotal[j]/(float)oGraph.GraphTotal)+"]", oFont_Chart, Brushes.Black, new PointF(AxisMarginLeft + AxisXLen + 20, AxisMarginUp + 12.5F * j - 5));
                
                }


            }
            catch (Exception)
            {
                
                throw;
            }
            return oBitmap;
        }


        public static Color GetColor(string status)
        {
            Color oColor=Color.Tomato;
            try
            {
                switch (status)
                {
                    case "Design":
                        oColor = Color.Turquoise; break;
                    case "Expired":
                        oColor = Color.Olive; break;
                    case "Imported":
                        oColor = Color.Tan; break;
                    case "Ready":
                        oColor = Color.DeepPink; break;
                    case "Review - Failed":
                        oColor = Color.Red; break;
                    case "Review - Pass":
                        oColor = Color.Green; break;

                    case "Blocked":
                        oColor = Color.Olive; break;
                    case "Deferred":
                        oColor = Color.MediumPurple; break;
                    case "Failed":
                        oColor = Color.Red; break;
                    case "N/A":
                        oColor = Color.Black; break;
                    case "No Run":
                        oColor = Color.Goldenrod; break;
                    case "Not Completed":
                        oColor = Color.Violet; break;
                    case "Passed":
                        oColor = Color.Green; break;
                    case "Skipped":
                        oColor = Color.Gray; break;

                    default: oColor = Color.Tomato; 
                        break;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            return oColor;
 
        }
    }
}
