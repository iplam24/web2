using index.cs_basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.dataBaseAccess;
using index.cs_sql;
namespace index
{
    public partial class dienthoai : System.Web.UI.Page
    {
        sanphamsql spsql = new sanphamsql();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }
        private void LoadProducts()
        {
            // Lấy danh sách sản phẩm
            List<sanpham> products = spsql.layThongTinSP();

            // Phân loại sản phẩm
            var dienThoai = products.Where(p => {
                int phanLoai;
                return int.TryParse(p.PhanLoai, out phanLoai) && phanLoai == 1;
            }).ToList();

            var laptops = products.Where(p => {
                int phanLoai;
                return int.TryParse(p.PhanLoai, out phanLoai) && phanLoai == 2;
            }).Take(12).ToList();

            var phuKien = products.Where(p => {
                int phanLoai;
                return int.TryParse(p.PhanLoai, out phanLoai) && phanLoai == 3;
            }).Take(12).ToList();

            // Liên kết dữ liệu vào từng Repeater
            RepeaterPhones.DataSource = dienThoai;
            RepeaterPhones.DataBind();

            
        }

        protected void btnAddToCart_Command(object sender, CommandEventArgs e)
        {
            string maSP = e.CommandArgument.ToString();
            string taiKhoan = Session["dangnhap"]?.ToString();
            int soLuong = 1; // Hoặc lấy từ một ô nhập số lượng nếu có
            decimal giaban = spsql.layGiaSanPham(maSP);
            if (!string.IsNullOrEmpty(taiKhoan))
            {
                spsql.themVaoGioHang(taiKhoan, maSP, soLuong, giaban);
                string script = "<script>alert('Thêm sản phẩm vào giỏ hàng thành công!');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, false);
            }
            else
            {
                string script = "<script>alert('Bạn cần đăng nhập để thêm sản phẩm vào giỏ hàng.');</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, false);
                Response.Redirect("dangnhap.aspx");
            }
        }
    }
}