using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Globalization;
using CsvHelper;

namespace CSVViewerApp.Pages
{
    public class IndexModel : PageModel
    {
        public DataTable? DataTable { get; set; }
        public string? ErrorMessage { get; set; }

        public async Task OnPostAsync(IFormFile? csvFile)
        {
            if (csvFile == null || csvFile.Length == 0)
            {
                ErrorMessage = "Please select a CSV file.";
                return;
            }

            try
            {
                DataTable = new DataTable();

                using (var stream = csvFile.OpenReadStream())
                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();

                    // Add columns
                    if (csv.HeaderRecord != null)
                    {
                        foreach (var header in csv.HeaderRecord)
                        {
                            DataTable.Columns.Add(header);
                        }

                        // Read data rows
                        while (csv.Read())
                        {
                            var row = DataTable.NewRow();
                            for (int i = 0; i < csv.HeaderRecord.Length; i++)
                            {
                                row[i] = csv.GetField(i) ?? string.Empty;
                            }
                            DataTable.Rows.Add(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error loading CSV: {ex.Message}";
            }
        }
    }
}
