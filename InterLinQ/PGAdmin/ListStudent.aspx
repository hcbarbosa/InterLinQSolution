<%@ Page Title="" Language="C#" MasterPageFile="~/PGAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="ListStudent.aspx.cs" Inherits="InterLinQ.PGAdmin.ListStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo" runat="server">
    <div class="imagem_close" title="Close"><a href="admin.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; " class="pull-right"/></a></div><br><br />
    <h3>Studant's List</h3>
    <asp:Table ID="listEstudante" runat="server" CssClass="table"></asp:Table>
    <div id="pesquisa"></div>
</asp:Content>
