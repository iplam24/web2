using index.cs_basic;
using index.cs_sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace index
{
    public partial class chitietsanpham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string maSP = Request.QueryString["MaSP"];
            LoadProductDetails();

        }
        private void LoadProductDetails()
        {
            string productId = Request.QueryString["MaSP"];

            // Kết nối đến cơ sở dữ liệu
            string connectionString = @"Data Source=localhost;Initial Catalog=webqlbandt;Integrated Security=True;";
            string query = "SELECT * FROM tbl_sanpham WHERE MaSP = @MaSP";

            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            da.SelectCommand.Parameters.AddWithValue("@MaSP", productId);

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                // Truyền dữ liệu vào Repeater
                RepeaterProduct.DataSource = dt;
                RepeaterProduct.DataBind();
            }
        }
    }
}