using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.cs_sql;
using index.dataBaseAccess;

namespace index.admin
{
    public partial class themtaikhoan : System.Web.UI.Page
    {
        userAccount userAccount=new userAccount();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_luu_Click(object sender, EventArgs e)
        {
            string taikhoan = txttaikhoan.Text.Trim();
            string matkhau = txtmatkhau.Text.Trim();
            string email =txtemail.Text.Trim();
            userAccount.themtaikhoan(taikhoan, matkhau,email);
            Response.Write("Thêm tài khoản thành công");
            Response.Redirect("taikhoan.aspx");
           
        }
    }
}