<%@ Page Title="" Language="C#" MasterPageFile="~/PGClasse/Classes.Master" AutoEventWireup="true" CodeBehind="Lista_Classes.aspx.cs" Inherits="InterLinQ.PGClasse.Lista_Classes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="formularios" runat="server">
     <div class="span8">
    <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand"  OnPreRender="GridView1_PreRender" DataKeyNames="Id " CssClass="info table table-striped display table-hover" >
                                     <Columns>
                                    <asp:BoundField DataField="Nome" HeaderText="Name" HeaderStyle-Wrap="False"  />
                                    <asp:BoundField DataField="Periodo" HeaderText="Period" HtmlEncode="true" HtmlEncodeFormatString="true"/>
                                    <asp:ButtonField  ButtonType="Button" Text="Informações"    CommandName="info" ControlStyle-CssClass="btn btn-success accordion-toggle pull-right" SortExpression=""  />
                                   
                                     </Columns>
                              </asp:GridView>
            </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="info" runat="server">
</asp:Content>
