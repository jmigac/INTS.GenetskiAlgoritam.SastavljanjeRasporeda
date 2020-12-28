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
            ((System.ComponentModel.ISupportInitialize)(this.dgvRasporedKolokvija)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRasporedKolokvija
            // 
            this.dgvRasporedKolokvija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRasporedKolokvija.Location = new System.Drawing.Point(12, 12);
            this.dgvRasporedKolokvija.Name = "dgvRasporedKolokvija";
            this.dgvRasporedKolokvija.Size = new System.Drawing.Size(377, 404);
            this.dgvRasporedKolokvija.TabIndex = 0;
            // 
            // mCalendar
            // 
            this.mCalendar.Location = new System.Drawing.Point(401, 12);
            this.mCalendar.Name = "mCalendar";
            this.mCalendar.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 428);
            this.Controls.Add(this.mCalendar);
            this.Controls.Add(this.dgvRasporedKolokvija);
            this.Name = "Form1";
            this.Text = "Raspored pisanja kolokvija";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRasporedKolokvija)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRasporedKolokvija;
        private System.Windows.Forms.MonthCalendar mCalendar;
    }
}

