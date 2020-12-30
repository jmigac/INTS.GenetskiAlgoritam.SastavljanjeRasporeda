namespace GenetskiAlgoritamSastavljanjaRasporeda
{
    partial class Form1
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
            this.dgvRasporedKolokvija = new System.Windows.Forms.DataGridView();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblFitnessMax = new System.Windows.Forms.Label();
            this.lblBrojGeneracija = new System.Windows.Forms.Label();
            this.txtFitnessMax = new System.Windows.Forms.TextBox();
            this.txtBrGeneracija = new System.Windows.Forms.TextBox();
            this.btnGeneriraj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRasporedKolokvija)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRasporedKolokvija
            // 
            this.dgvRasporedKolokvija.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRasporedKolokvija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRasporedKolokvija.Location = new System.Drawing.Point(12, 59);
            this.dgvRasporedKolokvija.Name = "dgvRasporedKolokvija";
            this.dgvRasporedKolokvija.Size = new System.Drawing.Size(975, 516);
            this.dgvRasporedKolokvija.TabIndex = 0;
            // 
            // lblScore
            // 
            this.lblScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(12, 578);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(31, 13);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "Text:";
            // 
            // lblFitnessMax
            // 
            this.lblFitnessMax.AutoSize = true;
            this.lblFitnessMax.Location = new System.Drawing.Point(12, 9);
            this.lblFitnessMax.Name = "lblFitnessMax";
            this.lblFitnessMax.Size = new System.Drawing.Size(65, 13);
            this.lblFitnessMax.TabIndex = 3;
            this.lblFitnessMax.Text = "Fitness max:";
            // 
            // lblBrojGeneracija
            // 
            this.lblBrojGeneracija.AutoSize = true;
            this.lblBrojGeneracija.Location = new System.Drawing.Point(12, 33);
            this.lblBrojGeneracija.Name = "lblBrojGeneracija";
            this.lblBrojGeneracija.Size = new System.Drawing.Size(80, 13);
            this.lblBrojGeneracija.TabIndex = 4;
            this.lblBrojGeneracija.Text = "Broj generacija:";
            // 
            // txtFitnessMax
            // 
            this.txtFitnessMax.Location = new System.Drawing.Point(98, 6);
            this.txtFitnessMax.Name = "txtFitnessMax";
            this.txtFitnessMax.Size = new System.Drawing.Size(134, 20);
            this.txtFitnessMax.TabIndex = 5;
            this.txtFitnessMax.Text = "0.99";
            // 
            // txtBrGeneracija
            // 
            this.txtBrGeneracija.Location = new System.Drawing.Point(98, 30);
            this.txtBrGeneracija.Name = "txtBrGeneracija";
            this.txtBrGeneracija.Size = new System.Drawing.Size(134, 20);
            this.txtBrGeneracija.TabIndex = 6;
            this.txtBrGeneracija.Text = "35";
            // 
            // btnGeneriraj
            // 
            this.btnGeneriraj.Location = new System.Drawing.Point(238, 6);
            this.btnGeneriraj.Name = "btnGeneriraj";
            this.btnGeneriraj.Size = new System.Drawing.Size(96, 44);
            this.btnGeneriraj.TabIndex = 7;
            this.btnGeneriraj.Text = "Generiraj";
            this.btnGeneriraj.UseVisualStyleBackColor = true;
            this.btnGeneriraj.Click += new System.EventHandler(this.btnGeneriraj_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 600);
            this.Controls.Add(this.btnGeneriraj);
            this.Controls.Add(this.txtBrGeneracija);
            this.Controls.Add(this.txtFitnessMax);
            this.Controls.Add(this.lblBrojGeneracija);
            this.Controls.Add(this.lblFitnessMax);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.dgvRasporedKolokvija);
            this.Name = "Form1";
            this.Text = "Raspored pisanja kolokvija";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRasporedKolokvija)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRasporedKolokvija;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblFitnessMax;
        private System.Windows.Forms.Label lblBrojGeneracija;
        private System.Windows.Forms.TextBox txtFitnessMax;
        private System.Windows.Forms.TextBox txtBrGeneracija;
        private System.Windows.Forms.Button btnGeneriraj;
    }
}

