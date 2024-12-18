<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="phukien.aspx.cs" Inherits="index.phukien" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
</asp:Content>
