<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="InterLinQ.About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../bootstrap/css/bootstrap.css"/>
        <link rel="stylesheet" href="../bootstrap/css/bootstrap.min.css"/>
        <link rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.css"/> 
        <link rel="stylesheet" href="../bootstrap/css/bootstrap-responsive.min.css"/> 
    
        <link rel="stylesheet" href="../bootstrap/css/demo_table.css"/>
         <script src="../bootstrap/js/jquery.js"></script>
        
        <link rel="stylesheet" href="../bootstrap/css/style.css"/>
</head>

<body>
    <form id="form1" runat="server">
    <div id="in-sub-nav" >
            <div class="container">

                <div class="row">
                    <div class="span12">

                        <ul>

                           <li><a href="../PGALuno/Alunos.aspx" class="menu " id="link1"><img src='../bootstrap/img/arquivo.png'class="imagem_menu"/><br>Studants</a></li>                                                      
                            <li><a href="../PGClasse/Classesp.aspx" class="menu" id="link2"><img src='../bootstrap/img/gerenciar.png'class="imagem_menu"/><br>Manager classes</a></li>
                            <%
                             InterLinQ.Usuario u = new InterLinQ.Usuario();
                               
                               u = ( InterLinQ.Usuario ) Session["User"];
                               
                               if(u.permissao.Contains("Admin")){
                                %>
                            
                             <li><a href="../PGAdmin/admin.aspx" class="menu" id="link3" ><img src='../bootstrap/img/adm.png' class="imagem_menu" /><br>Administrator</a></li>                            
                             <%} %>
                            
                            
                             <li><a href="../Help.aspx" class="menu" id="link4"><img src='../bootstrap/img/help.png' class="imagem_menu" /><br/>Help</a></li> 
                             <li><a href="../About.aspx" class="menu" id="link5"><img src='../bootstrap/img/about.png'class="imagem_menu"/><br>About</a></li>
                            <li><a  href="../Logout.aspx" class="menu" onclick="" id="link6"><img src='../bootstrap/img/sair.png'class="imagem_menu"/><br>Exit</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="page">
            <div class="page-container">
                <div class="container">

                    <div class="span11">
                      <embed src="documentos/Documentacao.pdf" width="100%" height="900px;"/>
                    </div>
                    <div class="span4">
                       
                    </div>

                </div>


            </div>




        </div>
    </form>
</body>
</html>
