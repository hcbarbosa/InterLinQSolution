<%@ Page Title="" Language="C#" MasterPageFile="~/PGALuno/Alunos.Master" AutoEventWireup="true" CodeBehind="MatriculaAL.aspx.cs" Inherits="InterLinQ.PGALuno.MatriculaAL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="formulario" runat="server">

    <div class="imagem_close" title="Close"><a href="Alunos.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; "/></a></div><br><br />

   <form class="form-inline" role="form">
   
  

    
    
       
   <asp:Literal ID="search" runat="server" />
       <div style="margin-left:20px">
   <asp:Literal ID="litCorpo" runat="server"  />
    </div>
    
           
       

   

</form>
</asp:Content>
