
namespace Harkkatyö_Ohj2
{
    partial class Tilastot
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
            this.dgvTilastot = new System.Windows.Forms.DataGridView();
            this.Nimi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Voitot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Häviöt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tasapeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Helppo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keskivaikea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vaikea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTilastot)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTilastot
            // 
            this.dgvTilastot.AllowUserToAddRows = false;
            this.dgvTilastot.AllowUserToDeleteRows = false;
            this.dgvTilastot.AllowUserToResizeColumns = false;
            this.dgvTilastot.AllowUserToResizeRows = false;
            this.dgvTilastot.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTilastot.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvTilastot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTilastot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nimi,
            this.Voitot,
            this.Häviöt,
            this.Tasapeli,
            this.Helppo,
            this.Keskivaikea,
            this.Vaikea});
            this.dgvTilastot.Location = new System.Drawing.Point(0, 0);
            this.dgvTilastot.Name = "dgvTilastot";
            this.dgvTilastot.Size = new System.Drawing.Size(799, 447);
            this.dgvTilastot.TabIndex = 0;
            // 
            // Nimi
            // 
            this.Nimi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nimi.Frozen = true;
            this.Nimi.HeaderText = "Nimi";
            this.Nimi.Name = "Nimi";
            this.Nimi.Width = 52;
            // 
            // Voitot
            // 
            this.Voitot.Frozen = true;
            this.Voitot.HeaderText = "Voitot";
            this.Voitot.Name = "Voitot";
            this.Voitot.Width = 59;
            // 
            // Häviöt
            // 
            this.Häviöt.Frozen = true;
            this.Häviöt.HeaderText = "Häviöt";
            this.Häviöt.Name = "Häviöt";
            this.Häviöt.Width = 63;
            // 
            // Tasapeli
            // 
            this.Tasapeli.Frozen = true;
            this.Tasapeli.HeaderText = "Tasapelit";
            this.Tasapeli.Name = "Tasapeli";
            this.Tasapeli.Width = 75;
            // 
            // Helppo
            // 
            this.Helppo.Frozen = true;
            this.Helppo.HeaderText = "Helppo";
            this.Helppo.Name = "Helppo";
            this.Helppo.Width = 66;
            // 
            // Keskivaikea
            // 
            this.Keskivaikea.Frozen = true;
            this.Keskivaikea.HeaderText = "Keskivaikea";
            this.Keskivaikea.Name = "Keskivaikea";
            this.Keskivaikea.Width = 90;
            // 
            // Vaikea
            // 
            this.Vaikea.Frozen = true;
            this.Vaikea.HeaderText = "Vaikea";
            this.Vaikea.Name = "Vaikea";
            this.Vaikea.Width = 65;
            // 
            // Tilastot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvTilastot);
            this.Name = "Tilastot";
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Tilastot_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTilastot)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTilastot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nimi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Voitot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Häviöt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tasapeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn Helppo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keskivaikea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vaikea;
    }
}