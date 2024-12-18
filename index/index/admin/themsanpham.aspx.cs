using index.cs_basic;
using index.cs_sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace index.admin
{
    public partial class adminn : System.Web.UI.Page
    {
        sanphamsql spsql = new sanphamsql();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Chỉ thực hiện khi tải lần đầu
            {
               
                
            }
        }



        protected void btn_luu_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các TextBox
            string ma = txtMaSP.Text.Trim();
            string ten = txtTenSP.Text.Trim();
            string hangSX = txtHangSX.Text.Trim();
            string ngayPH = txtNgayPH.Text.Trim();
            string kichThuoc = txtKichThuoc.Text.Trim();
            string chip = txtChip.Text.Trim();
            string ram = txtRam.Text.Trim();
            string boNho = txtBoNho.Text.Trim();
            string dungLuong = txtDungLuong.Text.Trim();
            string os = txtOS.Text.Trim();
            string trongLuong = txtTrongLuong.Text.Trim();
            string giaNhap = txtGiaNhap.Text.Trim();
            string giaBan = txtGiaBan.Text.Trim();
            string mauSac = txtMauSac.Text.Trim();
            string mota = txtMota.Text.Trim();
            String phanloai = txtPhanLoai.Text.Trim();
            // Khai báo và gán giá trị cho các ảnh
            string anh1 ="", anh2 ="", anh3 = "";

            // Kiểm tra và lưu ảnh vào thư mục
            string folderPath = Server.MapPath("~/admin/imgprd");  // Đảm bảo thư mục tồn tại

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath); // Tạo thư mục nếu không tồn tại
            }

            // Lưu ảnh 1
            if (file_up1.HasFile)
            {
               

                // Lưu ảnh mới
                anh1 = "imgprd/" + file_up1.FileName;
                string filepath1 = Path.Combine(folderPath, file_up1.FileName);
                file_up1.SaveAs(filepath1);
            }

            // Lưu ảnh 2
            if (file_up2.HasFile)
            {
               

                // Lưu ảnh mới
                anh2 = "imgprd/" + file_up2.FileName;
                string filepath2 = Path.Combine(folderPath, file_up2.FileName);
                file_up2.SaveAs(filepath2);
            }

            // Lưu ảnh 3
            if (file_up3.HasFile)
            {
                
               

                // Lưu ảnh mới
                anh3 = "imgprd/" + file_up3.FileName;
                string filepath3 = Path.Combine(folderPath, file_up3.FileName);
                file_up3.SaveAs(filepath3);
            }

            // Tạo đối tượng sanpham
            sanpham sp = new sanpham
            {
                MaSP = ma,
                TenSP = ten,
                TenHang = hangSX,
                NgayPhatHanh = ngayPH,
                KichThuocMan = kichThuoc,
                Chip = chip,
                Ram = ram,
                BoNho = boNho,
                DungLuongPin = dungLuong,
                HeDieuHanh = os,
                TrongLuong = trongLuong,
                GiaNhap = giaNhap,
                GiaBan = giaBan,
                MauSac = mauSac,
                MoTa = mota,
                HinhAnh1 = anh1,
                HinhAnh2 = anh2,
                HinhAnh3 = anh3,
                PhanLoai=phanloai
            };

            // Gọi phương thức themSanPham với đối tượng sanpham
            spsql.themSanPham(sp);

            // Thông báo thành công
            Response.Write("<script>alert('Sản phẩm đã được thêm thành công!');</script>");
            Response.Redirect("sanpham.aspx");
        }

    }
}