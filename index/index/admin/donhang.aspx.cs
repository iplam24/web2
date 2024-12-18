using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.dataBaseAccess;
namespace index.admin
{
    public partial class donhang : System.Web.UI.Page
    {
        donhangsql dhsql = new donhangsql();
        protected void Page_Load(object sender, EventArgs e)
        {
            dhsql.hienThidonhang(tbl_donhang);
        }
    }
}