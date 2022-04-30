using Microsoft.Reporting.WinForms;
using SistemaIndustrial.View.Entities;
using SistemaIndustrial.View.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SistemaIndustrial.View.Reports.ReportCompraGado
{
	public class ReportCompraGado
	{
		private static CompraGado _compraGadoCabecalho;

		private static List<CompraGadoItem> _listcompraGadoItens;
		public async static void Load(LocalReport report,int idCompraGado)
		{
			await GetCompraGado(idCompraGado);

			var items = _listcompraGadoItens; 
			var parameters = new[] { new ReportParameter("Title", "Relatório de Compra de Gado"),
									 new ReportParameter("Id", _compraGadoCabecalho.Id.ToString()),
									 new ReportParameter("DataEntrega", _compraGadoCabecalho.DataEntrega.ToShortDateString()),
									 new ReportParameter("Pecuarista", _compraGadoCabecalho.Pecuarista.Nome),};
			using var fs = new FileStream(".\\ReportCompraGado.rdlc", FileMode.Open);
			report.LoadReportDefinition(fs);
			report.DataSources.Add(new ReportDataSource("Items", items));
			report.SetParameters(parameters);

			report.Refresh();
			

		}
		private static async Task GetCompraGado(int idCompraGado)
        {
			var compraGadoAsync =  CompraGadoServices.GetById(idCompraGado);
			_compraGadoCabecalho = await compraGadoAsync;

			var pecuaristaAsync = PecuaristaServices.GetById(_compraGadoCabecalho.IdPecuarista);
			_compraGadoCabecalho.Pecuarista = await pecuaristaAsync;

			var itensCompra =  CompraGadoItemServices.GetAll().Result;
			_listcompraGadoItens =  itensCompra.Where(o => o.IdCompraGado == idCompraGado).ToList();

		}
	}
}
