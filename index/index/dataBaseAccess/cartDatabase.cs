using index.cs_sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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


    }
}