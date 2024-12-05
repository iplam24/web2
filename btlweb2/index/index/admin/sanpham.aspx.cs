using index.cs_sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace index.admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        sanphamsql sanphamsql = new sanphamsql();
        protected void Page_Load(object sender, EventArgs e)
        {
            sanphamsql.hienThiSanPham(tbl_sanpham);
        }
    }
}