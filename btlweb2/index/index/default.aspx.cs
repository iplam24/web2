using index.cs_basic;
using index.cs_sql;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            sanpham sp = new sanpham();

            if (!IsPostBack)
            {
                LoadProducts();


            }

        }
        private void LoadProducts()
        {
            // Lấy danh sách sản phẩm
            List<sanpham> products = spsql.layThongTinSP();

            // Tạo danh sách để chứa các hình ảnh
            List<string> hinhanh = new List<string>();

            // Duyệt qua từng sản phẩm và lấy hình ảnh
            foreach (var product in products)
            {
                // Kiểm tra xem HinhAnh1 có dữ liệu không
                if (!string.IsNullOrEmpty(product.HinhAnh1))
                {
                    hinhanh.Add(product.HinhAnh1);
                }
            }
            var featuredProducts = products.Take(12).ToList();

            // Liên kết dữ liệu vào Repeater
            RepeaterProducts.DataSource = featuredProducts;
            RepeaterProducts.DataBind();

            // Nếu bạn muốn sử dụng 'hinhanh' ở đâu đó sau này, bạn đã có danh sách các hình ảnh
            // Ví dụ, in ra danh sách hình ảnh
            foreach (var img in hinhanh)
            {
                Console.WriteLine(img);  // In ra đường dẫn hình ảnh
            }
        }
        protected void btnAddToCart_Command(object sender, CommandEventArgs e)
        {
            string maSP = e.CommandArgument.ToString();
            string taiKhoan = Session["dangnhap"]?.ToString();
            int soLuong = 1; // Hoặc lấy từ một ô nhập số lượng nếu có

            if (!string.IsNullOrEmpty(taiKhoan))
            {
                spsql.themVaoGioHang(taiKhoan, maSP, soLuong);
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
