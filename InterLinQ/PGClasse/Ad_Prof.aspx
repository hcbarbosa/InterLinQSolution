<%@ Page Title="" Language="C#" MasterPageFile="~/PGClasse/Classes.Master" AutoEventWireup="true" CodeBehind="Ad_Prof.aspx.cs" Inherits="InterLinQ.PGClasse.Ad_Prof" %>
<asp:Content ID="Content1" ContentPlaceHolderID="formularios" runat="server">
     <%-- 
    Document   : cadastra_prof
    Created on : 20/09/2013, 20:17:21
    Author     : Marcilio
--%>


    
    <div id="form_prof" style="width:670px">
      <div id="btn_form" class="text-center" style="width:670px">
                    <span class="btn_formulario"><asp:Button ID="Salva" CssClass=" btn btn-navbar btn-large" runat="server" Text="Save" Width="150" OnClick="Salva_Click"/></span><span class="btn_formulario"><input type="reset" class=" btn btn-navbar btn-large"  value="Clean" style="width: 150px"/></span>
             <div class="pull-right" title="Close"><a href="Classesp.aspx"  ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; "/></a></div><br/>
                </div>
    
      <label style="margin-left: 23px;">Name: <span style="color:red">*</span> <input type="text" class="input-xxlarge" id="Nome"  runat="server" required="required"/></label>
      <div class="span8" style="width:670px">
                    <label class="pull-left">RG:<span style="color:red">*</span> <input type="text" id="RG"  maxlength="10" runat="server" required="required" style="margin-left: 18px;"/></label>
                    <label class="pull-left " style=" margin-left: 80px;">ID: <input type="text" id="CPF" runat="server" class="input-large" onkeypress="MascaraCPF(this)" maxlength="14"  value=""/></label><br />
          <label class="pull-left">Registre:<span style="color:red">*</span> <input type="text" id="NREGISTRO" runat="server" required="required"/></label><br />
      </div>
        <div class="span8" style="width:670px">
                    <label >Adress:<span style="color:red">*</span> <input type="text" id="endereco" runat="server" class="" required="required" style=" width: 530px;"/> </label>
                    
                    <label class="pull-left">Area: <span style="color:red">*</span> <input type="text" id="bairro" runat="server" class="input-large" required="required"/></label>
        <label class="pull-left" style=" margin-left: 43px;">Complement: <input type="text" class="" runat="server" id="complemento"/></label>            
       </div>
             <div class="span8" style="width:670px">
                    
                        
                       <label class="pull-left">Country: <span style="color:red">*</span> <asp:DropDownList ID="pais"  Width="80px" runat="server" CssClass="input-medium dist"></asp:DropDownList></label>
                            <label class="pull-left">Estate: <span style="color:red">*</span> <asp:DropDownList ID="estado"  runat="server" style="width: 164px;" CssClass="input-large dist"></asp:DropDownList></label>
                            <label class="pull-left">City: <span style="color:red">*</span> <select runat="server" class="input-medium dist" style="width: 169px;"   name="cidade" id="cidade" ></select></label>

                        <label class="pull-left" >Phone:<span style="color:red">*</span>  <input type="text" class="input-medium" onkeypress="MascaraTelefone(this)" maxlength="14" runat="server" id="tel1" required="required" style="width:150px"/></label>
                        <label class="pull-left" style=" margin-left: 160px;"> Cell phone: <input type="text" class="input-medium" runat="server" id="tel2"   onkeypress ="MascaraTelefone(this)" maxlength="14" /></label>        
                     
                    </div>
                    
    </div>                 
     <script src="../JS/Mascara.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="info" runat="server">
</asp:Content>
