<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="suasanpham.aspx.cs" Inherits="index.admin.suasanpham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <h2>Sửa sản phẩm</h2>
    <div>
        <table class="auto-style1">
<tr>
    <td colspan="2"><h1 style="text-align:center;font-size:30px">Sửa thông tin chi tiết sản phẩm</h1></td>
</tr>
<tr>
    <td class="auto-style2">Mã sản phẩm</td>
    <td>
        <asp:TextBox ID="txtMaSP" runat="server" ReadOnly="True" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Tên sản phẩm</td>
    <td>
        <asp:TextBox ID="txtTenSP" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Hãng sản xuất</td>
    <td>
        <asp:TextBox ID="txtHangSX" runat="server" ></asp:TextBox>
        
    </td>
</tr>
<tr>
    <td class="auto-style2">Ngày phát hành</td>
    <td>
        <asp:TextBox ID="txtNgayPH" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Kích thước</td>
    <td>
        <asp:TextBox ID="txtKichThuoc" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Chíp</td>
    <td>
        <asp:TextBox ID="txtChip" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Ram</td>
    <td>
        <asp:TextBox ID="txtRam" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Bộ nhớ</td>
    <td>
        <asp:TextBox ID="txtBoNho" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Dung lượng pin</td>
    <td>
        <asp:TextBox ID="txtDungLuong" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Hệ điều hành</td>
    <td>
        <asp:TextBox ID="txtOS" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Trọng lượng</td>
    <td>
        <asp:TextBox ID="txtTrongLuong" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Giá nhập</td>
    <td>
        <asp:TextBox ID="txtGiaNhap" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Giá bán</td>
    <td>
        <asp:TextBox ID="txtGiaBan" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Màu sắc</td>
    <td>
        <asp:TextBox ID="txtMauSac" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Mô tả</td>
    <td>
        <asp:TextBox ID="txtMota" runat="server" Rows="5" TextMode="MultiLine" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Ảnh 1</td>
    <td>
        <asp:Label ID="img1" runat="server"></asp:Label>
        <img id="imgPreview1" src="" alt="" width="200" height="200" />
        <br />
        <asp:FileUpload ID="file_up1" runat="server" />
        <br />
        Ảnh cũ:<br />
        <asp:TextBox ID="txtAnh1" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Ảnh 2</td>
    <td>
        <asp:Label ID="img2" runat="server"></asp:Label>
        <img id="imgPreview2" src="" alt="" width="200" height="200" />
        <br />
        <asp:FileUpload ID="file_up2" runat="server" />
        <br />
        Ảnh cũ:<br />
        <asp:TextBox ID="txtAnh2" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Ảnh 3</td>
    <td>
        <asp:Label ID="img3" runat="server"></asp:Label>
        <img id="imgPreview3" src="" alt="1" width="200" height="200" />
        <br />
        <asp:FileUpload ID="file_up3" runat="server" />
        <br />
        Ảnh cũ:<br />
        <asp:TextBox ID="txtAnh3" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style2">Phân loại</td>
    <td>
        <asp:TextBox ID="txtPhanLoai" runat="server" ></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="auto-style3" colspan="2" style="text-align:center">
        <asp:Button ID="btn_luu" runat="server" Height="36px" Text="Lưu" Width="77px" CssClass="btn_luu" OnClick="btn_luu_Click" />
        <asp:Button ID="btn_Huy" runat="server" Height="36px" Text="Huỷ" Width="77px" CssClass="btn_huy" />
        </td>
</tr>
</table>
        
       
        
        
       
        
        
       
        
        
       
    </div>
    <script type="text/javascript">
    // Hàm này cập nhật ảnh khi người dùng chọn file
    function updateImagePreview(fileInputId, previewImgId) {
        var fileInput = document.getElementById(fileInputId); // Lấy đối tượng FileUpload từ ID
        var file = fileInput.files[0]; // Lấy tệp đầu tiên

        if (file) {
            var reader = new FileReader(); // FileReader giúp đọc ảnh từ file
            reader.onload = function (e) {
                // Khi ảnh đã được đọc, cập nhật đường dẫn vào thẻ <img> để hiển thị
                document.getElementById(previewImgId).src = e.target.result;
            }
            reader.readAsDataURL(file); // Đọc file dưới dạng Data URL để hiển thị ảnh
        }
    }

    // Đảm bảo khi trang tải xong, gán sự kiện onchange cho file input
    window.onload = function () {
        // Gán sự kiện onchange cho file input 1
        document.getElementById('<%= file_up1.ClientID %>').onchange = function() {
            updateImagePreview('<%= file_up1.ClientID %>', 'imgPreview1');
        };

        // Gán sự kiện onchange cho file input 2
        document.getElementById('<%= file_up2.ClientID %>').onchange = function() {
            updateImagePreview('<%= file_up2.ClientID %>', 'imgPreview2');
        };

        // Gán sự kiện onchange cho file input 3
        document.getElementById('<%= file_up3.ClientID %>').onchange = function() {
            updateImagePreview('<%= file_up3.ClientID %>', 'imgPreview3');
        };
    };
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
