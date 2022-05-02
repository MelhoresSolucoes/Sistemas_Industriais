using System.Windows.Forms;

namespace SistemaIndustrial.View
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.mnuCompraGado = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuCadAnimal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPecuarista = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCompraGado,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1064, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // mnuCompraGado
            // 
            this.mnuCompraGado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuCompraGado.Image = ((System.Drawing.Image)(resources.GetObject("mnuCompraGado.Image")));
            this.mnuCompraGado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuCompraGado.Name = "mnuCompraGado";
            this.mnuCompraGado.Size = new System.Drawing.Size(101, 22);
            this.mnuCompraGado.Text = "Compra de Gado";
            this.mnuCompraGado.Click += new System.EventHandler(this.mnuCompraGado_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadAnimal,
            this.mnuPecuarista});
            this.toolStripDropDownButton1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(72, 22);
            this.toolStripDropDownButton1.Text = "Cadastros";
            this.toolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // mnuCadAnimal
            // 
            this.mnuCadAnimal.Name = "mnuCadAnimal";
            this.mnuCadAnimal.Size = new System.Drawing.Size(128, 22);
            this.mnuCadAnimal.Text = "Animal";
            this.mnuCadAnimal.Click += new System.EventHandler(this.mnuCadAnimal_Click);
            // 
            // mnuPecuarista
            // 
            this.mnuPecuarista.Name = "mnuPecuarista";
            this.mnuPecuarista.Size = new System.Drawing.Size(128, 22);
            this.mnuPecuarista.Text = "Pecuarista";
            this.mnuPecuarista.Click += new System.EventHandler(this.mnuPecuarista_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SistemaIndustrial.View.Properties.Resources.image_marfrig;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1064, 573);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Text = "Sistemas Industriais";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripDropDownButton toolStripDropDownButton1;
        private ToolStripMenuItem mnuCadAnimal;
        private ToolStripMenuItem mnuPecuarista;
        private ToolStripButton mnuCompraGado;
    }
}