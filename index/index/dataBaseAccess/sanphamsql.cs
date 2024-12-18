using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using index.cs_basic;
using System.IO;


namespace index.cs_sql
{

    
    public class sanphamsql
    {
        connect conn = new connect();

        public void hienThiSanPham(Table tbl_sanpham)
        {
            conn.moKetNoi();
            string sql = "select * from tbl_sanpham";
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            SqlDataReader reader = cmd.ExecuteReader();
            int j = 1;
            while (reader.Read()) 
            { 
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                cell.Text=j.ToString();
                row.Cells.Add(cell);
                for (int i = 0; i < 19; i++) 
                { 
                    TableCell c = new TableCell();
                    if (i == 15)  
                    {
                        c.Text = "<img src='"+reader[i].ToString()+"'>";
                    }
                    else if (i == 16)
                    {
                        c.Text = "<img src='" + reader[i].ToString() + "'>";
                    }
                    else if (i == 17)
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
                cll.Text="<a href='suasanpham.aspx?masp="+reader[0].ToString()+"'> Sửa </a>";
                cll.Text += "<a href='javascript:void(0);' onclick=\"if(confirm('Bạn có chắc chắn muốn xóa sản phẩm này?')) { window.location.href='xoasanpham.aspx?masp=" + reader[0].ToString() + "'; }\"> Xóa </a>";


                row.Cells.Add(cll);
                tbl_sanpham.Rows.Add(row);
                j++;
            }
        }

        public List<sanpham> layThongTinSP()
        {
            List<sanpham> dsSanPham = new List<sanpham>();

            try
            {
                conn.moKetNoi();
                string sql = "SELECT * FROM tbl_sanpham";
                SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    sanpham product = new sanpham
                    {
                        MaSP = reader["MaSP"].ToString(),
                        TenSP = reader["TenSP"].ToString(),
                        TenHang = reader["TenHang"].ToString(),
                        NgayPhatHanh = reader["NgayPhatHanh"].ToString(),
                        KichThuocMan = reader["KichThuocMan"].ToString(),
                        Chip = reader["Chip"].ToString(),
                        Ram = reader["Ram"].ToString(),
                        BoNho = reader["BoNho"].ToString(),
                        DungLuongPin = reader["DungLuongPin"].ToString(),
                        HeDieuHanh = reader["HeDieuHanh"].ToString(),
                        TrongLuong = reader["TrongLuong"].ToString(),
                        GiaNhap = reader["GiaNhap"].ToString(),
                        GiaBan = reader["GiaBan"].ToString(),
                        MauSac = reader["MauSac"].ToString(),
                        MoTa = reader["MoTa"].ToString(),
                        HinhAnh1 = reader["HinhAnh1"].ToString(),
                        HinhAnh2 = reader["HinhAnh2"].ToString(),
                        HinhAnh3 = reader["HinhAnh3"].ToString(),
                        PhanLoai = reader["PhanLoai"].ToString()    
                    };
                    // Kiểm tra giá trị của HinhAnh1
                    Console.WriteLine("HinhAnh1: " + product.HinhAnh1); // Đảm bảo HinhAnh1 có giá trị
                    dsSanPham.Add(product);
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

            return dsSanPham;
        }

        public void themSanPham(sanpham sp)
        {

            conn.moKetNoi();
            string sql = "INSERT INTO tbl_sanpham VALUES (@MaSP, @TenSP, @TenHang, @NgayPhatHanh, @KichThuocMan, @Chip, @Ram, @BoNho, @DungLuongPin, @HeDieuHanh, @TrongLuong, @GiaNhap, @GiaBan, @MauSac, @MoTa, @Anh1, @Anh2, @Anh3,@loai)";
            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            

            cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
            cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
            cmd.Parameters.AddWithValue("@TenHang", sp.TenHang);
            cmd.Parameters.AddWithValue("@NgayPhatHanh", sp.NgayPhatHanh);
            cmd.Parameters.AddWithValue("@KichThuocMan", sp.KichThuocMan);
            cmd.Parameters.AddWithValue("@Chip", sp.Chip);
            cmd.Parameters.AddWithValue("@Ram", sp.Ram);
            cmd.Parameters.AddWithValue("@BoNho", sp.BoNho);
            cmd.Parameters.AddWithValue("@DungLuongPin", sp.DungLuongPin);
            cmd.Parameters.AddWithValue("@HeDieuHanh", sp.HeDieuHanh);
            cmd.Parameters.AddWithValue("@TrongLuong", sp.TrongLuong);
            cmd.Parameters.AddWithValue("@GiaNhap", sp.GiaNhap);
            cmd.Parameters.AddWithValue("@GiaBan", sp.GiaBan);
            cmd.Parameters.AddWithValue("@MauSac", sp.MauSac);
            cmd.Parameters.AddWithValue("@MoTa", sp.MoTa);
            cmd.Parameters.AddWithValue("@Anh1", sp.HinhAnh1);
            cmd.Parameters.AddWithValue("@Anh2", sp.HinhAnh2);
            cmd.Parameters.AddWithValue("@Anh3", sp.HinhAnh3);
            cmd.Parameters.AddWithValue("@loai", sp.PhanLoai);
            cmd.ExecuteNonQuery();
        }
        public sanpham LaySanPhamTheoMa(string maSP)
        {
            
            sanpham sp = new sanpham();
            conn.moKetNoi();
            string sql = "SELECT * FROM tbl_sanpham WHERE MaSP =@maSP ";

            SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
            cmd.Parameters.AddWithValue("@MaSP", maSP);

          
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    sp.MaSP = reader["MaSP"].ToString();
                    sp.TenSP = reader["TenSP"].ToString();
                    sp.TenHang = reader["TenHang"].ToString();
                    sp.NgayPhatHanh = reader["NgayPhatHanh"].ToString();
                    sp.KichThuocMan = reader["KichThuocMan"].ToString();
                    sp.Chip = reader["Chip"].ToString();
                    sp.Ram = reader["Ram"].ToString();
                    sp.BoNho = reader["BoNho"].ToString();
                    sp.DungLuongPin = reader["DungLuongPin"].ToString();
                    sp.HeDieuHanh = reader["HeDieuHanh"].ToString();
                    sp.TrongLuong = reader["TrongLuong"].ToString();
                    sp.GiaNhap = reader["GiaNhap"].ToString();
                    sp.GiaBan = reader["GiaBan"].ToString();
                    sp.MauSac = reader["MauSac"].ToString();
                    sp.MoTa = reader["MoTa"].ToString();
                    sp.HinhAnh1 = reader["HinhAnh1"].ToString();
                    sp.HinhAnh2 = reader["HinhAnh2"].ToString();
                    sp.HinhAnh3 = reader["HinhAnh3"].ToString();
                    sp.PhanLoai = reader["PhanLoai"].ToString();
                }
            }
            
            return sp;
        }
        public void suaSanPham(sanpham sp)
        {
            conn.moKetNoi();

            // Câu truy vấn UPDATE
            string query = "UPDATE tbl_sanpham SET " +
                    "TenSP = @ten, " +
                    "TenHang = @hang, " +
                    "NgayPhatHanh = @ngayph, " +
                    "KichThuocMan = @kichthuoc, " +
                    "Chip = @chip, " +
                    "Ram = @ram, " +
                    "BoNho = @rom, " +
                    "DungLuongPin = @pin, " +
                    "HeDieuHanh = @hedieuhanh, " +
                    "TrongLuong = @trongluong, " +
                    "GiaNhap = @gianhap, " +
                    "GiaBan = @giaban, " +
                    "MauSac = @mausac, " +
                    "MoTa = @mota, " +
                    "HinhAnh1 = @anh1, " +
                    "HinhAnh2 = @anh2, " +
                    "HinhAnh3 = @anh3, " +
                    "PhanLoai = @loai " +
                    "WHERE MaSP = @ma";

            SqlCommand cmd = new SqlCommand(query, conn.SQLConn);
            cmd.Parameters.AddWithValue("@ma", sp.MaSP);
            cmd.Parameters.AddWithValue("@ten", sp.TenSP);
            cmd.Parameters.AddWithValue("@hang", sp.TenHang);
            cmd.Parameters.AddWithValue("@ngayph", sp.NgayPhatHanh);
            cmd.Parameters.AddWithValue("@kichthuoc", sp.KichThuocMan);
            cmd.Parameters.AddWithValue("@chip", sp.Chip);
            cmd.Parameters.AddWithValue("@ram", sp.Ram);
            cmd.Parameters.AddWithValue("@rom", sp.BoNho);
            cmd.Parameters.AddWithValue("@pin", sp.DungLuongPin);
            cmd.Parameters.AddWithValue("@hedieuhanh", sp.HeDieuHanh);
            cmd.Parameters.AddWithValue("@trongluong", sp.TrongLuong);
            cmd.Parameters.AddWithValue("@gianhap", sp.GiaNhap);
            cmd.Parameters.AddWithValue("@giaban", sp.GiaBan);
            cmd.Parameters.AddWithValue("@mausac", sp.MauSac);
            cmd.Parameters.AddWithValue("@mota", sp.MoTa);

            // Kiểm tra và chỉ thêm tham số ảnh nếu có file ảnh mới
            cmd.Parameters.AddWithValue("@anh1", string.IsNullOrEmpty(sp.HinhAnh1) ? (object)DBNull.Value : sp.HinhAnh1);
            cmd.Parameters.AddWithValue("@anh2", string.IsNullOrEmpty(sp.HinhAnh2) ? (object)DBNull.Value : sp.HinhAnh2);
            cmd.Parameters.AddWithValue("@anh3", string.IsNullOrEmpty(sp.HinhAnh3) ? (object)DBNull.Value : sp.HinhAnh3);
            cmd.Parameters.AddWithValue("@loai", sp.PhanLoai);

            // Thực thi câu lệnh SQL
            cmd.ExecuteNonQuery();

            conn.dongKetNoi();
        }


        public void xoaSanPham(string masp)
        {
            try
            {
                // Mở kết nối đến cơ sở dữ liệu
                conn.moKetNoi();

                // Truy vấn SQL để lấy thông tin các hình ảnh của sản phẩm cần xóa
                string sql = "SELECT HinhAnh1, HinhAnh2, HinhAnh3 FROM tbl_sanpham WHERE MaSP = @maSP";

                SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
                cmd.Parameters.AddWithValue("@maSP", masp);

                SqlDataReader reader = cmd.ExecuteReader();

                // Kiểm tra nếu sản phẩm tồn tại trong cơ sở dữ liệu
                if (reader.HasRows)
                {
                    reader.Read(); // Đọc một bản ghi

                    // Lấy tên ảnh từ cơ sở dữ liệu
                    string hinhAnh1 = reader["HinhAnh1"].ToString();
                    string hinhAnh2 = reader["HinhAnh2"].ToString();
                    string hinhAnh3 = reader["HinhAnh3"].ToString();

                    // Đóng kết nối sau khi lấy được thông tin ảnh
                    reader.Close();

                    // Đường dẫn đến thư mục chứa ảnh (có thể thay đổi theo cấu trúc hệ thống)
                    string folderPath = HttpContext.Current.Server.MapPath("~/admin/");

                    // Xóa các ảnh nếu chúng tồn tại trong thư mục
                    if (!string.IsNullOrEmpty(hinhAnh1) && File.Exists(Path.Combine(folderPath, hinhAnh1)))
                    {
                        File.Delete(Path.Combine(folderPath, hinhAnh1));
                    }

                    if (!string.IsNullOrEmpty(hinhAnh2) && File.Exists(Path.Combine(folderPath, hinhAnh2)))
                    {
                        File.Delete(Path.Combine(folderPath, hinhAnh2));
                    }

                    if (!string.IsNullOrEmpty(hinhAnh3) && File.Exists(Path.Combine(folderPath, hinhAnh3)))
                    {
                        File.Delete(Path.Combine(folderPath, hinhAnh3));
                    }

                    // Xóa sản phẩm khỏi cơ sở dữ liệu
                    string deleteSql = "DELETE FROM tbl_sanpham WHERE MaSP = @maSP";
                    SqlCommand deleteCmd = new SqlCommand(deleteSql, conn.SQLConn);
                    deleteCmd.Parameters.AddWithValue("@maSP", masp);
                    deleteCmd.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("Sản phẩm không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa sản phẩm: " + ex.Message);
            }
            finally
            {
                // Đảm bảo kết nối được đóng lại dù có lỗi hay không
                conn.dongKetNoi();
            }
        }
        public void themVaoGioHang(string taiKhoan, string maSP, int soLuong,decimal GiaBan)
        {
            try
            {
                conn.moKetNoi();

                // Kiểm tra nếu sản phẩm đã có trong giỏ hàng của người dùng chưa
                string checkSql = "SELECT COUNT(*) FROM tbl_giohang WHERE TaiKhoan = @TaiKhoan AND MaSP = @MaSP";
                SqlCommand checkCmd = new SqlCommand(checkSql, conn.SQLConn);
                checkCmd.Parameters.AddWithValue("@TaiKhoan", taiKhoan);
                checkCmd.Parameters.AddWithValue("@MaSP", maSP);
                int count = (int)checkCmd.ExecuteScalar();

                if (count > 0)
                {
                    // Nếu đã có trong giỏ hàng, cập nhật số lượng
                    string updateSql = "UPDATE tbl_giohang SET SoLuong = SoLuong + @SoLuong WHERE TaiKhoan = @TaiKhoan AND MaSP = @MaSP";
                    SqlCommand updateCmd = new SqlCommand(updateSql, conn.SQLConn);
                    updateCmd.Parameters.AddWithValue("@TaiKhoan", taiKhoan);
                    updateCmd.Parameters.AddWithValue("@MaSP", maSP);
                    updateCmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    // Nếu chưa có trong giỏ hàng, thêm mới
                    string insertSql = "INSERT INTO tbl_giohang (TaiKhoan, MaSP, SoLuong, NgayThem,GiaBan) VALUES (@TaiKhoan, @MaSP, @SoLuong, @NgayThem,@GiaBan)";
                    SqlCommand insertCmd = new SqlCommand(insertSql, conn.SQLConn);
                    insertCmd.Parameters.AddWithValue("@TaiKhoan", taiKhoan);
                    insertCmd.Parameters.AddWithValue("@MaSP", maSP);
                    insertCmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    insertCmd.Parameters.AddWithValue("@NgayThem", DateTime.Now);
                    insertCmd.Parameters.AddWithValue("@GiaBan",GiaBan);
                    insertCmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sản phẩm vào giỏ hàng: " + ex.Message);
            }
            finally
            {
                conn.dongKetNoi();
            }
        }
        public decimal layGiaSanPham(string maSP)
        {
            decimal giaBan = 0;

            try
            {
                conn.moKetNoi();
                string sql = "SELECT GiaBan FROM tbl_sanpham WHERE MaSP = @MaSP";
                SqlCommand cmd = new SqlCommand(sql, conn.SQLConn);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    giaBan = Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy giá sản phẩm: " + ex.Message);
            }
            finally
            {
                conn.dongKetNoi();
            }

            return giaBan;
        }


    }
}
