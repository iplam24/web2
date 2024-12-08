using index.admin;
using index.cs_sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

using index.cs_basic;
using System.Net.Mail;
using System.Net;

namespace index.dataBaseAccess
{
    public class userAccount
    {
        connect conn = new connect();

        public void hienThiTaiKhoan(Table tbl_taikhoan)
        {
            conn.moKetNoi();
            string sql = "select * from tbl_taikhoan";
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            SqlDataReader reader = cmd.ExecuteReader();
            int j = 1;
            while (reader.Read())
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = j.ToString();
                row.Cells.Add(cell);
                for (int i = 0; i < 4; i++)
                {
                    TableCell c = new TableCell();
                  
                    c.Text = reader[i].ToString();
                    


                    row.Cells.Add(c);
                }
                TableCell cll = new TableCell();
                cll.Text = "<a href='suataikhoan.aspx?taikhoan=" + reader[0].ToString() + "'> Sửa </a>";
                cll.Text += "<a href='javascript:void(0);' onclick=\"if(confirm('Bạn có chắc chắn muốn xóa tài khoản này?')) { window.location.href='xoataikhoan.aspx?taikhoan=" + reader[0].ToString() + "'; }\"> Xóa </a>";


                row.Cells.Add(cll);
                tbl_taikhoan.Rows.Add(row);
                j++;
            }
        }
        public void themtaikhoan(string taikhoan, string matkhau, string email)
        {
            conn.moKetNoi();
            string sql = @"INSERT INTO tbl_taikhoan (TaiKhoan, MatKhau, VaiTro, Email) VALUES (@taikhoan, @matkhau, 2, @email)";
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);

            // Thêm các tham số vào câu lệnh SQL
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan);
            cmd.Parameters.AddWithValue("@matkhau", matkhau);
            cmd.Parameters.AddWithValue("@email", email);

            // Thực thi câu lệnh SQL
            cmd.ExecuteNonQuery();
        }
        private string MaHoaMatKhau(string matkhau)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(matkhau));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
        public bool KiemTraTaiKhoanTonTai(string taikhoan)
        {
            conn.moKetNoi();
            string sql = "SELECT COUNT(*) FROM tbl_taikhoan WHERE Taikhoan = @taikhoan";
            using (SqlCommand cmd = new SqlCommand(sql, conn.SQLConn))
            {
                cmd.Parameters.AddWithValue("@taikhoan", taikhoan);
                int count = (int)cmd.ExecuteScalar();
                return count > 0; // Nếu có bản ghi tồn tại, trả về true
            }
        }
        public void suaTaiKhoan( string taiKhoanMoi, string matKhau, string vaiTro,string email)
        {
            // Mở kết nối
            conn.moKetNoi();

            
            string sql = "UPDATE tbl_taikhoan " +
                         "SET TaiKhoan = @taiKhoanMoi, MatKhau = @matKhau, VaiTro = @vaiTro,Email=@email " +
                         "WHERE TaiKhoan = @taiKhoanMoi";

            using (SqlCommand cmd = new SqlCommand(sql, conn.SQLConn))
            {
                // Thêm tham số vào câu lệnh
                cmd.Parameters.AddWithValue("@taiKhoanMoi", taiKhoanMoi);
                cmd.Parameters.AddWithValue("@matKhau", matKhau);
                cmd.Parameters.AddWithValue("@vaiTro", vaiTro);
                cmd.Parameters.AddWithValue("@email",email );


                // Thực thi câu lệnh
                cmd.ExecuteNonQuery();
            }

            // Đóng kết nối
            conn.dongKetNoi();
        }
        public user layTaiKhoanTheoTen(string taiKhoan)
        {
            // Mở kết nối
            conn.moKetNoi();

            // Câu lệnh SQL
            string sql = "SELECT * FROM tbl_taikhoan WHERE TaiKhoan = @taiKhoan";

            using (SqlCommand cmd = new SqlCommand(sql, conn.SQLConn))
            {
                // Thêm tham số vào câu lệnh
                cmd.Parameters.AddWithValue("@taiKhoan", taiKhoan);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Nếu tìm thấy tài khoản, trả về đối tượng TaiKhoan
                        user tk = new user
                        {
                            taiKhoan = reader["TaiKhoan"].ToString(),
                            matKhau = reader["MatKhau"].ToString(),
                            vaiTro = reader["VaiTro"].ToString(),
                            email = reader["Email"].ToString()
                        };
                        return tk;
                    }
                }
            }

            // Đóng kết nối
            conn.dongKetNoi();

            // Nếu không tìm thấy tài khoản, trả về null
            return null;
        }
        public void xoaTaiKhoan(string taikhoan)
        {
            conn.moKetNoi();
            string sql = @"delete from tbl_taikhoan where TaiKhoan=@taikhoan";
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            cmd.Parameters.AddWithValue("@taikhoan",taikhoan);
            cmd.ExecuteNonQuery();


        }

        public bool dangnhap(string taikhoan,string matkhau)
        {
            conn.moKetNoi();
            string sql = @"SELECT COUNT(*) FROM tbl_taikhoan 
                       WHERE TaiKhoan = @taiKhoan AND MatKhau = @matKhau";
            using (SqlCommand cmd = new SqlCommand(sql, conn.SQLConn))
            {
                // Thêm tham số để bảo vệ khỏi SQL Injection
                cmd.Parameters.AddWithValue("@taiKhoan", taikhoan);
               cmd.Parameters.AddWithValue("@matKhau", matkhau);

                // Thực thi lệnh và lấy kết quả
                int userCount = (int)cmd.ExecuteScalar();

                // Kiểm tra kết quả
                return userCount > 0; // Trả về true nếu tồn tại tài khoản và mật khẩu
            }
            
            

        }
        public int layvaitro(string taikhoan)
        {
            try
            {
                // Mở kết nối
                conn.moKetNoi();

                // Lệnh SQL để lấy vai trò của tài khoản
                string sql = @"SELECT VaiTro FROM tbl_taikhoan 
                       WHERE TaiKhoan = @taiKhoan";

                using (SqlCommand cmd = new SqlCommand(sql, conn.SQLConn))
                {
                    // Thêm tham số để tránh SQL Injection
                    cmd.Parameters.AddWithValue("@taiKhoan", taikhoan);

                    // Thực thi lệnh và lấy vai trò
                    object result = cmd.ExecuteScalar();

                    // Kiểm tra kết quả và trả về vai trò
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        // Trả về -1 nếu tài khoản không tồn tại
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi khi lấy vai trò: " + ex.Message);
                return -2; // Trả về mã lỗi khác nếu có lỗi
            }
            finally
            {
                // Đảm bảo đóng kết nối
                conn.dongKetNoi();
            }
        }
        public bool kiemTraEmail(string email)
        {
            conn.moKetNoi();
            string sql = "SELECT COUNT(*) FROM tbl_taikhoan WHERE Email = @Email";
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            cmd.Parameters.AddWithValue("@Email", email);
            int count = (int)cmd.ExecuteScalar();
            conn.dongKetNoi();
            return count > 0;
        }
        public void luuMaXacNhan(string email, string maXacNhan)
        {
            conn.moKetNoi();
            string sql = "UPDATE tbl_taikhoan SET MaXacNhan = @MaXacNhan WHERE Email = @Email";
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            cmd.Parameters.AddWithValue("@MaXacNhan", maXacNhan);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.ExecuteNonQuery();
            conn.dongKetNoi();
        }
        public bool kiemTraMaXacNhan(string email, string maXacNhan)
        {
            conn.moKetNoi();
            string sql = "SELECT COUNT(*) FROM tbl_taikhoan WHERE Email = @Email AND MaXacNhan = @MaXacNhan";
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@MaXacNhan", maXacNhan);
            int count = (int)cmd.ExecuteScalar();
            conn.dongKetNoi();
            return count > 0;
        }

        public void capNhatMatKhau(string email, string matKhauMoi)
        {
            conn.moKetNoi();
            string sql = "UPDATE tbl_taikhoan SET MatKhau = @MatKhau WHERE Email = @Email";
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            cmd.Parameters.AddWithValue("@MatKhau", matKhauMoi); // Mã hóa mật khẩu trước khi lưu
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.ExecuteNonQuery();
            conn.dongKetNoi();
        }
        public void guiEmail(string toEmail, string subject, string body)
        {
            try
            {
                // Cấu hình thông tin gửi email
                string fromEmail = "lam.cu.14304@gmail.com"; // Email của bạn
                string password = "bckb fbqr endv hqbw"; // Mật khẩu ứng dụng (application password)
                string smtpHost = "smtp.gmail.com"; // SMTP server (thay đổi theo nhà cung cấp email)
                int smtpPort = 587; // Cổng SMTP (587 hoặc 465)

                // Tạo đối tượng SmtpClient
                SmtpClient smtpClient = new SmtpClient(smtpHost, smtpPort)
                {
                    Credentials = new NetworkCredential(fromEmail, password),
                    EnableSsl = true // Sử dụng SSL
                };

                // Tạo đối tượng MailMessage
                MailMessage mailMessage = new MailMessage(fromEmail, toEmail, subject, body)
                {
                    IsBodyHtml = true // Email có thể chứa HTML
                };

                // Gửi email
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi gửi email
                throw new Exception("Gửi email thất bại: " + ex.Message);
            }
        }

    }
}