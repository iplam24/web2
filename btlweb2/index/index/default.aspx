<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="index.trangchu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       
  <div class="product-container">
    <h1 class="featured-title">Sản phẩm nổi bật</h1>
    <div class="product-grid">
        <asp:Repeater ID="RepeaterProducts" runat="server">
            <ItemTemplate>
                <div class="product-item">
                    <!-- Link to product details page -->
                    <a href='<%# "/product-details.aspx?MaSP=" + Eval("MaSP") %>'>
                        <img class="product-image" src='<%# "/admin/" + Eval("HinhAnh1") %>' alt='<%# Eval("TenSP") %>' />
                    </a>
                    <h3 class="product-name"><%# Eval("TenSP") %></h3>
                    <p class="product-price"><%# String.Format("{0:0,0 VNĐ}", Eval("GiaBan")) %></p>
                    <!-- Button to add product to cart -->
                    <asp:Button 
                        ID="btnAddToCart"
                        CssClass="btn-add-to-cart" 
                        Text="Thêm vào giỏ hàng" 
                        CommandName="AddToCart" 
                        CommandArgument='<%# Eval("MaSP") %>' 
                        runat="server" OnCommand="btnAddToCart_Command" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

<div class="suggested-container">
    <h2 class="suggested-title">Gợi ý cho bạn </h2>
    <div class="suggested-grid">
        <div class="suggested-item">
            <img class="product-image" src="img/dellinspironi5.jpg" alt="Dell inspiron 15 3520 i5" />
            <h3 class="product-name">Dell inspiron 15 3520 i5</h3>
            <p class="product-price">20.000.000 VNĐ</p>
            <button class="btn-add-to-cart">Thêm vào giỏ hàng</button>
        </div>
        <div class="suggested-item">
            <img class="product-image" src="img/Hp245.jpg" alt="HP 245 G10 R5 7530U" />
            <h3 class="product-name">HP 245 G10 R5 753U</h3>
            <p class="product-price">12.490.000 VNĐ</p>
            <button class="btn-add-to-cart">Thêm vào giỏ hàng </button>
        </div>
        <div class="suggested-item">
            <img class="product-image" src="img/neoi5.jpg" alt="neoi5" />
            <h3 class="product-name">Acer Predator Helios Neo PHN16 i5</h3>
            <p class="product-price">25.000.000 VNĐ</p>
            <button class="btn-add-to-cart">Thêm vào giỏ hàng</button>
     </div>
        <div class="suggested-item">
            <img class="product-image" src="img/AsusTUFGaming.jpg" alt="Asus TUF Gaming F15 FX507ZC4 i5" />
            <h3 class="product-name">Asus TUF Gaming F15 FX507ZC4 i5</h3>
            <p class="product-price">20.490.000 VNĐ</p>
            <button class="btn-add-to-cart">Thêm vào giỏ hàng</button>
        </div>
        <div class="suggested-item">
            <img class="product-image" src="img/LenovoGaming.jpg" alt="Lenovo Gaming LOQ 15ARP9 R7 " />
            <h3 class="product-name">Lenovo Gaming LOQ 15ARP9 R7 </h3>
            <p class="product-price">26.490.000 VNĐ</p>
            <button class="btn-add-to-cart">Thêm vào giỏ hàng </button>
        </div>
</div>
</div>
    <!-- h2--->
        <div class="slide">
        <div class="slide"><img src="img/cd3.jpg"alt=" cd3" />
    </div>
</div>

        <!--- phụ kiện chính hãng --->
        <div class="accessories-container">
            <h2 class="accessories-title">Phụ kiện chính hãng</h2>
            <div class="accessories-grid">
                <!--- Phụ kiện 1-->
                <div class="accessories-item">
                    <img class="accessory-image" src="img/taiNgheBluetooth.jpg" alt="Tai nghe chụp tai bluetooth" />
                    <h3 class="accessory-name">Tai nghe chụp tai bluetooth sony</h3>
                    <p class="accessory-price">500.000 VNĐ</p>
                    <button class="btn-add-to-cart">Thêm vào giỏ hàng</button>
                </div>
                <!--- PK2--->
                <div class="accessories-item">
                    <img class="accessory-image" src="img/TaiNgheBluetoothTrue.jpg" alt="Tai nghe bluetooth true" />
                    <h3 class="accessory-name">Tai nghe Bluetooth true wireless</h3>
                    <p class="accessory-price">990.000 VNĐ</p>
                      <button class="btn-add-to-cart">Thêm vào giỏ hàng</button>
                </div>
                <!---PK3-->
                <div class="accessories-item">
                     <img class="accessory-image" src="img/Cusac2cong.jpg" alt="Củ sạc type C 2 cổng " />
                    <h3 class="accessory-name">Củ xạc Type C 2 cổng 35W MNWP3ZA-A</h3>
                     <p class="accessory-price"> 1.190.000 VNĐ</p>
                     <button class="btn-add-to-cart">Thêm vào giỏ hàng</button>
                </div>

        </div>
            </div>
        <!-- Footer -->
        
</asp:Content>
