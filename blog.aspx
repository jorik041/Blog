<%@ Page Language="C#" AutoEventWireup="true" CodeFile="blog.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="myblog" %>


<%@ Register Assembly="pageGV" Namespace="pageGV" TagPrefix="pgv" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">

<html>
<head runat="server">


    <link href="blog.css" rel="stylesheet" type="text/css" />

       <style type="text/css">
    .imgrefresh
    {
        background-image: url("./refresh.png");
        width:32px;
        height:32px;
        border:0px;
        background-position:top top;
    }
    
    </style>

    <title>That's my blog engine</title>
</head>
<body>
    
    <div style="text-align:center;margin:0;padding:0">
    <img src="blog.png" style="border:0px;margin-top:5px;margin-bottom:12px;padding:0" alt="Blog header image" />
    </div>

               
    <form id="form1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    <Scripts>
    <asp:ScriptReference Path="jquery-1.7.js" />
    </Scripts>
    </asp:ScriptManager>

        <input id="HiddenField1" type="hidden" runat="server" value="" />
     
    <div>


        <pgv:pagedGridView ID="GridView1" runat="server" AllowPaging="True" PageSize="5" OnRowDataBound="GridView1_RowDataBound"
           AutoGenerateColumns="false" DataSourceID="BlogDataSource" OnPageIndexChanging="GridView1_PageIndexChanging" 
            CssClass="gridview1" BorderStyle="None" BorderWidth="0px" GridLines="None" 
            ShowHeader="False" CellPadding="12">
            <Columns>

        <asp:TemplateField HeaderText="That's my blog!" SortExpression="email">
          
            <ItemTemplate>
            <div style="text-align:center">
                 <asp:Label ID="Label2" runat="server" ForeColor="#FFFAED"
                    Text='<%# Bind("blogID") %>'></asp:Label>

                        <asp:Label ID="Label3" runat="server" ForeColor="Orange"
                    Text='<%# postedDate(Eval("posted")) %>'></asp:Label>
                     <asp:Label ID="Label4" runat="server" ForeColor="Orange"
                    Text='<%# editedDate(Eval("lastedited")) %>'></asp:Label>
            </div>

                <br />
                    
            <%# ConvertFlag(Eval("blogMsgText")) %>



   <div class="divdiv">
     

     <table id="verifyTable" style="margin-left:auto;margin-right:auto;border:0px;padding:0px;">
     <tr>
     <td>
          <asp:Image ClientIDMode="Static" ID="imCaptcha" CssClass="cap" ImageUrl="Captcha.ashx" runat="server" Width="55" Height="29" />
     </td>
     <td>
          <asp:Button ID="btnRefresh" runat="server" OnClick="RefreshImg" CssClass="imgrefresh" ToolTip="Update"
            CausesValidation="False" />
 </td>
 <td>
        <asp:TextBox ID="txtVerify" CssClass="txtComment" runat="server" Width="100px" MaxLength="5"></asp:TextBox>
 </td>
 </tr>
 </table>
       <asp:Label ID="Label1" runat="server" Font-Size="14pt" Text="What is your name?"></asp:Label>
   <asp:TextBox ID="txtName" CssClass="txtComment" runat="server" TextMode="SingleLine" Width="175" MaxLength="25"></asp:TextBox><br />
   <asp:TextBox ClientIDMode="Static" ID="txtComment" CssClass="txtComment" runat="server" TextMode="MultiLine" Rows="5" Width="400"></asp:TextBox><br />
   <asp:Button ID="btnAddComment" runat="server" Text="Add comment" OnClick="addComment"  />
   </div>


   <p class="addcommentclass" id="ac" runat="server">Add comment</p>

   <p runat="server" class="showcommentclass" id="showcommentclass">Show comments</p>

        <div class="divcomments" id="divcomments">
         <asp:GridView ID="GridView2" runat="server" AllowPaging="true" PageSize="10" ShowHeader="false"
         OnRowCommand="GridView2_RowCommand" GridLines="None"
           AutoGenerateColumns="false" DataSourceID="BlogDataSource2" BorderWidth="0" CssClass="gridview2">
                      <Columns>

        <asp:TemplateField SortExpression="cID">
                   <ItemTemplate>
                   <p>
                   <span style="color:Red;font-size:14pt">
                       <%# Eval("commentName") %>
                   </span> 
                       <%# Eval("commentMsgText") %>
                  </p>
                   </ItemTemplate>
        </asp:TemplateField>
                     </Columns>
              </asp:GridView>

        </div>



                 <asp:EntityDataSource ID="BlogDataSource2" runat="server" 
        EntitySetName="blogcomments"
            ContextTypeName="blogpostsModel.blogdbEntities" 
            EnableFlattening="False" EnableUpdate="false"
             Select="it.[cID], it.[commentMsgText],it.[commentName]" OrderBy="it.[cID]" 
             Where="it.[commentID] =@bID">
    <WhereParameters>
          <asp:ControlParameter ControlID="Label2" Name="bID" PropertyName="Text" Type="Int32"/>
      </WhereParameters>
        </asp:EntityDataSource>


   
            </ItemTemplate>
        </asp:TemplateField>
            </Columns>

             <PagerStyle CssClass="pagerst" Font-Names="Georgia,Comic Sans" 
                Font-Size="XX-Large" ForeColor="#CC00FF" />

            </pgv:pagedGridView>

            <div class="pager" style="margin-right:auto;margin-left:auto;width:500px;text-align:center;">
                    <asp:DataPager ID="pager" runat="server" PageSize="5" PagedControlID="GridView1" QueryStringField="page">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonCssClass="command" FirstPageText="«" PreviousPageText="‹"
                                RenderDisabledButtonsAsLabels="true" ShowFirstPageButton="true" ShowPreviousPageButton="true"
                                ShowLastPageButton="false" ShowNextPageButton="false" />
                            <asp:NumericPagerField ButtonCount="7" NumericButtonCssClass="command" CurrentPageLabelCssClass="current"
                                NextPreviousButtonCssClass="command" />
                            <asp:NextPreviousPagerField ButtonCssClass="command" LastPageText="»" NextPageText="›"
                                RenderDisabledButtonsAsLabels="true" ShowFirstPageButton="false" ShowPreviousPageButton="false"
                                ShowLastPageButton="true" ShowNextPageButton="true" />
                        </Fields>
                    </asp:DataPager>
                </div>


        <asp:EntityDataSource ID="BlogDataSource" runat="server" 
        EntitySetName="blogposts"
            ContextTypeName="blogpostsModel.blogdbEntities" 
            EnableFlattening="False" EnableUpdate="false">
        </asp:EntityDataSource>


        <br />
             
    </div>



    <script type="text/javascript">
//        var addc; 

        var isPostBack = document.getElementById("isPostBack");
        if (isPostBack != null) {
            addc = new Array(4);
            var stro = document.getElementById("HiddenField1").value;
            addc = stro.split(",");

        } else {
            addc = new Array(4);
            addc[0] = 0; addc[1] = 0; addc[2] = 0; addc[3] = 0; addc[4] = 0;
        }

        $(function () {
            function getLines(id) {
                return $('#' + id).val().split("\n").length
            }


            $('.txtComment').keyup(function (event) {
                var allowedNumberOfLines = 4;

                var txtareaID = $(event.target).attr('id');

                if (getLines(txtareaID) > allowedNumberOfLines) {
                    modifiedText = $(this).val().split("\n").slice(0, allowedNumberOfLines);
                    $(this).val(modifiedText.join("\n"));
                }

                var text = jQuery('#'+txtareaID).val();
                if (text.length > 200) {
                    text = text.substring(0, 200);
                    jQuery('#' + txtareaID).val(text);
                }


            });
        });

        function writeToHidden() {
            var st = addc[0] + "," + addc[1] + "," + addc[2] + "," + addc[3] + "," + addc[4]
            document.getElementById('HiddenField1').value = st;
        }

        $(document).ready(function () {

            $('.divdiv').each(function (i) {
                if (addc[i] == 0) {
                    $(this).css("display", "none");
                    $(this).next(".addcommentclass").text("Add comment");
                }
                else {
                    $(this).next(".addcommentclass").text("Do not add comment");
                }

            });

            //            $(".divdiv").hide();
            $(".divcomments").hide();


            $(".addcommentclass").click(function () {
                if ($(this).text() == "Add comment") {
                    $(this).prev(".divdiv").slideToggle(600);
                    $(this).text("Do not add comment");
                    pos = $(this).attr("id");
                    pos = pos.substring(pos.length - 1, pos.length);
                    addc[pos] = 1;
                    writeToHidden();
                }
                else {
                    $(this).prev(".divdiv").hide(600);
                    $(this).text("Add comment");
                    pos = $(this).attr("id");
                    pos = pos.substring(pos.length - 1, pos.length);
                    addc[pos] = 0;
                    writeToHidden();
                }
            });

            $(".showcommentclass").click(function () {
                if ($(this).text().indexOf("Show comments") > -1) {
                    $(this).next(".divcomments").slideToggle(300);
                    $(this).text("Hide comments");
                }
                else {
                    $(this).next(".divcomments").hide(300);
                    $(this).text("Show comments");
                }
            });

        });


                 // not realy needed now, but might bee needed later
                function refreshIMG() {
                    var sessionValue = '<%= Session["commentcap"] %>';
                    alert(sessionValue);
                }


              </script>

    </form>

</body>
</html>
