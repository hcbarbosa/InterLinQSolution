<%@ Page Title="" Language="C#" MasterPageFile="~/PGClasse/Classes.Master" AutoEventWireup="true" CodeBehind="Lista_Turmas.aspx.cs" Inherits="InterLinQ.PGClasse.Lista_Turmas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="formularios" runat="server">
     <div class="pull-right" title="close"><a href="Classesp.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; "/></a></div><br>
    <div class="span8" style="width: 900px;">
        <h2>Classroom's List</h2>
    <asp:GridView ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand"  OnPreRender="GridView1_PreRender" DataKeyNames="id " CssClass="info table table-striped display table-hover" >
                                     <Columns>
                                    <asp:BoundField DataField="nome" HeaderText="Name" HeaderStyle-Wrap="False"  />
                                    <asp:BoundField DataField="periodo" HeaderText="Period" HtmlEncode="true" HtmlEncodeFormatString="true"/>
                                    <asp:ButtonField  ButtonType="Button" Text="Options"    CommandName="info" ControlStyle-CssClass="btn btn-success accordion-toggle pull-right" SortExpression=""  />

                                   
                                     </Columns>
                              </asp:GridView>
            </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="info" runat="server">
</asp:Content>
