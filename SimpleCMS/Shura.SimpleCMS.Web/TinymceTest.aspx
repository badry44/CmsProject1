<%@ Page validateRequest="false" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TinymceTest.aspx.cs" Inherits="Shura.SimpleCMS.Web.TinymceTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    
    <script src="Scripts/tinymce/tinymce.min.js"></script>
    <script src="http://tinymce.cachefly.net/4.0/tinymce.min.js"></script>
    <script src="Scripts/tinymce/jquery.tinymce.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="row x_title">
                <div class="col-md-6">
                </div>
                
<script lang="javascript ">
function Changed( textControl )
{
   alert( textControl.value );
}
function change_isGood() {
    //  alert("Uploads/" + x);

    tinyMCE.activeEditor.execCommand("mceInsertContent", true, "<h1>hello world</h1>");


}
function wtf() {
    document.getElementById("pls").innerHTML="hello";
    
    
}


</script>
                 
        
                        
   <script>tinymce.init({
    selector: '.conTiny',
    theme: 'modern',
    plugins: [
      'advlist autolink lists link image charmap print preview hr anchor pagebreak',
      'searchreplace wordcount visualblocks visualchars code fullscreen',
      'insertdatetime media nonbreaking save table contextmenu directionality',
      'emoticons template paste textcolor colorpicker textpattern imagetools codesample  help'
    ],
    toolbar1: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image',
    toolbar2: 'print preview media | forecolor backcolor emoticons | codesample help',
    image_advtab: true,
    templates: [
      { title: 'Test template 1', content: 'Test 1' },
      { title: 'Test template 2', content: 'Test 2' }
    ],
   

    content_css: [
      '//fonts.googleapis.com/css?family=Lato:300,300i,400,400i',
      '//www.tinymce.com/css/codepen.min.css'
    ],
    image_advtab: true,
    paste_data_images: true,
    images_upload_url: 'TinymceTest.aspx',
    automatic_uploads: true,

    images_upload_base_path: '/Image',
     location: '/Image',
    file_browser_callback: function (field_name, url, type, win) {
    
        if (type == 'image') $('#my_form input').click();
    }

});</script>

       <%--         <iframe id="form_target" name="form_target" style="display:none"></iframe>
<form id="my_form" action="/upload/" target="form_target" method="post" enctype="multipart/form-data" style="width:0px;height:0;overflow:hidden">
    <input name="image" type="file" onchange="$('#my_form').submit();this.value='';">
</form>--%>
                     
              
                                             <textarea id="conTiny1" runat="server" class="conTiny"  value="hassan badry"  ></textarea> 
                    <form id="form2" method="post" runat="server">
                         <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="Button2" runat="server" Text="tryUpload" OnClick="Button2_Click"/>
                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
                        <asp:Label Text="" runat="server" ID="lblMessage" ></asp:Label>
                     </form>
            <br />
                <div id ="pls">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>  
                    </div>
                <div>
                   
                </div>
                     
                
                </div>
        </div>
    </div>
</asp:Content>
