using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.dataBaseAccess;
using index.cs_basic;

namespace index.admin
{
    public partial class suataikhoan : System.Web.UI.Page
    {
        userAccount userA=new userAccount();
        
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                string taikhoan = Request.QueryString["taikhoan"];
                txttaikhoan.Text = taikhoan;
                user us = userA.layTaiKhoanTheoTen(taikhoan);
                txtmatkhau.Text = us.matKhau;
                txtvaitro.Text = us.vaiTro;
                txtemail.Text=us.email;
                
            }
        }

        protected void btn_luu_Click(object sender, EventArgs e)
        {
            
            string taikhoan = txttaikhoan.Text.Trim();
            string matkhau=txtmatkhau.Text.Trim();
            string vaitro=txtvaitro.Text.Trim();
            string email=txtemail.Text.Trim();
            userA.suaTaiKhoan(taikhoan,matkhau,vaitro,email);
            Response.Redirect("taikhoan.aspx");
        }
    }
}