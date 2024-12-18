<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="khuyenmai.aspx.cs" Inherits="index.khuyenmai" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="promo-page">
<h1>Khuyến Mãi Hiện Có</h1>

<div class="promo-container">
    <div class="promo-item">
        <div class="promo-info">
            <img src="img/giamgia.jpg" alt="Khuyến mãi giảm giá" class="promo-image">
            <h3>Giảm 10% cho đơn hàng trên 500.000 VNĐ</h3>
            <p>Mã khuyến mãi: <strong>DISCOUNT10</strong></p>
            <p>Hạn sử dụng: 31/12/2024</p>
        </div>
        <button class="apply-btn" onclick="applyPromo('DISCOUNT10')">Áp Dụng</button>
    </div>
     <div class="promo-item">
        <div class="promo-info">
            <img src="img/giamgia.jpg" alt="Khuyến mãi cho đơn hàng đầu tiên" class="promo-image">
            <h3>Giảm 50.000 VNĐ cho đơn hàng đầu tiên</h3>
            <p>Mã khuyến mãi: <strong>FIRST50</strong></p>
            <p>Hạn sử dụng: 31/12/2024</p>
        </div>
        <button class="apply-btn" onclick="applyPromo('FIRST50')">Áp Dụng</button>
    </div>
     <div class="promo-item">
        <div class="promo-info">
            <img src="img/giamgia.jpg" alt="Miễn phí giao hàng" class="promo-image">
            <h3>Miễn phí giao hàng cho đơn hàng trên 1.000.000 VNĐ</h3>
            <p>Mã khuyến mãi: <strong>SHIPFREE</strong></p>
            <p>Hạn sử dụng: 31/12/2024</p>
        </div>
        <button class="apply-btn" onclick="applyPromo('SHIPFREE')">Áp Dụng</button>
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
