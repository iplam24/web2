using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
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
            if (usa.dangnhap(taikhoan, matkhau))
            {
                int vtro = usa.layvaitro(taikhoan);

                // Tạo cookie lưu thông tin đăng nhập
                SetUserCookie(taikhoan);

                // Lưu vào session
                Session["dangnhap"] = taikhoan;

                // Chuyển hướng dựa trên vai trò bằng JavaScript
                string redirectUrl = vtro == 1 ? "admin/admin.aspx" : "default.aspx";
                string script = $"<script>alert('Đăng nhập thành công! Xin chào'); window.location='{redirectUrl}';</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "AlertRedirect", script, false);
            }
            else
            {
                txtthongbao.Text = "Tài khoản hoặc mật khẩu không chính xác!";
                txtusername.Focus();
            }
        }
        private void SetUserCookie(string username)
        {
            HttpCookie ck = Request.Cookies["username"] ?? new HttpCookie("username");
            ck.Value = username;
            ck.Expires = DateTime.Now.AddDays(1);
            ck.Secure = Request.IsSecureConnection;
            ck.HttpOnly = true;
            ck.SameSite = SameSiteMode.Strict;
            Response.Cookies.Add(ck);
        }
    }
}