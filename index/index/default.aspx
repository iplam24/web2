<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="index.trangchu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <asp:Button ID="btn_admin" runat="server" Text="PanelAdmin"  OnClick="btn_admin_Click" CssClass="btn-add-to-cart;" ClientIDMode="Static"/>
          <div class="slide">
        <div class="slide"><img src="img/cd4.jpg"alt=" cd3" />
    </div>
</div>
    <div class="slideshow-container">

     <div class="mySlides fade">
        
         <img src="img/img1.jpg" style="width:100%">
     </div>

     <div class="mySlides fade">
         
          <img src="img/imgjs1.png" style="width:100%">
   
     </div>

     <div class="mySlides fade">
         <img src="img/img(4).jpg" style="width:100%">
     </div>

     <div class="mySlides fade">
         <img src="img/imgjs(3).jpg" style="width:100%">
     </div>

 </div>
 <br>

 <div style="text-align:center">
     <span class="dot" onclick="currentSlide(1)"></span>
     <span class="dot" onclick="currentSlide(2)"></span>
     <span class="dot" onclick="currentSlide(3)"></span>
     <span class="dot" onclick="currentSlide(4)"></span>
 </div>
    <div class="product-container">
    <h1 class="featured-title">Điện thoại nổi bật</h1>
    <div class="product-grid">
       <asp:Repeater ID="RepeaterPhones" runat="server">
        <ItemTemplate>
            <div class="product-item">
                <a href='<%# "chitietsanpham.aspx?MaSP=" + Eval("MaSP") %>'>
                    <img class="product-image" src='<%# "/admin/" + Eval("HinhAnh1") %>' alt='<%# Eval("TenSP") %>' />
                </a>
                <h3 class="product-name"><%# Eval("TenSP") %></h3>
                <p class="product-price"><%# String.Format("{0:0,0 VNĐ}", Eval("GiaBan")) %> VNĐ</p>
                <asp:Button ID="btnAddToCart" CssClass="btn-add-to-cart" Text="Thêm vào giỏ hàng"
                    CommandName="AddToCart" CommandArgument='<%# Eval("MaSP") %>'
                    runat="server" OnCommand="btnAddToCart_Command" />
            </div>
        </ItemTemplate>
    </asp:Repeater>
    </div>
</div>

<div class="suggested-container">
    
    <h1 class="featured-title">LapTop nổi bật</h1>
    <div class="product-grid">
        <asp:Repeater ID="RepeaterLaptops" runat="server">
            <ItemTemplate>
                <div class="product-item">
                    <!-- Link to product details page -->
                    <a href='<%# "chitietsanpham.aspx?MaSP=" + Eval("MaSP") %>'>
                        <img class="product-image" src='<%# "/admin/" + Eval("HinhAnh1") %>' alt='<%# Eval("TenSP") %>' />
                    </a>
                    <h3 class="product-name"><%# Eval("TenSP") %></h3>
                    <p class="product-price"><%# String.Format("{0:0,0 VNĐ}", Eval("GiaBan")) %> VNĐ</p>
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
               
                    <asp:Repeater ID="RepeaterAccessories" runat="server">
                    <ItemTemplate>
             <div class="accessories-item">
                        <a href='<%# "chitietsanpham.aspx?MaSP=" + Eval("MaSP") %>'>
                        <img class="accessory-image" src='<%# "/admin/" + Eval("HinhAnh1") %>' alt='<%# Eval("TenSP") %>' />
                        </a>
                        <h3 class="accessory-name"><%# Eval("TenSP") %></h3>
                        <p class="accessory-price"><%# String.Format("{0:0,0 VNĐ}", Eval("GiaBan")) %> VNĐ</p>
                        <asp:Button ID="btnAddToCart" CssClass="btn-add-to-cart" Text="Thêm vào giỏ hàng"
                    CommandName="AddToCart" CommandArgument='<%# Eval("MaSP") %>'
                    runat="server" OnCommand="btnAddToCart_Command" />
           </div>
                    </ItemTemplate>
                    </asp:Repeater>
               
              

        </div>
            </div>
        <!-- Footer -->
        
</asp:Content>
