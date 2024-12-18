<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="danhsachsanpham.aspx.cs" Inherits="index.danhsachsanpham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <div class="product-container">
    <h1 class="featured-title">Danh sách sản phẩm</h1>
    <div class="product-grid">
       <asp:Repeater ID="RepeaterSanPham" runat="server">
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
</asp:Content>
