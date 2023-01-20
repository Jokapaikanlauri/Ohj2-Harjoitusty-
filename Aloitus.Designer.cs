
namespace Harkkatyö_Ohj2
{
    partial class Aloitus
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPelaaja2 = new System.Windows.Forms.TextBox();
            this.tbPelaaja1 = new System.Windows.Forms.TextBox();
            this.rbHelppo = new System.Windows.Forms.RadioButton();
            this.rbKeskivaikea = new System.Windows.Forms.RadioButton();
            this.rbVaikea = new System.Windows.Forms.RadioButton();
            this.tbKortit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTilastot = new System.Windows.Forms.Button();
            this.btnAloita = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbKaksinpeli = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pbEsikatselu = new System.Windows.Forms.PictureBox();
            this.pbKortit = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEsikatselu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKortit)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(539, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pelaaja 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(540, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pelaaja 2:";
            this.label2.Visible = false;
            // 
            // tbPelaaja2
            // 
            this.tbPelaaja2.Location = new System.Drawing.Point(614, 144);
            this.tbPelaaja2.Name = "tbPelaaja2";
            this.tbPelaaja2.Size = new System.Drawing.Size(175, 20);
            this.tbPelaaja2.TabIndex = 3;
            this.tbPelaaja2.Visible = false;
            this.tbPelaaja2.Leave += new System.EventHandler(this.tbPelaaja2_Leave);
            this.tbPelaaja2.Validating += new System.ComponentModel.CancelEventHandler(this.tbPelaaja2_Validating);
            this.tbPelaaja2.Validated += new System.EventHandler(this.tbPelaaja2_Validated);
            // 
            // tbPelaaja1
            // 
            this.tbPelaaja1.Location = new System.Drawing.Point(617, 75);
            this.tbPelaaja1.Name = "tbPelaaja1";
            this.tbPelaaja1.Size = new System.Drawing.Size(175, 20);
            this.tbPelaaja1.TabIndex = 1;
            this.tbPelaaja1.Leave += new System.EventHandler(this.tbPelaaja1_Leave);
            this.tbPelaaja1.Validating += new System.ComponentModel.CancelEventHandler(this.tbPelaaja1_Validating);
            this.tbPelaaja1.Validated += new System.EventHandler(this.tbPelaaja1_Validated);
            // 
            // rbHelppo
            // 
            this.rbHelppo.AutoSize = true;
            this.rbHelppo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbHelppo.Location = new System.Drawing.Point(543, 231);
            this.rbHelppo.Name = "rbHelppo";
            this.rbHelppo.Size = new System.Drawing.Size(73, 22);
            this.rbHelppo.TabIndex = 4;
            this.rbHelppo.Text = "Helppo";
            this.rbHelppo.UseVisualStyleBackColor = true;
            // 
            // rbKeskivaikea
            // 
            this.rbKeskivaikea.AutoSize = true;
            this.rbKeskivaikea.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbKeskivaikea.Location = new System.Drawing.Point(655, 231);
            this.rbKeskivaikea.Name = "rbKeskivaikea";
            this.rbKeskivaikea.Size = new System.Drawing.Size(105, 22);
            this.rbKeskivaikea.TabIndex = 5;
            this.rbKeskivaikea.Text = "Keskivaikea";
            this.rbKeskivaikea.UseVisualStyleBackColor = true;
            // 
            // rbVaikea
            // 
            this.rbVaikea.AutoSize = true;
            this.rbVaikea.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbVaikea.Location = new System.Drawing.Point(542, 271);
            this.rbVaikea.Name = "rbVaikea";
            this.rbVaikea.Size = new System.Drawing.Size(70, 22);
            this.rbVaikea.TabIndex = 6;
            this.rbVaikea.Text = "Vaikea";
            this.rbVaikea.UseVisualStyleBackColor = true;
            // 
            // tbKortit
            // 
            this.tbKortit.Location = new System.Drawing.Point(655, 336);
            this.tbKortit.Name = "tbKortit";
            this.tbKortit.Size = new System.Drawing.Size(134, 20);
            this.tbKortit.TabIndex = 7;
            this.tbKortit.TextChanged += new System.EventHandler(this.tbKortit_TextChanged);
            this.tbKortit.Leave += new System.EventHandler(this.tbKortit_Leave);
            this.tbKortit.Validating += new System.ComponentModel.CancelEventHandler(this.tbKortit_Validating);
            this.tbKortit.Validated += new System.EventHandler(this.tbKortit_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(570, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Valitse vaikeustaso";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(540, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Korttien määrä:";
            // 
            // btnTilastot
            // 
            this.btnTilastot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTilastot.Location = new System.Drawing.Point(614, 27);
            this.btnTilastot.Name = "btnTilastot";
            this.btnTilastot.Size = new System.Drawing.Size(87, 33);
            this.btnTilastot.TabIndex = 0;
            this.btnTilastot.Text = "Tilastot";
            this.btnTilastot.UseVisualStyleBackColor = true;
            this.btnTilastot.Click += new System.EventHandler(this.btnTilastot_Click);
            // 
            // btnAloita
            // 
            this.btnAloita.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAloita.Location = new System.Drawing.Point(614, 396);
            this.btnAloita.Name = "btnAloita";
            this.btnAloita.Size = new System.Drawing.Size(87, 33);
            this.btnAloita.TabIndex = 8;
            this.btnAloita.Text = "Aloita peli";
            this.btnAloita.UseVisualStyleBackColor = true;
            this.btnAloita.Click += new System.EventHandler(this.btnAloita_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(539, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Pelaa kaksinpeliä:";
            // 
            // cbKaksinpeli
            // 
            this.cbKaksinpeli.AutoSize = true;
            this.cbKaksinpeli.Location = new System.Drawing.Point(671, 111);
            this.cbKaksinpeli.Name = "cbKaksinpeli";
            this.cbKaksinpeli.Size = new System.Drawing.Size(15, 14);
            this.cbKaksinpeli.TabIndex = 2;
            this.cbKaksinpeli.UseVisualStyleBackColor = true;
            this.cbKaksinpeli.Click += new System.EventHandler(this.cbKaksinpeli_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pbEsikatselu
            // 
            this.pbEsikatselu.Image = global::Harkkatyö_Ohj2.Properties.Resources.pelikortti;
            this.pbEsikatselu.Location = new System.Drawing.Point(165, 86);
            this.pbEsikatselu.Name = "pbEsikatselu";
            this.pbEsikatselu.Size = new System.Drawing.Size(188, 296);
            this.pbEsikatselu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEsikatselu.TabIndex = 14;
            this.pbEsikatselu.TabStop = false;
            this.pbEsikatselu.VisibleChanged += new System.EventHandler(this.tbKortit_TextChanged);
            // 
            // pbKortit
            // 
            this.pbKortit.Location = new System.Drawing.Point(12, 27);
            this.pbKortit.Name = "pbKortit";
            this.pbKortit.Size = new System.Drawing.Size(491, 411);
            this.pbKortit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbKortit.TabIndex = 12;
            this.pbKortit.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(814, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.toolStripMenuItem1.Image = global::Harkkatyö_Ohj2.Properties.Resources.lataus;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(28, 20);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(99, 22);
            this.toolStripMenuItem3.Text = "Ohje";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // Aloitus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(814, 450);
            this.Controls.Add(this.pbEsikatselu);
            this.Controls.Add(this.pbKortit);
            this.Controls.Add(this.cbKaksinpeli);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAloita);
            this.Controls.Add(this.btnTilastot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbKortit);
            this.Controls.Add(this.rbVaikea);
            this.Controls.Add(this.rbKeskivaikea);
            this.Controls.Add(this.rbHelppo);
            this.Controls.Add(this.tbPelaaja1);
            this.Controls.Add(this.tbPelaaja2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Aloitus";
            this.Text = " Muistipeli";
            this.VisibleChanged += new System.EventHandler(this.btnAloita_Click);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEsikatselu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKortit)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbPelaaja2;
        public System.Windows.Forms.TextBox tbPelaaja1;
        public System.Windows.Forms.RadioButton rbHelppo;
        public System.Windows.Forms.RadioButton rbKeskivaikea;
        public System.Windows.Forms.RadioButton rbVaikea;
        public System.Windows.Forms.TextBox tbKortit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnTilastot;
        public System.Windows.Forms.Button btnAloita;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbKaksinpeli;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pbKortit;
        private System.Windows.Forms.PictureBox pbEsikatselu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}

