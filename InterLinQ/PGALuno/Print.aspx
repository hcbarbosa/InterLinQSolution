<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="InterLinQ.PGALuno.Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
    <link rel="stylesheet" href="../bootstrap/css/bootstrap.css">
        <link rel="stylesheet" href="../bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="../JSPrint/csss/960.css" type="text/css" media="screen"/>
    <link rel="stylesheet" href="../JSPrint/csss/screen.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="../JSPrint/csss/print.css" type="text/css" media="print" />
    <link rel="stylesheet" href="../JSPrint/css/print-preview.css" type="text/css" media="screen"/>
    <script src="../JSPrint/Jquery.js" type="text/javascript"></script>
     <script src="../JSPrint/jquery.print-preview.js" type="text/javascript"></script>
     <script src="../bootstrap/js/bootstrap.js"></script> 
      <script src="../bootstrap/js/bootstrap.min.js"></script> 
  
    <script type="text/javascript">
        $(function () {
            /*
             * Initialise example carousel
             */
            $("#feature > div").scrollable({ interval: 2000 }).autoscroll();

            /*
             * Initialise print preview plugin
             */
            // Add link for print preview and intialise
            $('#aside').prepend('<a class="print-preview  ">Print this page</a>');
            $('a.print-preview').printPreview();

            // Add keybinding (not recommended for production use)
            $(document).bind('keydown', function (e) {
                var code = (e.keyCode ? e.keyCode : e.which);
                if (code == 80 && !$('#print-modal').length) {
                    $.printPreview.loadPrintPreview();
                    return false;
                }
            });
        });



    </script>
</head>
    
<body>                
  
<div id="header" class="container_12">
    <strong>Report Card</strong>
</div>

<div id="content" class="container_12 clearfix">

    <div id="content-main" class="grid_8">
        <table width="450"  border="1" >
  <tr>
    <td colspan="12"><table width="510" border="0" class="table">
      <tr>
        <td width="41">Name:</td>
        <td width="312"><asp:Label ID="lblNome" runat="server"></asp:Label></td>
        <td width="23">RM</td>
        <td width="56"><asp:Label ID="lblRM" runat="server"></asp:Label></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td colspan="12"><table width="510" border="0">
      <tr>
        <td width="64">Grade/Year:</td>
        <td width="85"><asp:Label ID="lblserie" runat="server"></asp:Label></td>
        <td width="60">Period:</td>
        <td width="94"><asp:Label ID="lblperiodo" runat="server"></asp:Label></td>
        <td width="27">RG:</td>
        <td width="94"><asp:Label ID="lblrg" runat="server"></asp:Label></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td>Subjects</td>
    <td colspan="2">1º Bim.</td>
    <td colspan="2">2º Bim.</td>
    <td colspan="2">3º Bim.</td>
    <td colspan="2">4º Bim.</td>
    <td>REC.</td>
    <td colspan="2">Final Con.</td>
  </tr>


  <tr>
   <td>Grades/Absences</td>
    <td>G</td>
    <td>A</td>
    <td>G</td>
    <td>A</td>
    <td>G</td>
    <td>A</td>
    <td>G</td>
    <td>A</td>
    <td>G</td>
    <td width="20">A</td>
    <td>Status</td>
  </tr>
  <asp:Literal ID="grades" runat="server" />
   
  <tr>
    <td colspan="12">Signature of Parent/Responsible</td>
  </tr>
  <tr>
    <td colspan="12"><table width="490" border="0">
      <tr>
        <td width="80">1º Bim:</td>
        <td width="100">____________________</td>
        <td width="80">2º Bim:</td>
        <td width="100">____________________</td>
      </tr>
      <tr>
        <td  width="80">3º Bim:</td>
        <td>____________________</td>
        <td width="80">4º Bim:</td>
        <td>____________________</td>
      </tr>
    </table></td>
  </tr>
</table>
    </div>

    <div id="aside" class="grid_3 push_1">
        <div id="nav">
            <h2>Option</h2>
             
            <ul>
                <li><a href="Alunos.aspx" class=" btn btn-danger btn-large">Go Back!</a></li>
                
            </ul>
        </div>
        
       
    </div>
</div>

<div id="footer" class="container_12">
    
</div>
</body>
</html>
