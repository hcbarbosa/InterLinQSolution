<%@ Page Title="" Language="C#" MasterPageFile="~/PGALuno/Alunos.Master" AutoEventWireup="true" CodeBehind="Notas_Faltas.aspx.cs" Inherits="InterLinQ.PGALuno.Notas_Faltas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="formulario" runat="server">
     <div class="imagem_close" title="Close"><a href="Alunos.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; "/></a></div><br><br />
                    <ul class="nav nav-tabs  " style="background-color: #F9F9FF;  " >
                        <li><a > Studant's Name:<i></i> <asp:Label ID="NomeAl" runat="server" /></a></li>
                        <li><a  >Classroom: <i></i><asp:Label ID="serie" runat="server" /></a></li>
                        
                        <li>
                          <label id="lblbimestre" runat="server"> Bimester:<asp:DropDownList ID="muda_bimestre" AutoPostBack="true" CssClass="input-medium"   runat="server">

                            </asp:DropDownList>                           
                            
                         </label>   </li>
                        
                            <li> <asp:Button ID="salva" runat="server" Text="Save"  CssClass="btn btn-success" OnClick="salva_Click"/> </li>
                            <li><input type="reset" id="Clean" runat="server" class="btn    btn-danger " value="Clean"/></li>
                    </ul>
                
            
      
                        <div id="space"></div>
       <%--  --%>
    <asp:Table id="Table" runat="server" CssClass=" display  table table-striped table-hover" >
         
    </asp:Table>
    <asp:Table id="Tables" runat="server" CssClass=" display  table table-striped table-hover" >
         
    </asp:Table>

          <script src="../JS/MascMoney.js"></script>
    
     <script src="../JS/Mascara.js"></script>


</asp:Content>
