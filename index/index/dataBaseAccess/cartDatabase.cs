using index.cs_basic;
using index.cs_sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace index.dataBaseAccess
{
    public class cartDatabase
    {
        connect conn = new connect();

        public void hienThiGioHang(Table tbl_giohang)
        {
            conn.moKetNoi();
            string sql = "select * from v_giohang";
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            SqlDataReader reader = cmd.ExecuteReader();
            int j = 1;
            while (reader.Read())
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = j.ToString();
                row.Cells.Add(cell);


                for (int i = 0; i <8; i++)
                {
                    TableCell c = new TableCell();
                    if (i == 3)
                    {
                        c.Text = "<img src='" + reader[i].ToString() + "'>";
                    }
                    
                    else
                    {
                        c.Text = reader[i].ToString();
                    }


                    row.Cells.Add(c);
                }
                TableCell cll = new TableCell();
                cll.Text = "<a href='suagiohang.aspx?masp=" + reader[0].ToString() + "'> Sửa </a>";
                cll.Text += "<a href='javascript:void(0);' onclick=\"if(confirm('Bạn có chắc chắn muốn giỏ hàng này')) { window.location.href='xoagiohang.aspx?taikhoan=" + reader[0].ToString() + "'; }\"> Xóa </a>";


                row.Cells.Add(cll);
                tbl_giohang.Rows.Add(row);
                j++;
            }
        }
        public void hienThiGioHang(Repeater repeaterCart)
        {
            try
            {
                conn.moKetNoi();
                string sql = "SELECT * FROM v_giohang WHERE TaiKhoan = @TaiKhoan";
                SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
                cmd.Parameters.AddWithValue("@TaiKhoan", HttpContext.Current.Session["dangnhap"]);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                repeaterCart.DataSource = dt;
                repeaterCart.DataBind();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Error: " + ex.Message);
            }
            finally
            {
                conn.dongKetNoi(); 
            }
        }
        public void xoaGioHang(string taikhoan,string masp)
        {
            conn.moKetNoi(); // Mở kết nối

            // Lấy mã sản phẩm từ giỏ hàng của tài khoản
           // string masp = layMaSPGH(taikhoan);

            // Nếu không có sản phẩm trong giỏ hàng, không thực hiện xóa
            if (masp != null)
            {
                // Câu truy vấn xóa sản phẩm trong giỏ hàng
                string sql = @"DELETE FROM tbl_giohang WHERE TaiKhoan = @taikhoan AND MaSP = @masp";

                // Khởi tạo SqlCommand với câu truy vấn SQL
                SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);

                // Thêm tham số vào câu truy vấn
                cmd.Parameters.AddWithValue("@taikhoan", taikhoan);
                cmd.Parameters.AddWithValue("@masp", masp); // Đảm bảo thêm đúng tham số cho @masp

                // Thực thi câu lệnh xóa
                cmd.ExecuteNonQuery();
            }
        }
        public void xoaGioHangt(string taikhoan)
        {
            conn.moKetNoi(); // Mở kết nối

            // Lấy mã sản phẩm từ giỏ hàng của tài khoản
             string masp = layMaSPGH(taikhoan);

            // Nếu không có sản phẩm trong giỏ hàng, không thực hiện xóa
            if (masp != null)
            {
                // Câu truy vấn xóa sản phẩm trong giỏ hàng
                string sql = @"DELETE FROM tbl_giohang WHERE TaiKhoan = @taikhoan AND MaSP = @masp";

                // Khởi tạo SqlCommand với câu truy vấn SQL
                SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);

                // Thêm tham số vào câu truy vấn
                cmd.Parameters.AddWithValue("@taikhoan", taikhoan);
                cmd.Parameters.AddWithValue("@masp", masp); // Đảm bảo thêm đúng tham số cho @masp

                // Thực thi câu lệnh xóa
                cmd.ExecuteNonQuery();
            }
        }

        public string layMaSPGH(string taikhoan)
        {
            conn.moKetNoi(); // Mở kết nối

            // Câu truy vấn lấy mã sản phẩm từ giỏ hàng dựa trên tài khoản
            string sql = @"SELECT MaSP FROM tbl_giohang WHERE TaiKhoan = @taikhoan";

            // Khởi tạo SqlCommand với câu truy vấn SQL
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);

            // Thêm tham số @taikhoan vào câu truy vấn
            cmd.Parameters.AddWithValue("@taikhoan", taikhoan); // Kiểm tra lại tham số này

            // Đọc kết quả từ cơ sở dữ liệu
            using (SqlDataReader reader = cmd.ExecuteReader())  // Sử dụng 'using' để đảm bảo đóng reader
            {
                // Kiểm tra nếu có kết quả
                if (reader.HasRows)
                {
                    reader.Read(); // Di chuyển đến dòng đầu tiên
                    return reader["MaSP"].ToString(); // Trả về giá trị MaSP
                }
                else
                {
                    return null; // Nếu không có kết quả, trả về null
                }
            }
        }
        public decimal tinhTongTien(string taikhoan)
        {
            conn.moKetNoi();
            decimal tongTien = 0;
            string query = "SELECT SUM(ThanhTien) AS TongTien FROM v_giohang WHERE Taikhoan = @taikhoan"; // Sửa cú pháp SQL

            using (SqlCommand cmd = new SqlCommand(query, conn.SQLConn))
            {
                cmd.Parameters.AddWithValue("@taikhoan", taikhoan);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Truy cập cột với tên đã thay đổi
                        tongTien = reader["TongTien"] != DBNull.Value ? Convert.ToDecimal(reader["TongTien"]) : 0;
                    }
                }
            }

            return tongTien;

        }
        public List<giohang> layGioHang(string taikhoan)
        {
            conn.moKetNoi(); // Mở kết nối

            List<giohang> gioHangs = new List<giohang>(); // Tạo danh sách giỏ hàng để lưu trữ kết quả

            try
            {
                // Truy vấn giỏ hàng dựa trên tài khoản
                string sql = "SELECT TaiKhoan, MaSP, SoLuong, NgayThem, GiaBan FROM v_giohang WHERE TaiKhoan = @TaiKhoan";

                // Sử dụng using để đảm bảo tài nguyên được giải phóng đúng cách
                using (SqlCommand cmd = new SqlCommand(sql, conn.SQLConn))
                {
                    cmd.Parameters.Add("@TaiKhoan", SqlDbType.NVarChar).Value = taikhoan;

                    // Thực hiện truy vấn và đọc dữ liệu
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("Không có dữ liệu cho tài khoản: " + taikhoan);
                        }

                        while (reader.Read())
                        {
                            giohang item = new giohang()
                            {
                                TaiKhoan = reader["TaiKhoan"].ToString(),
                                MaSP = reader["MaSP"].ToString(),
                                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                NgayThem = reader["NgayThem"].ToString(),
                                GiaBan = Convert.ToDecimal(reader["GiaBan"])
                            };

                            gioHangs.Add(item); // Thêm sản phẩm vào danh sách giỏ hàng
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // In chi tiết lỗi
                Console.WriteLine("Lỗi khi lấy giỏ hàng: " + ex.Message);
                Console.WriteLine("Stack trace: " + ex.StackTrace); // In chi tiết lỗi
            }
            finally
            {
                conn.dongKetNoi(); // Đảm bảo đóng kết nối
            }

            // Kiểm tra kết quả
            if (gioHangs.Count == 0)
            {
                Console.WriteLine("Giỏ hàng trống hoặc không có sản phẩm.");
            }

            return gioHangs; // Trả về danh sách giỏ hàng
        }

        public int layIDDH(string taikhoan)
        {
            try
            {
                conn.moKetNoi();

                string sql = @"SELECT MaDonHang FROM tbl_donhang WHERE TaiKhoan = @TaiKhoan";
                SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
                cmd.Parameters.AddWithValue("@TaiKhoan", taikhoan);

                var result = cmd.ExecuteScalar(); // Lấy giá trị từ cột đầu tiên của kết quả

                if (result != null)
                {
                    // Nếu kết quả không null, chuyển đổi thành int và trả về
                    return Convert.ToInt32(result);
                }
                else
                {
                    // Nếu không có kết quả, trả về giá trị mặc định hoặc một giá trị không hợp lệ
                    return -1; // Hoặc có thể là một giá trị hợp lý như 0
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nếu có
                Console.WriteLine("Lỗi khi lấy MaDonHang: " + ex.Message);
                return -1; // Trả về giá trị mặc định khi gặp lỗi
            }
            finally
            {
                conn.dongKetNoi(); // Đảm bảo đóng kết nối
            }
        }


        public void themDonDH(string taikhoan, string ten, string email, string sdt, string tongtien)
        {
            try
            {
                conn.moKetNoi(); // Mở kết nối với cơ sở dữ liệu

                // Câu truy vấn SQL để thêm đơn hàng vào bảng tbl_donhang
                string sql = @"
        INSERT INTO tbl_donhang (TaiKhoan, HoTen, Email, SDT, NgayDatHang, TrangThai, TongTien)
        VALUES (@TaiKhoan, @HoTen, @Email, @SDT, @NgayDatHang, @TrangThai, @TongTien); 
        SELECT SCOPE_IDENTITY();"; // Lấy ID của đơn hàng mới

                SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);

                // Thêm các tham số vào câu truy vấn
                cmd.Parameters.AddWithValue("@TaiKhoan", taikhoan);
                cmd.Parameters.AddWithValue("@HoTen", ten);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters.AddWithValue("@NgayDatHang", DateTime.Now); // Lấy thời gian hiện tại làm ngày đặt hàng
                cmd.Parameters.AddWithValue("@TrangThai", "Chưa xử lý"); // Trạng thái mặc định của đơn hàng là "Chưa xử lý"

                // Chuyển tongtien từ string sang decimal (hoặc float, tùy vào loại dữ liệu bạn sử dụng trong cơ sở dữ liệu)
                decimal tongTienDecimal = 0;
                if (!decimal.TryParse(tongtien, out tongTienDecimal))
                {
                    // Nếu không thể chuyển đổi được, trả về 0 (hoặc xử lý lỗi theo yêu cầu của bạn)
                    tongTienDecimal = 0;
                }
                cmd.Parameters.AddWithValue("@TongTien", tongTienDecimal); // Tổng tiền của đơn hàng

                // Thực thi câu lệnh SQL và lấy ID của đơn hàng vừa thêm
                object result = cmd.ExecuteScalar();

                // Kiểm tra kết quả trả về từ ExecuteScalar()
                if (result != null)
                {
                    int idDonHang = Convert.ToInt32(result); // Chuyển kết quả thành ID của đơn hàng
                    Console.WriteLine("ID đơn hàng: " + idDonHang);

                    // Sau khi thêm đơn hàng thành công, thêm chi tiết đơn hàng vào bảng tbl_ctdondh
                    List<giohang> gioHang = layGioHang(taikhoan);
                    if (gioHang.Count == 0)
                    {
                        Console.WriteLine("Giỏ hàng rỗng, không có sản phẩm để chèn vào đơn hàng.");
                    }
                    else
                    {
                        foreach (var item in gioHang)
                        {
                            Console.WriteLine($"Đang thêm: MaSP = {item.MaSP}, SoLuong = {item.SoLuong}, GiaTien = {item.GiaBan}");
                            string sqlChiTiet = @"
        INSERT INTO tbl_ctdondh (MaDonHang, MaSP, SoLuong, GiaTien)
        VALUES (@MaDonHang, @MaSP, @SoLuong, @GiaTien)";

                            SqlCommand cmdChiTiet = new SqlCommand(sqlChiTiet, conn.SQLConn);
                            cmdChiTiet.Parameters.AddWithValue("@MaDonHang", idDonHang);
                            cmdChiTiet.Parameters.AddWithValue("@MaSP", item.MaSP);
                            cmdChiTiet.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                            cmdChiTiet.Parameters.AddWithValue("@GiaTien", item.GiaBan);

                            try
                            {
                                int rowsAffected = cmdChiTiet.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    Console.WriteLine("Thêm chi tiết đơn hàng thành công.");
                                }
                                else
                                {
                                    Console.WriteLine("Không có dòng nào được chèn.");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Lỗi khi thực thi câu lệnh: " + ex.Message);
                            }
                        }
                    }

                }
                else
                {
                    // Trường hợp không có ID được trả về
                    Console.WriteLine("Lỗi: Không lấy được ID đơn hàng.");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Lỗi khi thêm đơn hàng: " + ex.Message);
            }
            finally
            {
                conn.dongKetNoi(); // Đảm bảo đóng kết nối sau khi thực hiện xong
            }
        }


        //Hamf xoa all gio hang
        public void xoaALLGioHang(string taikhoan)
        {
            conn.moKetNoi();
            string sql = @"delete from tbl_giohang where TaiKhoan=@taikhoan";
            SqlCommand cmd= new SqlCommand(sql, conn.SQLConn);
            cmd.Parameters.AddWithValue("@taikhoan",taikhoan);

            cmd.ExecuteNonQuery();
        }


    }
}