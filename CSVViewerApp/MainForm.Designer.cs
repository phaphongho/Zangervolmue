using System.Windows.Forms;

namespace CSVViewerApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnOpenCsvFile;
        private Label lblFilterColumn;
        private ComboBox cmbFilterColumn;
        private Label lblSearch;
        private TextBox txtSearch;
        private DataGridView dataGridView1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnOpenCsvFile = new Button();
            this.lblFilterColumn = new Label();
            this.cmbFilterColumn = new ComboBox();
            this.lblSearch = new Label();
            this.txtSearch = new TextBox();
            this.dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // btnOpenCsvFile
            this.btnOpenCsvFile.Location = new System.Drawing.Point(12, 12);
            this.btnOpenCsvFile.Name = "btnOpenCsvFile";
            this.btnOpenCsvFile.Size = new System.Drawing.Size(120, 30);
            this.btnOpenCsvFile.TabIndex = 0;
            this.btnOpenCsvFile.Text = "Open CSV File";
            this.btnOpenCsvFile.UseVisualStyleBackColor = true;
            this.btnOpenCsvFile.Click += new System.EventHandler(this.btnOpenCsvFile_Click);

            // lblFilterColumn
            this.lblFilterColumn.AutoSize = true;
            this.lblFilterColumn.Location = new System.Drawing.Point(150, 17);
            this.lblFilterColumn.Name = "lblFilterColumn";
            this.lblFilterColumn.Size = new System.Drawing.Size(80, 15);
            this.lblFilterColumn.TabIndex = 1;
            this.lblFilterColumn.Text = "Filter Column:";

            // cmbFilterColumn
            this.cmbFilterColumn.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbFilterColumn.FormattingEnabled = true;
            this.cmbFilterColumn.Location = new System.Drawing.Point(235, 14);
            this.cmbFilterColumn.Name = "cmbFilterColumn";
            this.cmbFilterColumn.Size = new System.Drawing.Size(150, 23);
            this.cmbFilterColumn.TabIndex = 2;
            this.cmbFilterColumn.SelectedIndexChanged += new System.EventHandler(this.cmbFilterColumn_SelectedIndexChanged);

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(410, 17);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(50, 15);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Search:";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(465, 14);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 23);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // dataGridView1
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(960, 500);
            this.dataGridView1.TabIndex = 5;

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 572);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.cmbFilterColumn);
            this.Controls.Add(this.lblFilterColumn);
            this.Controls.Add(this.btnOpenCsvFile);
            this.Name = "MainForm";
            this.Text = "CSV Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
