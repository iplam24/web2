<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="quenmatkhau.aspx.cs" Inherits="index.quenmatkhau" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="dangky">
    <h3>Quên mật khẩu</h3>
    <table>
        <tr>
            <td>Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnLayLaiMatKhau" runat="server" Text="Lấy lại mật khẩu" OnClick="btnLayLaiMatKhau_Click" CssClass="btn-add-to-cart"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblThongBao" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
</div>
</asp:Content>
