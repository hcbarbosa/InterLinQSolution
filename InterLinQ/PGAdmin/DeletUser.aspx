<%@ Page Title="" Language="C#" MasterPageFile="~/PGAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="DeletUser.aspx.cs" Inherits="InterLinQ.PGAdmin.DeletUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo" runat="server">
   <div class="imagem_close" title="Close"><a href="admin.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; " class="pull-right"/></a></div><br><br />
     <h3>Deleting an User</h3>

    <div class="form-group">
    <label for="exampleInputEmail1">Email address:<span style="color:red">*</span></label>
    <input type="email" class="form-control" required runat="server" id="Email1" placeholder="Enter email">
  </div>

    <button class="btn btn-danger btn-lg" data-toggle="modal" onclick="Deleta()">
  Delete
</button>


    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
        <h4 class="modal-title" id="myModalLabel">Are You Sure?</h4>
      </div>
      <div class="modal-body">
      Insert Your PassWord:<span style="color:red">*</span> <input type="password" required class="form-control" runat="server" id="Passwd" name="PwUser" placeholder="Password"/>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        <button type="submit" class="btn btn-danger">Delet User !</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
</asp:Content>
