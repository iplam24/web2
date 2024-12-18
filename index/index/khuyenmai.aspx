<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="khuyenmai.aspx.cs" Inherits="index.khuyenmai" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="promo-page">
<div class="promo-page">
    <h1>Khuyến Mãi Hiện Có</h1>

    <div class="promo-container">
        <asp:Repeater ID="repeaterKM" runat="server">
            <ItemTemplate>
                <div class="promo-item">
                    <div class="promo-info">
                        <img src='<%# "/admin/" +Eval("HinhAnh") %>' alt="Khuyến mãi giảm giá" class="promo-image">
                        <h3><%# Eval("TenKhuyenMai") %></h3>
                        <p>Mã khuyến mãi: <strong><%# Eval("MaKhuyenMai") %></strong></p>                      
                        <p>Mô tả: <%# Eval("MoTa") %></p>
                        <p>Ngày bắt đầu: <%# Eval("NgayBatDau") %></p>
                        <p>Ngày kết thúc: <%# Eval("NgayKetThuc") %></p>
                        <p>Mức Giảm Giá: <%# Eval("MucGiamGia") %></p>
                    </div>                   
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
         </div>
             <script>
        // Mảng các mã khuyến mãi
        const promos = [
            {
                code: 'DISCOUNT10',
                description: 'Giảm 10% cho đơn hàng trên 500.000 VNĐ',
                expiration: '31/12/2024',
            },
            {
                code: 'FIRST50',
                description: 'Giảm 50.000 VNĐ cho đơn hàng đầu tiên',
                expiration: '31/12/2024',
            },
            {
                code: 'SHIPFREE',
                description: 'Miễn phí giao hàng cho đơn hàng trên 1.000.000 VNĐ',
                expiration: '31/12/2024',
            },
        ];

        // Hàm áp dụng mã khuyến mãi
        function applyPromo(code) {
            const promo = promos.find(p => p.code === code);
            const messageElem = document.getElementById('message');

            if (promo) {
                const currentDate = new Date();
                const expirationDate = new Date(promo.expiration);

                // Kiểm tra hạn sử dụng
                if (currentDate <= expirationDate) {
                    messageElem.textContent = `Mã khuyến mãi ${code} đã được áp dụng thành công!`;
                    messageElem.className = 'message'; // Hiển thị thông báo thành công
                } else {
                    messageElem.textContent = `Mã khuyến mãi ${code} đã hết hạn.`;
                    messageElem.className = 'message error'; // Hiển thị thông báo lỗi
                }
            } else {
                messageElem.textContent = 'Mã khuyến mãi không hợp lệ.';
                messageElem.className = 'message error'; // Hiển thị thông báo lỗi
            }

            messageElem.style.display = 'block'; // Hiển thị thông báo
        }

             </script>
</asp:Content>
