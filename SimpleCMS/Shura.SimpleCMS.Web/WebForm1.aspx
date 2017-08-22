<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Shura.SimpleCMS.Web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>trythisone</title>
    <script src="Scripts/tinymce/tinymce.min.js"></script>
    <script>tinymce.init({
    selector: '.conTiny'
});

        function Changed(textControl) {
            alert(textControl.value);
        }
        function change_isGood() {

            alert("hi");


        }


    </script>
</head>
<body>
                        
                <form id="form2" method="post" runat="server" onchange ="tinyMCE.triggerSave();">
                                             <textarea id="conTiny1" runat="server" class="conTiny"  value="hassan badry"  ></textarea> 

                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
                     </form>
            <br />
                     
                 <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                
 
    
</body>
</html>
