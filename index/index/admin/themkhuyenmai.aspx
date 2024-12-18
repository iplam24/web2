<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="themkhuyenmai.aspx.cs" Inherits="index.admin.themkhuyenmai" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <table class="auto-style1">
<tr>
    <td colspan="2"><h1 style="text-align:center;font-size:30px">Thêm khuyến mãi</h1></td>
</tr>
<tr>
    <td class="auto-style2">Mã khuyến mãi</td>
    <td>
        <asp:TextBox ID="txtMaKM" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Tên khuyến mãi</td>
    <td>
        <asp:TextBox ID="txtTenKM" runat="server" ></asp:TextBox>
    </td>
</tr>


<tr>
    <td class="auto-style2">Mô Tả</td>
    <td>
        <asp:TextBox ID="txtMoTa" runat="server" ></asp:TextBox>
    </td>
</tr>

<tr>
    <td class="auto-style2">Ngày bắt đầu</td>
    <td>
        <asp:TextBox ID="txtNgayBD" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Ngày kết thúc</td>
    <td>
        <asp:TextBox ID="txtNgayKT" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Mức giảm giá</td>
    <td>
        <asp:TextBox ID="txtMucGG" runat="server" ></asp:TextBox>
    </td>
</tr>

<tr>
    <td class="auto-style2">Hinh anh</td>
    <td>
        <asp:FileUpload ID="file_up1" runat="server" />
    </td>
</tr>

<tr>
    <td class="auto-style3" colspan="2" style="text-align:center">
        <asp:Button ID="btnLuu" runat="server" Height="36px" Text="Lưu" Width="77px" CssClass="btn_luu" OnClick="btn_luu_Click" />
        <asp:Button ID="btnHuy" runat="server" Height="36px" Text="Huỷ" Width="77px" CssClass="btn_huy" OnClick="btnHuy_Click" />
        </td>
</tr>
</table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
