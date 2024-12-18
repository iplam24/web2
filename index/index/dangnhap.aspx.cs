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
            if (!IsPostBack)
            {
                string reason = Request.QueryString["reason"];
                if (reason == "cart")
                {
                    lblthongbao.Text = "Bạn cần đăng nhập để sử dụng chức năng giỏ hàng.";
                }
            }
        }

        protected void btn_dangnhap_Click(object sender, EventArgs e)
        {
            string taikhoan = txtusername.Text.Trim();
            string matkhau = txtpassword.Text.Trim();

            if (usa.dangnhap(taikhoan, matkhau))
            {
                int vtro = usa.layvaitro(taikhoan);

                // Tạo cookie lưu thông tin đăng nhập
                SetUserCookie(taikhoan);

                // Lưu vào session
                Session["dangnhap"] = taikhoan;

                // Kiểm tra nếu có redirect
                string redirectUrl = Request.QueryString["redirect"];
                if (!string.IsNullOrEmpty(redirectUrl))
                {
                    Response.Redirect(redirectUrl); // Chuyển đến trang đích
                }
                else
                {
                    // Chuyển hướng mặc định dựa vào vai trò
                    redirectUrl = vtro == 1 ? "admin/admin.aspx" : "default.aspx";
                    Response.Redirect(redirectUrl);
                }
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