using Microsoft.Reporting.WinForms;
using Proyecto_TFG.Commands;
using Proyecto_TFG.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Proyecto_TFG.ViewModels
{
    internal class PDFViewModel:ViewModelBase
    {
        public ICommand updateViewCommandv2;
        
        public string PDFData { get; set; }

        ReportViewer myReport { get; set; }

        ReportDataSource rds { get; set; }

        private string CurrentPath = Environment.CurrentDirectory;
        private string OutboundOrder = "Reporting/OutboundPDF.rdlc";
        private string InboundOrder = "Reporting/InboundPDF.rdlc";
        public PDFViewModel(UpdateViewCommandV2 updateViewCommand)
        {
            updateViewCommandv2 = updateViewCommand;
            myReport = new ReportViewer();
            rds = new ReportDataSource();
        }

        public void generatePDF(int orderid)
        {
            rds.Name = "outboundPDF";
            rds.Value = DataSetHandler.getOutboundDataByOrderId(orderid);
            myReport.LocalReport.DataSources.Add(rds);
            myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, OutboundOrder);
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            PDFData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
        }

        public void generateInbPDF(int orderid)
        {
            rds.Name = "InboundPDF";
            rds.Value = DataSetHandler.getInboundDataByOrderID(orderid);
            myReport.LocalReport.DataSources.Add(rds);
            myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InboundOrder);
            byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
            PDFData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
        }
    }
}
