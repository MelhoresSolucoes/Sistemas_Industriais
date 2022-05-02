using Microsoft.Reporting.WinForms;
using SistemaIndustrial.Reports;
using SistemaIndustrial.Reports.Reports;
using SistemaIndustrial.View.Entities;
using SistemaIndustrial.View.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIndustrial.View
{
    public partial class frmConsultaCompraGado : Form
    {
        private int _idCompraGado;
        private int _idPecuarista;
        private DateTime _dataInicio;
        private DateTime _dataFim;

        public frmConsultaCompraGado()
        {
            InitializeComponent();

            ListarPecuaristasAsync();

            txtDataEntregaInicial.Value = DateTime.Now;
            txtDataEntregaFinal.Value = DateTime.Now;

            chkPeriodo.Checked = true;

        }

        #region MÉTODO
        private string BindProperty(object property, string propertyName)
        {
            if (property == null)
                return "";

            string retValue = "";
            if (propertyName.Contains("."))
            {
                PropertyInfo[] arrayProperties;
                string leftPropertyName;
                leftPropertyName = propertyName.Substring(0, propertyName.IndexOf("."));
                arrayProperties = property.GetType().GetProperties();
                foreach (PropertyInfo propertyInfo in arrayProperties)
                {
                    if (propertyInfo.Name == leftPropertyName)
                    {
                        retValue = BindProperty(
                          propertyInfo.GetValue(property, null),
                          propertyName.Substring(propertyName.IndexOf(".") + 1));
                        break;
                    }
                }
            }
            else
            {
                Type propertyType;
                PropertyInfo propertyInfo;
                propertyType = property.GetType();
                propertyInfo = propertyType.GetProperty(propertyName);
                retValue = propertyInfo.GetValue(property, null).ToString();
            }
            return retValue;
        }
        private async Task ListarPecuaristasAsync()
        {
            var listPecuaristas = await PecuaristaServices.GetAll();
            pecuaristaBindingSource.DataSource = listPecuaristas;

            cboPecuarista.Refresh();

            cboPecuarista.SelectedItem = null;
        }
        private async void ListarCompraGado()
        {
            try
            {
                if (ValidarParametrosPesquisa() == false)
                    throw new Exception("Informe algum dos parêmtros disponíveis para pequisa.");

                var listGadoService = await CompraGadoServices.GetAll();

                var listGado = listGadoService.ToList().Where(o => (o.IdPecuarista == _idPecuarista || _idPecuarista == 0)
                                                                       && (o.Id == _idCompraGado || _idCompraGado == 0)
                                                                       && (o.DataEntrega.Date >= _dataInicio.Date && o.DataEntrega.Date < _dataFim.Date.AddDays(1) && chkPeriodo.Checked || !chkPeriodo.Checked))
                                                                        .ToList();

                compraGadoBindingSource.DataSource = listGado;
                gridComprasGado.Refresh();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message + "\n\n Abra novamente esta tela de consulta", "Listar Compra de Gado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Listar Compra de Gado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private bool ValidarParametrosPesquisa()
        {
            bool id = false, pecuarista = false, periodo = false;

            _dataFim = new DateTime();
            _dataInicio = new DateTime();
            _idCompraGado = 0;
            _idPecuarista = 0;

            if (txtIdCompraGado.Value > 0)
            {
                id = true;
                _idCompraGado = int.Parse(txtIdCompraGado.Value.ToString());
            }
            if (cboPecuarista.SelectedItem != null)
            {
                pecuarista = true;
                _idPecuarista = ((Pecuarista)cboPecuarista.SelectedItem).Id;
            }
            if (chkPeriodo.Checked)
            {
                periodo = true;
                _dataInicio = txtDataEntregaInicial.Value;
                _dataFim = txtDataEntregaFinal.Value;
            }

            if (id || pecuarista || periodo)
                return true;
            else
                return false;
        }
        #endregion

        #region EVENTOS
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmCadCompraGado tela = new frmCadCompraGado(new CompraGado());
            if ( tela.ShowDialog()== DialogResult.OK)
                ListarCompraGado();
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmConsultaCompraGado_Load(object sender, EventArgs e)
        {
            if (!ValidarParametrosPesquisa())
            {
                MessageBox.Show("Informe os parâmetros desejados para a pesquisa", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            ListarCompraGado();

        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ListarCompraGado();
        }
        private void chkPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPeriodo.Checked)
            {
                txtDataEntregaInicial.Enabled = true;
                txtDataEntregaFinal.Enabled = true;
            }
            else
            {
                txtDataEntregaInicial.Enabled = false;
                txtDataEntregaFinal.Enabled = false;
            }
        }
        private void txtIdCompraGado_ValueChanged(object sender, EventArgs e)
        {
            if(txtIdCompraGado.Value!=0)
            {
                chkPeriodo.Checked = false;
                cboPecuarista.SelectedItem = null;
            }
        }
        private void gridComprasGado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((gridComprasGado.Rows[e.RowIndex].DataBoundItem != null) && (gridComprasGado.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(gridComprasGado.Rows[e.RowIndex].DataBoundItem, gridComprasGado.Columns[e.ColumnIndex].DataPropertyName);
            }
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            frmCadCompraGado tela = new frmCadCompraGado((CompraGado)compraGadoBindingSource.Current);
            
            if (tela.ShowDialog() == DialogResult.OK)
                ListarCompraGado();
        }
        private async void btnImprimir_Click(object sender, EventArgs e)
        {
            CompraGado compragado = (CompraGado)compraGadoBindingSource.Current;

            if (compragado == null)
            {
                MessageBox.Show("Selecione uma Compra de Gado", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

           


           // Process.Start(@".\SistemaIndustrial.Reports.exe");
           frmReport telaReport = new frmReport(compragado.Id);
            telaReport.Show();
        }

        #endregion


    }
}