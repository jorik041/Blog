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

using pageGV;

public partial class myblog : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        AppDomain.CurrentDomain.SetData("DataDirectory", Server.MapPath(".") + "\\App_Data");

        if (!IsPostBack)
        {

            refreshcaptcha();

        }

        if (IsPostBack)
        {
            ClientScript.RegisterHiddenField("isPostBack", "1");
        }

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
                pp.InnerText = "Show comments ( "+Convert.ToString(grid2.Rows.Count)+" )";
            }
            else
            {
                pp.InnerText = "";
            }


            } 


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

            convertHTMLcode conv=new convertHTMLcode();
            mesag=conv.convertHTMLtext(mesag);


            var re = new Regex("\'<(?<tag>.*)>\'", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
            mesag = re.Replace(mesag, "&lt;${tag}&gt;");
            re =new Regex("\"<(?<tag>.*)>\"", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
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
        pod="";
             if (value != null)
        {
            pod = "added at: " + value.ToString(); 
             }
             return  pod;
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

       TextBox txtN = (TextBox)Datafld.Controls[15];
        TextBox txtB = (TextBox)Datafld.Controls[17];

        TextBox txtVerify = (TextBox)Datafld.Controls[11];

        if (Session["commentcap"] != null)
        {
            if (txtVerify.Text != Session["commentcap"].ToString())
            {
                txtVerify.Text = "";
                refreshcaptcha();
                return;

            }

        }

        else
        {
            txtVerify.Text = "";
            refreshcaptcha();
            return;
        }





        String stroka;

        stroka = txtB.Text;

        if (stroka.Trim().Length<1) 
            return;

        System.Text.StringBuilder sb2 = new System.Text.StringBuilder(
                  HttpUtility.HtmlEncode(stroka));

        string commm;
        commm = sb2.ToString();
        commm = Regex.Replace(commm, "\\n", "<br />", RegexOptions.IgnoreCase);


        stroka = txtN.Text;
        System.Text.StringBuilder sb3 = new System.Text.StringBuilder(
                  HttpUtility.HtmlEncode(stroka));
        string naaame;
        naaame = sb3.ToString();


        int commmID;
        commmID = Convert.ToInt16(lbl.Text);

        blogpostsModel.blogdbEntities bl = new blogpostsModel.blogdbEntities();
        blogpostsModel.blogcomment po = new blogpostsModel.blogcomment();
        po.commentID =commmID;
        po.commentMsgText = commm;
        po.commentName = naaame;
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


            Response.Redirect(Request.Path);

        }

    }




    protected void RefreshImg(object sender, EventArgs e)
    {

        refreshcaptcha();

    }


    public void GridView1_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        HiddenField1.Value = "0,0,0,0,0";
    }


 protected void refreshcaptcha(){

     Random ran = new Random();

     int no = ran.Next();

     Session["commentcap"] = no.ToString().Substring(1, 3);

     foreach (GridViewRow row in GridView1.Rows)
     {
         Image imc = (Image)row.FindControl("imCaptcha");

         imc.ImageUrl = imc.ImageUrl;

     } 


    }

}