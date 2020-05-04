namespace RSI_Hotel_Booking.Reservations
{
    partial class ReservationItem
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
            this.city = new System.Windows.Forms.Label();
            this.hotel = new System.Windows.Forms.Label();
            this.room = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.raportBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // city
            // 
            this.city.AutoSize = true;
            this.city.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.city.Location = new System.Drawing.Point(4, 4);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(64, 25);
            this.city.TabIndex = 0;
            this.city.Text = "label1";
            // 
            // hotel
            // 
            this.hotel.AutoSize = true;
            this.hotel.Location = new System.Drawing.Point(6, 29);
            this.hotel.Name = "hotel";
            this.hotel.Size = new System.Drawing.Size(46, 17);
            this.hotel.TabIndex = 1;
            this.hotel.Text = "label1";
            // 
            // room
            // 
            this.room.AutoSize = true;
            this.room.Location = new System.Drawing.Point(6, 55);
            this.room.Name = "room";
            this.room.Size = new System.Drawing.Size(46, 17);
            this.room.TabIndex = 2;
            this.room.Text = "label1";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Location = new System.Drawing.Point(227, 11);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(46, 17);
            this.date.TabIndex = 3;
            this.date.Text = "label1";
            // 
            // raportBtn
            // 
            this.raportBtn.Location = new System.Drawing.Point(436, 26);
            this.raportBtn.Name = "raportBtn";
            this.raportBtn.Size = new System.Drawing.Size(75, 33);
            this.raportBtn.TabIndex = 4;
            this.raportBtn.Text = "Raport";
            this.raportBtn.UseVisualStyleBackColor = true;
            this.raportBtn.Click += new System.EventHandler(this.raportBtn_Click);
            // 
            // ReservationItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.raportBtn);
            this.Controls.Add(this.date);
            this.Controls.Add(this.room);
            this.Controls.Add(this.hotel);
            this.Controls.Add(this.city);
            this.Name = "ReservationItem";
            this.Size = new System.Drawing.Size(525, 80);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label city;
        private System.Windows.Forms.Label hotel;
        private System.Windows.Forms.Label room;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Button raportBtn;
    }
}
