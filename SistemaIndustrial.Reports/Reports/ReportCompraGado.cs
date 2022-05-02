using Microsoft.Reporting.WinForms;
using SistemaIndustrial.View.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIndustrial.Reports.Reports
{
    public class ReportCompraGado
    {
        private static CompraGadoViewModel _compraGadoCabecalho;
        private readonly static string _connectionString = ConfigurationManager.ConnectionStrings["SisIndConnectionString"].ConnectionString;
        public static void Load( int idCompraGado)
        {
            List<CompraGadoItemViewModel> listcompraGadoItens =  BuscarItensCompra(idCompraGado);
            BuscarCabecalhoCompra(idCompraGado);

            var parameters = new[] { new ReportParameter("Title", "Relatório de Compra de Gado"),
                                     new ReportParameter("Id", _compraGadoCabecalho.Id.ToString()),
                                     new ReportParameter("DataEntrega", _compraGadoCabecalho.DataEntrega.ToShortDateString()),
                                     new ReportParameter("Pecuarista", _compraGadoCabecalho.Pecuarista)};
            FileStream fs = new FileStream(".\\ReportCompraGado.rdlc", FileMode.Open);

            ReportViewer reportViewer = new ReportViewer();
            reportViewer.LocalReport.LoadReportDefinition(fs);
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("dsCompraGado", listcompraGadoItens));
            reportViewer.LocalReport.SetParameters(parameters);

            reportViewer.LocalReport.Refresh();

        }
        private static List<CompraGadoItemViewModel> BuscarItensCompra(int idCompraGado)
        {
            
            SqlConnection cnn = default(SqlConnection);
            SqlCommand cmd = default(SqlCommand);

            string sql = "Select Id,Descricao,Preco,Quantidade,Total from vwCompraGadoItem as C Where C.IdCompraGado = @IdCompraGado";

            cnn = new SqlConnection(_connectionString);

            cmd.Parameters.AddWithValue("@IdCompraGado", idCompraGado);
            cmd.CommandText = sql;

            SqlDataReader dr = cmd.ExecuteReader();

            List<CompraGadoItemViewModel> listCompraGado = new List<CompraGadoItemViewModel>();

            while (dr.Read())
            {
                CompraGadoItemViewModel compraGadoItemVM = new CompraGadoItemViewModel();
                compraGadoItemVM.Id = dr.GetInt32(0);
                compraGadoItemVM.Descricao = dr.GetString(1);
                compraGadoItemVM.Preco = dr.GetDecimal(2);
                compraGadoItemVM.Quantidade = dr.GetInt32(3);
                compraGadoItemVM.Total = dr.GetDecimal(4);

                listCompraGado.Add(compraGadoItemVM);
            }

            return listCompraGado;
        }
        private static CompraGadoViewModel BuscarCabecalhoCompra(int IdCompraGado)
        {
            
            SqlConnection cnn = default(SqlConnection);
            SqlCommand cmd = default(SqlCommand);

            string sql = "Select Id,Nome,DataEntrega,Total from vwCompraGado as C Where C.IdCompraGado = @IdCompraGado";

            cnn = new SqlConnection(_connectionString);

            cmd.Parameters.AddWithValue("@IdCompraGado", IdCompraGado);
            cmd.CommandText = sql;

            SqlDataReader dr = cmd.ExecuteReader();

            _compraGadoCabecalho = new CompraGadoViewModel();
            _compraGadoCabecalho.Id = dr.GetInt32(0);
            _compraGadoCabecalho.Pecuarista = dr.GetString(1);
            _compraGadoCabecalho.DataEntrega = dr.GetDateTime(2);
            _compraGadoCabecalho.Total = dr.GetDecimal(3);

            return _compraGadoCabecalho;
        }
    }
}
