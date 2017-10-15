namespace Client
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.radioButtonSquare = new System.Windows.Forms.RadioButton();
            this.radioButtonRectangle = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // radioButtonSquare
            // 
            this.radioButtonSquare.AutoSize = true;
            this.radioButtonSquare.Checked = true;
            this.radioButtonSquare.Location = new System.Drawing.Point(729, 12);
            this.radioButtonSquare.Name = "radioButtonSquare";
            this.radioButtonSquare.Size = new System.Drawing.Size(125, 26);
            this.radioButtonSquare.TabIndex = 0;
            this.radioButtonSquare.TabStop = true;
            this.radioButtonSquare.Text = "all Squares";
            this.radioButtonSquare.UseVisualStyleBackColor = true;
            this.radioButtonSquare.CheckedChanged += new System.EventHandler(this.radioButtonSquareRectangle_CheckedChanged);
            // 
            // radioButtonRectangle
            // 
            this.radioButtonRectangle.AutoSize = true;
            this.radioButtonRectangle.Location = new System.Drawing.Point(729, 45);
            this.radioButtonRectangle.Name = "radioButtonRectangle";
            this.radioButtonRectangle.Size = new System.Drawing.Size(150, 26);
            this.radioButtonRectangle.TabIndex = 1;
            this.radioButtonRectangle.Text = "all Rectangles";
            this.radioButtonRectangle.UseVisualStyleBackColor = true;
            this.radioButtonRectangle.CheckedChanged += new System.EventHandler(this.radioButtonSquareRectangle_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 182);
            this.Controls.Add(this.radioButtonRectangle);
            this.Controls.Add(this.radioButtonSquare);
            this.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton radioButtonSquare;
        private System.Windows.Forms.RadioButton radioButtonRectangle;
    }
}

