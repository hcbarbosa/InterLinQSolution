<%@ Page Title="" Language="C#" MasterPageFile="~/PGAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="Ano.aspx.cs" Inherits="InterLinQ.PGAdmin.Ano" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo" runat="server">

      <script src="../JS/tela_adm/anoletivo.js"></script>
    <div class="imagem_close" title="Close"><a href="admin.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; " class="pull-right"/></a></div><br><br />
    <span><h4>Add New school year <i></i><a class="btn btn-success " onclick="fnClickAddRow()">+</a></h4> </span>

    <br />
    <br />
    <table id="periodo" class="table" >
        <thead>
            <tr>
                <th >school year</th>
                <th>Status</th>
                <th>Edit</th>
            </tr>
            
        </thead>
        <tbody>

        </tbody>
    </table>

</asp:Content>
