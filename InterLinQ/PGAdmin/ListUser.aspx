<%@ Page Title="" Language="C#" MasterPageFile="~/PGAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="ListUser.aspx.cs" Inherits="InterLinQ.PGAdmin.ListUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Conteudo" runat="server">
    <div class="imagem_close" title="Close"><a href="admin.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; "  class="pull-right"/></a></div><br><br />
    <h3>User's List</h3>
    <asp:GridView runat="server" AutoGenerateColumns="false" BorderColor="White" CssClass="table" ID="grdUser" OnPreRender="grdUser_PreRender" DataKeyNames="Id" OnRowCommand="grdUser_RowCommand">
            <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
               
                <asp:BoundField DataField="permi" HeaderText="Permission" />
               
            </Columns>
        </asp:GridView>

</asp:Content>
