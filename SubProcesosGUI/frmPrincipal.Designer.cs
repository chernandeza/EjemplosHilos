namespace SubProcesosGUI
{
    partial class frmPrincipal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbCorredor3 = new System.Windows.Forms.ProgressBar();
            this.pbCorredor2 = new System.Windows.Forms.ProgressBar();
            this.pbCorredor1 = new System.Windows.Forms.ProgressBar();
            this.lblC3 = new System.Windows.Forms.Label();
            this.lblC2 = new System.Windows.Forms.Label();
            this.lblC1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblCr1 = new System.Windows.Forms.Label();
            this.lblCr2 = new System.Windows.Forms.Label();
            this.lblCr3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCr3);
            this.panel1.Controls.Add(this.lblCr2);
            this.panel1.Controls.Add(this.lblCr1);
            this.panel1.Controls.Add(this.pbCorredor3);
            this.panel1.Controls.Add(this.pbCorredor2);
            this.panel1.Controls.Add(this.pbCorredor1);
            this.panel1.Controls.Add(this.lblC3);
            this.panel1.Controls.Add(this.lblC2);
            this.panel1.Controls.Add(this.lblC1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 151);
            this.panel1.TabIndex = 0;
            // 
            // pbCorredor3
            // 
            this.pbCorredor3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.pbCorredor3.Location = new System.Drawing.Point(95, 112);
            this.pbCorredor3.Name = "pbCorredor3";
            this.pbCorredor3.Size = new System.Drawing.Size(341, 23);
            this.pbCorredor3.TabIndex = 5;
            // 
            // pbCorredor2
            // 
            this.pbCorredor2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pbCorredor2.Location = new System.Drawing.Point(95, 60);
            this.pbCorredor2.Name = "pbCorredor2";
            this.pbCorredor2.Size = new System.Drawing.Size(341, 23);
            this.pbCorredor2.TabIndex = 4;
            // 
            // pbCorredor1
            // 
            this.pbCorredor1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pbCorredor1.Location = new System.Drawing.Point(95, 10);
            this.pbCorredor1.Name = "pbCorredor1";
            this.pbCorredor1.Size = new System.Drawing.Size(341, 23);
            this.pbCorredor1.TabIndex = 3;
            // 
            // lblC3
            // 
            this.lblC3.AutoSize = true;
            this.lblC3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblC3.Location = new System.Drawing.Point(3, 112);
            this.lblC3.Name = "lblC3";
            this.lblC3.Size = new System.Drawing.Size(86, 21);
            this.lblC3.TabIndex = 2;
            this.lblC3.Text = "Corredor 3";
            // 
            // lblC2
            // 
            this.lblC2.AutoSize = true;
            this.lblC2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblC2.Location = new System.Drawing.Point(3, 62);
            this.lblC2.Name = "lblC2";
            this.lblC2.Size = new System.Drawing.Size(86, 21);
            this.lblC2.TabIndex = 1;
            this.lblC2.Text = "Corredor 2";
            // 
            // lblC1
            // 
            this.lblC1.AutoSize = true;
            this.lblC1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblC1.Location = new System.Drawing.Point(3, 12);
            this.lblC1.Name = "lblC1";
            this.lblC1.Size = new System.Drawing.Size(86, 21);
            this.lblC1.TabIndex = 0;
            this.lblC1.Text = "Corredor 1";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(511, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(89, 44);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Iniciar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblCr1
            // 
            this.lblCr1.AutoSize = true;
            this.lblCr1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCr1.Location = new System.Drawing.Point(442, 12);
            this.lblCr1.Name = "lblCr1";
            this.lblCr1.Size = new System.Drawing.Size(32, 21);
            this.lblCr1.TabIndex = 6;
            this.lblCr1.Text = "0%";
            // 
            // lblCr2
            // 
            this.lblCr2.AutoSize = true;
            this.lblCr2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCr2.Location = new System.Drawing.Point(442, 62);
            this.lblCr2.Name = "lblCr2";
            this.lblCr2.Size = new System.Drawing.Size(32, 21);
            this.lblCr2.TabIndex = 7;
            this.lblCr2.Text = "0%";
            // 
            // lblCr3
            // 
            this.lblCr3.AutoSize = true;
            this.lblCr3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCr3.Location = new System.Drawing.Point(442, 112);
            this.lblCr3.Name = "lblCr3";
            this.lblCr3.Size = new System.Drawing.Size(32, 21);
            this.lblCr3.TabIndex = 8;
            this.lblCr3.Text = "0%";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 177);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPrincipal";
            this.Text = "Subprocess and Synchronization";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblC3;
        private System.Windows.Forms.Label lblC2;
        private System.Windows.Forms.Label lblC1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar pbCorredor3;
        private System.Windows.Forms.ProgressBar pbCorredor2;
        private System.Windows.Forms.ProgressBar pbCorredor1;
        private System.Windows.Forms.Label lblCr3;
        private System.Windows.Forms.Label lblCr2;
        private System.Windows.Forms.Label lblCr1;
    }
}

