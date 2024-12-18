using index.dataBaseAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace index.admin
{
    public partial class themkhuyenmai : System.Web.UI.Page
    {
        khuyenmaisql km = new khuyenmaisql();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_luu_Click(object sender, EventArgs e)
        {
            string MaKhuyenMai = txtMaKM.Text.Trim();
            string TenKhuyenMai = txtTenKM.Text.Trim();
            string MoTa = txtMoTa.Text.Trim();
            string NgayBatDau = txtNgayBD.Text.Trim();
            string NgayKetThuc = txtNgayKT.Text.Trim();
            string MucGiamgia = txtMucGG.Text.Trim();
            string folderPath = Server.MapPath("~/admin/imgprd");  // Đảm bảo thư mục tồn tại
            string anh = "";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath); // Tạo thư mục nếu không tồn tại
            }

            // Lưu ảnh 1
            if (file_up1.HasFile)
            {


                // Lưu ảnh mới
                anh = "imgprd/" + file_up1.FileName;
                string filepath1 = Path.Combine(folderPath, file_up1.FileName);
                file_up1.SaveAs(filepath1);
            }
            km.ThemKhuyenMai(MaKhuyenMai, TenKhuyenMai, MoTa, NgayBatDau,NgayKetThuc,MucGiamgia,anh);
            Response.Write("Thêm khuyenmai");
            Response.Redirect("khuyenmai.aspx");
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaKM.Text = "";
            txtTenKM.Text = "";
            txtMoTa.Text = "";
            txtNgayBD.Text = "";
            txtNgayKT.Text = "";
            txtMucGG.Text = "";
        }
    }
}