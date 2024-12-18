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
    public partial class suasanpham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string masp = Request.QueryString["masp"];
                LoadSanPham(masp);
            }
        }
        sanphamsql spsql = new sanphamsql();

        private void LoadSanPham(string maSP)
        {
            // Lấy thông tin sản phẩm từ cơ sở dữ liệu dựa trên MaSP
            sanpham sp = spsql.LaySanPhamTheoMa(maSP);

            // Gán giá trị vào các TextBox
            txtMaSP.Text = sp.MaSP;
            txtTenSP.Text = sp.TenSP;
            txtHangSX.Text = sp.TenHang;
            txtNgayPH.Text = sp.NgayPhatHanh;
            txtKichThuoc.Text = sp.KichThuocMan;
            txtChip.Text = sp.Chip;
            txtRam.Text = sp.Ram;
            txtBoNho.Text = sp.BoNho;
            txtDungLuong.Text = sp.DungLuongPin;
            txtOS.Text = sp.HeDieuHanh;
            txtTrongLuong.Text = sp.TrongLuong;
            txtGiaNhap.Text = sp.GiaNhap.ToString();
            txtGiaBan.Text = sp.GiaBan.ToString();
            txtMauSac.Text = sp.MauSac;
            txtMota.Text = sp.MoTa;
            txtAnh1.Text = sp.HinhAnh1;
            txtAnh2.Text = sp.HinhAnh2;
            txtAnh3.Text = sp.HinhAnh3;
            txtPhanLoai.Text = sp.PhanLoai;
            // Nếu có ảnh, bạn có thể hiển thị lên Label
            img1.Text = "<img src='" + sp.HinhAnh1 + "'>";
            img2.Text = "<img src='" + sp.HinhAnh2 + "'>";
            img3.Text = "<img src='" + sp.HinhAnh3 + "'>";
        }


        protected void btn_luu_Click(object sender, EventArgs e)
        {
            sanpham sp = new sanpham();
            // Gán giá trị từ các textbox vào đối tượng sanpham
            sp.MaSP = txtMaSP.Text.Trim();
            sp.TenSP = txtTenSP.Text.Trim();
            sp.TenHang = txtHangSX.Text.Trim();
            sp.NgayPhatHanh = txtNgayPH.Text.Trim();
            sp.KichThuocMan = txtKichThuoc.Text;
            sp.Chip = txtChip.Text.Trim();
            sp.Ram = txtRam.Text.Trim();
            sp.BoNho = txtBoNho.Text.Trim();
            sp.DungLuongPin = txtDungLuong.Text.Trim();
            sp.HeDieuHanh = txtOS.Text.Trim();
            sp.TrongLuong = txtTrongLuong.Text.Trim();
            sp.GiaNhap = txtGiaNhap.Text.Trim();
            sp.GiaBan = txtGiaBan.Text.Trim();
            sp.MauSac = txtMauSac.Text.Trim();
            sp.MoTa = txtMota.Text.Trim();
            sp.PhanLoai=txtPhanLoai.Text.Trim();
            string folderPath = Server.MapPath("~/admin/imgprd");  // Đảm bảo thư mục tồn tại
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath); // Tạo thư mục nếu không tồn tại
            }

            // Kiểm tra và lưu ảnh 1
            if (file_up1.HasFile)
            {

                string oldfile = txtAnh1.Text.Trim();
                
                    string oldFilePath = HttpContext.Current.Server.MapPath("~/admin/");
                    if (!string.IsNullOrEmpty(oldfile) && File.Exists(Path.Combine(oldFilePath, oldfile)))
                    {
                        File.Delete(Path.Combine(oldFilePath, oldfile));
                    }
                

                // Lưu ảnh mới
                sp.HinhAnh1 = "imgprd/" + file_up1.FileName;
                string filepath1 = Path.Combine(folderPath, file_up1.FileName);
                file_up1.SaveAs(filepath1);
            }
            else
            {
                // Nếu không chọn ảnh mới, giữ nguyên ảnh cũ
                sp.HinhAnh1 = txtAnh1.Text;
            }

            // Kiểm tra và lưu ảnh 2
            if (file_up2.HasFile)
            {
                // Xóa ảnh cũ nếu có

                string oldfile = txtAnh2.Text.Trim();

                string oldFilePath = HttpContext.Current.Server.MapPath("~/admin/");
                if (!string.IsNullOrEmpty(oldfile) && File.Exists(Path.Combine(oldFilePath, oldfile)))
                {
                    File.Delete(Path.Combine(oldFilePath, oldfile));
                }

                // Lưu ảnh mới
                sp.HinhAnh2 = "imgprd/" + file_up2.FileName;
                string filepath2 = Path.Combine(folderPath, file_up2.FileName);
                file_up2.SaveAs(filepath2);
            }
            else
            {
                // Nếu không chọn ảnh mới, giữ nguyên ảnh cũ
                sp.HinhAnh2 = txtAnh2.Text; 
            }

            // Kiểm tra và lưu ảnh 3
            if (file_up3.HasFile)
            {

                string oldfile = txtAnh3.Text.Trim();

                string oldFilePath = HttpContext.Current.Server.MapPath("~/admin/");
                if (!string.IsNullOrEmpty(oldfile) && File.Exists(Path.Combine(oldFilePath, oldfile)))
                {
                    File.Delete(Path.Combine(oldFilePath, oldfile));
                }

                // Lưu ảnh mới
                sp.HinhAnh3 = "imgprd/" + file_up3.FileName;
                string filepath3 = Path.Combine(folderPath, file_up3.FileName);
                file_up3.SaveAs(filepath3);
            }
            else
            {
                // Nếu không chọn ảnh mới, giữ nguyên ảnh cũ
                sp.HinhAnh3 = txtAnh3.Text;
            }

            // Cập nhật sản phẩm
            spsql.suaSanPham(sp);

            // Thông báo thành công
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Cập nhật sản phẩm thành công!');", true);
            Response.Redirect("sanpham.aspx");
        }


    }
}