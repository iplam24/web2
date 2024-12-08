using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.dataBaseAccess;
namespace index
{
    public partial class dangnhap : System.Web.UI.Page
    {
        userAccount usa = new userAccount();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string taikhoan=txtusername.Text.Trim();
            string matkhau=txtpassword.Text.Trim();
            bool dangnhap=usa.dangnhap(taikhoan, matkhau);
            if (dangnhap) 
            {
                int vtro = usa.layvaitro(taikhoan);
                if (vtro == 1) 
                {
                    Session["dangnhap"] = taikhoan;
                    Response.Redirect("~/admin/admin.aspx");
                }
                else
                {
                    Session["dangnhap"] = taikhoan;
                    Response.Redirect("trangchu.aspx");
                }
            }
            else
            {
                txtthongbao.Text = "Tài khoản hoặc mật khẩu không chính xác!";
                txtusername.Focus();
            }
        }
    }
}