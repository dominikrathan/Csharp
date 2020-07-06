namespace SVD
{
    partial class Form2
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
            this.l_Jakou = new System.Windows.Forms.Label();
            this.b_Puvodni = new System.Windows.Forms.Button();
            this.b_Zkomprimovanou = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l_Jakou
            // 
            this.l_Jakou.AutoSize = true;
            this.l_Jakou.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_Jakou.Location = new System.Drawing.Point(82, 71);
            this.l_Jakou.Name = "l_Jakou";
            this.l_Jakou.Size = new System.Drawing.Size(425, 29);
            this.l_Jakou.TabIndex = 0;
            this.l_Jakou.Text = "Jakou verzi obrázku si přejete editovat?";
            // 
            // b_Puvodni
            // 
            this.b_Puvodni.BackColor = System.Drawing.Color.DarkCyan;
            this.b_Puvodni.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Puvodni.ForeColor = System.Drawing.Color.Snow;
            this.b_Puvodni.Location = new System.Drawing.Point(48, 135);
            this.b_Puvodni.Name = "b_Puvodni";
            this.b_Puvodni.Size = new System.Drawing.Size(250, 67);
            this.b_Puvodni.TabIndex = 21;
            this.b_Puvodni.Text = "Původní";
            this.b_Puvodni.UseVisualStyleBackColor = false;
            this.b_Puvodni.Click += new System.EventHandler(this.button1_Click);
            // 
            // b_Zkomprimovanou
            // 
            this.b_Zkomprimovanou.BackColor = System.Drawing.Color.DarkCyan;
            this.b_Zkomprimovanou.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Zkomprimovanou.ForeColor = System.Drawing.Color.Snow;
            this.b_Zkomprimovanou.Location = new System.Drawing.Point(314, 135);
            this.b_Zkomprimovanou.Name = "b_Zkomprimovanou";
            this.b_Zkomprimovanou.Size = new System.Drawing.Size(250, 67);
            this.b_Zkomprimovanou.TabIndex = 22;
            this.b_Zkomprimovanou.Text = "Zkomprimovanou";
            this.b_Zkomprimovanou.UseVisualStyleBackColor = false;
            this.b_Zkomprimovanou.Click += new System.EventHandler(this.b_Zkomprimovanou_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 285);
            this.Controls.Add(this.b_Zkomprimovanou);
            this.Controls.Add(this.b_Puvodni);
            this.Controls.Add(this.l_Jakou);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_Jakou;
        private System.Windows.Forms.Button b_Puvodni;
        private System.Windows.Forms.Button b_Zkomprimovanou;
    }
}