<%@ Page Title="" Language="C#" MasterPageFile="~/PGClasse/Classes.Master" AutoEventWireup="true" CodeBehind="Informacoes.aspx.cs" Inherits="InterLinQ.PGClasse.Informacoes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="formularios" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="info" runat="server">
     <div class="container " >
         <div id="alteracoes"></div>
        
                <div class="row">
                    <div class="span12">     
                        <ul class="nav nav-tabs navbar-fixed-top " style="background-color: #F9F9FF">
                            <div id ="modal" ></div>
                            <li><a href="#home" data-toggle="tab">List Students</a></li>
                            <li><a href="#profile" data-toggle="tab" onclick="carrega()" >List Diciplines</a></li>
                            <a href="Lista_Turmas.aspx" class="btn  accordion-toggle pull-right btn-danger" onclick="">Close <img src="../bootstrap/img/close.png" style="width: 32px ; height: 32px;" class=""/></a>
                           <div class="btn-group">
                            <button class="btn btn-default btn-lg dropdown-toggle" type="button" data-toggle="dropdown">Add
                             <img src="../bootstrap/img/cadastrar.png" style="width: 32px ; height: 32px;" class=""/>
                                <span class="caret">
                              </span>
                             </button>
                            <ul class="dropdown-menu">
                                
                               <li><a href="#" id="Atualiza" runat="server" onclick="updateMaterias()">Add Mattre/Teacher</a></li>
                                <li><a href="#" onclick="AdAluno()">Student</a></li>
                            </ul>
                            </div>
                             <a class="btn btn-success accordion-toggle   " id="btnSalva" onclick="submit()">Save Updates<b> <img src="../bootstrap/img/save.png" class=""/></a>
                              <a class="btn btn-danger accordion-toggle   " onclick="ConfRemocaoTurma()">Remove<b> <img src="../bootstrap/img/delete.png" class=""/></a>
                             
                             </ul>
                         <input type="hidden" value="" id="IDTurma" runat="server" />
                    </div>
                </div>
            </div>
           
            <div class="page-container">
                <div class="container">
                    <div class="tab-content" style="overflow-x:hidden;overflow-y:hidden;">
                        <div class="tab-pane active" id="home">
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />

                            
                            <asp:Table ID="tb_aluno" runat="server" CssClass="table"  ></asp:Table>
                        </div>
                        <div class="tab-pane" id="profile"  >
                             <br />
                            <br />
                            <br />
                            <br />
                            <br />
                           
                            <asp:Table ID="tb_materias" CssClass="table" runat="server" >
                               

                            </asp:Table>
                            
                        </div>
                    </div>





                </div>
            </div>
            <div class="span4">
            </div>
            
  
   
    <script src="../JS/tela_classe/mostra_info.js"></script>
</asp:Content>
