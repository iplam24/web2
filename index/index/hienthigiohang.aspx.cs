using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using index.cs_basic;
using index.dataBaseAccess;
namespace index
{
    public partial class hienthigiohang : System.Web.UI.Page
    {
        cartDatabase cart = new cartDatabase();
        khuyenmaisql km = new khuyenmaisql();
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

        protected void btn_apdung_Click(object sender, EventArgs e)
        {
            string makm = txtKM.Text; // Lấy mã giảm giá từ TextBox
            string taikhoan = Session["dangnhap"] as string; // Lấy tài khoản từ Session

            if (string.IsNullOrEmpty(taikhoan))
            {
                // Nếu chưa đăng nhập, chuyển hướng đến trang đăng nhập
                Response.Redirect("dangnhap.aspx");
            }
            else
            {
                // Lấy mức giảm giá từ mã khuyến mãi
                decimal mucGiamGia = km.layMucGiamGia(makm);

                // Tính tổng tiền ban đầu
                decimal tongTienBanDau = cart.tinhTongTien(taikhoan);

                // Tính tổng tiền sau khi giảm giá
                decimal tongTienSauGiam = tongTienBanDau - (tongTienBanDau * mucGiamGia / 100);

                // Gán tổng tiền sau giảm giá vào Label trong FooterTemplate
                RepeaterItem footerItem = RepeaterCart.Controls[RepeaterCart.Controls.Count - 1] as RepeaterItem;
                if (footerItem != null && footerItem.ItemType == ListItemType.Footer)
                {
                    Label lblThongBao = (Label)footerItem.FindControl("lbl_thongbao");
                    if (lblThongBao != null)
                    {
                        lblThongBao.Text = string.Format("{0:0,0 VNĐ}", tongTienSauGiam);
                    }
                }
            }
        }
        protected void btnmua_Click(object sender, EventArgs e)
        {
            string taiKhoan = Session["dangnhap"].ToString(); // Lấy tài khoản từ session
            string hoten = name.Text.Trim(); // Lấy tên người mua từ input
            string email = emaill.Text.Trim(); // Lấy email từ input
            string sdt = phone.Text.Trim(); // Lấy số điện thoại từ input
            string diachi = address.Text.Trim(); // Lấy địa chỉ từ input

            // Lấy giỏ hàng từ session
            List<giohang> gioHang = cart.layGioHang(taiKhoan);

            if (gioHang == null || gioHang.Count == 0)
            {
                // Nếu giỏ hàng rỗng
                Response.Write("<script>alert('Giỏ hàng của bạn đang rỗng!');</script>");
                return;
            }

            // Tính tổng tiền giỏ hàng
            decimal tongTien = cart.tinhTongTien(taiKhoan);

            // Chuyển tổng tiền sang kiểu chuỗi để lưu vào cơ sở dữ liệu
            string tongTienString = tongTien.ToString("F2"); // Chuyển thành chuỗi với 2 chữ số thập phân

            // Thêm đơn hàng vào bảng tbl_donhang
            cart.themDonDH(taiKhoan, hoten, email, sdt, tongTienString);
            cart.xoaALLGioHang(taiKhoan);
            
            

            // Thông báo thành công và chuyển hướng
            Response.Write("<script>alert('Đặt hàng thành công!'); window.location.href='hienthigiohang.aspx';</script>");
        }




    }


}
