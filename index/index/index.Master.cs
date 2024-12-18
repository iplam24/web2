using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.dataBaseAccess;
namespace index
{
    public partial class index : System.Web.UI.MasterPage
    {

        userAccount usa = new userAccount();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dangnhap"] != null)
            {
               
                Hyperdangxuat.Visible = true;
                Hyperdangxuat.NavigateUrl = "dangxuat.aspx";
            }
            else 
            {
                
                Hyperdangxuat.Text = "Đăng nhập";
                Hyperdangxuat.NavigateUrl = "dangnhap.aspx";
            }
            
        }
    }
}