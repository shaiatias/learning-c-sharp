namespace WidthHeight_Events
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
            this.checkBoxBlue = new System.Windows.Forms.CheckBox();
            this.checkBoxGreen = new System.Windows.Forms.CheckBox();
            this.checkBoxRed = new System.Windows.Forms.CheckBox();
            this.labelMinMaxSize = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxBlue
            // 
            this.checkBoxBlue.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBoxBlue.Location = new System.Drawing.Point(2, 154);
            this.checkBoxBlue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxBlue.Name = "checkBoxBlue";
            this.checkBoxBlue.Size = new System.Drawing.Size(34, 22);
            this.checkBoxBlue.TabIndex = 5;
            this.checkBoxBlue.Text = "B";
            this.checkBoxBlue.UseVisualStyleBackColor = true;
            // 
            // checkBoxGreen
            // 
            this.checkBoxGreen.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBoxGreen.Location = new System.Drawing.Point(2, 118);
            this.checkBoxGreen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxGreen.Name = "checkBoxGreen";
            this.checkBoxGreen.Size = new System.Drawing.Size(34, 23);
            this.checkBoxGreen.TabIndex = 4;
            this.checkBoxGreen.Text = "G";
            this.checkBoxGreen.UseVisualStyleBackColor = true;
            // 
            // checkBoxRed
            // 
            this.checkBoxRed.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBoxRed.Location = new System.Drawing.Point(2, 84);
            this.checkBoxRed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxRed.Name = "checkBoxRed";
            this.checkBoxRed.Size = new System.Drawing.Size(34, 20);
            this.checkBoxRed.TabIndex = 3;
            this.checkBoxRed.Text = "R";
            this.checkBoxRed.UseVisualStyleBackColor = true;
            // 
            // labelMinMaxSize
            // 
            this.labelMinMaxSize.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMinMaxSize.Location = new System.Drawing.Point(33, 2);
            this.labelMinMaxSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMinMaxSize.Name = "labelMinMaxSize";
            this.labelMinMaxSize.Size = new System.Drawing.Size(97, 19);
            this.labelMinMaxSize.TabIndex = 6;
            this.labelMinMaxSize.Text = "MIN SIZE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(244, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(416, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "Height";
            // 
            // labelWidth
            // 
            this.labelWidth.BackColor = System.Drawing.Color.White;
            this.labelWidth.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelWidth.Location = new System.Drawing.Point(304, 2);
            this.labelWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(62, 22);
            this.labelWidth.TabIndex = 9;
            // 
            // labelHeight
            // 
            this.labelHeight.BackColor = System.Drawing.Color.White;
            this.labelHeight.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelHeight.Location = new System.Drawing.Point(490, 2);
            this.labelHeight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(62, 22);
            this.labelHeight.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1199, 287);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMinMaxSize);
            this.Controls.Add(this.checkBoxBlue);
            this.Controls.Add(this.checkBoxGreen);
            this.Controls.Add(this.checkBoxRed);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxBlue;
        private System.Windows.Forms.CheckBox checkBoxGreen;
        private System.Windows.Forms.CheckBox checkBoxRed;
        public System.Windows.Forms.Label labelMinMaxSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label labelWidth;
        public System.Windows.Forms.Label labelHeight;
    }
}

