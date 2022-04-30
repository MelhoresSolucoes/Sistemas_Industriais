using Microsoft.Reporting.WinForms;
using SistemaIndustrial.View.Reports.ReportCompraGado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIndustrial.View
{
    public partial class frmReportViewers : Form
    {
        private ReportViewer _reportViewer;
        private int _idCompraGado;
        private LocalReport _report;
        public frmReportViewers(LocalReport report)
        {
            _report = report;
            StartContrutor();
        }
        public frmReportViewers()
        {
            StartContrutor();
        }

        private void StartContrutor()
        {
            InitializeComponent();

            _reportViewer = new ReportViewer();
            _reportViewer.Dock = DockStyle.Fill;
            Controls.Add(_reportViewer);
        }

        private void frmReportViewers_Load(object sender, EventArgs e)
        {
            frmReportViewers_Load(sender, e, _reportViewer);
        }

        private void frmReportViewers_Load(object sender, EventArgs e, ReportViewer _reportViewer)
        {

            //_report.LoadReportDefinition(reportDefinition);
            //_report.DataSources.Add(new ReportDataSource("source", dataSource));
            //_report.SetParameters(parameters);
            //_reportViewer.LocalReport.LoadReportDefinition(report);

            _reportViewer.RefreshReport();
            

        }
    }
}
