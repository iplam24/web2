using index.cs_basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.dataBaseAccess;
namespace index
{
    public partial class khuyenmai : System.Web.UI.Page
    {
        khuyenmaisql kmsql = new khuyenmaisql();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadKhuyenMai();
        }
        private void LoadKhuyenMai()
        {
            // Lấy danh sách khuyến mãi
            List<khuyenmaii> kms = kmsql.layThongTinKM();

            // Liên kết dữ liệu vào từng Repeater
            repeaterKM.DataSource = kms;
            repeaterKM.DataBind();
        }
    }
}