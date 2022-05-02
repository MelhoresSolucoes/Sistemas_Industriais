using System.Windows.Forms;

namespace SistemaIndustrial.View
{
    partial class frmCadCompraGado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDataEntrega = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPecuarista = new System.Windows.Forms.ComboBox();
            this.pecuaristaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.lblTotalCompra = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.gridItens = new System.Windows.Forms.DataGridView();
            this.Animal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPreco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compraGadoItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnExcluirCompra = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pecuaristaBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compraGadoItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtDataEntrega);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboPecuarista);
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 77);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtDataEntrega
            // 
            this.txtDataEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataEntrega.Location = new System.Drawing.Point(322, 37);
            this.txtDataEntrega.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.txtDataEntrega.Name = "txtDataEntrega";
            this.txtDataEntrega.Size = new System.Drawing.Size(113, 23);
            this.txtDataEntrega.TabIndex = 1;
            this.txtDataEntrega.Value = new System.DateTime(2022, 4, 25, 17, 8, 46, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pecuarista";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Data de Entrega";
            // 
            // cboPecuarista
            // 
            this.cboPecuarista.DataSource = this.pecuaristaBindingSource;
            this.cboPecuarista.DisplayMember = "Nome";
            this.cboPecuarista.FormattingEnabled = true;
            this.cboPecuarista.Location = new System.Drawing.Point(11, 37);
            this.cboPecuarista.Name = "cboPecuarista";
            this.cboPecuarista.Size = new System.Drawing.Size(300, 23);
            this.cboPecuarista.TabIndex = 0;
            this.cboPecuarista.ValueMember = "Id";
            // 
            // pecuaristaBindingSource
            // 
            this.pecuaristaBindingSource.DataSource = typeof(SistemaIndustrial.View.Entities.Pecuarista);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnExcluir);
            this.groupBox2.Controls.Add(this.lblTotalCompra);
            this.groupBox2.Controls.Add(this.btnNovo);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.gridItens);
            this.groupBox2.Location = new System.Drawing.Point(11, 86);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 398);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Itens de Compra (Animais)";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluir.Image = global::SistemaIndustrial.View.Properties.Resources.page_white_delete;
            this.btnExcluir.Location = new System.Drawing.Point(403, 14);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(29, 25);
            this.btnExcluir.TabIndex = 2;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // lblTotalCompra
            // 
            this.lblTotalCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCompra.AutoSize = true;
            this.lblTotalCompra.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalCompra.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalCompra.Location = new System.Drawing.Point(361, 378);
            this.lblTotalCompra.Name = "lblTotalCompra";
            this.lblTotalCompra.Size = new System.Drawing.Size(71, 14);
            this.lblTotalCompra.TabIndex = 15;
            this.lblTotalCompra.Text = "00000000";
            // 
            // btnNovo
            // 
            this.btnNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovo.Image = global::SistemaIndustrial.View.Properties.Resources.page_white_add;
            this.btnNovo.Location = new System.Drawing.Point(372, 14);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(29, 25);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Total: R$";
            // 
            // gridItens
            // 
            this.gridItens.AllowUserToAddRows = false;
            this.gridItens.AllowUserToDeleteRows = false;
            this.gridItens.AllowUserToOrderColumns = true;
            this.gridItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridItens.AutoGenerateColumns = false;
            this.gridItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Animal,
            this.quantidadeDataGridViewTextBoxColumn,
            this.colPreco,
            this.colTotal});
            this.gridItens.DataSource = this.compraGadoItemBindingSource;
            this.gridItens.Location = new System.Drawing.Point(12, 43);
            this.gridItens.Name = "gridItens";
            this.gridItens.ReadOnly = true;
            this.gridItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridItens.Size = new System.Drawing.Size(422, 332);
            this.gridItens.TabIndex = 13;
            this.gridItens.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridItens_CellFormatting);
            // 
            // Animal
            // 
            this.Animal.DataPropertyName = "Animal.Descricao";
            this.Animal.HeaderText = "Animal";
            this.Animal.Name = "Animal";
            this.Animal.ReadOnly = true;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            this.quantidadeDataGridViewTextBoxColumn.DataPropertyName = "Quantidade";
            this.quantidadeDataGridViewTextBoxColumn.HeaderText = "QTD";
            this.quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            this.quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantidadeDataGridViewTextBoxColumn.Width = 60;
            // 
            // colPreco
            // 
            this.colPreco.DataPropertyName = "Animal.Preco";
            this.colPreco.HeaderText = "Preço (R$)";
            this.colPreco.Name = "colPreco";
            this.colPreco.ReadOnly = true;
            // 
            // colTotal
            // 
            this.colTotal.DataPropertyName = "Total";
            this.colTotal.HeaderText = "Total (R$)";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // compraGadoItemBindingSource
            // 
            this.compraGadoItemBindingSource.DataSource = typeof(SistemaIndustrial.View.Entities.CompraGadoItem);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipTitle = "Atualizar";
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Image = global::SistemaIndustrial.View.Properties.Resources.cross;
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(370, 491);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(84, 27);
            this.btnFechar.TabIndex = 0;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGravar.Image = global::SistemaIndustrial.View.Properties.Resources.accept;
            this.btnGravar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGravar.Location = new System.Drawing.Point(186, 491);
            this.btnGravar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(84, 27);
            this.btnGravar.TabIndex = 3;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnExcluirCompra
            // 
            this.btnExcluirCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcluirCompra.Image = global::SistemaIndustrial.View.Properties.Resources.page_white_delete;
            this.btnExcluirCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirCompra.Location = new System.Drawing.Point(278, 491);
            this.btnExcluirCompra.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnExcluirCompra.Name = "btnExcluirCompra";
            this.btnExcluirCompra.Size = new System.Drawing.Size(84, 27);
            this.btnExcluirCompra.TabIndex = 4;
            this.btnExcluirCompra.Text = "&Excluir";
            this.btnExcluirCompra.UseVisualStyleBackColor = true;
            this.btnExcluirCompra.Click += new System.EventHandler(this.btnExcluirCompra_Click);
            // 
            // frmCadCompraGado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 525);
            this.Controls.Add(this.btnExcluirCompra);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCadCompraGado";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de compra de gado";
            this.Load += new System.EventHandler(this.frmCadCompraGado_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pecuaristaBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridItens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compraGadoItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private ComboBox cboPecuarista;
        private Button button3;
        private Button button2;
        private Button button1;
        private GroupBox groupBox2;
        private Label label5;
        private Label label4;
        private DataGridView gridItens;
        private Button btnExcluir;
        private Button btnNovo;
        private ToolTip toolTip1;
        private Button btnFechar;
        private Button btnGravar;
        private BindingSource pecuaristaBindingSource;
        private DateTimePicker txtDataEntrega;
        private BindingSource compraGadoItemBindingSource;
        private DataGridViewTextBoxColumn animalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idAnimalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idCompraGadoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn colPreco;
        private DataGridViewTextBoxColumn compraGadoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn Animal;
        private Label lblTotalCompra;
        private Button btnExcluirCompra;
    }
}