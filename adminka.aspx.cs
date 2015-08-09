using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using System.Data.Entity;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Web.Security;


public partial class blog : System.Web.UI.Page
{


    //blogdbModel.blogdbEntities blogContext;


    protected void Page_Load(object sender, EventArgs e)
    {


        AppDomain.CurrentDomain.SetData("DataDirectory", Server.MapPath(".") + "\\App_Data");
           

        //blogContext = new blogdbModel.blogdbEntities();
        //blogContext.ContextOptions.LazyLoadingEnabled = true;

        //GridView1.DataSource = blogContext.posts;
        //GridView1.DataBind();

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.DataItem != null)
        {
            GridView grid2 = (GridView)e.Row.FindControl("GridView2");

            HtmlGenericControl pp = (HtmlGenericControl)e.Row.FindControl("showcommentclass");

            if (grid2 == null)
            {
                pp.InnerText = "";
                return;
            }


            if (grid2.Rows.Count > 0)
            {
                pp.InnerText = "Show comments ( " + Convert.ToString(grid2.Rows.Count)+" )";
            }
            else
            {
                pp.InnerText = "";
            }


            } 

    }


    protected void SignOut(object sender, EventArgs e)
    {
        try
        {
            FormsAuthentication.SignOut();
            Response.Redirect(Request.UrlReferrer.ToString());
        }
        catch { }

    }



    protected override void OnUnload(EventArgs e)
    {
        //blogContext.Dispose();
    }

    protected string ConvertURL(object value)
    {
        return "addpost.aspx?id=" + value;
    }


    protected string ConvertFlag(object value)
    {

        if (value != null)
        {

            System.Text.StringBuilder sb = new System.Text.StringBuilder(
                   HttpUtility.HtmlEncode(value));

            string mesag = "";
            mesag = sb.ToString();

            convertHTMLcode conv = new convertHTMLcode();
            mesag = conv.convertHTMLtext(mesag);

            var re = new Regex("\'<(?<tag>.*)>\'", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
            mesag = re.Replace(mesag, "&lt;${tag}&gt;");
            re = new Regex("\"<(?<tag>.*)>\"", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
            mesag = re.Replace(mesag, "&lt;${tag}&gt;");

            //mesag = Regex.Replace(mesag, "'<", "&lt;", RegexOptions.IgnoreCase);
            //mesag = Regex.Replace(mesag, ">'", "&gt;", RegexOptions.IgnoreCase);
            //mesag = Regex.Replace(mesag, "\"<", "&lt;", RegexOptions.IgnoreCase);
            //mesag = Regex.Replace(mesag, ">\"", "&gt;", RegexOptions.IgnoreCase);

            mesag = Regex.Replace(mesag, "frame", "&#102;rame", RegexOptions.IgnoreCase);
            mesag = Regex.Replace(mesag, "object", "&#111;bject", RegexOptions.IgnoreCase);
            mesag = Regex.Replace(mesag, "script", "&#115;cript", RegexOptions.None);
            mesag = Regex.Replace(mesag, "Script", "&#83;cript", RegexOptions.None);
            return mesag;

        }

        return "";
    }


    protected string postedDate(object value)
    {
        string pod;
        pod = "";
        if (value != null)
        {
            pod = "added at: " + value.ToString();
        }
        return pod;
    }
    protected string editedDate(object value)
    {
        string pod;
        pod = "";
        if (value != null)
        {
            pod = "   edited at: " + value.ToString();
        }
        return pod;
    }



    protected void ShowAddComment(object sender, EventArgs e)
    {
          Button btn = (Button)sender;

        GridViewRow row = (GridViewRow)btn.NamingContainer;

        DataControlFieldCell Datafld = (DataControlFieldCell)row.Controls[0];

        TextBox txtB = (TextBox)Datafld.Controls[3];
        Button btnB = (Button)Datafld.Controls[5];

        btnB.Visible = true;
        txtB.Visible = true;

        btn.Visible = false;
    }


    protected void addComment(object sender, EventArgs e)
    {

        Button btn = (Button)sender;

        GridViewRow row = (GridViewRow)btn.NamingContainer;

        DataControlFieldCell Datafld = (DataControlFieldCell)row.Controls[0];

        Label lbl = (Label)Datafld.Controls[1];

        TextBox txtB = (TextBox)Datafld.Controls[3];


        String stroka;

        stroka = txtB.Text;

        if (stroka.Trim().Length<1) 
            return;

        System.Text.StringBuilder sb2 = new System.Text.StringBuilder(
                  HttpUtility.HtmlEncode(stroka));

        string commm;
        commm = sb2.ToString();
        commm = Regex.Replace(commm, "\\n", "<br />", RegexOptions.IgnoreCase);

        int commmID;
        commmID = Convert.ToInt16(lbl.Text);

        blogpostsModel.blogdbEntities bl = new blogpostsModel.blogdbEntities();
        blogpostsModel.blogcomment po = new blogpostsModel.blogcomment();
        po.commentID =commmID;
        po.commentMsgText = commm;
        bl.AddToblogcomments(po);
        bl.SaveChanges();


        Response.Redirect(Request.Path);

    }



    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "RemoveRecord")
        {
       
        string lbltext;
            try
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridView gr = sender as GridView; 
                GridViewRow row = gr.Rows[index];

               Label lbl = row.FindControl("cID") as Label;
                lbltext = lbl.Text.Trim();
            }
            catch {
                return; 
            }


            blogpostsModel.blogdbEntities bl = new blogpostsModel.blogdbEntities();

            blogpostsModel.blogcomment bc = new blogpostsModel.blogcomment();

            // remove using command
            string qStr = "Delete FROM blogcomments where cID="+lbltext;
            bl.ExecuteStoreCommand(qStr);
            bl.SaveChanges();


            // remove using entity
            //try
            //{
            //    var itm = (from item in bl.blogcoments where item.cID == 9 select item).First();
            //    if (itm!=null){
            //    bl.DeleteObject(itm);
            //    bl.SaveChanges();
            //}
            //}
            //catch { }


            Response.Redirect(Request.Path);

        }

    }


}