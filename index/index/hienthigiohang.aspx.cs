using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.dataBaseAccess;
namespace index
{
    public partial class hienthigiohang : System.Web.UI.Page
    {
        cartDatabase cart = new cartDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["dangnhap"] != null)
            {
                cart.hienThiGioHang(RepeaterCart);
                string taikhoan = Session["dangnhap"] as string;
                decimal tongTien = cart.tinhTongTien(taikhoan);

                // Gắn tổng tiền vào ViewState hoặc Label để hiển thị
                
            }
            else
            {
                Response.Redirect("dangnhap.aspx?reason=cart&redirect=hienthigiohang.aspx");

            }
        }
        protected void RepeaterCart_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer) // Chỉ xử lý khi là Footer
            {
                // Tìm Label trong FooterTemplate
                Label lblThongBao = (Label)e.Item.FindControl("lbl_thongbao");
                if (lblThongBao != null)
                {
                    // Gán tổng tiền vào Label
                    string taikhoan = Session["dangnhap"] as string;
                    decimal tongTien = cart.tinhTongTien(taikhoan);
                    lblThongBao.Text = string.Format("{0:0,0 VNĐ}", tongTien);
                }
            }
        }

        protected void btn_xoa_Click(object sender, EventArgs e)
        {
            string taikhoan = Session["dangnhap"] as string;
            // Lấy thông tin nút xóa được bấm
            Button btn = (Button)sender;

            // Lấy mã sản phẩm từ CommandArgument
            string maSP = btn.CommandArgument;
            if (string.IsNullOrEmpty(taikhoan))
            {
                // Nếu không có tài khoản trong session, có thể redirect về trang đăng nhập hoặc hiển thị thông báo lỗi
                Response.Redirect("dangnhap.aspx");
            }
            else
            {

                // Nếu có tài khoản trong session, thực hiện xóa giỏ hàng
                cart.xoaGioHang(taikhoan,maSP);
                cart.hienThiGioHang(RepeaterCart);
            }

        }
    }
}