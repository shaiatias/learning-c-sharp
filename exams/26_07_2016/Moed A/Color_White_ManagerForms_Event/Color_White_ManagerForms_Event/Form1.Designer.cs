namespace Color_White_ManagerForms_Event
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
            this.label_ButtonLabelMinMax = new System.Windows.Forms.Label();
            this.radioButtonMin = new System.Windows.Forms.RadioButton();
            this.radioButtonMax = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label_ButtonLabelMinMax
            // 
            this.label_ButtonLabelMinMax.Font = new System.Drawing.Font("Arial", 12F);
            this.label_ButtonLabelMinMax.Location = new System.Drawing.Point(2, -1);
            this.label_ButtonLabelMinMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ButtonLabelMinMax.Name = "label_ButtonLabelMinMax";
            this.label_ButtonLabelMinMax.Size = new System.Drawing.Size(86, 22);
            this.label_ButtonLabelMinMax.TabIndex = 2;
            // 
            // radioButtonMin
            // 
            this.radioButtonMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButtonMin.Location = new System.Drawing.Point(262, -1);
            this.radioButtonMin.Name = "radioButtonMin";
            this.radioButtonMin.Size = new System.Drawing.Size(58, 25);
            this.radioButtonMin.TabIndex = 12;
            this.radioButtonMin.Text = "Min";
            this.radioButtonMin.UseVisualStyleBackColor = true;
            this.radioButtonMin.CheckedChanged += new System.EventHandler(this.radioButtonMinMax_CheckedChanged);
            // 
            // radioButtonMax
            // 
            this.radioButtonMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButtonMax.Location = new System.Drawing.Point(392, -1);
            this.radioButtonMax.Name = "radioButtonMax";
            this.radioButtonMax.Size = new System.Drawing.Size(58, 25);
            this.radioButtonMax.TabIndex = 13;
            this.radioButtonMax.Text = "Max";
            this.radioButtonMax.UseVisualStyleBackColor = true;
            this.radioButtonMax.CheckedChanged += new System.EventHandler(this.radioButtonMinMax_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1314, 258);
            this.Controls.Add(this.radioButtonMax);
            this.Controls.Add(this.radioButtonMin);
            this.Controls.Add(this.label_ButtonLabelMinMax);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_ButtonLabelMinMax;
        private System.Windows.Forms.RadioButton radioButtonMax;
        private System.Windows.Forms.RadioButton radioButtonMin;
    }
}

