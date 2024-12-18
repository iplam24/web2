using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.dataBaseAccess;
namespace index.admin
{
    public partial class xoataikhoan : System.Web.UI.Page
    {

        userAccount usa=new userAccount();
        protected void Page_Load(object sender, EventArgs e)
        {
            string taikhoan = Request.QueryString["taikhoan"];
            usa.xoaTaiKhoan(taikhoan);
            Response.Redirect("taikhoan.aspx");
        }
    }
}