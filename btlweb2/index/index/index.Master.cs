using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace index
{
    public partial class index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dangnhap"] != null)
            {
                txtXinChao.Text = "Xin Chào " + Session["dangnhap"];
                Hyperdangxuat.Visible = true;
                Hyperdangxuat.NavigateUrl = "dangxuat.aspx";
            }
            else 
            {
                txtXinChao.Text = "";
                Hyperdangxuat.Text = "Đăng nhập";
                Hyperdangxuat.NavigateUrl = "dangnhap.aspx";
            }
        }
    }
}