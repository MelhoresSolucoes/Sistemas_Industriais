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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            MdiClient ctlMDI = (MdiClient)this.Controls[this.Controls.Count - 1];
            ctlMDI.BackColor = Color.White;
            ctlMDI.BackgroundImage = this.BackgroundImage;
        }

        private void mnuCompraGado_Click(object sender, EventArgs e)
        {
            AbrirMdiClient(new frmConsultaCompraGado());
        }

        private void mnuCadAnimal_Click(object sender, EventArgs e)
        {
            AbrirMdiClient(new frmCadAnimal());
        }

        private void mnuPecuarista_Click(object sender, EventArgs e)
        {
            AbrirMdiClient(new frmCadPecuarista());
        }

        /// <summary>
        /// Abre telas instanciadas na tela Main
        /// </summary>
        /// <param name="tela">Objeto Form Instanciado</param>
        private void AbrirMdiClient(Form tela)
        {
            if (tela == null)
            {
                MessageBox.Show("O formulário informado não possui uma instância.", "Abrir Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tela.WindowState = FormWindowState.Normal;
            tela.StartPosition = FormStartPosition.CenterScreen;
            tela.MdiParent = this;
            tela.Show();
        }

    }
}
