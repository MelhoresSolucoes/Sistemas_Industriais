using SistemaIndustrial.View.Entities;
using SistemaIndustrial.View.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIndustrial.View
{
    public partial class frmCadCompraGado : Form
    {
        private List<CompraGadoItem> _listCompraGadoItem;
        private CompraGado _compraGado;
        private CompraGadoItem _compraGadoItemSelecionado;
        public frmCadCompraGado(CompraGado compraGado)
        {
            InitializeComponent();

            _compraGado = compraGado;
            Start();
        }

        #region METODOS
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
        private void DefinirToolTip()
        {
            toolTip1.SetToolTip(btnNovo, "Novo Item de Compra  (Ctrl+N)");
            toolTip1.SetToolTip(btnExcluir, "Excluir Item de Compra     (Ctrl+D)");
            toolTip1.SetToolTip(btnExcluirCompra, "Excluir Compra de Gado ");
            toolTip1.SetToolTip(btnGravar, "Gravar Compra de Gado");
            toolTip1.SetToolTip(btnFechar, "Retorna à tela de consulta");
            toolTip1.ToolTipTitle = "";
            toolTip1.IsBalloon = false;
        }
        private async Task Start()
        {
            try
            {

                DefinirToolTip();
                await ListarPecuaristasAsync();
                await ListarCompraGadoItemAsync();
                ValidarInstancias();

                if (_compraGado == null)
                    _compraGado = new CompraGado();

                if (_compraGado.Id > 0) //Para alterar Compra
                {
                    this.Text += "    CÓDIGO (Id): " + _compraGado.Id;
                    cboPecuarista.SelectedItem = cboPecuarista.Items.Cast<Pecuarista>()
                                                                    .Where(x => x.Id == _compraGado.IdPecuarista).FirstOrDefault();
                    txtDataEntrega.Value = _compraGado.DataEntrega;
                }
                else //Para Nova Compra
                {
                    this.Text += "    NOVA COMPRA";
                    txtDataEntrega.Value = DateTime.Now;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private async Task GravarCabecalhoAsync()
        {
            Pecuarista pecuaristaSelecionado = (Pecuarista)cboPecuarista.SelectedItem;

            _compraGado.IdPecuarista = pecuaristaSelecionado.Id;
            _compraGado.DataEntrega = txtDataEntrega.Value;
            _compraGado.Total = _listCompraGadoItem.Sum(c => c.Total);
            _compraGado.Pecuarista = null;

            _compraGado = await CompraGadoServices.Save(_compraGado);
        }
        private async Task GravarItensAsync()
        {
            foreach (var item in _listCompraGadoItem)
            {
                item.IdCompraGado = _compraGado.Id;
                item.Animal = null;
                await CompraGadoItemServices.Save(item);
                item.Animal = await AnimalServices.GetById(item.IdAnimal);

            }
        }
        private async Task ListarPecuaristasAsync()
        {
            var listPecuaristas = PecuaristaServices.GetAll();
            pecuaristaBindingSource.DataSource = await listPecuaristas;
            
            cboPecuarista.Refresh();

            cboPecuarista.SelectedIndex = -1;
        }
        private async Task ListarCompraGadoItemAsync()
        {
            _listCompraGadoItem = await CompraGadoItemServices.GetAll();

            ValidarInstancias();

            if (_compraGado.Id > 0)
            {
                _listCompraGadoItem = _listCompraGadoItem.Where(o => o.IdCompraGado == _compraGado.Id).ToList();

                PreencherGrid();
            }
            else
                _listCompraGadoItem  = null;
        }
        private void PreencherGrid()
        {
            compraGadoItemBindingSource.DataSource = null;
            gridItens.DataSource = null;

            compraGadoItemBindingSource.DataSource = _listCompraGadoItem;
            gridItens.DataSource=compraGadoItemBindingSource;
            gridItens.Refresh();

            if (_listCompraGadoItem == null)
                return;

            decimal totalCompra = _listCompraGadoItem.Sum(o => o.Total);
            lblTotalCompra.Text = totalCompra.ToString("N2");
        }
        private void ValidarInstancias()
        {
            if (_compraGado == null)
                _compraGado = new CompraGado();
            if (_listCompraGadoItem == null)
                _listCompraGadoItem = new List<CompraGadoItem>();
        }
        private void ValidarDados()
        {
            if (cboPecuarista.SelectedItem == null)
            {
                throw new Exception("Informe o Pecuarista.");
            }
            if (_listCompraGadoItem.Count == 0)
            {
                throw new Exception("Informe pelo menos 1 item de compra!");
            }
        }
        private void BuscarItemSelecionado()
        {
            _compraGadoItemSelecionado = (CompraGadoItem)compraGadoItemBindingSource.Current;
        }
        #endregion

        #region EVENTOS
        private void frmCadCompraGado_Load(object sender, EventArgs e)
        {
            cboPecuarista.Focus();
        }
        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            BuscarItemSelecionado();

            if (_compraGado == null)
            {
                MessageBox.Show("Selecione a item à ser excluído!", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Excluir o item " + _compraGadoItemSelecionado.Animal.Descricao + "?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            if (_compraGadoItemSelecionado.Id <= 0)
            {
                _listCompraGadoItem.Remove(_compraGadoItemSelecionado);
                PreencherGrid();
            }
            else
            {
                await CompraGadoItemServices.Delete(_compraGadoItemSelecionado.Id);

                await ListarCompraGadoItemAsync();
            }
        }
        private async void btnExcluirCompra_Click(object sender, EventArgs e)
        {

            if (_compraGado == null)
            {
                MessageBox.Show("Selecione uma Compra de Gado existente!", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Excluir a compra de gado número " + _compraGado.Id.ToString() + "?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            await CompraGadoServices.Delete(_compraGado.Id);

            MessageBox.Show("A compra de gado nº " + _compraGado.Id + " foi excluído com sucesso.", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }
        private async void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarDados();
                await GravarCabecalhoAsync ();
                await GravarItensAsync();

                MessageBox.Show("Compra de gado realizada com sucesso!", "Gravar", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                PreencherGrid();
                //DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gravar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboPecuarista.Focus();
                return;
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmIncluirItemCompraGado tela = new frmIncluirItemCompraGado(_listCompraGadoItem);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                if (_listCompraGadoItem == null)
                    _listCompraGadoItem = new List<CompraGadoItem>();

                _listCompraGadoItem.Add(tela.CompraGadoItem);
            }
            PreencherGrid();
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            
        }
        private void gridItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var x =_listCompraGadoItem;

            if ((gridItens.Rows[e.RowIndex].DataBoundItem != null) && (gridItens.Columns[e.ColumnIndex].DataPropertyName.Contains(".")))
            {
                e.Value = BindProperty(gridItens.Rows[e.RowIndex].DataBoundItem, gridItens.Columns[e.ColumnIndex].DataPropertyName);
            }
        }
        #endregion


    }
}
