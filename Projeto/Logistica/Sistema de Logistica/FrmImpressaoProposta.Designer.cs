﻿namespace Projeto.Logistica.Sistema_de_Logistica
{
    partial class FrmImpressaoProposta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImpressaoProposta));
            this.rvProposta = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvProposta
            // 
            this.rvProposta.AutoScroll = false;
            this.rvProposta.AutoSize = false;
            this.rvProposta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvProposta.Location = new System.Drawing.Point(0, 0);
            this.rvProposta.Name = "ReportViewer";
            this.rvProposta.ServerReport.BearerToken = null;
            this.rvProposta.Size = new System.Drawing.Size(679, 795);
            this.rvProposta.TabIndex = 0;
            // 
            // FrmImpressaoProposta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(679, 795);
            this.Controls.Add(this.rvProposta);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmImpressaoProposta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impressão de Proposta";
            this.Load += new System.EventHandler(this.FrmImpressaoProposta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        public Microsoft.Reporting.WinForms.ReportViewer rvProposta;
    }
}