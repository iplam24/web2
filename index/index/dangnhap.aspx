<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="dangnhap.aspx.cs" Inherits="index.dangnhap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
           <div class="dangky">

               <table style="width: 418px">
                   <tr>
                       <td colspan="2" style="height: 22px">
                           <asp:Label ID="lblthongbao" runat="server"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td colspan="2" style="height: 22px">Đăng nhập</td>
                   </tr>
                   <tr>
                       <td style="width: 222px">Tài khoản:</td>
                       <td style="width: 312px">
                           <asp:TextBox ID="txtusername" runat="server" Width="221px"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td style="height: 22px; width: 222px">Mật khẩu:</td>
                       <td style="height: 22px; width: 312px">
                           <asp:TextBox ID="txtpassword" runat="server" Width="223px" TextMode="Password"></asp:TextBox>
                       </td>
                   </tr>
                   <tr>
                       <td style="height: 22px; width: 222px">&nbsp;</td>
                       <td style="height: 22px; width: 312px">
                           <asp:Label ID="txtthongbao" runat="server" ForeColor="red"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td colspan="2">
                           <asp:Button ID="btn_dangnhap" runat="server" Text="Đăng nhập" Width="143px" OnClick="btn_dangnhap_Click" CssClass="btn-add-to-cart"/>
&nbsp; </td>
                   </tr>
                   <tr>
                       <td style="width: 222px">
                           <a href="quenmatkhau.aspx" >Quên mật khẩu?</a>&nbsp;</td>
                       <td>
                            <a href="dangkytaikhoan.aspx">Đăng ký tài khoản mới</a>&nbsp;</td>
                   </tr>
               </table>

           </div>
</asp:Content>
