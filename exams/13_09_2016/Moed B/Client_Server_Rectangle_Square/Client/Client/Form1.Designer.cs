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
            this.ButtonNew = new System.Windows.Forms.Button();
            this.buttonRectangle = new System.Windows.Forms.Button();
            this.buttonSquare = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCounter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonNew
            // 
            this.ButtonNew.Font = new System.Drawing.Font("Arial", 11F);
            this.ButtonNew.Location = new System.Drawing.Point(926, 12);
            this.ButtonNew.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(113, 76);
            this.ButtonNew.TabIndex = 1;
            this.ButtonNew.Text = "New";
            this.ButtonNew.UseVisualStyleBackColor = true;
            this.ButtonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.Location = new System.Drawing.Point(1046, 12);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Size = new System.Drawing.Size(129, 31);
            this.buttonRectangle.TabIndex = 4;
            this.buttonRectangle.Text = "Rectangle";
            this.buttonRectangle.UseVisualStyleBackColor = true;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangleSquare_Click);
            // 
            // buttonSquare
            // 
            this.buttonSquare.Location = new System.Drawing.Point(1046, 49);
            this.buttonSquare.Name = "buttonSquare";
            this.buttonSquare.Size = new System.Drawing.Size(129, 32);
            this.buttonSquare.TabIndex = 5;
            this.buttonSquare.Text = "Square";
            this.buttonSquare.UseVisualStyleBackColor = true;
            this.buttonSquare.Click += new System.EventHandler(this.buttonRectangleSquare_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(948, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "counter";
            // 
            // labelCounter
            // 
            this.labelCounter.AutoSize = true;
            this.labelCounter.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelCounter.Location = new System.Drawing.Point(968, 123);
            this.labelCounter.Name = "labelCounter";
            this.labelCounter.Size = new System.Drawing.Size(36, 39);
            this.labelCounter.TabIndex = 7;
            this.labelCounter.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 192);
            this.Controls.Add(this.labelCounter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSquare);
            this.Controls.Add(this.buttonRectangle);
            this.Controls.Add(this.ButtonNew);
            this.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonNew;
        private System.Windows.Forms.Button buttonRectangle;
        private System.Windows.Forms.Button buttonSquare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCounter;

    }
}

