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
        }
        public frmReport(int idCompra)
        {
            InitializeComponent();
            _IdCompra = idCompra;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dsv_SisIndDataSet1.vwCompraGado'. Você pode movê-la ou removê-la conforme necessário.
            this.vwCompraGadoTableAdapter.Fill(this.dsv_SisIndDataSet1.vwCompraGado);
        }
        private void CriarReportCompraGado()
        {
            BuscarCabecalhoCompra();
            BuscarItensCompra();

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
            string sql = "Select Id,Descricao,Preco,Quantidade,Total from vwCompraGadoItem as C Where C.idCompraGado = @IdCompraGado";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Connection.Open();
                command.Parameters.AddWithValue("@IdCompraGado", _IdCompra);
                command.ExecuteNonQuery();

                SqlDataReader reader = command.ExecuteReader();
                _listItens = new List<CompraGadoItemViewModel>();
                
                while (reader.Read())
                {
                    CompraGadoItemViewModel itemCompra = new CompraGadoItemViewModel();
                    itemCompra.Id = int.Parse(reader["Id"].ToString());
                    //itemCompra.IdCompraGado = int.Parse(reader["IdCompraGado"].ToString());
                    itemCompra.Preco = decimal.Parse(reader["Preco"].ToString()); 
                    itemCompra.Descricao = reader["Descricao"].ToString();
                    itemCompra.Quantidade = int.Parse(reader["Quantidade"].ToString());
                    itemCompra.Total = decimal.Parse(reader["Total"].ToString());
                    
                    _listItens.Add(itemCompra);
                }

                return true;
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            _IdCompra = Int32.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            CriarReportCompraGado();
            this.reportViewer1.RefreshReport();
        }
    }
}
