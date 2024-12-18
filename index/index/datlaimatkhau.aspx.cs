using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.dataBaseAccess;
namespace index
{
    public partial class datlaimatkhau : System.Web.UI.Page
    {
        userAccount usa=new userAccount();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDatLaiMatKhau_Click(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"];
            string code = Request.QueryString["code"];

            string matKhauMoi = txtMatKhauMoi.Text.Trim();
            string xacNhanMatKhau = txtXacNhanMatKhau.Text.Trim();

            if (matKhauMoi != xacNhanMatKhau)
            {
                lblThongBao.Text = "Mật khẩu xác nhận không khớp!";
                return;
            }

            // Kiểm tra mã xác nhận có hợp lệ
            if (usa.kiemTraMaXacNhan(email, code)) // usa.kiemTraMaXacNhan kiểm tra mã và email trong DB
            {
                // Cập nhật mật khẩu mới
                usa.capNhatMatKhau(email, matKhauMoi); // Hàm cập nhật mật khẩu
                lblThongBao.Text = "Mật khẩu đã được đặt lại thành công!";
                lblThongBao.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblThongBao.Text = "Liên kết đặt lại mật khẩu không hợp lệ hoặc đã hết hạn!";
            }
        }
    }
}