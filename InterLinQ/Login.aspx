<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InterLinQ.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <link rel="stylesheet" href="bootstrap/css/bootstrap.css">
        <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">
        <link rel="stylesheet" href="bootstrap/css/bootstrap-responsive.css"> 
        <link rel="stylesheet" href="bootstrap/css/bootstrap-responsive.min.css"> 
       
        <script src="bootstrap/js/jquery.js"></script>
        <script src="bootstrap/js/bootstrap.js"></script> 
        <script src="bootstrap/js/bootstrap.min.js"></script> 
        <link rel="stylesheet" href="bootstrap/css/login.css">
    </head>
    <body>
        <div class="container">
	<section id="content">
            <form id="Form1"  runat="server" method="post">
                <h1 class="">   </h1>
			<div>
                            <input type="text" name="EmailUser" runat="server" class="" placeholder="Email" required="" id="username" />
			</div>
			<div>
				<input type="password" name="senha" runat="server" placeholder="Password" required="" id="password" />
			</div>
			<div>
                            <input type="submit" id="btnlog" value="Enter  " class="btn" />
				 <span class="alert-error  badge btn-danger" runat="server" id="erro"> Incorrect User or Password !</span>
			</div>
                        
		</form><!-- form -->
               
	</section>
            <!-- content -->
</div><!-- container -->
    </body>
    
    
</html>

