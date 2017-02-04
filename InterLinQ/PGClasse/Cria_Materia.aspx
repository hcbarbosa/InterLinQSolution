<%@ Page Title="" Language="C#" MasterPageFile="~/PGClasse/Classes.Master" AutoEventWireup="true" CodeBehind="Cria_Materia.aspx.cs" Inherits="InterLinQ.PGClasse.Cria_Materia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="formularios" runat="server">
    <%-- 
    Document   : cria_materia
    Created on : 21/09/2013, 16:45:06
    Author     : Marcilio
--%>
<div class="span8" style=" width: 900px;">

    
    <div class="row ">
        <div class="col-lg-12">
            <div class="pull-right" title="close"><a href="Classesp.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; "/></a></div><br>
            
                    

                <h2>New Discipline</h2>
 
                    <div class="row" style="width: 450px;">
                        
                        <div class="pull-left form-group tipo-grupo">
                            <label style="margin-left:20px">Subjects</label><br/>
                        </div>
                        <div class="pull-right form-group numero-grupo">
                            <label>Informations</label><br/>
                        </div>
                    </div>

                    <div class="row">
                        <div class=" col-lg-12 materia" style="width: 700px;">
                            <div style="width: 700px;">
                                <div class="pull-left" style=" margin-right: 70px;">
                                    <input type="text" name="Nome[]" required id="Nome" class='form-control input-xlarge' placeholder='Name' />
                                </div>
                                <div class="pull-left" style=" margin-right: 20px;" >
                                   <input type="text" name="Info[]"  required  id="Info" class='form-control input-xlarge' placeholder='Additional Anformation'/>	
                                </div>
                                <div class="pull-left">
                                    <a class="btn btn-success materia-add" onclick=" ad_materia()">+</a>
                                </div>
                                
                            </div>
                           
                        </div>
                        
                                
                            </div>
            <div class="pull-left btn-group btn-toolbar">
                                    <div class="row">
                                        <div class="col-lg-8">
                                    <asp:Button ID="Cria" Text="Save" runat="server" CssClass="btn btn-success "  OnClick="Cria_Click"/> 
                                   
                                    <input type="reset" class="btn btn-danger" value="Clean" />
                                     </div>
                                    </div>
                                </div>
                    </div>
           
        </div>  
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="info" runat="server">
</asp:Content>
