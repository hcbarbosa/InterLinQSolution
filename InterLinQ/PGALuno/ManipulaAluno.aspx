<%@ Page Title="" Language="C#" MasterPageFile="~/PGALuno/Alunos.Master" AutoEventWireup="true" CodeBehind="ManipulaAluno.aspx.cs" Inherits="InterLinQ.PGALuno.ManipulaAluno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="formulario" runat="server">

    

    <div id="formulario" > 
            
            <input type="hidden" name="idAluno" runat="server" value="" id="idAluno" />
                <div id="btn_form" class="text-center">
                    <span class="btn_formulario"><asp:Button ID="salvaAluno" Text="Save" runat="server" OnClick="salvaAluno_Click"  CssClass="btn btn-navbar btn-large btnsalva" Width="150px" /></span><span class="btn_formulario"><input type="reset" class=" btn btn-navbar btn-large btnsalva"  value="Clean" style="width: 150px" /> </span>
                    <span class="btn_formulario"><asp:LinkButton id="Matricular" Text="Register" CssClass=" btn btn-navbar btn-large btn-success matricular" runat="Server" Width="150px" /> </span>
             <div class="imagem_close" title="Close"><a href="Alunos.aspx" ><img src="../bootstrap/img/close.png"style="width: 30px;height: 30px; "/></a></div><br>
             
                </div>
                <div class="container" style="width:950px;margin-right:0">  
                    <div id="box_form_1">
                        <div id="sub1">
                            <label>Name:<span style="color:red">*</span> <input type="text" runat="server" class="c_max " id="Nome" value="" required="required"/></label>
                        </div>
                        <div id="sub2">       
                            <script>
                                

                            </script>           
                            <label class="pull-left">Birthday:<input type="date" id="nascimento" min="1900-01-31" max="2100-12-31" class="input-medium" runat="server"  required="required"/></label>
                            <label class="pull-right" > Gender: <select class="input-medium" name="sexo" style="width:130px" id="Sexo" runat="server">
                                <option>select</option>
                                <option>Male</option>
                                <option>Female</option>                     
                               </select></label>
                        </div>
                        <div id="sub3">
                            <label class="pull-left" >RM:<span style="color:red">*</span><input type="text" value="" onkeypress="MascaraRMRA(this)" maxlength="9" required="" id="rm" runat="server" class="r_campos"/></label>                 
                            <label class="pull-right" > RA:<span style="color:red">*</span> <input type="text" id="ra" required="required"  onkeypress="MascaraRMRA(this)" maxlength="9"  class="r_campos" runat="server"/></label> 
                            <label class="pull-left" >RG:    <span style="color:red">*</span><input type="text" required="required" class="r_campos" runat="server" id="rg" maxlength="10"/></label>
                            <label class="pull-right">ID: <input type="text"  id="CPF" class="r_campos" maxlength="14" runat="server" onkeypress="MascaraCPF(this)" /></label>
                            <label class="pull-left">RNE: <input type="text" id="rne" runat="server" class="r_campos" maxlength="10"/></label>
                            <label class="pull-right" id="lblstatus" runat="server">Status: <input type="text" readonly id="txtStatus" class="r_campos" runat="server" /></label>
                        </div> 
                        <div id="sub4">
                            <div id="sub4_nomes1">
                                <label> Father: <input type="text" id="nomepai" runat="server" class="nomes"/></label>
                            </div><br/>
                            <div id="sub4_nomes2">
                                <label>Mother: <input type="text" id="nomemae" runat="server" class="nomes"/> </label>
                            </div>
                        </div>

                    </div>

                    <div id="box_form_2">
                       <div id="box2_sub1">

                            <label class="pull-left">Country<asp:DropDownList ID="pais"  Width="70px" runat="server" CssClass="input-medium dist"></asp:DropDownList></label>
                            <label class="pull-left">State<span style="color:red">*</span><asp:DropDownList ID="estado"  runat="server" CssClass="input-medium dist"></asp:DropDownList></label>
                            <label class="pull-left">City:<span style="color:red">*</span><select runat="server" class="input-medium dist"  name="cidade" id="cidade" >

                                                            </select></label>
                        </div>
                        <div id="box2_sub2">
                            <label>Adress:<span style="color:red">*</span> <input type="text" class="nomes2" id="Rua" runat="server" required="required"/> </label>
                        </div>
                        <label class="pull-left">Area:<span style="color:red">*</span> <asp:TextBox ID="Bairro" runat="server" required CssClass="" Width="200px" /></label>
                        <label class="pull-right">Complement:<asp:TextBox ID="Complemento" CssClass="input-medium" runat="server" Width="140px" /></label>
                        <label class="pull-left" style="margin-right: 15px">Phone:<span style="color:red">*</span> <input type="tel" id="tel1" runat="server" class="input-small" required="required" onkeypress="MascaraTelefone(this)"  style="width:120px" maxlength="14"/></label>
                        <label class="pull-left"> Cell phone:<span style="color:red">*</span> <input type="tel" id="tel2" runat="server" class="input-small" onkeypress="MascaraTelefone(this)" style="width:120px" maxlength="14"/></label>          
                        
                      
                    </div>
                    <div id="box_form_3">
                      <div id="box_imagem" class="img-rounded">
                          <asp:Image ID="Image1" runat="server"  Width="100%" Height="100%"/>
                        </div>
                        <div style="margin-left:55px">
                        <asp:FileUpload ID="Imagem" runat="server" CssClass="btn accordion-group col-lg-5" Font-Size="XX-Small" Width="60%" />
                       </div>
                       
                       
                       
                        <div id="box_inf" class="">
                           <br/><h5>Medical information</h5>
                            <textarea rows="8" cols="300" runat="server" name="inf-medic"  id="txt_inf" style="width: 300px;">
                        
                            </textarea>
                        </div>

                    </div>

                    <div id="box_form_4">

                        <h5 >School transcripts</h5>
                        <div id="tabela">
                        <table runat="server"  id="tbhitorico">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th class="input-xlarge text-center tb_historico">School</th>
                                    <th class="input-mini text-center">Year</th>
                                    <th class="input-xlarge text-center" >City</th>
                                    <th class="text-center" style="width: 20px;">State</th>
                                    <th class="input-small text-center tb_pais">Country</th>
                                </tr>
                               
                            </thead>
                           <%-- <tbody>
                                 <tr >
                                    <%for (int i = 0 ; i < 12 ; i++){%>
                                    <th class="input-small text-center"  style="width:120px"><%= i + 1%>º Grade</th>
                                    <td class="text-center"><input type="text" class="input-xlarge tb_historico " name="<%=i+1+"serie[]"%>"/></td>
                                    <td class="text-center"><input type="text" class="input-mini " name="<%=i+1+"serie[]"%>"/></td>
                                    <td class="text-center"><input type="text" class="input-xlarge tb_historico  city" /></td>
                                    <td class="text-center"><input type="text" style="width: 20px;" class="state"/></td>
                                    <td class="text-center"><input type="text" class="input-small tb_pais coutry"/></td>
                                </tr>
                                <%} %>
                               
                               

                            </tbody>--%>
                        </table>
                        </div>
                    </div>
                  
                </div>
           
        </div>
      <script src="../JS/tela_aluno/historigoAjax.js"></script> 
    <script src="../JS/Mascara.js"></script>
</asp:Content>
