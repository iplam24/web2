<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="chitietsanpham.aspx.cs" Inherits="index.chitietsanpham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <script>
             // Lấy tất cả các ảnh thumbnail
             const thumbnailImages = document.querySelectorAll('.thumbnail img');

             // Lấy ảnh chính
             const mainImage = document.querySelector('.product-main-img');

             // Thêm sự kiện click vào mỗi ảnh thumbnail
             thumbnailImages.forEach((thumbnail) => {
                 thumbnail.addEventListener('click', () => {
                     // Lấy đường dẫn đến ảnh chính từ thuộc tính data-main-image-src
                     const mainImageSrc = thumbnail.getAttribute('data-main-image-src');

                     // Gán đường dẫn đến ảnh chính vào thuộc tính src của ảnh chính
                     mainImage.src = mainImageSrc;
                 });
             });
         </script>
         

<div class="ctsp" style="display: flex; flex-direction: column; gap: 20px;">
           <asp:Repeater ID="RepeaterProduct" runat="server">
    <ItemTemplate>
        <div class="ctsp" style="display: flex; flex-direction: column; gap: 20px;">
            <h2 class="sproduct-name"><%# Eval("TenSP") %></h2>

            <!-- Row chứa hình ảnh và thông tin sản phẩm -->
            <div class="sproduct-main" style="display: flex; gap: 20px;">
                <!-- Slide Container -->
                <div class="sproduct-image" style="flex: 1; height:auto">
                    <div class="simage-container" style="position: relative; width: 100%; height:400px; overflow: hidden;">
                        <div class="slideshow-container" style="width: 100%; height: 100%;">
                            <div class="mySlides fade">
                                <img src='<%# "/admin/" + Eval("HinhAnh1") %>' alt='<%# Eval("TenSP") %>' class="slide-img">
                            </div>
                            <div class="mySlides fade">
                                <img src='<%# "/admin/" + Eval("HinhAnh2") %>' alt='<%# Eval("TenSP") %>' class="slide-img">
                            </div>
                            <div class="mySlides fade">
                                <img src='<%# "/admin/" + Eval("HinhAnh3") %>' alt='<%# Eval("TenSP") %>' class="slide-img">
                            </div>
                        </div>

                        <!-- Nút chuyển ảnh -->
                        <div style="text-align: center; position: absolute; bottom: 10px; left: 50%; transform: translateX(-10%);">
                            <span class="dot" onclick="currentSlide(1)"></span>
                            <span class="dot" onclick="currentSlide(2)"></span>
                            <span class="dot" onclick="currentSlide(3)"></span>
                        </div>
                    </div>
                </div>

                <!-- Product Information -->
                <div class="sproduct-info" style="flex: 1; padding: 20px;">
                    <h3>Thông số kỹ thuật</h3>
                    <ul style="list-style: none; padding-left: 0; line-height: 1.8;">
                        <li><strong>Màn hình:</strong> <%# Eval("KichThuocMan") %></li>
                        <li><strong>Hệ điều hành:</strong> <%# Eval("HeDieuHanh") %></li>
                        <li><strong>Camera sau:</strong> <%# Eval("TrongLuong") %></li>
                        <li><strong>Camera trước:</strong> <%# Eval("MauSac") %></li>
                        <li><strong>Chipset:</strong> <%# Eval("Chip") %></li>
                        <li><strong>Bộ nhớ trong:</strong> <%# Eval("BoNho") %></li>
                        <li><strong>Pin:</strong> <%# Eval("DungLuongPin") %></li>
                    </ul>
                    <p class="sproduct-price" style="text-align:left"><%# Eval("GiaBan") %> VNĐ</p>

                    <div class="sproduct-actions">
                        <button class="sbtn-add-to-cart">Thêm vào giỏ hàng</button>
                        <button class="sbtn-buy-now">Mua ngay</button>
                    </div>
                </div>
            </div>

            <!-- Product Description -->
            <h2>Đánh giá</h2>
            <div class="sproduct-specs" style="padding: 20px; background-color: #f9f9f9; border-radius: 8px;">
                <p class="sproduct-description"><%# Eval("MoTa") %></p>
                <div class="sproduct-rating">
                    <span class="rating-title">Đánh giá: </span>
                    <span class="rating-stars">
                        <!-- Giả sử có 5 sao -->
                        <i class="fa fa-star" style="color: #ffcc00;"></i>
                        <i class="fa fa-star" style="color: #ffcc00;"></i>
                        <i class="fa fa-star" style="color: #ffcc00;"></i>
                        <i class="fa fa-star" style="color: #ffcc00;"></i>
                        <i class="fa fa-star" style="color: #ffcc00;"></i>
                    </span>
                    <span class="rating-count">(5/5) - 100 Đánh giá</span>
                </div>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

</div>



</asp:Content>
