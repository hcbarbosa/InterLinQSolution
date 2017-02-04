<%@ Page Title="" Language="C#" MasterPageFile="~/PGAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="MudaSenha.aspx.cs" Inherits="InterLinQ.PGAdmin.MudaSenha" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo" runat="server">
         <div class="imagem_close" title="Close"><a href="admin.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; " class="pull-right"/></a></div><br><br />
   <h3>Alter PassWord </h3>
  <div class="form-group">
    <label class="sr-only pull-left" >Email:<span style="color:red">*</span></label>
    <input type="email" required class="form-control" id="Email" runat="server"  placeholder="Enter email" style="margin-left: 30px;"/>
  </div>
    <br />
  <div class="form-group ">
    <label class="sr-only pull-left" >Password :<span style="color:red">*</span></label>
    <input type="password" required class="form-control" id="Passwd" runat="server" placeholder="Password"/>
  </div>
<br />
  
  
  <asp:Button  CssClass="btn btn-success" runat="server"  ID="change" Text="Change" OnClick="change_Click"></asp:Button>
    <button type="reset" class="btn btn-primary">Clean</button>
</asp:Content>
