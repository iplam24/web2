using index.dataBaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace index.admin
{
    public partial class xoagiohang : System.Web.UI.Page
    {
        cartDatabase cs = new cartDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            string magh = Request.QueryString["taikhoan"];
            cs.xoaGioHangt(magh);
            Response.Redirect("giohang.aspx");
        }
    }
}