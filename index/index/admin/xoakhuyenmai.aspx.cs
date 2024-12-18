using index.dataBaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace index.admin
{
    public partial class xoakhuyenmai : System.Web.UI.Page
    {
        khuyenmaisql kmsql = new khuyenmaisql();
        protected void Page_Load(object sender, EventArgs e)
        {
            string makm = Request.QueryString["khuyenmai"];
            kmsql.xoaKhuyenMai(makm);
            Response.Redirect("khuyenmai.aspx");
        }
    }
}