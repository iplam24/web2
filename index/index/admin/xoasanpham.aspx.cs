using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.cs_sql;
namespace index.admin
{
    
    public partial class xoasanpham : System.Web.UI.Page
    {
    
        sanphamsql spsql = new sanphamsql();
        protected void Page_Load(object sender, EventArgs e)
        {
            string masp = Request.QueryString["masp"];
            spsql.xoaSanPham(masp);
            Response.Redirect("sanpham.aspx");
        }
    }
}