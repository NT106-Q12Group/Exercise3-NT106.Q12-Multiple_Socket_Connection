# README.md

## 📋 THÔNG TIN NHÓM

| MSSV | Họ và Tên | Vai trò |
|------|-----------|---------|
| 24521245 | Trương Danh Nhân | Nhóm trưởng |
| 24521216 | Trương Vĩnh Nguyên | Thành viên |
| 24521227 | Đào Mạnh Nhân | Thành viên |
| 24521251 | Lê Ngọc Minh Nhật | Thành viên |
| 24521285 | Huỳnh Xuân Nin | Thành viên |

---

## 📝 MÔ TẢ BÀI TẬP

### Tổng quan
Bài tập xây dựng **hệ thống Client-Server** sử dụng giao thức **TCP/IP** để quản lý người dùng với các chức năng đầy đủ: đăng ký, đăng nhập, và quản lý thông tin cá nhân.

### Kiến trúc hệ thống

Hệ thống bao gồm **2 solution** chính:

**1. TCPClient Solution**
- Ứng dụng Windows Forms cho phép người dùng tương tác với hệ thống
- Gồm các form: SignIn, SignUp, Dashboard
- Class TCPClient để kết nối và giao tiếp với server

**2. TCPServer Solution**
- Máy chủ TCP xử lý các yêu cầu từ nhiều client đồng thời
- Gồm các class: TCPServer, Database, UserClass, UserRepo
- Sử dụng SQLite để lưu trữ dữ liệu người dùng

### Công nghệ sử dụng

- **Ngôn ngữ**: C# (.NET Core/Framework)
- **Giao thức mạng**: TCP/IP Socket
- **Cơ sở dữ liệu**: SQLite với Microsoft.Data.Sqlite
- **Giao diện**: Windows Forms
- **Bảo mật**: Mã hóa mật khẩu bằng SHA-256

### Tính năng chính

✅ **Đăng ký tài khoản**: Tạo tài khoản mới với validation đầy đủ (username, password, email, họ tên, ngày sinh, địa chỉ, số điện thoại)

✅ **Đăng nhập**: Xác thực người dùng với username và password

✅ **Dashboard**: Hiển thị thông tin cá nhân chi tiết sau khi đăng nhập

✅ **Đăng xuất**: Ngắt kết nối an toàn và quay về màn hình đăng nhập

✅ **Multi-client support**: Server hỗ trợ nhiều client kết nối đồng thời

### Giao thức truyền thông

Server và Client giao tiếp thông qua các message có định dạng `ACTION|param1|param2|...`

**Các lệnh hỗ trợ**:
- `SIGNUP|username|passwordHash|email|fullname|age|address|phone` - Đăng ký
- `SIGNIN|username|passwordHash` - Đăng nhập
- `GETUSER|username` - Lấy thông tin người dùng
- `SIGNOUT|username` - Đăng xuất

**Định dạng phản hồi**: `Success|data...` hoặc `Error|message`

---

## 🔧 HƯỚNG DẪN CÀI ĐẶT

### Yêu cầu hệ thống

- **.NET Framework/Core**: 6.0 trở lên
- **Hệ điều hành**: Windows (cho Windows Forms)
- **IDE**: Visual Studio 2019 hoặc mới hơn (khuyến nghị)
- **NuGet Package**: Microsoft.Data.Sqlite

### Bước 1: Cài đặt TCPServer

Clone hoặc tải source code về
`cd TCPServer`

Restore các NuGet packages
`dotnet restore`

Build project
`dotnet build`

Chạy server
`dotnet run`

**Lưu ý**: 
- Server sẽ lắng nghe trên **cổng 25565**
- File database `server.db` sẽ được tự động tạo khi chạy lần đầu tiên
- Console sẽ hiển thị log các kết nối và xử lý request

### Bước 2: Cài đặt TCPClient

Di chuyển đến thư mục TCPClient
`cd TCPClient`

Restore các NuGet packages
`dotnet restore`

Build project
`dotnet build`

Chạy client
`dotnet run`


**Lưu ý**: Client sẽ tự động kết nối đến server tại `127.0.0.1:25565`

### Cấu hình tùy chỉnh

Để thay đổi địa chỉ IP hoặc port của server, chỉnh sửa trong file `TCPClient.cs`:
```
public static class Session
{
    public static TCPClient Client { get; } = new TCPClient("127.0.0.1", 25565);
}
```
Để thay đổi port lắng nghe của server, điều chỉnh trong file main của TCPServer.

---

## 📥 HƯỚNG DẪN CÀI ĐẶT

### Bước 1: Clone Repository
```
git clone https://github.com/NT106-Q12Group/Exercise3-NT106.Q12-Multiple_Socket_Connection
```
### Bước 2: Cài Đặt Dependencies

1. Mở Visual Studio 2019 hoặc 2022
2. Mở file `.sln` trong thư mục đã clone
3. Cài đặt NuGet Package:
   - Right-click vào Solution → Manage NuGet Packages
   - Tìm và cài `Microsoft.Data.Sqlite`

### Bước 3: Build Project

- Build Server: `Ctrl + Shift + B` trên project TCPServer
- Build Client: `Ctrl + Shift + B` trên project TCPClient

### Bước 4: Khởi Động Server

1. Mở project TCPServer
2. Chạy `TCPServer.cs` hoặc nhấn `F5`
3. Server sẽ lắng nghe tại **cổng 25565**
4. Database `server.db` sẽ được tạo tự động
5. Console hiển thị: `✅ [SERVER] Listening on port 25565...`

### Bước 5: Chạy Client

1. Mở project TCPClient (trong Visual Studio khác)
2. Chạy ứng dụng Client hoặc nhấn `F5`
3. Form đăng nhập sẽ xuất hiện
4. Đảm bảo Server đang chạy trước khi sử dụng Client

---

## 📚 HƯỚNG DẪN SỬ DỤNG

### Khởi Động Server

1. Chạy chương trình TCP Server
2. Console sẽ hiển thị: `✅ [SERVER] Listening on port 25565...`
3. Server sẵn sàng nhận kết nối từ client

### Đăng Ký Tài Khoản Mới

1. Mở ứng dụng Client
2. Nhấn link "Đăng ký" tại màn hình đăng nhập
3. Điền đầy đủ thông tin:
   - **Username**: 4-20 ký tự, chỉ chứa chữ cái, số và dấu gạch dưới
   - **Password**: Tối thiểu 8 ký tự
   - **Confirm Password**: Phải khớp với password
   - **Email**: Đúng định dạng email
   - **Full Name**: Họ và tên đầy đủ
   - **Birthday**: Định dạng dd/MM/yyyy (ví dụ: 15/08/2003)
   - **Address**: Địa chỉ
   - **Phone**: 10 chữ số, bắt đầu bằng số 0
4. Nhấn "Đăng ký"
5. Hệ thống sẽ thông báo kết quả
6. Nếu thành công, tự động chuyển về màn hình đăng nhập

### Đăng Nhập Hệ Thống

1. Nhập Username và Password
2. Nhấn "Đăng nhập" hoặc nhấn `Enter`
3. Nếu thành công, chuyển đến Dashboard
4. Nếu thất bại, hiển thị thông báo lỗi cụ thể

### Xem Thông Tin Tài Khoản

- Sau khi đăng nhập, Dashboard sẽ hiển thị:
  - Username
  - Họ và tên đầy đủ
  - Email
  - Ngày sinh
  - Địa chỉ
  - Số điện thoại
- Tất cả thông tin ở chế độ **read-only** (chỉ đọc)

### Đăng Xuất

- Nhấn nút "Đăng xuất" trong Dashboard
- Server nhận thông báo đăng xuất
- Kết nối TCP được ngắt
- Quay lại màn hình đăng nhập
---
## 🖼️ CÁC MÀN HÌNH GIAO DIỆN ỨNG DỤNG

### Màn hình Đăng nhập 

![](https://sf-static.upanhlaylink.com/img/image_20251028f27818f719aa6f3c05af6047c14b87af.jpg)

**📌 Mục đích**: Form cho phép người dùng đăng nhập vào hệ thống

**🎨 Các thành phần giao diện**:
- **TextBox Username**: Nhập tên đăng nhập, có placeholder "Tên đăng nhập"
- **TextBox Password**: Nhập mật khẩu (ẩn ký tự bằng dấu *), có placeholder "Nhập mật khẩu"
- **Button Đăng nhập**: Thực hiện đăng nhập
- **LinkLabel Đăng ký**: Chuyển sang form đăng ký

**⚙️ Chức năng xử lý**:
- Kiểm tra các trường không được để trống
- Mã hóa mật khẩu bằng SHA-256 trước khi gửi lên server
- Gửi request `SIGNIN|username|passwordHash` đến server
- Nhận response từ server và xử lý:
  - Nếu `Success`: Parse thông tin user và chuyển đến Dashboard
  - Nếu `Error`: Hiển thị MessageBox thông báo lỗi cụ thể
- Hỗ trợ nhấn Enter để đăng nhập (AcceptButton)

**🎯 Validation**:
- Username không được rỗng
- Password không được rỗng
- Kiểm tra kết nối server trước khi đăng nhập

---

### Màn hình Đăng ký 

![](https://sf-static.upanhlaylink.com/img/image_202510284476205e394547fc514e48deaf101934.jpg)

**📌 Mục đích**: Form cho phép người dùng tạo tài khoản mới với đầy đủ thông tin cá nhân

**🎨 Các thành phần giao diện**:
- **TextBox Username**: Nhập tên đăng nhập, placeholder "Tên đăng nhập (4–20 ký tự, chữ/số/_ )"
- **TextBox Password**: Nhập mật khẩu (ẩn ký tự), placeholder "Nhập mật khẩu"
- **TextBox Confirm Password**: Xác nhận mật khẩu (ẩn ký tự), placeholder "Xác nhận mật khẩu"
- **TextBox Email**: Nhập email, placeholder "Email"
- **TextBox Fullname**: Nhập họ tên, placeholder "Họ và tên"
- **TextBox Birthdate**: Nhập ngày sinh, placeholder "Ngày sinh (dd/MM/yyyy)"
- **TextBox Address**: Nhập địa chỉ, placeholder "Địa chỉ"
- **TextBox Phone**: Nhập số điện thoại (chỉ cho phép nhập số), placeholder "Số điện thoại (10 số, bắt đầu 0)"
- **Button Đăng ký**: Thực hiện đăng ký
- **LinkLabel Đăng nhập**: Quay lại form đăng nhập

**⚙️ Chức năng xử lý**:
- Placeholder tự động ẩn/hiện khi focus/blur
- TextBox phone chỉ cho phép nhập số (KeyPress event)
- Giới hạn phone tối đa 10 ký tự (MaxLength)
- Mã hóa password bằng SHA-256
- Gửi request `SIGNUP|username|hash|email|fullname|age|address|phone`
- Xử lý response và hiển thị thông báo

**🎯 Validation chi tiết**:
1. **Username**: 
   - Độ dài 4-20 ký tự
   - Chỉ chấp nhận a-z, A-Z, 0-9, _ (regex: `^[a-zA-Z0-9_]+$`)

2. **Password**:
   - Tối thiểu 8 ký tự

3. **Confirm Password**:
   - Phải khớp với password

4. **Email**:
   - Định dạng email hợp lệ (regex: `^[^@\s]+@[^@\s]+\.[^@\s]+$`)

5. **Ngày sinh**:
   - Định dạng dd/MM/yyyy (ví dụ: 31/12/2001)
   - Không được ở tương lai
   - Không trước năm 1900
   - Parse bằng DateTime.TryParseExact

6. **Số điện thoại**:
   - Đúng 10 chữ số
   - Bắt đầu bằng số 0
   - Regex: `^0\d{9}$`

**💡 Đặc điểm nổi bật**:
- Hiển thị thông báo lỗi cụ thể cho từng trường
- Focus tự động vào trường bị lỗi
- Prevent double-click bằng flag `_busy`
- Tự động chuyển về màn hình đăng nhập sau khi đăng ký thành công

---

### Màn hình Dashboard 

![](https://sf-static.upanhlaylink.com/img/image_202510282db62f4fd23d24f347ad61ebd5139b07.jpg)

**📌 Mục đích**: Hiển thị thông tin cá nhân của người dùng sau khi đăng nhập thành công

**🎨 Các thành phần giao diện**:
- **TextBox Username**: Hiển thị tên đăng nhập (ReadOnly)
- **TextBox Fullname**: Hiển thị họ và tên đầy đủ (ReadOnly)
- **TextBox Email**: Hiển thị địa chỉ email (ReadOnly)
- **TextBox Age**: Hiển thị ngày sinh (ReadOnly)
- **TextBox Address**: Hiển thị địa chỉ (ReadOnly)
- **TextBox Phone**: Hiển thị số điện thoại (ReadOnly)
- **Button Đăng xuất**: Thực hiện đăng xuất và quay về màn hình đăng nhập

**⚙️ Chức năng xử lý**:
- Nhận object `UserView` từ SignIn form
- Load event tự động điền thông tin vào các TextBox
- Set tất cả TextBox ở chế độ ReadOnly
- Khi click "Đăng xuất":
  - Kiểm tra kết nối server
  - Gửi request `SIGNOUT|username` đến server
  - Ngắt kết nối TCP (`_client.Disconnect()`)
  - Ẩn form hiện tại và show form SignIn mới
  - Hiển thị MessageBox xác nhận đăng xuất

**💡 Đặc điểm**:
- Không cho phép chỉnh sửa thông tin (ReadOnly)
- Prevent double-click logout bằng flag `_busy`
- Handle error gracefully khi server disconnect
- Constructor nhận TCPClient và UserView để maintain state

### Console Server (TCPServer)

![](https://sf-static.upanhlaylink.com/img/image_20251028dc027d62c0073de538b78a9f6f073a38.jpg)

**📌 Mục đích**: Console application hiển thị log và trạng thái của server

**🎨 Thông tin hiển thị**:
- Thông báo server đang lắng nghe trên cổng 25565
- Log kết nối từ client (IP address)
- Log các request nhận được từ client (SIGNIN, SIGNUP, GETUSER, SIGNOUT)
- Log các response gửi về client (Success/Error)
- Thông báo ngắt kết nối khi client disconnect

**⚙️ Chức năng**:
- Khởi tạo database `server.db` tự động nếu chưa tồn tại
- Lắng nghe và chấp nhận kết nối từ nhiều client đồng thời
- Xử lý request theo mẫu giao thức `ACTION|param1|param2|...`
- Ghi log chi tiết mọi hoạt động để debug và giám sát

---

## 💾 CẤU TRÚC CƠ SỞ DỮ LIỆU

Server sử dụng **SQLite** với bảng `Users`:

| Trường | Kiểu dữ liệu | Ràng buộc | Mô tả |
|--------|-------------|----------|-------|
| Id | INTEGER | PRIMARY KEY, AUTOINCREMENT | ID tự động tăng |
| Username | TEXT | UNIQUE, NOT NULL | Tên đăng nhập (duy nhất) |
| PasswordHash | TEXT | NOT NULL | Mật khẩu đã mã hóa SHA-256 |
| Email | TEXT | - | Địa chỉ email |
| FullName | TEXT | - | Họ và tên đầy đủ |
| Age | TEXT | - | Ngày sinh (định dạng dd/MM/yyyy) |
| Address | TEXT | - | Địa chỉ liên hệ |
| Phone | TEXT | - | Số điện thoại |

**Khởi tạo database**: File `server.db` được tự động tạo trong thư mục ứng dụng khi server chạy lần đầu

---

## 🔐 BẢO MẬT

- **Mã hóa mật khẩu**: Sử dụng SHA-256 để hash password trước khi truyền và lưu trữ
- **Không lưu plaintext**: Không có mật khẩu dạng text thường trong database
- **Validation đầy đủ**: Kiểm tra dữ liệu ở cả client và server side
- **Exception handling**: Xử lý lỗi để tránh crash và lộ thông tin nhạy cảm
- **Connection check**: Kiểm tra kết nối trước khi gửi dữ liệu

---

## ⚠️ XỬ LÝ LỖI

Hệ thống xử lý các tình huống lỗi phổ biến:

- ❌ Không kết nối được server: Hiển thị thông báo "Không thể kết nối server (25565)"
- ❌ Username đã tồn tại: Server trả về "Username already exists"
- ❌ Sai thông tin đăng nhập: Server trả về "User not found" hoặc "Wrong password"
- ❌ Dữ liệu không hợp lệ: Client validation và hiển thị lỗi cụ thể
- ❌ Mất kết nối: Auto disconnect và hiển thị thông báo
- ❌ Database error: Catch exception và trả về error message

---

## 📂 CẤU TRÚC PROJECT
```
TCPClient/
├── SignIn.cs 
├── SignIn.Designer.cs 
├── SignUp.cs 
├── SignUp.Designer.cs 
├── Dashboard.cs 
├── Dashboard.Designer.cs 
└── TCPClient.cs 

TCPServer/
├── TCPServer.cs 
├── Database.cs 
├── UserClass.cs 
└── UserRepo.cs 
│
│
└── README.md # File hướng dẫn này
```

---

## 🚀 DEMO & TESTING

### Test case đăng ký
1. Đăng ký với username hợp lệ → ✅ Success
2. Đăng ký với username đã tồn tại → ❌ Error
3. Đăng ký với password < 8 ký tự → ❌ Error
4. Đăng ký với email sai format → ❌ Error
5. Đăng ký với phone không đúng 10 số → ❌ Error

### Test case đăng nhập
1. Đăng nhập với thông tin đúng → ✅ Success
2. Đăng nhập với username không tồn tại → ❌ Error
3. Đăng nhập với password sai → ❌ Error
4. Đăng nhập khi server offline → ❌ Connection error

---

