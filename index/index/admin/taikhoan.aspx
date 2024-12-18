<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="taikhoan.aspx.cs" Inherits="index.admin.taikhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2>Danh sách sản phẩm</h2>
    <a href="themtaikhoan.aspx">Thêm tài khoản</a>
    <div>
    <asp:Table ID="tbl_taikhoan" runat="server" CssClass="tbl_taikhoan">
    <asp:TableRow runat="server">
        <asp:TableCell runat="server">STT</asp:TableCell>
        <asp:TableCell runat="server">Tài khoản</asp:TableCell>
        <asp:TableCell runat="server">Mật khẩu</asp:TableCell>
        <asp:TableCell runat="server">Vai trò</asp:TableCell>
        <asp:TableCell runat="server">Email</asp:TableCell>
        <asp:TableCell runat="server">Cập nhật</asp:TableCell>
    </asp:TableRow>
</asp:Table>
    </div>
        

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    
</asp:Content>
