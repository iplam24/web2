<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="hienthigiohang.aspx.cs" Inherits="index.hienthigiohang" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
             <div class="cart-container">
        <div class="cart-left">
            <h1>Giỏ hàng</h1>
            
            
            
            <asp:Repeater ID="RepeaterCart" runat="server" OnItemDataBound="RepeaterCart_ItemDataBound">
                <HeaderTemplate>
                    <!-- Tiêu đề cột của giỏ hàng -->
                    <div class="cart-item-header">
                      
                        
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
            <div class="cart-item">
                <div class="item-info">
                    
                    <img src='<%# "/admin/" + Eval("HinhAnh1") %>' alt='<%# Eval("TenSP") %>' />
                    <div>
                        <h3><%# Eval("TenSP") %></h3>
                        <p>Giá: <%# string.Format("{0:0,0 VNĐ}", Eval("GiaBan")) %> </p>
                    </div>
                </div>
                <div class="item-actions">
                    SL: <input type="number" value="<%# Eval("SoLuong") %>" min="1" />
                </div>
                <div class="item-actions">
                   
                    <asp:Button ID="btn_xoa" runat="server" Text="Xóa" CommandArgument='<%# Eval("MaSP") %>' OnClick="btn_xoa_Click" CssClass="btn-xoa" />
                </div>
                <div>
                    Thành tiền: <%# string.Format("{0:0,0 VNĐ}", Eval("ThanhTien")) %> 
                </div>
            </div>
        </ItemTemplate>

                <FooterTemplate>
                    <!-- Footer nếu cần, ví dụ tổng tiền -->
                    <div class="total">
                        Tổng tiền: 
                        <asp:Label ID="lbl_thongbao" runat="server" Text=""></asp:Label>
                    </div>
                </FooterTemplate>
            </asp:Repeater>

        </div>
                 
        <div class="cart-right">
            <div class="customer-info">
                <h3>Thông Tin Khách Hàng</h3>
                <label for="name">Họ và tên</label>
                <input type="text" id="name" placeholder="Nhập họ và tên">

                <label for="email">Email</label>
                
                
                <input type="email" id="email" placeholder="Nhập email">

                <label for="phone">Số điện thoại</label>
                <input type="tel" id="phone" placeholder="Nhập số điện thoại">

                <label for="address">Địa chỉ giao hàng</label>
                <input type="text" id="address" placeholder="Nhập địa chỉ giao hàng">

                
                <asp:Button ID="btnmua" runat="server" Text="Mua ngay" CssClass="btn-add-to-cart" />
            </div>
        </div>
    </div>
    <script>
    function updateTotal() {
        let checkboxes = document.querySelectorAll('.item-checkbox');
        let total = 0;

        checkboxes.forEach((checkbox) => {
            if (checkbox.checked) {
                // Lấy giá trị số lượng và giá thành tiền từ cùng một sản phẩm
                let cartItem = checkbox.closest('.cart-item');
                let soLuong = cartItem.querySelector('input[type="number"]').value;
                let giaBan = parseFloat(cartItem.querySelector('p').innerText.replace(/[^\d]/g, '')); // Loại bỏ ký tự không phải số
                total += giaBan * soLuong;
            }
        });

        // Hiển thị tổng tiền
        document.querySelector('.total strong').innerText = total.toLocaleString('vi-VN') + " VNĐ";
    }

    // Lắng nghe sự kiện khi checkbox hoặc số lượng thay đổi
    document.addEventListener('DOMContentLoaded', () => {
        let checkboxes = document.querySelectorAll('.item-checkbox');
        let quantityInputs = document.querySelectorAll('input[type="number"]');

        checkboxes.forEach(checkbox => checkbox.addEventListener('change', updateTotal));
        quantityInputs.forEach(input => input.addEventListener('input', updateTotal));
    });
    </script>

</asp:Content>
