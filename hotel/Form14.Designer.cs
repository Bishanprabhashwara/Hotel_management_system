﻿
namespace hotel
{
    partial class Form14
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.HOTELDataSet = new hotel.HOTELDataSet();
            this.tempOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tempOrderTableAdapter = new hotel.HOTELDataSetTableAdapters.tempOrderTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.HOTELDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempOrderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tempOrderBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "hotel.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // HOTELDataSet
            // 
            this.HOTELDataSet.DataSetName = "HOTELDataSet";
            this.HOTELDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tempOrderBindingSource
            // 
            this.tempOrderBindingSource.DataMember = "tempOrder";
            this.tempOrderBindingSource.DataSource = this.HOTELDataSet;
            // 
            // tempOrderTableAdapter
            // 
            this.tempOrderTableAdapter.ClearBeforeFill = true;
            // 
            // Form14
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form14";
            this.Text = "Form14";
            this.Load += new System.EventHandler(this.Form14_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HOTELDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempOrderBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tempOrderBindingSource;
        private HOTELDataSet HOTELDataSet;
        private HOTELDataSetTableAdapters.tempOrderTableAdapter tempOrderTableAdapter;
    }
}