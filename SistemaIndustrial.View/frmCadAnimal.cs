using SistemaIndustrial.View.Entities;
using SistemaIndustrial.View.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaIndustrial.View
{
    public partial class frmCadAnimal : Form
    {
        Animal _animalSelecionado;
        public frmCadAnimal()
        {
            InitializeComponent();
            ListarAnimaisAsync();
            DesativarCamposEdicao();
            DefinirToolTip();
        }

        #region EVENTOS
        private void frmCadAnimal_Load(object sender, EventArgs e)
        {

        }
        private void frmCadAnimal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                btnNovo.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.E)
            {
                btnEditar.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.D)
            {
                btnExcluir.PerformClick();
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            AtivarCamposEdicao();
            BuscarAnimalSelecionado();
            if (_animalSelecionado != null)
            {
                txtDescricao.Text = _animalSelecionado.Descricao;
                txtPreco.Text = _animalSelecionado.Preco.ToString("N2");
            }
        }
        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            BuscarAnimalSelecionado();
            if (_animalSelecionado == null)
            {
                MessageBox.Show("Selecione o animal à ser excluído!", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Excluir o animal " + _animalSelecionado.Descricao + "?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            await AnimalServices.Delete(_animalSelecionado.Id);

            await ListarAnimaisAsync();
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            AtivarCamposEdicao();
            LimparCampos();
            _animalSelecionado = new Animal();
        }
        private async void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarAnimal();
                GravarAnimal();
                LimparCampos();
                DesativarCamposEdicao();
                await ListarAnimaisAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no momento da gravação!\n" + ex.Message, "Gravar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void gridAnimais_SelectionChanged(object sender, EventArgs e)
        {
            LimparCampos();
            BuscarAnimalSelecionado();
            BloquearCamposEdicao();
        }
        private void txtPreco_Leave(object sender, EventArgs e)
        {
            var regex = new Regex(@"^\d+(\.\d{2})?$");
            if (regex.IsMatch(txtPreco.Text))
            {
                var culture = new CultureInfo("pt-BR");
                var valor = Convert.ToDecimal(txtPreco.Text, culture);
                txtPreco.Text = valor.ToString("N2");
            }
        }
        private void txtPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region MÉTODOS
        private void AtivarCamposEdicao()
        {
            lblDescricao.Enabled = true;
            txtDescricao.Enabled = true;
            lblPreco.Enabled= true;
            txtPreco.Enabled = true;
            btnGravar.Enabled = true;
            txtDescricao.Focus();
        }
        private void BloquearCamposEdicao()
        {
            lblDescricao.Enabled = false;
            txtDescricao.Enabled = false;
            lblPreco.Enabled = false;
            txtPreco.Enabled = false;
            btnGravar.Enabled = false;
            txtDescricao.Focus();
        }
        private void BuscarAnimalSelecionado()
        {
            _animalSelecionado = (Animal)animalBindingSource.Current;
        }
        private void DefinirToolTip()
        {
            toolTip1.SetToolTip(btnNovo, "Novo Animal     (Ctrl+N)");
            toolTip1.SetToolTip(btnEditar, "Editar Animal     (Ctrl+E)");
            toolTip1.SetToolTip(btnExcluir, "Excluir Animal     (Ctrl+D)");
            toolTip1.ToolTipTitle = "";
            toolTip1.IsBalloon = false;
        }
        private void DesativarCamposEdicao()
        {
            lblDescricao.Enabled = false;
            txtDescricao.Enabled = false;
            lblPreco.Enabled = false;
            txtPreco.Enabled = false;
            btnGravar.Enabled = false;
        }
        private async void GravarAnimal()
        {
            try
            {
                _animalSelecionado.Descricao = txtDescricao.Text;
                _animalSelecionado.Preco = decimal.Parse(txtPreco.Text);

                await AnimalServices.Save(_animalSelecionado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Gravar!\n\n" + ex.Message, "Gravando", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimparCampos()
        {
            txtPreco.Text = "";
            txtDescricao.Text = "";
            txtDescricao.Focus();
        }
        private async Task ListarAnimaisAsync()
        {
            var listAnimais = await AnimalServices.GetAll();
            animalBindingSource.DataSource = listAnimais;
            gridAnimais.Refresh();
        }
        private void ValidarAnimal()
        {
            if (txtDescricao.Text=="")
            {
                MessageBox.Show("Informe a descrição do Animal!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal precoValido;
            if (!decimal.TryParse(txtPreco.Text, out precoValido) || (precoValido <= 0))
            {
                MessageBox.Show("Informe o preço do Animal!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_animalSelecionado == null)
                _animalSelecionado = new Animal();
        }
        #endregion


    }
}
