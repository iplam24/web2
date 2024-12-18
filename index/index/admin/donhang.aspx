<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="donhang.aspx.cs" Inherits="index.admin.donhang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Table ID="tbl_donhang" runat="server" CssClass="tbl_taikhoan">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">STT</asp:TableCell>
            <asp:TableCell runat="server">Tài khoản</asp:TableCell>
            <asp:TableCell runat="server">Họ Tên</asp:TableCell>
            <asp:TableCell runat="server">Email</asp:TableCell>
            <asp:TableCell runat="server">SDT</asp:TableCell>
            <asp:TableCell runat="server">Mã đơn hàng</asp:TableCell>
            <asp:TableCell runat="server">Mã sản phẩm</asp:TableCell>
            <asp:TableCell runat="server">Số lượng </asp:TableCell>
            <asp:TableCell runat="server">Giá tiền</asp:TableCell>
            <asp:TableCell runat="server">Tổng tiền</asp:TableCell>
            <asp:TableCell runat="server">Ngày đặt hàng</asp:TableCell>
            <asp:TableCell runat="server">Trạng thái</asp:TableCell>
            <asp:TableCell runat="server">Cập nhật</asp:TableCell>
        </asp:TableRow>
    </asp:Table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
