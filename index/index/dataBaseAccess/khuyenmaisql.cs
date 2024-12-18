using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using index.cs_sql;
using System.Web.UI.WebControls;
using index.cs_basic;
using System.IO;

namespace index.dataBaseAccess
{
    public class khuyenmaisql
    {
        connect conn = new connect();

        public void HienThiKhuyenMai(Table tbl_khuyenmai)
        {
            conn.moKetNoi();
            string sql = "select * from tbl_khuyenmai";
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            SqlDataReader reader = cmd.ExecuteReader();
            int j = 1;
            while (reader.Read())
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text = j.ToString();
                row.Cells.Add(cell);
                for (int i = 0; i < 7; i++)
                {
                    TableCell c = new TableCell();
                    if (i == 6)
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
                cll.Text = "<a href='suakhuyenmai.aspx?makm="+reader[0].ToString()+"'> Sửa </a>";
                cll.Text += "<a href='javascript:void(0);' onclick=\"if(confirm('Bạn có chắc chắn muốn xóa tài khoản này?')) { window.location.href='xoakhuyenmai.aspx?khuyenmai=" + reader[0].ToString() + "'; }\"> Xóa </a>";


                row.Cells.Add(cll);
                tbl_khuyenmai.Rows.Add(row);
                j++;
            }
        }

        public void ThemKhuyenMai(string MaKhuyenMai, string TenKhuyenMai, string MoTa, string NgayBatDau, string NgayKetThuc, string MucGiamgia,string HinhAnh)
        {
            conn.moKetNoi();
            string sql = "INSERT INTO tbl_khuyenmai (MaKhuyenMai,TenKhuyenMai, MoTa, NgayBatDau, NgayKetThuc, MucGiamGia,HinhAnh) VALUES (@MaKhuyenMai, @TenKhuyenMai, @MoTa, @NgayBatDau, @NgayKetThuc, @GiamGia,@hinhanh)";
            using (SqlCommand command = new SqlCommand(sql, conn.SQLConn))
            {
                command.Parameters.AddWithValue("@MaKhuyenMai", MaKhuyenMai);
                command.Parameters.AddWithValue("@TenKhuyenMai", TenKhuyenMai);
                command.Parameters.AddWithValue("@MoTa", MoTa);
                command.Parameters.AddWithValue("@NgayBatDau", NgayBatDau);
                command.Parameters.AddWithValue("@NgayKetThuc", NgayKetThuc);
                command.Parameters.AddWithValue("@GiamGia", MucGiamgia);
                command.Parameters.AddWithValue("@hinhanh", HinhAnh);
                command.ExecuteNonQuery();
            }
        }
        public khuyenmaii LayKM(string maKM)
        {

            khuyenmaii km = new khuyenmaii();
            conn.moKetNoi();
            string sql = "SELECT * FROM tbl_khuyenmai WHERE MaKhuyenMai =@makm";

            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            cmd.Parameters.AddWithValue("@makm", maKM);


            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    km.MaKhuyenMai = reader["MaKhuyenMai"].ToString();
                    km.TenKhuyenMai = reader["TenKhuyenMai"].ToString();
                    km.MoTa = reader["MoTa"].ToString();
                    km.NgayBatDau = reader["NgayBatDau"].ToString();
                    km.NgayKetThuc = reader["NgayKetThuc"].ToString();
                    km.MucGiamGia = reader["MucGiamGia"].ToString();
                    km.HinhAnh = reader["HinhAnh"].ToString();
                }
            }

            return km;
        }
        public void SuaKhuyenMai(khuyenmaii km)
        {
            conn.moKetNoi();

            // Câu truy vấn UPDATE
            string query = "UPDATE tbl_khuyenmai SET " +
                    "TenKhuyenMai = @TenKhuyenMai, " +
                    "MoTa = @MoTa, " +
                    "NgayBatDau = @NgayBatDau, " +
                    "NgayKetThuc = @NgayKetThuc, " +
                    "MucGiamGia = @MucGiamGia, " +  // Sửa dấu phẩy ở đây
                    "HinhAnh = @HinhAnh " +
                    "WHERE MaKhuyenMai = @MaKhuyenMai";

            SqlCommand cmd = new SqlCommand(query, conn.SQLConn);
            cmd.Parameters.AddWithValue("@MaKhuyenMai", km.MaKhuyenMai);
            cmd.Parameters.AddWithValue("@TenKhuyenMai", km.TenKhuyenMai);
            cmd.Parameters.AddWithValue("@MoTa", km.MoTa);
            cmd.Parameters.AddWithValue("@NgayBatDau", km.NgayBatDau);
            cmd.Parameters.AddWithValue("@NgayKetThuc", km.NgayKetThuc);
            cmd.Parameters.AddWithValue("@MucGiamGia", km.MucGiamGia);
            cmd.Parameters.AddWithValue("@HinhAnh", km.HinhAnh); 

            // Thực thi câu lệnh SQL
            cmd.ExecuteNonQuery();

            conn.dongKetNoi();

        }
        public void xoaKhuyenMai(string makm)
        {
            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                conn.moKetNoi();

                // Truy vấn SQL để lấy thông tin các hình ảnh của khuyến mãi cần xóa
                string sql = "SELECT HinhAnh FROM tbl_khuyenmai WHERE MaKhuyenMai = @MaKhuyenMai";

                SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
                cmd.Parameters.AddWithValue("@MaKhuyenMai", makm);

                SqlDataReader reader = cmd.ExecuteReader();

                // Kiểm tra nếu khuyến mãi tồn tại trong cơ sở dữ liệu
                if (reader.HasRows)
                {
                    reader.Read(); // Đọc một bản ghi

                    // Lấy tên ảnh từ cơ sở dữ liệu
                    string hinhAnh = reader["HinhAnh"].ToString();

                    // Đóng kết nối sau khi lấy được thông tin ảnh
                    reader.Close();

                    // Đường dẫn đến thư mục chứa ảnh (có thể thay đổi theo cấu trúc hệ thống)
                    string folderPath = HttpContext.Current.Server.MapPath("~/admin/");

                    // Xóa các ảnh nếu chúng tồn tại trong thư mục
                    if (!string.IsNullOrEmpty(hinhAnh) && File.Exists(Path.Combine(folderPath, hinhAnh)))
                    {
                        File.Delete(Path.Combine(folderPath, hinhAnh));
                    }

                    // Xóa sản phẩm khỏi cơ sở dữ liệu
                    string deleteSql = "DELETE FROM tbl_khuyenmai WHERE MaKhuyenMai = @MaKhuyenMai";
                    SqlCommand deleteCmd = new SqlCommand(deleteSql, conn.SQLConn);
                    deleteCmd.Parameters.AddWithValue("@MaKhuyenMai", makm);
                    deleteCmd.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("Khuyến mãi không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa khuyến mãi: " + ex.Message);
            }
            finally
            {
                // Đảm bảo kết nối được đóng lại dù có lỗi hay không
                conn.dongKetNoi();
            }
        }

        public List<khuyenmaii> layThongTinKM()
        {
            List<khuyenmaii> dsKhuyenMai = new List<khuyenmaii>();

            try
            {
                conn.moKetNoi();
                string sql = "SELECT * FROM tbl_khuyenmai";
                SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    khuyenmaii km = new khuyenmaii();
                    {
                        km.MaKhuyenMai = reader["MaKhuyenMai"].ToString();
                        km.TenKhuyenMai = reader["TenKhuyenMai"].ToString();
                        km.MoTa = reader["MoTa"].ToString();
                        km.NgayBatDau = reader["NgayBatDau"].ToString();
                        km.NgayKetThuc = reader["NgayKetThuc"].ToString();
                        km.MucGiamGia = reader["MucGiamGia"].ToString();
                        km.HinhAnh = reader["HinhAnh"].ToString();
                    };
                    // Kiểm tra giá trị của HinhAnh1
                    Console.WriteLine("HinhAnh: " + km.HinhAnh); // Đảm bảo HinhAnh có giá trị
                    dsKhuyenMai.Add(km);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin sản phẩm: " + ex.Message);
            }
            finally
            {
                conn.dongKetNoi();
            }

            return dsKhuyenMai;
        }
        public decimal layMucGiamGia(string maKM)
        {
            conn.moKetNoi(); // Mở kết nối SQL
            string sql = @"select MucGiamGia from tbl_khuyenmai where MaKhuyenMai=@makm";
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            cmd.Parameters.AddWithValue("@makm", maKM);

            // Sử dụng ExecuteScalar để lấy giá trị đầu tiên trong kết quả truy vấn
            object result = cmd.ExecuteScalar();

            // Kiểm tra nếu không có kết quả trả về thì mặc định giá trị là 0
            if (result == null || result == DBNull.Value)
            {
                return 0;
            }

            // Chuyển đổi kết quả sang kiểu decimal và trả về
            return Convert.ToDecimal(result);
        }

    }
}
