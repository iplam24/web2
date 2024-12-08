<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="suataikhoan.aspx.cs" Inherits="index.admin.suataikhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <table class="auto-style1">
<tr>
    <td colspan="2"><h1 style="text-align:center;font-size:30px">Sửa tài khoản</h1></td>
</tr>
<tr>
    <td class="auto-style2">Tài khoản</td>
    <td>
        <asp:TextBox ID="txttaikhoan" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Mật khẩu</td>
    <td>
        <asp:TextBox ID="txtmatkhau" runat="server" ></asp:TextBox>
    </td>
</tr>


<tr>
    <td class="auto-style2">Vai trò</td>
    <td>
        <asp:TextBox ID="txtvaitro" runat="server" ></asp:TextBox>
    </td>
</tr>


<tr>
    <td class="auto-style2" style="height: 49px">Email</td>
    <td style="height: 49px">
        <asp:TextBox ID="txtemail" runat="server" ></asp:TextBox>
    </td>
</tr>


<tr>
    <td class="auto-style3" colspan="2" style="text-align:center">
        <asp:Button ID="btn_luu" runat="server" Height="36px" Text="Lưu" Width="77px" CssClass="btn_luu" OnClick="btn_luu_Click" />
        <asp:Button ID="btn_Huy" runat="server" Height="36px" Text="Huỷ" Width="77px" CssClass="btn_huy" />
        </td>
</tr>
</table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
