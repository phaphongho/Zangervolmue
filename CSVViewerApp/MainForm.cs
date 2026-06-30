using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CsvHelper;
using System.Globalization;

namespace CSVViewerApp
{
    public partial class MainForm : Form
    {
        private DataTable _dataTable;
        private DataTable _filteredDataTable;

        public MainForm()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            this.Text = "CSV Viewer - Filter & Search";
            this.Size = new System.Drawing.Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Mở OpenFileDialog và tải file CSV
        /// </summary>
        private void btnOpenCsvFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                openFileDialog.Title = "Select a CSV File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    LoadCsv(filePath);
                }
            }
        }

        /// <summary>
        /// Đọc file CSV và tải dữ liệu vào DataTable
        /// </summary>
        private void LoadCsv(string filePath)
        {
            try
            {
                _dataTable = new DataTable();
                
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    
                    // Thêm các cột vào DataTable
                    foreach (var header in csv.HeaderRecord)
                    {
                        _dataTable.Columns.Add(header);
                    }
                    
                    // Đọc dữ liệu
                    while (csv.Read())
                    {
                        var row = _dataTable.NewRow();
                        for (int i = 0; i < csv.HeaderRecord.Length; i++)
                        {
                            row[i] = csv.GetField(i) ?? string.Empty;
                        }
                        _dataTable.Rows.Add(row);
                    }
                }

                // Cập nhật DataGridView
                dataGridView1.DataSource = _dataTable;
                
                // Cập nhật ComboBox Filter Column
                PopulateFilterColumns();
                
                // Reset Search TextBox
                txtSearch.Clear();
                
                MessageBox.Show($"Loaded {_dataTable.Rows.Count} rows successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading CSV file: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tự động populate ComboBox với tên các cột từ CSV
        /// </summary>
        private void PopulateFilterColumns()
        {
            cmbFilterColumn.Items.Clear();
            
            if (_dataTable != null && _dataTable.Columns.Count > 0)
            {
                foreach (DataColumn column in _dataTable.Columns)
                {
                    cmbFilterColumn.Items.Add(column.ColumnName);
                }
                
                // Chọn cột đầu tiên mặc định
                cmbFilterColumn.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Lọc dữ liệu dựa trên cột được chọn và giá trị search
        /// </summary>
        private void ApplyFilter()
        {
            if (_dataTable == null || _dataTable.Rows.Count == 0)
                return;

            string selectedColumn = cmbFilterColumn.SelectedItem?.ToString();
            string searchValue = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(selectedColumn))
                return;

            // Tạo filtered DataTable
            _filteredDataTable = _dataTable.Clone();

            foreach (DataRow row in _dataTable.Rows)
            {
                string cellValue = row[selectedColumn].ToString().ToLower();
                
                // Lọc: nếu search trống thì hiển thị tất cả, nếu không thì kiểm tra chứa
                if (string.IsNullOrEmpty(searchValue) || cellValue.Contains(searchValue))
                {
                    _filteredDataTable.ImportRow(row);
                }
            }

            // Cập nhật DataGridView
            dataGridView1.DataSource = _filteredDataTable;
        }

        /// <summary>
        /// Sự kiện khi ComboBox Filter Column thay đổi
        /// </summary>
        private void cmbFilterColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        /// <summary>
        /// Sự kiện khi TextBox Search thay đổi (real-time filter)
        /// </summary>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }
    }
}
