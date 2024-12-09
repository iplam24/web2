<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="giohang.aspx.cs" Inherits="index.admin.giohang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <asp:Table ID="tbl_giohang" runat="server" CssClass="tbl_giohang">
        <asp:TableRow runat="server">
            <asp:TableCell runat="server">STT</asp:TableCell>
            <asp:TableCell runat="server">Tài khoản</asp:TableCell>
            <asp:TableCell runat="server">Mã sản phẩm</asp:TableCell>
            <asp:TableCell runat="server">Tên sản phẩm</asp:TableCell>
            <asp:TableCell runat="server">Hình ảnh</asp:TableCell>
            <asp:TableCell runat="server">Giá bán</asp:TableCell>
            <asp:TableCell runat="server">Số lượng</asp:TableCell>
            <asp:TableCell runat="server">Tổng tiền</asp:TableCell>
            <asp:TableCell runat="server">Ngày thêm</asp:TableCell>
            <asp:TableCell runat="server">Cập nhật</asp:TableCell>
        </asp:TableRow>
    </asp:Table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
