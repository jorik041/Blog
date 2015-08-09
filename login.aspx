<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>You should told me your password!</title>
</head>
<body>

<div style="margin-left:auto;margin-right:auto;margin-top:200px;width:250px;height:500px;text-align:center;">

    <form id="Form1" runat="server">
<table style="width:250px;border:0px;">
  <tr>
    <td style="width:80px">Username : </td>
    <td style="width:10px"> </td>
    <td><asp:TextBox Id="txtUser" width="150" runat="server"/></td>
  </tr>
  <tr>
    <td>Password : </td>
    <td style="width:10px"> </td>
    <td><asp:TextBox Id="txtPassword" width="150" TextMode="Password" runat="server"/></td>
  </tr>
  <tr>
    <td colspan="3"><asp:CheckBox id="chkPersistLogin" runat="server" />Check to remember<br/>
    </td>
  </tr>
  <tr>
    <td> </td>
    <td style="width:10px"> </td>
    <td><asp:Button Id="cmdLogin" OnClick="ProcessLogin" Text="Login" runat="server" /></td>
  </tr>
</table>
<br/>
<br/>
<div>

</div>
</form>
    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>

</div>

</body>
</html>
