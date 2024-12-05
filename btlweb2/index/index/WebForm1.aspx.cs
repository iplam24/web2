using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.cs_sql;
using index.cs_basic;

namespace index
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        sanphamsql spsql = new sanphamsql();
        string hinhanh = "";
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



    }
}