<%@ Page Title="" Language="C#" MasterPageFile="~/PGClasse/Classes.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="List_Profes.aspx.cs" Inherits="InterLinQ.PGClasse.List_Profes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="formularios" runat="server">
     <div class="pull-right" title="close"><a href="Classesp.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; "/></a></div><br>
     <div class="span8" style=" width: 900px;">
         <h3>List of Teachers</h3>
    <asp:GridView ID="ListaProf" runat="server" OnRowDataBound="ListaProf_RowDataBound" OnPreRender="ListaProf_PreRender" AutoGenerateColumns="false" OnRowCommand="ListaProf_RowCommand" DataKeyNames="id "  GridLines="None" CssClass="table table-striped display table-hover" >
                                     <Columns>
                                    <asp:BoundField DataField="nome" HeaderText="Name" HeaderStyle-Wrap="False"  />
                                     <asp:BoundField DataField="registro" HeaderText="Registro" HeaderStyle-Wrap="False"  />
                                   <asp:TemplateField>
                                       <ItemTemplate>
                                           
                                           <asp:Button ID="Button1"  Text="Edit" runat="server" OnCommand="Button1_Command" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  CommandName="Editar" CssClass="btn btn-primary accordion-toggle pull-right"  />
                                          <%-- <asp:Button ID="Button2"   Text="Delet"  runat="server" OnCommand="Button1_Command" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  CommandName="Delet" CssClass="btn btn-danger accordion-toggle pull-right"  />--%>

                                       </ItemTemplate>
                                   </asp:TemplateField>
                                    
                                   
                                     </Columns>
                              </asp:GridView>
            </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="info" runat="server">
</asp:Content>
