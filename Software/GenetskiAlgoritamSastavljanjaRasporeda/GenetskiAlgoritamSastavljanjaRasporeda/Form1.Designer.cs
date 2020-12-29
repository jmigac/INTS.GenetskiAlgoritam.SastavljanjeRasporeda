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
            this.mCalendar = new System.Windows.Forms.MonthCalendar();
            this.lblScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRasporedKolokvija)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRasporedKolokvija
            // 
            this.dgvRasporedKolokvija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRasporedKolokvija.Location = new System.Drawing.Point(12, 12);
            this.dgvRasporedKolokvija.Name = "dgvRasporedKolokvija";
            this.dgvRasporedKolokvija.Size = new System.Drawing.Size(1144, 404);
            this.dgvRasporedKolokvija.TabIndex = 0;
            // 
            // mCalendar
            // 
            this.mCalendar.Location = new System.Drawing.Point(107, 420);
            this.mCalendar.Name = "mCalendar";
            this.mCalendar.TabIndex = 1;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(318, 420);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(31, 13);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "Text:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 600);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.mCalendar);
            this.Controls.Add(this.dgvRasporedKolokvija);
            this.Name = "Form1";
            this.Text = "Raspored pisanja kolokvija";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRasporedKolokvija)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRasporedKolokvija;
        private System.Windows.Forms.MonthCalendar mCalendar;
        private System.Windows.Forms.Label lblScore;
    }
}

