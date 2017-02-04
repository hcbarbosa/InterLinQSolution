<%@ Page Title="" Language="C#" MasterPageFile="~/PGClasse/Classes.Master" AutoEventWireup="true" CodeBehind="Edit_Materia.aspx.cs" Inherits="InterLinQ.PGClasse.Edit_Materia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="formularios" runat="server">
     <div class="span8">

    
    <div class="row ">
        <div class="col-lg-12">
            <div class="pull-right" title="close"><a href="Classesp.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; "/></a></div><br>
            
                    

                <h2>Edit Discipline</h2>
 
                    <div class="row">
                        
                        <div class="col-lg-4 form-group tipo-grupo">
                            <label>Discipline's Name</label><br/>
                        </div>
                        <div class="col-lg-4 form-group numero-grupo">
                            <label>Informations</label><br/>
                        </div>
                    </div>

                    <div class="row">
                        <div class=" col-lg-12 materia">
                            <div class="row">
                                <div class="col-lg-4">
                                    <input type="hidden" id="idmateria" runat="server" />
                                    <input type="text" name="Nome" required runat="server" id="Nome" class='form-control input-xlarge' placeholder='Name' />
                                </div>
                                <div class="col-lg-4">
                                   <input type="text" name="Info"  required runat="server"  id="Info" class='form-control input-xlarge' placeholder='Aditional Informations'/>	
                                </div>
                               
                                
                            </div>
                           
                        </div>
                        
                                <div class="col-lg-8  btn-group btn-toolbar">
                                    <div class="row">
                                        <div class="col-lg-8">
                                    <asp:Button ID="Cria" Text="Update" runat="server" CssClass="btn btn-success "  OnClick="Cria_Click"/> 
                                   
                                    <input type="reset" class="btn btn-danger" value="Limpar" />
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
