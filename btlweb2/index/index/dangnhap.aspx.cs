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

                    HttpCookie ck = Request.Cookies["username"];
                    if (ck == null)
                    {
                        ck = new HttpCookie("username");
                    }
                    ck.Value = txtusername.Text.Trim();
                    ck.Expires = DateTime.Now.AddDays(1);
                    ck.Secure = Request.IsSecureConnection;  // Chỉ gửi cookie qua HTTPS
                    ck.HttpOnly = true;  // Không thể truy cập cookie từ JavaScript
                    ck.SameSite = SameSiteMode.Strict;  // Chỉ gửi cookie trong cùng domain
                    Response.Cookies.Add(ck);
                    Session["dangnhap"] = taikhoan;
                    Response.Redirect("~/admin/admin.aspx");
                }
                else
                {

                    HttpCookie ck = Request.Cookies["username"];
                    if (ck == null)
                    {
                        ck = new HttpCookie("username");
                    }
                    ck.Value = txtusername.Text.Trim();
                    ck.Expires = DateTime.Now.AddDays(1);
                    ck.Secure = Request.IsSecureConnection;  // Chỉ gửi cookie qua HTTPS
                    ck.HttpOnly = true;  // Không thể truy cập cookie từ JavaScript
                    ck.SameSite = SameSiteMode.Strict;  // Chỉ gửi cookie trong cùng domain
                    Response.Cookies.Add(ck);
                    Session["dangnhap"] = taikhoan;
                    Response.Redirect("default.aspx");
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