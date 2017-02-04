<%@ Page Title="" Language="C#" MasterPageFile="~/PGAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="CriaUser.aspx.cs" Inherits="InterLinQ.PGAdmin.CriaUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo" runat="server">
     <div class="imagem_close" title="Close"><a href="admin.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; " class="pull-right"/></a></div><br><br />
   <h3>Creating a New User</h3>

    <div class="form-group">
    <label class="sr-only pull-left" >Name:<span style="color:red">*</span></label>
    <input type="text" required class="form-control" id="UserName" runat="server"   placeholder="Enter Name" style="margin-left: 30px;"/>
  </div>
    <br />
  <div class="form-group">
    <label class="sr-only pull-left" >Email:<span style="color:red">*</span></label>
    <input type="email" required class="form-control" id="Email"  runat="server"   placeholder="Enter email" style="margin-left: 30px;"/>
  </div>
    <br />
  <div class="form-group ">
    <label class="sr-only pull-left" >Password :<span style="color:red">*</span></label>
    <input type="password" required class="form-control" id="Passwd"  runat="server"  placeholder="Password"/>
  </div>
    <br />

    <div class="form-group ">
    <label class="sr-only pull-left" >Permission :<span style="color:red">*</span></label>
    <select class="form-control"  runat="server" id="permissao">
        <option>choose</option>
  <option>common</option>
  <option>Admin</option>
  
    </select>
  </div>
    <br />
  
  <asp:Button  CssClass="btn btn-success" runat="server"  ID="create" Text="Create" OnClick="create_Click"></asp:Button>
    <button type="reset" class="btn btn-primary">Clean</button>

</asp:Content>
