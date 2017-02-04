<%@ Page Title="" Language="C#" MasterPageFile="~/PGClasse/Classes.Master" AutoEventWireup="true" CodeBehind="Cria_Sala.aspx.cs" Inherits="InterLinQ.PGClasse.Cria_Sala" %>
<asp:Content ID="Content1" ContentPlaceHolderID="formularios" runat="server">
     <%-- 
    Document   : cria_sala
    Created on : 21/09/2013, 14:44:06
    Author     : Marcilio
--%>
    <div class="span8" style="width:900px">
             <div class="pull-right" title="close"><a href="Classesp.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; "/></a></div><br>
<div class="container " style="margin-left: 30px;">
        <div class="row " style="width:800px">
            <div class="col-lg-12" style="width:800px">
            
                <h2>New classroom</h2>
                <h4 runat="server" id="Mensagem">Select a Complement and a Period to creat a new classroom </h4>
                 Classroom's Name :<span style="color:red">*</span> <asp:DropDownList ID="Nome" runat="server" AutoPostBack="true" CssClass="form-control">
                     <asp:ListItem>Choose</asp:ListItem>
                                         <asp:ListItem>1 Série </asp:ListItem>
                                         <asp:ListItem>2 Série </asp:ListItem>
                                         <asp:ListItem>3 Série </asp:ListItem>
                                         <asp:ListItem>4 Série </asp:ListItem>
                                         <asp:ListItem>5 Série </asp:ListItem>
                                         <asp:ListItem>6 Série </asp:ListItem>
                                         <asp:ListItem>7 Série </asp:ListItem>
                                         <asp:ListItem>8 Série </asp:ListItem>
                                         <asp:ListItem>9 sérei</asp:ListItem>
                                         <asp:ListItem>1 Ano Ensino Medio</asp:ListItem>
                                         <asp:ListItem>2 Ano Ensino Medio</asp:ListItem>
                                         <asp:ListItem>3 Ano Ensino Medio</asp:ListItem>   
                                  </asp:DropDownList>

                <asp:Literal ID="LiStMat" runat="server"  />
                <%-- Nome da Classe :  <select class='form-control' runat="server" id="Nome">
                                         <option>Select Name</option>
                                         <option>1 Série </option>
                                         <option>2 Série </option>
                                         <option>3 Série </option>
                                         <option>4 Série </option>
                                         <option>5 Série </option>
                                         <option>6 Série </option>
                                         <option>7 Série </option>
                                         <option>8 Série </option>
                                         <option>9 sérei</option>
                                         <option>1 Ano Ensino Medio</option>
                                         <option>2 Ano Ensino Medio</option>
                                         <option>3 Ano Ensino Medio</option>   
                                    </select>--%>
                 
               <%--  Complemento: <asp:DropDownList ID="Comple" runat="server" AutoPostBack="true" Width="50px" >
                    <asp:ListItem>Chose</asp:ListItem>
                     <asp:ListItem>A</asp:ListItem>
                                        <asp:ListItem>B</asp:ListItem>
                                        <asp:ListItem>C</asp:ListItem>
                                        <asp:ListItem>D</asp:ListItem>
                                        <asp:ListItem>F</asp:ListItem>
                                        <asp:ListItem>G</asp:ListItem>
                                        <asp:ListItem>H</asp:ListItem>
                              </asp:DropDownList>--%>
                <%-- Complement: <select class='form-control' name='Complemento' id="Comple" style="width:50px" >
                                        <option>Chose</option>
                                        <option>A</option>
                                        <option>B</option>
                                        <option>C</option>
                                        <option>D</option>
                                        <option>F</option>
                                        <option>G</option>
                                        <option>H</option>
                                        
                                    </select>	--%>
                <asp:Literal ID="ListComp" runat="server"  />
                 <asp:Literal ID="listPeriodo" runat="server"  />
                
                 <asp:Literal ID="ListaNewTurma" runat="server"  />
                
                <%-- Period: <select class='form-control' name='NPeriodo' id="Periodo" >
                                        <option>Selecione o Periodo</option>
                                        <option>Matutino</option>
                                        <option>Vespertino</option>
                                        <option>Noturno</option>
                                    </select>	--%>
                <%--    <div class="row">
                        <div class="col-lg-2 form-group ">
                            <label>Nome da Disciplina</label><br/>
                        </div>
                        <div class="col-lg-2 form-group ">
                            <label>Professor Responsável</label><br/>
                        </div>
                         
                    </div>

                    <div class="row">
                        <div class=" col-lg-8 aula ">
                            <div class="row">
                                <div class="col-lg-3">
                                   <select id="Materia" name="Materias[]" class='form-control'>
                                                                    
                                   </select>
                                   </div>
                                  <div class="col-lg-3">
                                  <select name="Professores[]" id="Professor" class='form-control'>
                                  </select>		
                                  </div>	
                               
                               
                                <div class="col-lg-1">
                                    <a class="btn btn-success aula-add" onclick=" ad_aula()">+</a>
                                </div>
                            </div>
                        </div>
                           <div class="col-lg-8  btn-group btn-toolbar">
                                                        <div class="row">
                                                            <div class="col-lg-8">
                                                                <asp:Button ID="criar" runat="server" Text="Criar" CssClass="btn btn-success" OnClick="criar_Click" />
                                                               
                                                                <input type="reset" class="btn btn-danger" value="Limpar" />
                                                            </div>
                                                        </div>
                                                    </div>
                    </div>--%>
           <div class="row">
                                                            <div class="col-lg-8">
                                                                <asp:Button ID="Confirma" runat="server" Text="Comfirm" CssClass="btn btn-success" OnClick="Confirma_Click" />
                                                               <asp:Button ID='criar' runat='server' Text='Save' CssClass='btn btn-success' OnClick='criar_Click' />
                                                                  <input type='reset' runat="server" class='btn btn-danger' id="limpar" value='Clean' />
                                                                <asp:LinkButton ID="Cancela" CssClass="btn btn-primary" Text="Cancel" runat="server" OnClick="Cancela_Click"></asp:LinkButton>
                                                            </div>
                                                        </div>
        </div>  
    </div>
</div>

</div>
     <script src="../JS/tela_classe/Cria_Sala.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="info" runat="server">
</asp:Content>
