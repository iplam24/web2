<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="datlaimatkhau.aspx.cs" Inherits="index.datlaimatkhau" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="DatLaiMatKhau">
    <h3>Đặt lại mật khẩu</h3>
    <table>
        <tr>
            <td>Mật khẩu mới:</td>
            <td>
                <asp:TextBox ID="txtMatKhauMoi" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Xác nhận mật khẩu:</td>
            <td>
                <asp:TextBox ID="txtXacNhanMatKhau" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnDatLaiMatKhau" runat="server" Text="Đặt lại mật khẩu" OnClick="btnDatLaiMatKhau_Click" />
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
