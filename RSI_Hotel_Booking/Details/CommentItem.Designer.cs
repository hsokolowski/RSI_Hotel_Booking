namespace RSI_Hotel_Booking.Details
{
    partial class CommentItem
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
            this.descriptionTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // descriptionTb
            // 
            this.descriptionTb.BackColor = System.Drawing.SystemColors.Control;
            this.descriptionTb.Location = new System.Drawing.Point(3, 3);
            this.descriptionTb.Multiline = true;
            this.descriptionTb.Name = "descriptionTb";
            this.descriptionTb.ReadOnly = true;
            this.descriptionTb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTb.Size = new System.Drawing.Size(669, 69);
            this.descriptionTb.TabIndex = 3;
            // 
            // CommentItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.descriptionTb);
            this.Name = "CommentItem";
            this.Size = new System.Drawing.Size(675, 73);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox descriptionTb;
    }
}
