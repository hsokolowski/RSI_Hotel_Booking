namespace RSI_Hotel_Booking.Hotel
{
    partial class HotelItem
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.name = new System.Windows.Forms.Label();
            this.adres = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.rate = new System.Windows.Forms.Label();
            this.closePlaces = new System.Windows.Forms.FlowLayoutPanel();
            this.roomsBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.roomsBtn);
            this.panel1.Controls.Add(this.closePlaces);
            this.panel1.Controls.Add(this.rate);
            this.panel1.Controls.Add(this.info);
            this.panel1.Controls.Add(this.adres);
            this.panel1.Controls.Add(this.name);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 241);
            this.panel1.TabIndex = 0;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.name.Location = new System.Drawing.Point(19, 18);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(73, 29);
            this.name.TabIndex = 0;
            this.name.Text = "name";
            // 
            // adres
            // 
            this.adres.AutoSize = true;
            this.adres.Location = new System.Drawing.Point(24, 51);
            this.adres.Name = "adres";
            this.adres.Size = new System.Drawing.Size(44, 17);
            this.adres.TabIndex = 1;
            this.adres.Text = "adres";
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(24, 77);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(31, 17);
            this.info.TabIndex = 2;
            this.info.Text = "info";
            // 
            // rate
            // 
            this.rate.AutoSize = true;
            this.rate.Location = new System.Drawing.Point(440, 28);
            this.rate.Name = "rate";
            this.rate.Size = new System.Drawing.Size(33, 17);
            this.rate.TabIndex = 3;
            this.rate.Text = "rate";
            // 
            // closePlaces
            // 
            this.closePlaces.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.closePlaces.Location = new System.Drawing.Point(24, 112);
            this.closePlaces.Name = "closePlaces";
            this.closePlaces.Size = new System.Drawing.Size(662, 113);
            this.closePlaces.TabIndex = 4;
            // 
            // roomsBtn
            // 
            this.roomsBtn.BackColor = System.Drawing.Color.Black;
            this.roomsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.roomsBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roomsBtn.Location = new System.Drawing.Point(571, 28);
            this.roomsBtn.Name = "roomsBtn";
            this.roomsBtn.Size = new System.Drawing.Size(115, 40);
            this.roomsBtn.TabIndex = 5;
            this.roomsBtn.Text = "Show rooms";
            this.roomsBtn.UseVisualStyleBackColor = false;
            // 
            // HotelItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "HotelItem";
            this.Size = new System.Drawing.Size(713, 241);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label adres;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.FlowLayoutPanel closePlaces;
        private System.Windows.Forms.Label rate;
        private System.Windows.Forms.Button roomsBtn;
    }
}
