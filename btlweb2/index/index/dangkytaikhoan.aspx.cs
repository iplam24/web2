using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.dataBaseAccess;
namespace index
{
    public partial class dangkytaikhoan : System.Web.UI.Page
    {
        userAccount usa= new userAccount();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btndangky_Click(object sender, EventArgs e)
        {
            string taikhoan = txtusername.Text.Trim();
            string matkhau = txtmatkhau.Text.Trim();
            string nhaplai = txtnhaplai.Text.Trim();
            string email = txtemail.Text.Trim();

            // Kiểm tra nếu các trường nhập liệu không rỗng hoặc null
            if (string.IsNullOrEmpty(taikhoan) || string.IsNullOrEmpty(matkhau) || string.IsNullOrEmpty(nhaplai) || string.IsNullOrEmpty(email))
            {
                lbl_thongbao.Text = "Vui lòng nhập đầy đủ thông tin";
            }
            else
            {
                if (matkhau == nhaplai)
                {
                    bool check = usa.KiemTraTaiKhoanTonTai(taikhoan);
                    if (check)
                    {
                        lbl_thongbao.Text = "Tài khoản đã tồn tại trong hệ thống!";
                    }
                    else
                    {
                        
                        usa.themtaikhoan(taikhoan, matkhau, email);
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Đăng ký thành công!');", true);
                        // Đảm bảo sẽ redirect sau khi thông báo alert hiển thị
                        Response.Redirect("dangnhap.aspx");
                    }
                }
                else
                {
                    lbl_thongbao.Text = "Mật khẩu không khớp!";
                }
            }

        }

    }

    }
    
