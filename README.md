# Hệ Thống Quản Lý Điểm Danh Sinh Viên

Đây là một ứng dụng web được xây dựng bằng ASP.NET Core để quản lý điểm
danh sinh viên, cho phép giảng viên ghi nhận điểm danh và ban quản lý
xem báo cáo. Hệ thống hỗ trợ nhiều vai trò (Sinh viên, Giảng viên, Quản
lý) với xác thực và phân quyền bằng ASP.NET Identity.

## Tính Năng

-   **Chức năng Giảng viên**: Ghi nhận và chỉnh sửa điểm danh sinh viên
    trong vòng 30 phút từ khi lớp học bắt đầu.
-   **Chức năng Sinh viên**: Xem trạng thái điểm danh cá nhân cho các
    lớp đã đăng ký.
-   **Chức năng Quản lý**: Xem báo cáo điểm danh toàn diện và xuất dữ
    liệu ra file Excel.
-   **Phân quyền**: Truy cập an toàn với các vai trò (Sinh viên, Giảng
    viên, Quản lý) qua ASP.NET Identity.
-   **Xuất Excel**: Tạo báo cáo điểm danh dưới dạng file Excel bằng
    ClosedXML.
-   **Thiết kế Tương Thích**: Sử dụng Bootstrap cho giao diện thân thiện
    với người dùng.

## Công Nghệ Sử Dụng

-   **Framework**: ASP.NET Core 8.0
-   **Cơ sở dữ liệu**: Microsoft SQL Server (LocalDB hoặc Express)
-   **ORM**: Entity Framework Core
-   **Giao diện**: Bootstrap, Razor Views
-   **Tạo Excel**: ClosedXML
-   **Xác thực**: ASP.NET Identity

## Yêu Cầu Hệ Thống

-   **.NET SDK**: Phiên bản 8.0.x (tải từ
    [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/8.0))
-   **SQL Server**: LocalDB (đi kèm Visual Studio) hoặc SQL Server
    Express
-   **IDE**: Visual Studio 2022
-   **Git**: Để clone repository

## Hướng Dẫn Cài Đặt

### 1. Clone Repository

``` bash
git clone https://github.com/yourusername/StudentAttendanceMVC.git
cd StudentAttendanceMVC
```

### 2. Cài Đặt Phụ Thuộc

-   Mở giải pháp trong Visual Studio.
-   Khôi phục các gói NuGet:
    -   Click chuột phải vào giải pháp \> Restore Packages, hoặc chạy:

    ``` bash
    dotnet restore
    ```

### 3. Cấu Hình Cơ Sở Dữ Liệu

-   Mở file appsettings.json và đảm bảo chuỗi kết nối đúng:

``` json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\mssqllocaldb;Database=StudentAttendanceDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

-   Nếu sử dụng SQL Server Express, cập nhật thành:

``` json
"DefaultConnection": "Server=localhost\SQLEXPRESS;Database=StudentAttendanceDb;Trusted_Connection=True;MultipleActiveResultSets=true"
```

-   Áp dụng migration để tạo cơ sở dữ liệu:
    -   Mở Package Manager Console (Tools \> NuGet Package Manager \>
        Package Manager Console).
    -   Đặt Default Project là StudentAttendanceMVC.
    -   Chạy:

    ``` bash
    Add-Migration InitialCreate
    Update-Database
    ```
-   Nếu "InitialCreate" đã tồn tại, dùng tên khác (ví dụ:
    AddAttendanceTracking) và tiếp tục.

### 4. Tạo Dữ Liệu Mặc Định

-   Chạy ứng dụng (`dotnet run` hoặc F5 trong Visual Studio) để tạo các
    vai trò mặc định (Sinh viên, Giảng viên, Quản lý) và người dùng quản
    lý mẫu.
-   Thông tin đăng nhập mặc định: **admin@example.com / Admin@123**.

### 5. Chạy Ứng Dụng

-   Khởi động ứng dụng:

``` bash
dotnet run
```

-   Truy cập tại `https://localhost:7057` (cổng có thể thay đổi).

## Hướng Dẫn Sử Dụng

### Giảng Viên

-   Đăng nhập bằng tài khoản Giảng viên.
-   Vào `/Schedules/LecturerStudents` để ghi nhận điểm danh.
-   Chọn/deselection sinh viên và lưu trong vòng 30 phút từ giờ bắt đầu
    lớp.

### Sinh Viên

-   Đăng nhập bằng tài khoản Sinh viên.
-   Truy cập `/Attendance/StudentAttendance` để xem trạng thái điểm danh
    cá nhân.

### Quản Lý

-   Đăng nhập bằng tài khoản Quản lý.
-   Vào `/Attendance/AdminAttendance` để xem toàn bộ điểm danh.
-   Chọn lớp để xem danh sách sinh viên và tải báo cáo Excel.

## Cấu Trúc Dự Án

-   `Controllers/`: Xử lý yêu cầu HTTP (ví dụ: AttendanceController,
    SchedulesController).
-   `Models/`: Định nghĩa các thực thể dữ liệu (ví dụ: ClassSession,
    Student).
-   `Views/`: Các view Razor cho giao diện (ví dụ:
    AdminAttendance.cshtml).
-   `Data/`: Chứa AppDbContext để tương tác với cơ sở dữ liệu.
-   `wwwroot/`: Các tệp tĩnh (CSS, JS).

## Hướng Dẫn Đóng Góp

-   Fork repository.
-   Tạo nhánh tính năng (`git checkout -b feature/new-feature`).
-   Commit thay đổi (`git commit -m "Thêm tính năng mới"`).
-   Đẩy lên nhánh (`git push origin feature/new-feature`).
-   Mở Pull Request.

## Báo Cáo Sự Cố

-   Báo lỗi hoặc đề xuất tính năng bằng cách mở issue trên GitHub.
-   Bao gồm các bước tái hiện và log (ví dụ: từ Output window).

### Hướng Dẫn
- **Lưu file**: Sao chép nội dung trên và dán vào file `README.md` trong thư mục gốc của dự án.
- **Tùy chỉnh**: Thay `https://github.com/yourusername/StudentAttendanceMVC.git` bằng URL repository thực tế của bạn.
- **Thêm LICENSE**: Tạo file `LICENSE` với nội dung MIT nếu cần.