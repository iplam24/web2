<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="hienthigiohang.aspx.cs" Inherits="index.hienthigiohang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
             <div class="cart-container">
        <div class="cart-left">
            <h1>Giỏ hàng</h1>
            
            <asp:Repeater ID="RepeaterCart" runat="server">
                <HeaderTemplate>
                    <!-- Tiêu đề cột của giỏ hàng -->
                    <div class="cart-item-header">
                      
                        
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="cart-item">
                        <div class="item-info">
                            <input type="checkbox" class="item-checkbox" ID="chkItem<%# Eval("MaSP") %>" />
                            <img src='<%# "/admin/" + Eval("HinhAnh1") %>' alt='<%# Eval("TenSP") %>' />
                            <div>
                                <h3><%# Eval("TenSP") %></h3>
                                <p>Giá: <%# string.Format("{0:0,0 VNĐ}", Eval("GiaBan")) %></p>
                            </div>
                        </div>
                        <div class="item-actions">
                            <input type="number" value="<%# Eval("SoLuong") %>" min="1" />
                        </div>
                        <div class="item-actions">
                            <button onclick="XoaSanPham('<%# Eval("MaSP") %>')">
                                <i class="fa fa-trash"></i> Xóa
                            </button>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    <!-- Footer nếu cần, ví dụ tổng tiền -->
                    <div class="total">
                        Tổng tiền: <strong><%# string.Format("{0:0,0 VNĐ}", Eval("TongTien")) %></strong>
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

                <button>Hoàn tất thông tin</button>
            </div>
        </div>
    </div>
</asp:Content>
