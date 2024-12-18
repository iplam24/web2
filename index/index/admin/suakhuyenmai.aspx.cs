using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.dataBaseAccess;
using index.cs_basic;
using System.Data.SqlClient;
using System.IO;


namespace index.admin
{
    public partial class suakhuyenmai : System.Web.UI.Page
    {
        khuyenmaisql kmsql = new khuyenmaisql();
        khuyenmaii km = new khuyenmaii();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                if (Request.QueryString["makm"] != null)
                {
                    string maKhuyenMai = Request.QueryString["makm"];
                    
                    LoadKM(maKhuyenMai);
                }
            }
        }
        // Hàm hiển thị thông tin khuyến mãi vào các TextBox
        private void LoadKM(string maKM)
        {
            // Lấy thông tin sản phẩm từ cơ sở dữ liệu dựa trên Makm
           
            
            khuyenmaii km=  kmsql.LayKM(maKM);
            // Gán giá trị vào các TextBox
            txtMaKM.Text = km.MaKhuyenMai;
            txtTenKM.Text = km.TenKhuyenMai;
            txtMoTa.Text=km.MoTa;
            txtNgayBD.Text=km.NgayBatDau;
            txtNgayKT.Text = km.NgayKetThuc;
            txtMucGG.Text = km.MucGiamGia;
            // Nếu có ảnh, bạn có thể hiển thị lên Label
            labelAnh.Text = "<img src='" + km.HinhAnh + "'>";
            txtAnh.Text = km.HinhAnh;
        }

        protected void btn_luu_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng khuyến mãi mới và gán thông tin từ các TextBox
            khuyenmaii km = new khuyenmaii();
            km.MaKhuyenMai=txtMaKM.Text.Trim();
            km.TenKhuyenMai= txtTenKM.Text.Trim();
            km.MoTa=txtMoTa.Text.Trim();
            km.NgayBatDau=txtNgayBD.Text.Trim();
            km.NgayKetThuc=txtNgayKT.Text.Trim();
            km.MucGiamGia=txtMucGG.Text.Trim();
            string folderPath = Server.MapPath("~/admin/imgprd");  // Đảm bảo thư mục tồn tại
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath); // Tạo thư mục nếu không tồn tại
            }

            // Kiểm tra và lưu ảnh 1
            if (file_up1.HasFile)
            {

                string oldfile = txtAnh.Text.Trim();

                string oldFilePath = HttpContext.Current.Server.MapPath("~/admin/");
                if (!string.IsNullOrEmpty(oldfile) && File.Exists(Path.Combine(oldFilePath, oldfile)))
                {
                    File.Delete(Path.Combine(oldFilePath, oldfile));
                }


                // Lưu ảnh mới
                km.HinhAnh = "imgprd/" + file_up1.FileName;
                string filepath1 = Path.Combine(folderPath, file_up1.FileName);
                file_up1.SaveAs(filepath1);
            }
            else
            {
                // Nếu không chọn ảnh mới, giữ nguyên ảnh cũ
                km.HinhAnh = txtAnh.Text;
            }

            kmsql.SuaKhuyenMai(km);
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