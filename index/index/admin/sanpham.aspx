<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="sanpham.aspx.cs" Inherits="index.admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="content">
    <h2>Danh sách sản phẩm</h2>
    <div>
        
       
        
         <h3><a href="themsanpham.aspx" style="text-align:center">Chọn vào đây để thêm sản phẩm</a></h3>
            
       
        <asp:Table ID="tbl_sanpham" runat="server" Width="1600px" CssClass="tblSanPham">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server">STT</asp:TableCell>
                <asp:TableCell runat="server">Mã sản phẩm</asp:TableCell>
                <asp:TableCell runat="server">Tên sản phẩm</asp:TableCell>
                <asp:TableCell runat="server">Hãng sản xuất</asp:TableCell>
                <asp:TableCell runat="server">Ngày phát hành</asp:TableCell>
                <asp:TableCell runat="server">Kích thước màn</asp:TableCell>
                <asp:TableCell runat="server">Chip</asp:TableCell>
                <asp:TableCell runat="server">Ram</asp:TableCell>
                <asp:TableCell runat="server">Bộ nhớ</asp:TableCell>
                <asp:TableCell runat="server">Pin</asp:TableCell>
                <asp:TableCell runat="server">Hệ điều hành</asp:TableCell>
                <asp:TableCell runat="server">Trọng lượng</asp:TableCell>
                <asp:TableCell runat="server">Giá nhập</asp:TableCell>
                <asp:TableCell runat="server">Giá bán</asp:TableCell>
                <asp:TableCell runat="server">Màu sắc</asp:TableCell>
                <asp:TableCell runat="server">Mô tả</asp:TableCell>
                <asp:TableCell runat="server">Ảnh 1</asp:TableCell>
                <asp:TableCell runat="server">Ảnh 2</asp:TableCell>
                <asp:TableCell runat="server">Ảnh 3</asp:TableCell>
                <asp:TableCell runat="server">Phân loại</asp:TableCell>
                <asp:TableCell runat="server">Chức năng</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
       
       
        
        
       
    </div>
    
</div>
</asp:Content>
