using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shura.SimpleCMS.DAL;
using Shura.SimpleCMS.Logic;
using System.Security.Cryptography;
using System.Data;

namespace Shura.SimpleCMS.Console
{
    class Program
    {
        private static readonly string Connection = System.Configuration.ConfigurationManager.ConnectionStrings["ShuraSimpleCMSConnectionString"].ConnectionString;

        static void Main(string[] args)
        {
            #region Logging into console and File
            const string fileName = "TextLogger.txt";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            Trace.Listeners.Clear();
            var twtl = new TextWriterTraceListener(fileName)
            {
                Name = fileName.Substring(0, fileName.IndexOf('.')),
                TraceOutputOptions = TraceOptions.ThreadId | TraceOptions.DateTime,
            };

            var ctl = new ConsoleTraceListener(false) { TraceOutputOptions = TraceOptions.DateTime };

            Trace.Listeners.Add(twtl);
            Trace.Listeners.Add(ctl);
            Trace.AutoFlush = true;
            #endregion

            #region Setting the db connection
            ShuraSimpleCMSDatabase.ConnectionString = Connection;
            #endregion

            //Testing methods calls goes here

            //Inserting...

           
            // ShuraSimpleCMSDatabase.ClsLookupTitles lt = new ShuraSimpleCMSDatabase.ClsLookupTitles();

            //ShuraSimpleCMSDatabase.ClsLookupTitles lt1 = new ShuraSimpleCMSDatabase.ClsLookupTitles();

            // This is to Select something then out it in object of ClsLookupTitles
            // ShuraSimpleCMSDatabase.ClsLookupTitles.Functions.GetRecord("[lt_Id] = 1", out lt1);
            //lt.lt_Id = 6;
            //lt.Delete();
            // Trace.WriteLine( Shura.SimpleCMS.Logic.Utility.RandomGenerator.Next(20));
            //string UCanTry = Getmd5("hassan");
            //Trace.WriteLine("this is UCanTry : " + UCanTry);
            using (DataTable dt = new DataTable("test"))
            {
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Rows.Add(55, "hassan");
                dt.Rows.Add(22, "mohamed");
                dt.Rows.Add(11, "ahmed");
                dt.Rows.Add(55, "badry");
                foreach (DataRow dr in dt.Rows)
                {
                    Trace.WriteLine("Name ="+ dr["Name"]+" ID="+dr["ID"]);
                }
            } 
           
            

            //dt = city.GetAllCity();//your datatable
            //string attachment = "attachment; filename=city.xls";
            //Response.ClearContent();
            //Response.AddHeader("content-disposition", attachment);
            //Response.ContentType = "application/vnd.ms-excel";
            //string tab = "";
            //foreach (DataColumn dc in dt.Columns)
            //{
            //    Response.Write(tab + dc.ColumnName);
            //    tab = "\t";
            //}
            //Response.Write("\n");
            //int i;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    tab = "";
            //    for (i = 0; i < dt.Columns.Count; i++)
            //    {
            //        Response.Write(tab + dr[i].ToString());
            //        tab = "\t";
            //    }
            //    Response.Write("\n");
            //}
            //Response.End();


            LoggingSystem.LogError("erorr");
            System.Console.ReadKey();
            //TestDeva1();
            //TestDeva2();


            LoggingExample();
        }

        #region Testing Methods
        /// <summary>
        /// 
        /// </summary>
        static void TestDeva1()
        {
            ArrayList ltr;
            ShuraSimpleCMSDatabase.ClsLookupTitles.Functions.GetAll(out ltr);

            Trace.WriteLine("Lookup titles: ");
            foreach (ShuraSimpleCMSDatabase.ClsLookupTitles record in ltr)
            {
                Trace.WriteLine(record.lt_Id + " - " + record.lt_title);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static void TestDeva2()
        {
            ArrayList ltr;
            ShuraSimpleCMSDatabase.ClsLookupValues.Functions.GetAll(out ltr);

            Trace.WriteLine("Lookup values: ");
            foreach (ShuraSimpleCMSDatabase.ClsLookupValues record in ltr)
            {
                Trace.WriteLine(record.lv_id + " - " + record.lv_value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static void LoggingExample()
        {
            try
            {
                throw new Exception("This is my exception");
            }
            catch (Exception ex)
            {
                LoggingSystem.LogError(ex, "Main - LoggingExample");
                Trace.WriteLine("exception logged!");
            }
            

        }
        #endregion
        static string Getmd5(string stt)
        {

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider() ;
            byte[] hassan;
            hassan = ASCIIEncoding.ASCII.GetBytes(stt);
            md5.ComputeHash(hassan);
            byte[] result = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i =0;i <result.Length;i++)
            {
                
                str.Append(result[i].ToString("x2"));
                Trace.WriteLine(result[i]+"    "+ result[i].ToString("x2"));
            }
        
            return str.ToString();
        }
       
        
    }
   
}
