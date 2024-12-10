using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.dataBaseAccess;
namespace index
{
    public partial class hienthigiohang : System.Web.UI.Page
    {
        cartDatabase cart = new cartDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dangnhap"] != null)
            {
                cart.hienThiGioHang(RepeaterCart);
            }
            else
            {
                Response.Redirect("dangnhap.aspx?reason=cart&redirect=hienthigiohang.aspx");

            }
        }
    }
}