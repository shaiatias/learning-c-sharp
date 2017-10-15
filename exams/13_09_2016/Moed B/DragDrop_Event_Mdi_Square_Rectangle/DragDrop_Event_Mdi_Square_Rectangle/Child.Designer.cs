namespace DragDrop_Event_Mdi_Square_Rectangle
{
    partial class Child
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
            this.radioButtonBlue = new System.Windows.Forms.RadioButton();
            this.radioButtonGreen = new System.Windows.Forms.RadioButton();
            this.radioButtonRed = new System.Windows.Forms.RadioButton();
            this.Max_RectangleSquare = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // radioButtonBlue
            // 
            this.radioButtonBlue.AutoSize = true;
            this.radioButtonBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonBlue.Location = new System.Drawing.Point(428, -2);
            this.radioButtonBlue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonBlue.Name = "radioButtonBlue";
            this.radioButtonBlue.Size = new System.Drawing.Size(59, 24);
            this.radioButtonBlue.TabIndex = 8;
            this.radioButtonBlue.Text = "Blue";
            this.radioButtonBlue.UseVisualStyleBackColor = true;
            // 
            // radioButtonGreen
            // 
            this.radioButtonGreen.AutoSize = true;
            this.radioButtonGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonGreen.Location = new System.Drawing.Point(358, -2);
            this.radioButtonGreen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonGreen.Name = "radioButtonGreen";
            this.radioButtonGreen.Size = new System.Drawing.Size(72, 24);
            this.radioButtonGreen.TabIndex = 7;
            this.radioButtonGreen.Text = "Green";
            this.radioButtonGreen.UseVisualStyleBackColor = true;
            // 
            // radioButtonRed
            // 
            this.radioButtonRed.AutoSize = true;
            this.radioButtonRed.Checked = true;
            this.radioButtonRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButtonRed.Location = new System.Drawing.Point(303, -2);
            this.radioButtonRed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonRed.Name = "radioButtonRed";
            this.radioButtonRed.Size = new System.Drawing.Size(57, 24);
            this.radioButtonRed.TabIndex = 6;
            this.radioButtonRed.TabStop = true;
            this.radioButtonRed.Text = "Red";
            this.radioButtonRed.UseVisualStyleBackColor = true;
            // 
            // Max_RectangleSquare
            // 
            this.Max_RectangleSquare.Font = new System.Drawing.Font("Arial", 14F);
            this.Max_RectangleSquare.Location = new System.Drawing.Point(-2, -2);
            this.Max_RectangleSquare.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Max_RectangleSquare.Name = "Max_RectangleSquare";
            this.Max_RectangleSquare.Size = new System.Drawing.Size(170, 24);
            this.Max_RectangleSquare.TabIndex = 9;
            this.Max_RectangleSquare.Text = "Max ";
            // 
            // Child
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1204, 197);
            this.Controls.Add(this.Max_RectangleSquare);
            this.Controls.Add(this.radioButtonBlue);
            this.Controls.Add(this.radioButtonGreen);
            this.Controls.Add(this.radioButtonRed);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Child";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RadioButton radioButtonBlue;
        public System.Windows.Forms.RadioButton radioButtonGreen;
        public System.Windows.Forms.RadioButton radioButtonRed;
        public System.Windows.Forms.Label Max_RectangleSquare;
    }
}