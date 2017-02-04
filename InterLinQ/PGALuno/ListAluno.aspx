<%@ Page Title="" Language="C#" MasterPageFile="~/PGALuno/Alunos.Master" AutoEventWireup="true" CodeBehind="ListAluno.aspx.cs" Inherits="InterLinQ.PGALuno.ListAluno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="formulario" runat="server">
    <div class="imagem_close" title="Close"><a href="Alunos.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; "/></a></div><br>
    <h2>Studant's List</h2>

    <asp:GridView ID="ListStudant" runat="server" OnPreRender="ListStudant_PreRender" OnRowDataBound="ListStudant_RowDataBound" AutoGenerateColumns="false" OnRowCommand="ListStudant_RowCommand" DataKeyNames="id "  GridLines="None" CssClass="table table-striped display table-hover" >
                                     <Columns>
                                    <asp:BoundField DataField="nome" HeaderText="Name" HeaderStyle-Wrap="False"  />
                                     <asp:BoundField DataField="rm" HeaderText="RM" HeaderStyle-Wrap="False"  />
                                     <asp:BoundField DataField="rg" HeaderText="RG" HeaderStyle-Wrap="False"  />

                                   
                                    
                                   
                                     </Columns>
                              </asp:GridView>
           

</asp:Content>
