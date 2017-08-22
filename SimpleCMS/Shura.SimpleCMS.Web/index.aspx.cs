using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shura.SimpleCMS.Web
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("test");
            dt.Columns.Add("ID", typeof(int)); // -> here we add Columns
                                               //every Column must have type 
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add(2015, "hassan");
            dt.Rows.Add(2016, "mohamed"); //here we add the Rows with Colums Data Type

           string tabValue = "\t";
            //tabValue = ";";

            string attachment = "attachment; filename=Try.xls";
            //here we put file name Like this .
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //this is excel format
            string tab = "";
            foreach (DataColumn dc in dt.Columns)
            {
                Response.Write(tab + dc.ColumnName);
                tab = tabValue;
            }
            //This for loop for adding tab between header columns (cells)

            Response.Write("\n");
            //This is For make Endline
            int i;
            foreach (DataRow dr in dt.Rows)
            {
                tab = "";
                for (i = 0; i < dt.Columns.Count; i++)
                {
                    Response.Write(tab + dr[i].ToString());
                    tab = tabValue;
                }
                Response.Write("\n");
            }
            Response.End();
            // here we add the rows one by one in the 2 for loops and then end the Response 


        }
    }
}