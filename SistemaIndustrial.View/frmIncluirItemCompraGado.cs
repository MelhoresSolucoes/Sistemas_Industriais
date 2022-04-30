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
    public partial class frmIncluirItemCompraGado : Form
    {
        public CompraGadoItem CompraGadoItem;
        public frmIncluirItemCompraGado(List<CompraGadoItem> listCompraGagoItem)
        {
            InitializeComponent();
            CompraGadoItem = new CompraGadoItem();

            ListarAnimaisAsync(listCompraGagoItem);
            CalculaTotal();
        }

        #region METODOS
        private void AtualizarPropriedadesCompraGadoItem()
        {
            CompraGadoItem.Animal = (Animal)cboAnimal.SelectedItem;
            CompraGadoItem.IdAnimal = CompraGadoItem.Animal.Id;
            CompraGadoItem.Quantidade = int.Parse(txtQuantidade.Value.ToString());
            CompraGadoItem.Total = txtTotal.Text == "" ? 0 : decimal.Parse(txtTotal.Text);
        }
        private void CalculaTotal()
        {
            Animal animal = (Animal)cboAnimal.SelectedItem;

            if (cboAnimal.SelectedItem == null)
                return;

            if (animal != null)
            {
                decimal total = animal.Preco * txtQuantidade.Value;
                txtTotal.Text = total.ToString("N2");
            }
        }
        private async Task ListarAnimaisAsync(List<CompraGadoItem> listCompraGagoItem)
        {
            
            List<Animal> listAnimaisTask = await AnimalServices.GetAll();
            List<Animal> listAnimais = new List<Animal>();
            listAnimais.AddRange(listAnimaisTask);

            if (listAnimais == null)
                return;

            if (listCompraGagoItem != null)
            {
                foreach (var item in listCompraGagoItem) //Remove da lista de animais, os que já utilizados no lançamento de compra de gado
                {
                    foreach (var animal in listAnimaisTask)
                    {
                        if (item.Animal != null)
                        {
                            if (animal.Id == item.Animal.Id)
                            {
                                listAnimais.Remove(animal);
                            }
                        }
                    }
                }
            }

            animalBindingSource.DataSource = listAnimais;
            cboAnimal.Refresh();
            cboAnimal.SelectedItem = null;


        }
        private void ValidarCamposInclusao()
        {
            if (cboAnimal.SelectedItem == null)
            {
                MessageBox.Show("Informe o Animal!", "Incluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboAnimal.Focus();
                return;
            }
            if (txtQuantidade.Value <= 0)
            {
                MessageBox.Show("Informe a Quantidade!", "Incluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantidade.Focus();
                return;
            }
        }
        #endregion

        #region EVENTOS
        private void cboAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Animal animal = (Animal) cboAnimal.SelectedItem;

            if (animal != null)
                txtPreco.Text = animal.Preco.ToString("N2");
        
            CalculaTotal();
        }
        private void txtQuantidade_ValueChanged(object sender, EventArgs e)
        {
            CalculaTotal();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            CalculaTotal();
        }
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarCamposInclusao();
                CalculaTotal();
                AtualizarPropriedadesCompraGadoItem();

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Incluir Item:\n" + ex.Message, "Incluir", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        #endregion


    }
}
