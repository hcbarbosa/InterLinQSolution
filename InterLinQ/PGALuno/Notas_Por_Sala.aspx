<%@ Page Title="" Language="C#" MasterPageFile="~/PGALuno/Alunos.Master" AutoEventWireup="true" CodeBehind="Notas_Por_Sala.aspx.cs" Inherits="InterLinQ.PGALuno.Notas_Por_Sala" %>
<asp:Content ID="Content1" ContentPlaceHolderID="formulario" runat="server">
     <div class="imagem_close" title="Close"><a href="Alunos.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; "/></a></div><br><br />
    <h2>Grades by Classroom</h2>
    <ul class="nav nav-tabs">
  <li><a href="#home"  data-toggle="tab">1st Bimester</a></li>
  <li><a href="#profile" data-toggle="tab">2nd Bimester</a></li>
  <li><a href="#messages" data-toggle="tab">3rd Bimester</a></li>
  <li><a href="#settings" data-toggle="tab">4th Bimester</a></li>
 
</ul>

<!-- Tab panes -->
<div class="tab-content">
  <div class="tab-pane active" id="home"> <asp:Table id="Table" runat="server" CssClass=" display  table table-striped table-hover table-condensed " >
         
    </asp:Table></div>
   
  <div class="tab-pane" id="profile"><asp:Table id="Table1" runat="server" CssClass=" display  table table-striped table-hover table-condensed " >
         
    </asp:Table></div>
     
  <div class="tab-pane" id="messages"><asp:Table id="Table2" runat="server" CssClass=" display  table table-striped table-hover table-condensed " >
         
    </asp:Table></div>

  <div class="tab-pane" id="settings"><asp:Table id="Table3" runat="server" CssClass=" display  table table-striped table-hover table-condensed " >
         
    </asp:Table></div>
   
</div>

     

</asp:Content>
