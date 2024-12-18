<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="lienhe.aspx.cs" Inherits="index.lienhe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="contact-section">
    <div class="contact-container">
        <!-- Contact Form - Bên trái -->
        <div class="contact-left">
            <h2 class="contact-title">Chúng tôi rất muốn nghe ý kiến của bạn</h2>
            <form class="contact-form">
                <div class="form-group">
                    <label for="name">Họ và tên</label>
                    <input type="text" id="name" name="name" required placeholder="Nhập họ và tên của bạn">
                </div>
                <div class="form-group">
                    <label for="email">Email</label>
                    <input type="email" id="email" name="email" required placeholder="Nhập email của bạn">
                </div>
                <div class="form-group">
                    <label for="message">Lời nhắn</label>
                    <textarea id="message" name="message" rows="5" required placeholder="Nhập lời nhắn của bạn"></textarea>
                </div>
                <button type="submit" class="btn-submit">Gửi</button>
            </form>
        </div>

        <!-- Company Info - Bên phải -->
        <div class="contact-right">
            <h3>Giới thiệu công ty</h3>
            <p>Chúng tôi là một công ty hàng đầu trong lĩnh vực phát triển phần mềm và giải pháp công nghệ. Chúng tôi cung cấp các sản phẩm và dịch vụ chất lượng cao nhằm đáp ứng nhu cầu của khách hàng trên toàn cầu.</p>
            <h3>Thông tin liên hệ</h3>
            <ul>
                <li>Email: <a href="mailto:contact@website.com">contact@website.com</a></li>
                <li>Điện thoại: <a href="tel:+123456789">+123 456 789</a></li>
                <li>Địa chỉ: 123 Phố Công Nghệ, Quận 1, TP.HCM</li>
            </ul>
        </div>
    </div>
</section>


</asp:Content>
