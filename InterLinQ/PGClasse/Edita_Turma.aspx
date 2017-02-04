<%@ Page Title="" Language="C#" MasterPageFile="~/PGClasse/Classes.Master" AutoEventWireup="true" CodeBehind="Edita_Turma.aspx.cs" Inherits="InterLinQ.PGClasse.Edita_Turma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="formularios" runat="server">
     <%-- 
    Document   : cria_sala
    Created on : 21/09/2013, 14:44:06
    Author     : Marcilio
--%>
       <script src="../JS/tela_classe/EditaTurma.js"></script>
   
             <div class="pull-right" title="close"><a href="Classesp.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; "/></a></div><br>
<div class="container " style="margin-left: 30px;">
        <div class="row ">
            <div class="col-lg-12">
            
                <h2>Edit classroom</h2>
                 Classroom's Name :  <input type="text" required name="Nome" runat="server" id="Nome" class='form-control telefone-field' placeholder='Nome'/>
                 <input type="hidden" id="idturma" runat="server" name="IDTurma" />
                 Period:<asp:DropDownList ID="Periodo" runat="server" >
                     <asp:ListItem Value="0">Select Period</asp:ListItem>
                     <asp:ListItem>Matutino</asp:ListItem>
                     <asp:ListItem>Vespertino</asp:ListItem>
                     <asp:ListItem>Noturno</asp:ListItem>
                        </asp:DropDownList> 
                   <div class='row' style=' width: 540px;'>
                        <div class=' pull-left form-group  'style='width:200px'>
                            <h4>Subjects</h4><br/>
                        </div>
                        <div class=' form-group '>
                            <h4 style='margin-left: 320px;' > Teacher</h4><br/>
                        </div>
                         
                    </div>

                    <div class='row'>
                        <div class=' col-lg-8 aula ' style='width: 600px;'>
                            <div class='row'>
                                <div class='pull-left'  style='width: 200px; margin-right: 120px;'>
                                   <select id='Materia' name='Materias[]' class='form-control'>
                                                                    
                                   </select>
                                   </div>
                                  <div class=' pull-left'>
                                  <select name='Professores[]' id='Professor' class='form-control'>
                                  </select>		
                                  </div>	
                               
                               
                                <div class='pull-left'>
                                    <a class='btn btn-success aula-add' style=' margin-left: 30px;' onclick=' ad_aula_ed()'>+</a>
                                </div>
                            </div>
                        </div>
                           
                           <div class="col-lg-8  btn-group btn-toolbar">
                                                        <div class="row">
                                                            <div class="col-lg-8">
                                                                <asp:Button ID="criar" runat="server" Text="Save" CssClass="btn btn-success" OnClick="criar_Click" />
                                                               
                                                                <input type="reset" class="btn btn-danger" value="Clean" />
                                                            </div>
                                                        </div>
                                                    </div>
                    </div>
           
        </div>  
    </div>
</div>


    
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="info" runat="server">
</asp:Content>
