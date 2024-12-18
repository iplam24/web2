using index.cs_basic;
using index.cs_sql;
using index.dataBaseAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace index
{
    public partial class trangchu : System.Web.UI.Page
    {

        sanphamsql spsql = new sanphamsql();
        userAccount usa= new userAccount();
        protected void Page_Load(object sender, EventArgs e)
        {
            sanpham sp = new sanpham();

            if (!IsPostBack)
            {
                LoadProducts();


            }
            if (Session["dangnhap"] != null)
            {
                int vtro = usa.layvaitro(Session["dangnhap"].ToString());
                if (vtro == 1)
                {
                    btn_admin.Visible = true;
                }
                else
                {
                    btn_admin.Visible = false;
                }
            }
            else
            {
                btn_admin.Visible=false;
               
            }
            

        }
        private void LoadProducts()
        {
            // Lấy danh sách sản phẩm
            List<sanpham> products = spsql.layThongTinSP();

            // Phân loại sản phẩm
            var dienThoai = products.Where(p => {
                int phanLoai;
                return int.TryParse(p.PhanLoai, out phanLoai) && phanLoai == 1;
            }).Take(6).ToList();

            var laptops = products.Where(p => {
                int phanLoai;
                return int.TryParse(p.PhanLoai, out phanLoai) && phanLoai == 2;
            }).Take(6).ToList();

            var phuKien = products.Where(p => {
                int phanLoai;
                return int.TryParse(p.PhanLoai, out phanLoai) && phanLoai == 3;
            }).Take(6).ToList();

            // Liên kết dữ liệu vào từng Repeater
            RepeaterPhones.DataSource = dienThoai;
            RepeaterPhones.DataBind();

            RepeaterLaptops.DataSource = laptops;
            RepeaterLaptops.DataBind();

            RepeaterAccessories.DataSource = phuKien;
            RepeaterAccessories.DataBind();
        }

        protected void btnAddToCart_Command(object sender, CommandEventArgs e)
        {
            string maSP = e.CommandArgument.ToString();
            string taiKhoan = Session["dangnhap"]?.ToString();
            int soLuong = 1; // Hoặc lấy từ một ô nhập số lượng nếu có
           decimal giaban = spsql.layGiaSanPham(maSP);
            if (!string.IsNullOrEmpty(taiKhoan))
            {
                spsql.themVaoGioHang(taiKhoan, maSP, soLuong,giaban);
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

        protected void btn_admin_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin/admin.aspx");
        }
    }

}
