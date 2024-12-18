<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="dangkytaikhoan.aspx.cs" Inherits="index.dangkytaikhoan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dangky">
     

 <table style="width: 450px">
     <tr>
         
         <td colspan="2"  style="text-align: center; color: orangered; font-size: 24px; ">Đăng ký tài khoản</>
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
         <td>&nbsp;</td>
         <td>
             <asp:Label ID="lbl_thongbao" runat="server" ForeColor="red"></asp:Label>
         </td>
     </tr>
     <tr>
         <td colspan="2" >
             <asp:Button ID="btndangky" runat="server" Height="38px" CssClass="btn-submit" Text="Đăng ký" Width="100px" OnClick="btndangky_Click" />
             <asp:Button ID="btnhuy" runat="server" Height="38px" CssClass="cancel-btn" Text="Hủy" Width="100px" />
         </td>
     </tr>
 </table>
     </div>
</asp:Content>
