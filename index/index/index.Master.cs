using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.cs_basic;
using index.cs_sql;
using index.dataBaseAccess;
namespace index
{
    public partial class index : System.Web.UI.MasterPage
    {

        userAccount usa = new userAccount();
        sanphamsql spsql= new sanphamsql();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dangnhap"] != null)
            {
               
                Hyperdangxuat.Visible = true;
                Hyperdangxuat.NavigateUrl = "dangxuat.aspx";
            }
            else 
            {
                
                Hyperdangxuat.Text = "Đăng nhập";
                Hyperdangxuat.NavigateUrl = "dangnhap.aspx";
            }
            txt_timkiem.Attributes.Add("placeholder", "Tìm kiếm sản phẩm......");
        }

        protected void btn_timkiem_Click(object sender, EventArgs e)
        {
            string timkiem = txt_timkiem.Text.Trim(); 
            List<sanpham> dssp= spsql.timKiemSanPham(timkiem);
            Session["dssp"]= dssp;
            Response.Redirect("danhsachsanpham.aspx");
        }
    }
}