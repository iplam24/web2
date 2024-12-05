using index.dataBaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace index.admin
{
    public partial class taikhoan : System.Web.UI.Page
    {
        userAccount acc = new userAccount();
        protected void Page_Load(object sender, EventArgs e)
        {
            acc.hienThiTaiKhoan(tbl_taikhoan);
        }
    }
}