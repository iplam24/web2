<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="dangkytaikhoan.aspx.cs" Inherits="index.dangkytaikhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dangky">
    <table style="width: 450px">
        <tr>
            <td colspan="2">Đăng ký tài khoản</td>
        </tr>
        <tr>
            <td>Tài khoản:</td>
            <td>
                <asp:TextBox ID="txtusername" runat="server" Width="209px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Mật khẩu:</td>
            <td>
                <asp:TextBox ID="txtmatkhau" runat="server" Width="209px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Nhập lại mật khẩu:</td>
            <td>
                <asp:TextBox ID="txtnhaplai" runat="server" Width="209px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Email:</td>
            <td>
                <asp:TextBox ID="txtemail" runat="server" Width="209px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btndangky" runat="server" Height="27px" Text="Đăng ký" Width="82px" OnClick="btndangky_Click" />
                <asp:Button ID="btnhuy" runat="server" Height="27px" Text="Hủy" Width="82px" />
            </td>
        </tr>
    </table>
        </div>
</asp:Content>
