namespace DragDrop_Event_ManagerForms_Square_Rectangle
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
            this.radioButton_Label = new System.Windows.Forms.RadioButton();
            this.radioButton_Button = new System.Windows.Forms.RadioButton();
            this.label_MinMax = new System.Windows.Forms.Label();
            this.label_RedGreenBlue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // radioButton_Label
            // 
            this.radioButton_Label.AutoSize = true;
            this.radioButton_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButton_Label.Location = new System.Drawing.Point(493, -4);
            this.radioButton_Label.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_Label.Name = "radioButton_Label";
            this.radioButton_Label.Size = new System.Drawing.Size(81, 29);
            this.radioButton_Label.TabIndex = 7;
            this.radioButton_Label.Text = "Label";
            this.radioButton_Label.UseVisualStyleBackColor = true;
            this.radioButton_Label.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_Button
            // 
            this.radioButton_Button.AutoSize = true;
            this.radioButton_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.radioButton_Button.Location = new System.Drawing.Point(387, -3);
            this.radioButton_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButton_Button.Name = "radioButton_Button";
            this.radioButton_Button.Size = new System.Drawing.Size(89, 29);
            this.radioButton_Button.TabIndex = 6;
            this.radioButton_Button.Text = "Button";
            this.radioButton_Button.UseVisualStyleBackColor = true;
            this.radioButton_Button.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // label_MinMax
            // 
            this.label_MinMax.Font = new System.Drawing.Font("Arial", 14F);
            this.label_MinMax.Location = new System.Drawing.Point(-3, 32);
            this.label_MinMax.Name = "label_MinMax";
            this.label_MinMax.Size = new System.Drawing.Size(61, 30);
            this.label_MinMax.TabIndex = 9;
            // 
            // label_RedGreenBlue
            // 
            this.label_RedGreenBlue.Font = new System.Drawing.Font("Arial", 14F);
            this.label_RedGreenBlue.Location = new System.Drawing.Point(-3, -1);
            this.label_RedGreenBlue.Name = "label_RedGreenBlue";
            this.label_RedGreenBlue.Size = new System.Drawing.Size(110, 30);
            this.label_RedGreenBlue.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1284, 242);
            this.Controls.Add(this.label_RedGreenBlue);
            this.Controls.Add(this.label_MinMax);
            this.Controls.Add(this.radioButton_Label);
            this.Controls.Add(this.radioButton_Button);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RadioButton radioButton_Label;
        public System.Windows.Forms.RadioButton radioButton_Button;
        public System.Windows.Forms.Label label_MinMax;
        public System.Windows.Forms.Label label_RedGreenBlue;
    }
}