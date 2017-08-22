using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Drawing;
namespace Shura.SimpleCMS.Web
{
    public partial class TinymceTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Do_this(object sender, EventArgs e)
        {
            //Literal1.Text = conTiny1.InnerText;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //Literal1.Text = conTiny.Value.ToString();

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Literal1.Text = conTiny1.Value.ToString();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                // Get the file extension
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName);

                if (fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".png")
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Only files with .JPG and .png extension are allowed";
                }
                else
                {
                    // Get the file size
                    int fileSize = FileUpload1.PostedFile.ContentLength;
                    // If file size is greater than 2 MB
                    if (fileSize > 4194304)
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "File size cannot be greater than 4 MB";
                    }
                    else
                    {
                        // Upload the file
                        FileUpload1.SaveAs(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "File uploaded successfully";
                    }
                }



                //tinyMCE.activeEditor.execCommand("mceInsertContent", true, "<img src='" + Server.MapPath("~/Uploads/" + FileUpload1.FileName) + "' alt='Uploaded Image' class='img-responsive' />");
                
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Please select a file";
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "change_isGood()", true);
            Button1_Click1(sender, e);
        }
    }
}