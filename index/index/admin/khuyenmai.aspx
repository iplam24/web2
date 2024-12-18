<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="khuyenmai.aspx.cs" Inherits="index.admin.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Danh sách sản phẩm</h2>
<a href="themkhuyenmai.aspx">Thêm khuyến mãi</a>
    <div>
    <asp:Table ID="tbl_khuyenmai" runat="server" Width="1041px" CssClass="tbl_giohang">
    <asp:TableRow runat="server">
        <asp:TableCell runat="server">STT</asp:TableCell>
        <asp:TableCell runat="server">Mã khuyến mãi</asp:TableCell>
        <asp:TableCell runat="server">Tên khuyến mãi</asp:TableCell>
        <asp:TableCell runat="server">Mô tả</asp:TableCell>
        <asp:TableCell runat="server">Ngày bắt đầu</asp:TableCell>
        <asp:TableCell runat="server">Ngày kết thúc</asp:TableCell>
        <asp:TableCell runat="server">Mức giảm giá</asp:TableCell>
        <asp:TableCell runat="server">Hình ảnh</asp:TableCell>
        <asp:TableCell runat="server">Cập nhật</asp:TableCell>
    </asp:TableRow>
</asp:Table>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
