using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.IO;
using System.Text.RegularExpressions;
using System.Web.Security;


public partial class addpost : System.Web.UI.Page
{

    string s;


    protected void Page_Load(object sender, EventArgs e)
    {

        s = Request.QueryString["id"];

        if (s == null)
        {


        }
        else
        {

            btnAddPost.Text ="Update post";

            if (!Page.IsPostBack){

            int requestID;
            requestID = Convert.ToInt16(s);

            blogpostsModel.blogdbEntities bl = new blogpostsModel.blogdbEntities();
            blogpostsModel.blogpost ite = bl.blogposts.First(c => c.blogID == requestID);
            string mesaga;
            mesaga = ite.blogMsgText;

            edited_html.Value = mesaga;

            //ClientScriptManager cs = Page.ClientScript;
            //String csName = "MyScript";
            //Type csType = this.GetType();
            //if (!cs.IsClientScriptBlockRegistered(csType, csName))
            //{
            //    ClientScript.RegisterClientScriptBlock(csType, csName,
            //    "<script type=\"text/javascript\">" +
            //    "alert('fgfg');" +
            //    "</script>");
            //}
     

            }
        }

    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "";

        if (!IsValid)
        {
            return;
        }




        if (FileUpload1.HasFile)
        {


            System.Drawing.Image img = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
            if ((img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid) || (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Gif.Guid) || (img.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Png.Guid))
            {}
            else
            {
                Label1.Text = "Only images are allowed!";
                return;
            }

            string fileExt =System.IO.Path.GetExtension(FileUpload1.FileName);

            fileExt = fileExt.ToUpper();

            if (FileUpload1.PostedFile.ContentType.IndexOf("image") == -1)
            {
                Label1.Text = "Only images are allowed!";
                return;
            }

            if (FileUpload1.PostedFile.ContentLength > 1000000)
            {
                Label1.Text = "File shouldn't be larger than 1 Mb";
                return;
            }

            if ((fileExt == ".JPG")||(fileExt == ".GIF")||(fileExt == ".PNG"))
            {
                try
                {
                    FileUpload1.SaveAs(Server.MapPath(".") + "\\blogimages\\" +
                       FileUpload1.FileName);


                    DIVimages.InnerHtml = "<img class=\"mainimage\" onclick=\"pasteImage('" + "blogimages/" + FileUpload1.FileName + "')\" src=\"" + "blogimages/" + FileUpload1.FileName + "\" alt=\"" + "blogimages/" + FileUpload1.FileName + "\" />";
                    
                }
                catch (Exception ex)
                {
                    Label1.Text = "ERROR: " + ex.Message.ToString();
                }
            }
            else
            {
                Label1.Text = "Only images are allowed!";
            }
        }
        else
        {
            Label1.Text = "You have not select file";
        }

    }

    protected void btnAddPost_Click(object sender, EventArgs e)
    {
         String str;

         str = edited_html.InnerText;
         string mesag = str;

         // we could save database in clean HTML
         
         //System.Text.StringBuilder sb = new System.Text.StringBuilder(
         //          HttpUtility.HtmlEncode(str));
         //string mesag = "";
         //mesag = sb.ToString();
         //convertHTMLcode conv = new convertHTMLcode();
         //mesag = conv.convertHTMLtext(mesag);

         blogpostsModel.blogdbEntities bl = new blogpostsModel.blogdbEntities();

         if (s == null)
         {

             blogpostsModel.blogpost po = new blogpostsModel.blogpost();
             //po.blogID = 3;
             po.blogMsgText = mesag;
             po.posted = DateTime.Now;
             bl.AddToblogposts(po);
             bl.SaveChanges();

         }
         else
         {
             int requestID2;
             requestID2 = Convert.ToInt16(s);

             blogpostsModel.blogpost ite = bl.blogposts.First(c => c.blogID == requestID2);
             ite.blogMsgText = mesag;
             ite.lastedited = DateTime.Now;
             bl.SaveChanges();

         }

         try
         {
             FormsAuthentication.SignOut();
         }
         catch { }

            Response.Redirect("blog.aspx");   

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




}