using Microsoft.Reporting.WinForms;
using SistemaIndustrial.Reports.Reports;
using SistemaIndustrial.View.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIndustrial.Reports
{
    public partial class frmReport : Form
    {

        private int _IdCompra;

        private CompraGadoViewModel _compraGadoCabecalho;
        private readonly static string _connectionString = ConfigurationManager.ConnectionStrings["SisIndConnectionString"].ConnectionString;
        private List<CompraGadoItemViewModel> _listItens;
        public frmReport()
        {
            InitializeComponent();
            _IdCompra = 30;
        }
        public frmReport(int idCompra)
        {
            InitializeComponent();
            _IdCompra = idCompra;
        }

        private void CriarReportCompraGado()
        {
            BuscarCabecalhoCompra();

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportEmbeddedResource = "SistemaIndustrial.Reports.Reports.ReportCompraGado.rdlc";

            var parameters = new[] { new ReportParameter("Title", "Relatório de Compra de Gado"),
                                     new ReportParameter("Id", _compraGadoCabecalho.Id.ToString()),
                                     new ReportParameter("DataEntrega",_compraGadoCabecalho.DataEntrega.ToShortDateString()),
                                     new ReportParameter("Pecuarista", _compraGadoCabecalho.Pecuarista),
                                     new ReportParameter("Total", _compraGadoCabecalho.Total.ToString("C2"))};

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsCompraGado", _listItens));
            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CriarReportCompraGado();
            this.reportViewer1.RefreshReport();
        }
        private bool BuscarCabecalhoCompra()
        {
            string sql = "Select Id,Nome,DataEntrega,Total from vwCompraGado as C Where C.Id = @IdCompraGado";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Connection.Open();
                command.Parameters.AddWithValue("@IdCompraGado", _IdCompra);
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    _compraGadoCabecalho = new CompraGadoViewModel();
                    _compraGadoCabecalho.Id = int.Parse(reader["Id"].ToString());
                    _compraGadoCabecalho.Pecuarista = reader.GetString(1);
                    _compraGadoCabecalho.DataEntrega = reader.GetDateTime(2);
                    _compraGadoCabecalho.Total = reader.GetDecimal(3);

                }

                return true;
            }
        }
        private bool BuscarItensCompra()
        {
            string sql = "Select Id,Descricao,Preco,Quantidade,Total from vwCompraGadoItem as C Where C.Id = @IdCompraGado";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Connection.Open();
                command.Parameters.AddWithValue("@IdCompraGado", _IdCompra);
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();
                if (_listItens == null)
                    _listItens = new List<CompraGadoItemViewModel>();
                
                while (reader.Read())
                {
                    CompraGadoItemViewModel itemCompra = new CompraGadoItemViewModel();
                    itemCompra.Id = int.Parse(reader["Id"].ToString());
                    itemCompra.IdCompraGado = int.Parse(reader["IdCompraGado"].ToString());
                    itemCompra.Preco = decimal.Parse(reader["Preco"].ToString()); 
                    itemCompra.Descricao = reader["Descricao"].ToString();
                    itemCompra.Total = decimal.Parse(reader["Total"].ToString());
                    
                    _listItens.Add(itemCompra);
                }

                return true;
            }
        }
    }
}
