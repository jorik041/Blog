<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminka.aspx.cs" Inherits="blog" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">

<html>
<head runat="server">

    <link href="blog.css" rel="stylesheet" type="text/css" />

    <title>Blog's editor panel</title>
</head>
<body>
    

    <form id="form1" runat="server">


    <div style="text-align:right">
          <asp:Button id="cmdSignOut" text="LogOut" runat="server" onClick="SignOut" 
            BackColor="#FFFF66" BorderColor="#CC9900" BorderStyle="Dotted" 
            Font-Size="Medium" ForeColor="Blue" />
        <br />
        <br />

    <a href="addpost.aspx">Add post</a>
    </div>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    <Scripts>
    <asp:ScriptReference Path="jquery-1.7.js" />
    </Scripts>
    </asp:ScriptManager>

    <div>



        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="5" OnRowDataBound="GridView1_RowDataBound"
           AutoGenerateColumns="false" DataSourceID="BlogDataSource" GridLines="None"
            CssClass="gridview1" BorderStyle="None">
            <Columns>

        <asp:TemplateField HeaderText="That's my blog!" SortExpression="email">
          
            <ItemTemplate>

                 <div style="text-align:center">
                 <asp:Label ID="Label2" runat="server" ForeColor="Orange"
                    Text='<%# Bind("blogID") %>'></asp:Label>

                     <asp:Label ID="Label3" runat="server" ForeColor="Orange"
                    Text='<%# postedDate(Eval("posted")) %>'></asp:Label>
                     <asp:Label ID="Label4" runat="server" ForeColor="Orange"
                    Text='<%# editedDate(Eval("lastedited")) %>'></asp:Label>
                 </div>

          <a href='<%# ConvertURL(Eval("blogID")) %>'>edit</a>
             
              <br />

               
            <%# ConvertFlag(Eval("blogMsgText")) %>



   <p runat="server" class="showcommentclass" id="showcommentclass">Show comments</p>

        <div class="divcomments" id="divcomments">
         <asp:GridView ID="GridView2" runat="server" AllowPaging="true" PageSize="10" ShowHeader="false"
         OnRowCommand="GridView2_RowCommand" GridLines="None"
           AutoGenerateColumns="false" DataSourceID="BlogDataSource2" BorderWidth="0" CssClass="gridview2">
                      <Columns>

        <asp:TemplateField SortExpression="cID">
                   <ItemTemplate>
                        <asp:Label ID="cID" runat="server" ForeColor="Orange" Visible="false"
                    Text='<%# Bind("cID") %>'></asp:Label>
                      <p>
                   <span style="color:Red;font-size:14pt">
                       <%# Eval("commentName") %>
                   </span> 
                       <%# Eval("commentMsgText") %>
                  </p>

                <asp:LinkButton ID="btnDel" runat="server" Width="25" Height="25"
              CommandName="RemoveRecord"
              CommandArgument="<%# ((GridViewRow) Container).RowIndex %>">
              <asp:Image ID="imgFolder" runat="server" ImageUrl="delete.png" BorderWidth="0" />
              </asp:LinkButton>

          

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
            </asp:GridView>

        <asp:EntityDataSource ID="BlogDataSource" runat="server" 
        EntitySetName="blogposts"
            ContextTypeName="blogpostsModel.blogdbEntities" 
            EnableFlattening="False" EnableUpdate="false">
        </asp:EntityDataSource>

     



    </div>


             <script type="text/javascript">


                 $(document).ready(function () {
          
                     $(".divcomments").hide();


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
    
              </script>

    </form>
</body>
</html>
