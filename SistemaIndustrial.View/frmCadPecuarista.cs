using SistemaIndustrial.View.Entities;
using SistemaIndustrial.View.Services;
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
    public partial class frmCadPecuarista : Form
    {

        Pecuarista _pecuaristaSelecionado;
        public frmCadPecuarista()
        {
            InitializeComponent();
            ListarPecuaristasAsync();
            DesativarCamposEdicao();
            DefinirToolTip();
        }

        #region EVENTOS

        private void btnEditar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            AtivarCamposEdicao();
            if (_pecuaristaSelecionado != null)
                txtNome.Text = _pecuaristaSelecionado.Nome;
        }
        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            if (_pecuaristaSelecionado == null)
            {
                MessageBox.Show("Selecione o pecuarista à ser excluído!", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Excluir a pecuarista " + _pecuaristaSelecionado.Nome + "?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            await PecuaristaServices.Delete(_pecuaristaSelecionado.Id);

            await ListarPecuaristasAsync();
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
            _pecuaristaSelecionado = new Pecuarista();
        }
        private void lstPecuaristas_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimparCampos();

            _pecuaristaSelecionado = (Pecuarista)lstPecuaristas.SelectedItem;
        }
        private void frmCadPecuarista_KeyDown(object sender, KeyEventArgs e)
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
        private async void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                GravarPecuarista();
                LimparCampos();
                DesativarCamposEdicao();
                await ListarPecuaristasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro no momento da gravação!\n" + ex.Message, "Gravar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region MÉTODOS
        private void AtivarCamposEdicao()
        {
            lblNome.Enabled = true;
            txtNome.Enabled = true;
            btnGravar.Enabled = true;
            txtNome.Focus();
        }
        private void DesativarCamposEdicao()
        {
            lblNome.Enabled = false;
            txtNome.Enabled = false;
            btnGravar.Enabled = false;
        }
        private void DefinirToolTip()
        {
            toolTip1.SetToolTip(btnNovo, "Novo Pecuarista     (Ctrl+N)");
            toolTip1.SetToolTip(btnEditar, "Editar Pecuarista     (Ctrl+E)");
            toolTip1.SetToolTip(btnExcluir, "Excluir Pecuarista     (Ctrl+D)");
            toolTip1.ToolTipTitle = "";
            toolTip1.IsBalloon = false;
        }
        private async void GravarPecuarista()
        {
            try
            {
                if (txtNome.Text.Length < 4)
                {
                    MessageBox.Show("Informe o nome do Pecuarista!");
                    return;
                }

                if (_pecuaristaSelecionado == null)
                    _pecuaristaSelecionado = new Pecuarista();

                _pecuaristaSelecionado.Nome = txtNome.Text;

                await PecuaristaServices.Save(_pecuaristaSelecionado);

                ListarPecuaristasAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Gravar!\n\n" + ex.Message, "Gravando", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimparCampos()
        {
            txtNome.Text = "";
            txtNome.Focus();
        }
        private async Task ListarPecuaristasAsync()
        {
            var listPecuaristas = await PecuaristaServices.GetAll();
            lstPecuaristas.DataSource = listPecuaristas;
            lstPecuaristas.DisplayMember = "Nome";
            lstPecuaristas.ValueMember = "Id";
            lstPecuaristas.Refresh();
        }

        #endregion

    }
}
