# CSV Viewer - WinForms Application

## Tính năng chính

✅ **Mở file CSV động** - Sử dụng OpenFileDialog để chọn bất kỳ file CSV nào trên máy  
✅ **Hiển thị dữ liệu** - Tất cả dữ liệu CSV được hiển thị trong DataGridView  
✅ **ComboBox tự động** - Tên cột tự động populate từ hàng đầu tiên của file CSV  
✅ **Filter real-time** - Lọc dữ liệu khi nhập vào TextBox Search (không phân biệt hoa/thường)  
✅ **Cấu trúc rõ ràng** - Tách thành các function: LoadCsv(), PopulateFilterColumns(), ApplyFilter()

## Cài đặt

### Yêu cầu
- .NET 6.0 trở lên
- Visual Studio 2022 hoặc cao hơn
- CsvHelper NuGet Package

### Cách chạy

1. Clone repository:
```bash
git clone https://github.com/phaphongho/Zangervolmue.git
cd Zangervolmue
```

2. Checkout branch:
```bash
git checkout feature/csv-viewer
```

3. Restore dependencies và build:
```bash
cd CSVViewerApp
dotnet restore
dotnet build
```

4. Chạy ứng dụng:
```bash
dotnet run
```

## Cách sử dụng

1. **Mở file CSV**: Click nút "Open CSV File" để chọn file CSV từ máy tính
2. **Chọn cột filter**: Chọn cột muốn lọc từ ComboBox "Filter Column"
3. **Nhập từ khóa search**: Gõ vào TextBox "Search" để lọc kết quả real-time

### Ví dụ

**Scenario 1**: Filter theo SYMBOL
- Filter Column: SYMBOL
- Search: NVDA
- Kết quả: Chỉ hiển thị dòng có SYMBOL = NVDA

**Scenario 2**: Filter theo ALERT (chứa)
- Filter Column: ALERT
- Search: Base
- Kết quả: Hiển thị các dòng có ALERT chứa chữ "Base"

## Cấu trúc Project

```
CSVViewerApp/
├── CSVViewerApp.csproj       # Project file
├── Program.cs                 # Entry point
├── MainForm.cs                # Logic chính
├── MainForm.Designer.cs       # UI Designer
└── .gitignore
```

## Code Structure

### MainForm.cs

- **btnOpenCsvFile_Click()** - Mở OpenFileDialog
- **LoadCsv(string filePath)** - Đọc CSV file và tải dữ liệu
- **PopulateFilterColumns()** - Tự động populate ComboBox từ headers
- **ApplyFilter()** - Lọc dữ liệu real-time
- **cmbFilterColumn_SelectedIndexChanged()** - Sự kiện chọn cột
- **txtSearch_TextChanged()** - Sự kiện search real-time

## Tính năng đặc biệt

✨ **Không phân biệt hoa/thường** - Tất cả so sánh đều là case-insensitive  
✨ **Cập nhật ComboBox tự động** - Khi đổi file CSV, ComboBox tự cập nhật cột mới  
✨ **Không hardcode** - Tất cả cột đều được lấy từ file CSV  
✨ **Giao diện đơn giản** - Dễ sử dụng, không cần cấu hình phức tạp

## License

MIT License
