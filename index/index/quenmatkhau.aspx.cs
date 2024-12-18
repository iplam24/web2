using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.dataBaseAccess;

namespace index
{
    public partial class quenmatkhau : System.Web.UI.Page
    {
        userAccount usa=new userAccount();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLayLaiMatKhau_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            // Kiểm tra email có tồn tại trong cơ sở dữ liệu không
            if (usa.kiemTraEmail(email)) // usa.kiemTraEmail là hàm kiểm tra email
            {
                // Tạo mã xác nhận hoặc liên kết đặt lại mật khẩu
                string maXacNhan = Guid.NewGuid().ToString();
                usa.luuMaXacNhan(email, maXacNhan); // Lưu mã xác nhận vào DB

                // Gửi email xác nhận
                string noiDungEmail = $"Click vào liên kết sau để đặt lại mật khẩu: " +
                                     $"https://localhost:44314/datlaimatkhau.aspx?email={email}&code={maXacNhan}";
                usa.guiEmail(email, "Lấy lại mật khẩu", noiDungEmail);

                lblThongBao.Text = "Vui lòng kiểm tra email để đặt lại mật khẩu.";
                lblThongBao.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblThongBao.Text = "Email không tồn tại!";
            }
        }
    }
}