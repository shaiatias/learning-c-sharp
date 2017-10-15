namespace Color_White_ManagerForms_Event
{
    partial class UserControl_Large
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioButtonColor = new System.Windows.Forms.RadioButton();
            this.radioButtonWhite = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radioButtonColor
            // 
            this.radioButtonColor.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radioButtonColor.Checked = true;
            this.radioButtonColor.Font = new System.Drawing.Font("Arial", 12F);
            this.radioButtonColor.Location = new System.Drawing.Point(-2, 2);
            this.radioButtonColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonColor.Name = "radioButtonColor";
            this.radioButtonColor.Size = new System.Drawing.Size(60, 35);
            this.radioButtonColor.TabIndex = 0;
            this.radioButtonColor.TabStop = true;
            this.radioButtonColor.Text = "Color";
            this.radioButtonColor.UseVisualStyleBackColor = true;
            // 
            // radioButtonWhite
            // 
            this.radioButtonWhite.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.radioButtonWhite.Font = new System.Drawing.Font("Arial", 12F);
            this.radioButtonWhite.Location = new System.Drawing.Point(-2, 42);
            this.radioButtonWhite.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonWhite.Name = "radioButtonWhite";
            this.radioButtonWhite.Size = new System.Drawing.Size(60, 35);
            this.radioButtonWhite.TabIndex = 1;
            this.radioButtonWhite.Text = "White";
            this.radioButtonWhite.UseVisualStyleBackColor = true;
            // 
            // UserControl_Large
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.Controls.Add(this.radioButtonWhite);
            this.Controls.Add(this.radioButtonColor);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserControl_Large";
            this.Size = new System.Drawing.Size(1310, 100);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonColor;
        private System.Windows.Forms.RadioButton radioButtonWhite;
    }
}
