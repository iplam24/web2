using index.dataBaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace index.admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        khuyenmaisql km = new khuyenmaisql();
        protected void Page_Load(object sender, EventArgs e)
        {
            km.HienThiKhuyenMai(tbl_khuyenmai);
        }
    }
}