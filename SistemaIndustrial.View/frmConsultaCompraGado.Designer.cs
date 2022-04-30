namespace SistemaIndustrial.View
{
    partial class frmConsultaCompraGado
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnNovaCompra = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboPecuarista = new System.Windows.Forms.ComboBox();
            this.pecuaristaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPeriodo = new System.Windows.Forms.CheckBox();
            this.txtIdCompraGado = new System.Windows.Forms.NumericUpDown();
            this.txtDataEntregaFinal = new System.Windows.Forms.DateTimePicker();
            this.txtDataEntregaInicial = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gridComprasGado = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pecuarista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataEntregaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPecuaristaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compraGadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnFechar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pecuaristaBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdCompraGado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComprasGado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compraGadoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = global::SistemaIndustrial.View.Properties.Resources.page_white_magnify;
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(484, 78);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(99, 29);
            this.btnPesquisar.TabIndex = 4;
            this.btnPesquisar.Text = "&Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::SistemaIndustrial.View.Properties.Resources.printer;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(403, 473);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(98, 29);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnNovaCompra
            // 
            this.btnNovaCompra.Image = global::SistemaIndustrial.View.Properties.Resources.add;
            this.btnNovaCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovaCompra.Location = new System.Drawing.Point(185, 473);
            this.btnNovaCompra.Name = "btnNovaCompra";
            this.btnNovaCompra.Size = new System.Drawing.Size(109, 29);
            this.btnNovaCompra.TabIndex = 2;
            this.btnNovaCompra.Text = "&Nova Compra";
            this.btnNovaCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovaCompra.UseVisualStyleBackColor = true;
            this.btnNovaCompra.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Image = global::SistemaIndustrial.View.Properties.Resources.page_white_edit;
            this.btnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterar.Location = new System.Drawing.Point(300, 473);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(97, 29);
            this.btnAlterar.TabIndex = 3;
            this.btnAlterar.Text = "Al&terar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "ID - Código da Compra";
            // 
            // cboPecuarista
            // 
            this.cboPecuarista.DataSource = this.pecuaristaBindingSource;
            this.cboPecuarista.DisplayMember = "Nome";
            this.cboPecuarista.FormattingEnabled = true;
            this.cboPecuarista.Location = new System.Drawing.Point(351, 22);
            this.cboPecuarista.Name = "cboPecuarista";
            this.cboPecuarista.Size = new System.Drawing.Size(233, 23);
            this.cboPecuarista.TabIndex = 1;
            this.cboPecuarista.ValueMember = "Id";
            // 
            // pecuaristaBindingSource
            // 
            this.pecuaristaBindingSource.DataSource = typeof(SistemaIndustrial.View.Entities.Pecuarista);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPeriodo);
            this.groupBox1.Controls.Add(this.txtIdCompraGado);
            this.groupBox1.Controls.Add(this.txtDataEntregaFinal);
            this.groupBox1.Controls.Add(this.txtDataEntregaInicial);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboPecuarista);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // chkPeriodo
            // 
            this.chkPeriodo.AutoSize = true;
            this.chkPeriodo.Location = new System.Drawing.Point(29, 59);
            this.chkPeriodo.Name = "chkPeriodo";
            this.chkPeriodo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkPeriodo.Size = new System.Drawing.Size(126, 19);
            this.chkPeriodo.TabIndex = 13;
            this.chkPeriodo.Text = "Buscar por Período";
            this.chkPeriodo.UseVisualStyleBackColor = true;
            this.chkPeriodo.CheckedChanged += new System.EventHandler(this.chkPeriodo_CheckedChanged);
            // 
            // txtIdCompraGado
            // 
            this.txtIdCompraGado.Location = new System.Drawing.Point(142, 23);
            this.txtIdCompraGado.Name = "txtIdCompraGado";
            this.txtIdCompraGado.Size = new System.Drawing.Size(114, 23);
            this.txtIdCompraGado.TabIndex = 12;
            this.txtIdCompraGado.ValueChanged += new System.EventHandler(this.txtIdCompraGado_ValueChanged);
            // 
            // txtDataEntregaFinal
            // 
            this.txtDataEntregaFinal.Enabled = false;
            this.txtDataEntregaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataEntregaFinal.Location = new System.Drawing.Point(351, 84);
            this.txtDataEntregaFinal.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.txtDataEntregaFinal.Name = "txtDataEntregaFinal";
            this.txtDataEntregaFinal.Size = new System.Drawing.Size(113, 23);
            this.txtDataEntregaFinal.TabIndex = 3;
            this.txtDataEntregaFinal.Value = new System.DateTime(2022, 4, 26, 0, 0, 0, 0);
            // 
            // txtDataEntregaInicial
            // 
            this.txtDataEntregaInicial.Enabled = false;
            this.txtDataEntregaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtDataEntregaInicial.Location = new System.Drawing.Point(142, 84);
            this.txtDataEntregaInicial.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.txtDataEntregaInicial.Name = "txtDataEntregaInicial";
            this.txtDataEntregaInicial.Size = new System.Drawing.Size(113, 23);
            this.txtDataEntregaInicial.TabIndex = 2;
            this.txtDataEntregaInicial.Value = new System.DateTime(2022, 4, 24, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Até";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Data de entrega de";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Pecuarista";
            // 
            // gridComprasGado
            // 
            this.gridComprasGado.AllowUserToAddRows = false;
            this.gridComprasGado.AllowUserToDeleteRows = false;
            this.gridComprasGado.AutoGenerateColumns = false;
            this.gridComprasGado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridComprasGado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.Pecuarista,
            this.dataEntregaDataGridViewTextBoxColumn,
            this.idPecuaristaDataGridViewTextBoxColumn});
            this.gridComprasGado.DataSource = this.compraGadoBindingSource;
            this.gridComprasGado.Location = new System.Drawing.Point(12, 155);
            this.gridComprasGado.Name = "gridComprasGado";
            this.gridComprasGado.ReadOnly = true;
            this.gridComprasGado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridComprasGado.Size = new System.Drawing.Size(591, 267);
            this.gridComprasGado.TabIndex = 1;
            this.gridComprasGado.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridComprasGado_CellFormatting);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 60;
            // 
            // Pecuarista
            // 
            this.Pecuarista.DataPropertyName = "Pecuarista.Nome";
            this.Pecuarista.HeaderText = "Pecuarista";
            this.Pecuarista.Name = "Pecuarista";
            this.Pecuarista.ReadOnly = true;
            this.Pecuarista.Width = 270;
            // 
            // dataEntregaDataGridViewTextBoxColumn
            // 
            this.dataEntregaDataGridViewTextBoxColumn.DataPropertyName = "DataEntrega";
            this.dataEntregaDataGridViewTextBoxColumn.HeaderText = "DataEntrega";
            this.dataEntregaDataGridViewTextBoxColumn.Name = "dataEntregaDataGridViewTextBoxColumn";
            this.dataEntregaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idPecuaristaDataGridViewTextBoxColumn
            // 
            this.idPecuaristaDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.idPecuaristaDataGridViewTextBoxColumn.HeaderText = "Total (R$)";
            this.idPecuaristaDataGridViewTextBoxColumn.Name = "idPecuaristaDataGridViewTextBoxColumn";
            this.idPecuaristaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // compraGadoBindingSource
            // 
            this.compraGadoBindingSource.DataSource = typeof(SistemaIndustrial.View.Entities.CompraGado);
            // 
            // btnFechar
            // 
            this.btnFechar.Image = global::SistemaIndustrial.View.Properties.Resources.cross;
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(507, 473);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(98, 29);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(217, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Consulta de Compras de Gado";
            // 
            // frmConsultaCompraGado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 505);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gridComprasGado);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnNovaCompra);
            this.Controls.Add(this.btnImprimir);
            this.Name = "frmConsultaCompraGado";
            this.ShowIcon = false;
            this.Text = "Consulta de compra de gado";
            this.Load += new System.EventHandler(this.frmConsultaCompraGado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pecuaristaBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIdCompraGado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComprasGado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compraGadoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label1;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private GroupBox groupBox1;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private Label label3;
        private Label label2;
        private DataGridView dataGridView1;
        private Button btnPesquisar;
        private Button btnImprimir;
        private Button btnNovaCompra;
        private Button btnAlterar;
        private Label label5;
        private BindingSource pecuaristaBindingSource;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker txtDataEntrega;
        private Button btnFechar;
        private DataGridViewTextBoxColumn pecuaristaDataGridViewTextBoxColumn;
        private BindingSource compraGadoBindingSource;
        private DateTimePicker txtDataEntregaFinal;
        private DateTimePicker txtDataEntregaInicial;
        private ComboBox cboPecuarista;
        private DataGridView gridComprasGado;
        private NumericUpDown txtQuantidade;
        private NumericUpDown txtIdCompraGado;
        private CheckBox chkPeriodo;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Pecuarista;
        private DataGridViewTextBoxColumn dataEntregaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idPecuaristaDataGridViewTextBoxColumn;
    }
}