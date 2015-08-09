<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addpost.aspx.cs" Inherits="addpost" validateRequest="false" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Add post to blog</title>

    <link href="my.css" rel="stylesheet" type="text/css" />
    <script src="my.js" type="text/javascript"></script>

    <style type="text/css">
    
    
    body
    {
        background-color:#FFFFFF;
    }
    
        p, span
    {
        color:#EDFFFF;
    }
    
 .mainimage {
  max-width: 250px;
  max-height: 250px;
  width: expression(this.width > 250 ? "250px" : true);
  height: expression(this.height > 250 ? "250px" : true);
        }
    
    </style>


<script type="text/javascript">
<!--


//-->
</script>

</head>

<body>



    <form id="form1" runat="server">

  <asp:Button id="cmdSignOut" text="Exit" runat="server" onClick="SignOut" 
    BackColor="#FFFF66" BorderColor="#CC9900" BorderStyle="Dotted" 
    Font-Size="Medium" ForeColor="Blue" />

    <br />
    <br />

    <div>
    
    <div id="allstuff" style="width:80%;margin-left:auto;margin-right:auto;">


<div id="buttons_panel" style="height:40px;white-space: nowrap;">

<p>

<img onclick="editor_FormatText('Bold');" alt="Bold" 
class="editor_button" onmouseout="editor_button_off(this)" onmouseover="editor_button_on(this)" src="images/bold.png">

<img onclick="editor_FormatText('Italic');" alt="Italic" src="images/italics.png"
class="editor_button" onmouseout="editor_button_off(this)" onmouseover="editor_button_on(this)">

<img class="editor_button" onmouseout="editor_button_off(this)" onmouseover="editor_button_on(this)" 
onclick="editor_FormatText('Underline');" alt="Underline" src="images/underline.png">


<img class="editor_button" onmouseout="editor_button_off(this)" onmouseover="editor_button_on(this)" style="background-color: #FFD5D5!important;" 
onclick="editor_FormatText('JustifyLeft');" alt="Align left" src="images/align_left.png">

<img class="editor_button" onmouseout="editor_button_off(this)" onmouseover="editor_button_on(this)" style="background-color: #FFD5D5!important;" 
onclick="editor_FormatText('JustifyCenter');" alt="Align center" src="images/align_center.png">

<img class="editor_button" onmouseout="editor_button_off(this)" onmouseover="editor_button_on(this)" style="background-color: #FFD5D5!important;"  
onclick="editor_FormatText('JustifyRight');" alt="Align right" src="images/align_right.png">




<img class="editor_button" onmouseout="editor_button_off(this)" onmouseover="editor_button_on(this)" 
onclick="editor_createlink();" alt="Insert link" src="images/link_add.png">

<img class="editor_button" onmouseout="editor_button_off(this)" onmouseover="editor_button_on(this)" 
onclick="editor_FormatText('UnLink');" alt="Remove link" src="images/link_delete.png">


<img class="editor_button" onmouseout="editor_button_off(this)" onmouseover="editor_button_on(this)" 
onclick="editor_FormatText('Undo');" alt="Undo" src="images/undo.png">

<img class="editor_button" onmouseout="editor_button_off(this)" onmouseover="editor_button_on(this)" 
onclick="editor_FormatText('Redo');" alt="Redo" src="images/redo.png">


<select id="editor_select_style" class="editor_select_style" onchange="editor_get_range(); editor_FormatText('formatBlock', this.value); this.value='';getHTML();" 
name="editor_select_style" style="vertical-align:middle;">
<option value="">- Style - </option>
<option value="<p>">Paragraph </option>
<option value="<h1>">Header 1 </option>
<option value="<h2>">Header 2 </option>
<option value="<h3>">Header 3 </option>
<option value="<h4>">Header 4 </option>
<option value="<h5>">Header 5 </option>
<option value="<h6>">Header 6 </option>
</select>

<input type="color" id="user_color" name="user_color" onchange="editor_FormatText('forecolor', document.all.user_color.value);" style="vertical-align: middle;" />
<img class="editor_button" onmouseout="editor_button_off(this)" onmouseover="editor_button_on(this)" 
onclick="editor_FormatText('forecolor', document.getElementById('user_color').value);" alt="Set color" src="images/ok.png" />
</p>


</div>

<div style="clear:both;"></div>

<textarea runat="server" rows="5" cols="5" style="width:98%; height:350px; border:1px solid #888;margin:0;" name="edited_html" id="edited_html"></textarea>

<iframe onload="editor_loaded();" src="canvas.html" id="editor_frame" title="editor" style="width:98%; height:350px; border:1px solid #888;margin:0;" name="editor_frame" id="editor_frame">
</iframe>


<div style="margin-top:5px;">
<img  id="btnHtml" onclick="showhtml();" alt="HTML" src="images/html.png" />

<img id="btnView" onclick="showview();" alt="Preview" src="images/view.png" />
</div>

</div>

<div style="text-align:center;">

<asp:FileUpload ID="FileUpload1" runat="server"  ToolTip="select image" /><br />

<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload File" />&nbsp;<br />
<asp:Label ID="Label1" runat="server"></asp:Label>

<asp:RegularExpressionValidator ID="revImage" ControlToValidate="FileUpload1" ValidationExpression="^.*\.((j|J)(p|P)(e|E)?(g|G)|(g|G)(i|I)(f|F)|(p|P)(n|N)(g|G))$" Text="That's not an image file!" runat="server" />

</div>

    </div>

    <div id="DIVimages" runat="server">
    </div>

<div style="text-align:center;">
    <asp:Button ID="btnAddPost" runat="server" Text="Add message" OnClientClick="getHTML()"
        onclick="btnAddPost_Click" />
</div>
    </form>

    
</body>
</html>
