using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.dataBaseAccess;
namespace index.admin
{
    
    public partial class giohang : System.Web.UI.Page
    {
        cartDatabase cart = new cartDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            cart.hienThiGioHang(tbl_giohang);
        }
    }
}