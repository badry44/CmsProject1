// ***************************************************************************************************************************
// * Auto generated file by DevA code generator version 01.01.02, Shura technologies all rights reserved                     *
// * WARNING: deleting or modifying generated code may compromise its integerity                                             *
// * File creation timestamp: 7/25/2017 3:29:12 PM                                                                           *
// *                                                                                                                         *
// * Created by Generator build date: April 23rd, 2008                                                                       *
// ***************************************************************************************************************************
using System;
using System.Collections;
using System.Windows.Forms;
using GenericDBEngine;
using System.Drawing;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace Shura.SimpleCMS.DAL
{



    public static class ShuraSimpleCMSDatabase
    {
        private static string connectionString = "Data Source=.\\MSSQLSERVER12;Initial Catalog=ShuraSimpleCMS;Integrated Security=False;User Id=sa;Password=root;";
        private const string formatFileTimeStamp = "yyyyMMddHHmmssfff";


        public static string ConnectionString
        {
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
                sqlEngine = new SqlEngine(connectionString);
            }
        }

        private static string logFile = Application.StartupPath + "\\Error.log";
        public enum RowOperations
        {
            Add = 1, Delete, Update
        }

        public static SqlEngine sqlEngine = new SqlEngine(connectionString);

        #region Table Names

        public static class Table_Names
        {
            public static string LookupTitles
            {
                get
                {
                    return "LookupTitles";
                }
            }
            public static string LookupValues
            {
                get
                {
                    return "LookupValues";
                }
            }
            public static string Pages
            {
                get
                {
                    return "Pages";
                }
            }
            public static string PagesContents
            {
                get
                {
                    return "PagesContents";
                }
            }
            public static string Users
            {
                get
                {
                    return "Users";
                }
            }
        }

        #endregion

        public static bool DoTransactions(ArrayList transactions)
        {
            SqlConnection con = null;
            SqlCommand com = null;
            SqlTransaction transaction = null;
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                transaction = con.BeginTransaction();
                com = new SqlCommand();
                com.Connection = con;
                com.Transaction = transaction;
                foreach (string command in transactions)
                {
                    com.CommandText = command;
                    com.ExecuteNonQuery();
                }
                transaction.Commit();
                con.Close();
                return true;
            }
            catch (Exception commitException)
            {
                LogError("At:" + DateTime.Now + "\tError:" + commitException.Message + "\t+StackTrace:" + commitException.StackTrace);
                try
                {
                    if (transaction != null)
                        transaction.Rollback();
                    if (con != null)
                        con.Close();
                }
                catch (Exception ex)
                {
                    LogError("At:" + DateTime.Now + "\tError:" + ex.Message + "\t+StackTrace:" + ex.StackTrace);
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
            }
            return false;
        }

        public static bool DoTransactions(ArrayList transactions, ArrayList parameters)
        {
            SqlConnection con = null;
            SqlCommand com = null;
            SqlTransaction transaction = null;
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                transaction = con.BeginTransaction();
                com = new SqlCommand();
                com.Connection = con;
                com.Transaction = transaction;
                int i = 0;
                foreach (string command in transactions)
                {
                    com.CommandText = command;
                    com.Parameters.Clear();
                    foreach (SqlParameter sqlPar in (ArrayList)parameters[i])
                        com.Parameters.Add(sqlPar);
                    com.ExecuteNonQuery();
                    i++;
                }
                transaction.Commit();
                con.Close();
                return true;
            }
            catch (Exception commitException)
            {
                try
                {
                    if (transaction != null)
                        transaction.Rollback();
                    if (con != null)
                        con.Close();
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
            }
            return false;
        }

        public static void LogError(string errorData)
        {
            FileInfo file = new FileInfo(logFile);
            if (file.Exists)
                if (file.Length > 512 * 1024)
                    try
                    {
                        file.Delete();
                    }
                    catch { }
            try
            {
                File.AppendAllText(logFile, DateTime.Now.ToString(formatFileTimeStamp) + ":" + errorData + Environment.NewLine + Environment.NewLine);
            }
            catch
            { }
        }
        public static void LogError(string errorData, string logFile)
        {
            FileInfo file = new FileInfo(logFile);
            if (file.Exists)
                if (file.Length > 512 * 1024)
                    try
                    {
                        file.Delete();
                    }
                    catch { }
            try
            {
                File.AppendAllText(logFile, DateTime.Now.ToString(formatFileTimeStamp) + ":" + errorData + Environment.NewLine + Environment.NewLine);
            }
            catch
            { }
        }
        #region Debugging variables

        public static bool debugExceptionsMode = false;
        public static bool debugMode = false;

        #endregion


        #region Classes

        #region LookupTitles

        [Serializable]
        public class ClsLookupTitles
        {
            private string basicQueryString = "SELECT * FROM [LookupTitles]";

            public ClsLookupTitles() { }
            public ClsLookupTitles(short lt_Id)
            {
                this.lt_Id = lt_Id;
            }

            public ArrayList relationshipChecks = new ArrayList();

            public bool DependanciesExist(out bool dependancyExists)
            {
                dependancyExists = true;
                try
                {
                    foreach (string selectStatement in relationshipChecks)
                    {
                        if (!sqlEngine.DataExists(selectStatement, out dependancyExists))
                            return false;
                        if (dependancyExists)
                            return true;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }

            public override string ToString()
            {
                return "LookupTitles";
            }


            public string BasicQueryString
            {
                get
                {
                    return basicQueryString;
                }
                set
                {
                    basicQueryString = value;
                }
            }

            #region Column Names

            public static class Column_Names
            {
                public static string lt_Id
                {
                    get
                    {
                        return "lt_Id";
                    }
                }
                public static string lt_title
                {
                    get
                    {
                        return "lt_title";
                    }
                }
                public static string lt_title_ar
                {
                    get
                    {
                        return "lt_title_ar";
                    }
                }
            }

            #endregion

            #region Data Fields


            private short df_lt_Id;
            public bool lt_Id_changed = false;
            public short lt_Id
            {
                get
                {
                    return df_lt_Id;
                }
                set
                {
                    df_lt_Id = value;
                    oldData.lt_Id = value;
                }
            }

            private string df_lt_title;
            public bool lt_title_changed = false;
            public string lt_title
            {
                get
                {
                    return df_lt_title;
                }
                set
                {
                    if (oldData.lt_title != value)
                    {
                        df_lt_title = value;
                        oldData.lt_title = value;
                        lt_title_changed = true;
                    }
                }
            }

            private string df_lt_title_ar;
            public bool lt_title_ar_changed = false;
            public string lt_title_ar
            {
                get
                {
                    return df_lt_title_ar;
                }
                set
                {
                    if (oldData.lt_title_ar != value)
                    {
                        df_lt_title_ar = value;
                        oldData.lt_title_ar = value;
                        lt_title_ar_changed = true;
                    }
                }
            }


            #endregion

            public void ResetChangesFlags()
            {
                lt_Id_changed = false;
                lt_title_changed = false;
                lt_title_ar_changed = false;
            }

            #region OldData Class

            [Serializable]
            private class OldData
            {
                public short lt_Id = new short();
                public string lt_title;
                public string lt_title_ar;
            }

            #endregion

            private OldData oldData = new OldData();

            #region Static Get Functions

            public static class Functions
            {
                public static bool GetRecord(string condition, out ClsLookupTitles LookupTitles)
                {
                    LookupTitles = new ClsLookupTitles();
                    string sqlString = "SELECT * FROM [LookupTitles]";
                    sqlString += " WHERE " + condition;
                    try
                    {
                        SqlEngine sqlEngine = new SqlEngine(connectionString);
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        if (dr.Read())
                        {
                            if (!Convert.IsDBNull(dr["lt_Id"]))
                            {
                                LookupTitles.lt_Id = Convert.ToInt16(dr["lt_Id"].ToString());
                            }
                            else
                                LookupTitles.lt_Id = 0;
                            LookupTitles.oldData.lt_Id = LookupTitles.lt_Id;
                            if (!Convert.IsDBNull(dr["lt_title"]))
                            {
                                LookupTitles.lt_title = Convert.ToString(dr["lt_title"].ToString());
                            }
                            else
                                LookupTitles.lt_title = null;
                            LookupTitles.oldData.lt_title = LookupTitles.lt_title;
                            if (!Convert.IsDBNull(dr["lt_title_ar"]))
                            {
                                LookupTitles.lt_title_ar = Convert.ToString(dr["lt_title_ar"].ToString());
                            }
                            else
                                LookupTitles.lt_title_ar = null;
                            LookupTitles.oldData.lt_title_ar = LookupTitles.lt_title_ar;
                            LookupTitles.ResetChangesFlags();
                        }
                        else
                            LookupTitles = null;
                        dr.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (debugMode)
                            MessageBox.Show(ex.Message);
                        if (debugExceptionsMode)
                            throw ex;
                    }
                    LookupTitles = null;
                    return false;
                }
                public static bool GetRecords(string condition, out ArrayList LookupTitlesRecords)
                {
                    ClsLookupTitles LookupTitles;
                    LookupTitlesRecords = new ArrayList();
                    string sqlString = "SELECT * FROM [LookupTitles]";
                    sqlString += " WHERE " + condition;
                    try
                    {
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        while (dr.Read())
                        {
                            LookupTitles = new ClsLookupTitles();
                            if (!Convert.IsDBNull(dr["lt_Id"]))
                            {
                                LookupTitles.lt_Id = Convert.ToInt16(dr["lt_Id"].ToString());
                            }
                            else
                                LookupTitles.lt_Id = 0;
                            LookupTitles.oldData.lt_Id = LookupTitles.lt_Id;
                            if (!Convert.IsDBNull(dr["lt_title"]))
                            {
                                LookupTitles.lt_title = Convert.ToString(dr["lt_title"].ToString());
                            }
                            else
                                LookupTitles.lt_title = null;
                            LookupTitles.oldData.lt_title = LookupTitles.lt_title;
                            if (!Convert.IsDBNull(dr["lt_title_ar"]))
                            {
                                LookupTitles.lt_title_ar = Convert.ToString(dr["lt_title_ar"].ToString());
                            }
                            else
                                LookupTitles.lt_title_ar = null;
                            LookupTitles.oldData.lt_title_ar = LookupTitles.lt_title_ar;
                            LookupTitles.ResetChangesFlags();
                            LookupTitlesRecords.Add(LookupTitles);
                        }
                        dr.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (debugMode)
                            MessageBox.Show(ex.Message);
                        if (debugExceptionsMode)
                            throw ex;
                    }
                    return false;
                }
                public static bool GetAll(out ArrayList LookupTitlesRecords)
                {
                    ClsLookupTitles LookupTitles;
                    LookupTitlesRecords = new ArrayList();
                    string sqlString = "SELECT * FROM [LookupTitles]";
                    try
                    {
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        while (dr.Read())
                        {
                            LookupTitles = new ClsLookupTitles();
                            if (!Convert.IsDBNull(dr["lt_Id"]))
                            {
                                LookupTitles.lt_Id = Convert.ToInt16(dr["lt_Id"].ToString());
                            }
                            else
                                LookupTitles.lt_Id = 0;
                            LookupTitles.oldData.lt_Id = LookupTitles.lt_Id;
                            if (!Convert.IsDBNull(dr["lt_title"]))
                            {
                                LookupTitles.lt_title = Convert.ToString(dr["lt_title"].ToString());
                            }
                            else
                                LookupTitles.lt_title = null;
                            LookupTitles.oldData.lt_title = LookupTitles.lt_title;
                            if (!Convert.IsDBNull(dr["lt_title_ar"]))
                            {
                                LookupTitles.lt_title_ar = Convert.ToString(dr["lt_title_ar"].ToString());
                            }
                            else
                                LookupTitles.lt_title_ar = null;
                            LookupTitles.oldData.lt_title_ar = LookupTitles.lt_title_ar;
                            LookupTitles.ResetChangesFlags();
                            LookupTitlesRecords.Add(LookupTitles);
                        }
                        dr.Close();
                        if (LookupTitlesRecords.Count == 0)
                            LookupTitles = null;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (debugMode)
                            MessageBox.Show(ex.Message);
                        if (debugExceptionsMode)
                            throw ex;
                    }
                    return false;
                }
            }

            #endregion

            #region Non-static Get Functions

            public bool GetRecord(SqlDataReader dr, out ClsLookupTitles LookupTitles)
            {
                LookupTitles = new ClsLookupTitles();
                try
                {
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["lt_Id"]))
                        {
                            LookupTitles.lt_Id = Convert.ToInt16(dr["lt_Id"].ToString());
                        }
                        else
                            LookupTitles.lt_Id = 0;
                        LookupTitles.oldData.lt_Id = LookupTitles.lt_Id;
                        if (!Convert.IsDBNull(dr["lt_title"]))
                        {
                            LookupTitles.lt_title = Convert.ToString(dr["lt_title"].ToString());
                        }
                        else
                            LookupTitles.lt_title = null;
                        LookupTitles.oldData.lt_title = LookupTitles.lt_title;
                        if (!Convert.IsDBNull(dr["lt_title_ar"]))
                        {
                            LookupTitles.lt_title_ar = Convert.ToString(dr["lt_title_ar"].ToString());
                        }
                        else
                            LookupTitles.lt_title_ar = null;
                        LookupTitles.oldData.lt_title_ar = LookupTitles.lt_title_ar;
                        LookupTitles.ResetChangesFlags();
                    }
                    else
                        LookupTitles = null;
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                LookupTitles = null;
                return false;
            }
            public bool GetRecord(string condition, out ClsLookupTitles LookupTitles)
            {
                string sqlString = "SELECT * FROM [LookupTitles]";
                sqlString += " WHERE " + condition;
                LookupTitles = new ClsLookupTitles();
                try
                {
                    SqlEngine sqlEngine = new SqlEngine(connectionString);
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["lt_Id"]))
                        {
                            LookupTitles.lt_Id = Convert.ToInt16(dr["lt_Id"].ToString());
                        }
                        else
                            LookupTitles.lt_Id = 0;
                        LookupTitles.oldData.lt_Id = LookupTitles.lt_Id;
                        if (!Convert.IsDBNull(dr["lt_title"]))
                        {
                            LookupTitles.lt_title = Convert.ToString(dr["lt_title"].ToString());
                        }
                        else
                            LookupTitles.lt_title = null;
                        LookupTitles.oldData.lt_title = LookupTitles.lt_title;
                        if (!Convert.IsDBNull(dr["lt_title_ar"]))
                        {
                            LookupTitles.lt_title_ar = Convert.ToString(dr["lt_title_ar"].ToString());
                        }
                        else
                            LookupTitles.lt_title_ar = null;
                        LookupTitles.oldData.lt_title_ar = LookupTitles.lt_title_ar;
                        LookupTitles.ResetChangesFlags();
                    }
                    else
                        LookupTitles = null;
                    dr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                LookupTitles = null;
                return false;
            }
            public bool GetRecord()
            {
                try
                {
                    string whereCondition = " WHERE ";
                    whereCondition += "lt_Id='" + df_lt_Id + "' AND ";
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                    string sqlString = "SELECT * FROM [LookupTitles]" + whereCondition;
                    try
                    {
                        SqlEngine sqlEngine = new SqlEngine(connectionString);
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        if (dr.Read())
                        {
                            if (!Convert.IsDBNull(dr["lt_Id"]))
                            {
                                lt_Id = Convert.ToInt16(dr["lt_Id"].ToString());
                            }
                            else
                                lt_Id = 0;
                            oldData.lt_Id = lt_Id;
                            if (!Convert.IsDBNull(dr["lt_title"]))
                            {
                                lt_title = Convert.ToString(dr["lt_title"].ToString());
                            }
                            else
                                lt_title = null;
                            oldData.lt_title = lt_title;
                            if (!Convert.IsDBNull(dr["lt_title_ar"]))
                            {
                                lt_title_ar = Convert.ToString(dr["lt_title_ar"].ToString());
                            }
                            else
                                lt_title_ar = null;
                            oldData.lt_title_ar = lt_title_ar;
                            ResetChangesFlags();
                        }
                        else
                            throw new Exception("Record not found");
                        dr.Close();
                        return true;
                    }
                    catch (Exception InnerEx)
                    {
                        if (debugMode)
                            MessageBox.Show(InnerEx.Message);
                        if (debugExceptionsMode)
                            throw InnerEx;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool GetRecord(out ClsLookupTitles LookupTitles)
            {
                string whereCondition = " WHERE ";
                whereCondition += "lt_Id='" + df_lt_Id + "' AND ";
                whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                LookupTitles = new ClsLookupTitles(df_lt_Id);
                string sqlString = "SELECT * FROM [LookupTitles]" + whereCondition;
                try
                {
                    SqlEngine sqlEngine = new SqlEngine(connectionString);
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["lt_Id"]))
                        {
                            LookupTitles.lt_Id = Convert.ToInt16(dr["lt_Id"].ToString());
                        }
                        else
                            LookupTitles.lt_Id = 0;
                        LookupTitles.oldData.lt_Id = LookupTitles.lt_Id;
                        if (!Convert.IsDBNull(dr["lt_title"]))
                        {
                            LookupTitles.lt_title = Convert.ToString(dr["lt_title"].ToString());
                        }
                        else
                            LookupTitles.lt_title = null;
                        LookupTitles.oldData.lt_title = LookupTitles.lt_title;
                        if (!Convert.IsDBNull(dr["lt_title_ar"]))
                        {
                            LookupTitles.lt_title_ar = Convert.ToString(dr["lt_title_ar"].ToString());
                        }
                        else
                            LookupTitles.lt_title_ar = null;
                        LookupTitles.oldData.lt_title_ar = LookupTitles.lt_title_ar;
                        LookupTitles.ResetChangesFlags();
                    }
                    else
                        LookupTitles = null;
                    dr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                LookupTitles = null;
                return false;
            }
            public bool GetRecords(string condition, out ArrayList LookupTitlesRecords)
            {
                ClsLookupTitles LookupTitles;
                LookupTitlesRecords = new ArrayList();
                string sqlString = "SELECT * FROM [LookupTitles]";
                sqlString += " WHERE " + condition;
                try
                {
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    while (dr.Read())
                    {
                        LookupTitles = new ClsLookupTitles();
                        if (!Convert.IsDBNull(dr["lt_Id"]))
                        {
                            LookupTitles.lt_Id = Convert.ToInt16(dr["lt_Id"].ToString());
                        }
                        else
                            LookupTitles.lt_Id = 0;
                        LookupTitles.oldData.lt_Id = LookupTitles.lt_Id;
                        if (!Convert.IsDBNull(dr["lt_title"]))
                        {
                            LookupTitles.lt_title = Convert.ToString(dr["lt_title"].ToString());
                        }
                        else
                            LookupTitles.lt_title = null;
                        LookupTitles.oldData.lt_title = LookupTitles.lt_title;
                        if (!Convert.IsDBNull(dr["lt_title_ar"]))
                        {
                            LookupTitles.lt_title_ar = Convert.ToString(dr["lt_title_ar"].ToString());
                        }
                        else
                            LookupTitles.lt_title_ar = null;
                        LookupTitles.oldData.lt_title_ar = LookupTitles.lt_title_ar;
                        LookupTitles.ResetChangesFlags();
                        LookupTitlesRecords.Add(LookupTitles);
                    }
                    dr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool GetAll(out ArrayList LookupTitlesRecords)
            {
                ClsLookupTitles LookupTitles;
                LookupTitlesRecords = new ArrayList();
                string sqlString = "SELECT * FROM [LookupTitles]";
                try
                {
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    while (dr.Read())
                    {
                        LookupTitles = new ClsLookupTitles();
                        if (!Convert.IsDBNull(dr["lt_Id"]))
                        {
                            LookupTitles.lt_Id = Convert.ToInt16(dr["lt_Id"].ToString());
                        }
                        else
                            LookupTitles.lt_Id = 0;
                        LookupTitles.oldData.lt_Id = LookupTitles.lt_Id;
                        if (!Convert.IsDBNull(dr["lt_title"]))
                        {
                            LookupTitles.lt_title = Convert.ToString(dr["lt_title"].ToString());
                        }
                        else
                            LookupTitles.lt_title = null;
                        LookupTitles.oldData.lt_title = LookupTitles.lt_title;
                        if (!Convert.IsDBNull(dr["lt_title_ar"]))
                        {
                            LookupTitles.lt_title_ar = Convert.ToString(dr["lt_title_ar"].ToString());
                        }
                        else
                            LookupTitles.lt_title_ar = null;
                        LookupTitles.oldData.lt_title_ar = LookupTitles.lt_title_ar;
                        LookupTitles.ResetChangesFlags();
                        LookupTitlesRecords.Add(LookupTitles);
                    }
                    dr.Close();
                    if (LookupTitlesRecords.Count == 0)
                        LookupTitles = null;
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool GetNext(string colName, string cmpValue, out ClsLookupTitles nextRecord)
            {
                return GetRecord(colName + ">'" + cmpValue + "' ORDER BY " + colName, out nextRecord);
            }
            public bool GetNext(string colName, string cmpValue, string sqlCondition, out ClsLookupTitles nextRecord)
            {
                return GetRecord(colName + ">'" + cmpValue + "' AND " + sqlCondition + " ORDER BY " + colName, out nextRecord);
            }
            public bool GetPrevious(string colName, string cmpValue, out ClsLookupTitles prevRecord)
            {
                return GetRecord(colName + "<'" + cmpValue + "' ORDER BY " + colName + " DESC", out prevRecord);
            }
            public bool GetPrevious(string colName, string cmpValue, string sqlCondition, out ClsLookupTitles prevRecord)
            {
                return GetRecord(colName + "<'" + cmpValue + "' AND " + sqlCondition + " ORDER BY " + colName + " DESC", out prevRecord);
            }
            public bool GetFirst(string colName, out ClsLookupTitles firstRecord)
            {
                firstRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [LookupTitles] ORDER BY " + colName, out dr))
                    return false;
                if (!GetRecord(dr, out firstRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }
            public bool GetFirst(string colName, string sqlCondition, out ClsLookupTitles firstRecord)
            {
                firstRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [LookupTitles] WHERE " + sqlCondition
                    + " ORDER BY " + colName, out dr))
                    return false;
                if (!GetRecord(dr, out firstRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }
            public bool GetLast(string colName, out ClsLookupTitles lastRecord)
            {
                lastRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [LookupTitles] ORDER BY " + colName + " DESC", out dr))
                    return false;
                if (!GetRecord(dr, out lastRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }
            public bool GetLast(string colName, string sqlCondition, out ClsLookupTitles lastRecord)
            {
                lastRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [LookupTitles] WHERE " + sqlCondition
                    + " ORDER BY " + colName + " DESC", out dr))
                    return false;
                if (!GetRecord(dr, out lastRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }

            #endregion

            #region Row Operations


            public bool Add()
            {
                string sqlString;
                string values = "";
                string fields = "";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    if (lt_title_changed)
                    {
                        fields += "lt_title,";
                        values += "N'" + lt_title + "',";
                    }
                    if (lt_title_ar_changed)
                    {
                        fields += "lt_title_ar,";
                        values += "N'" + lt_title_ar + "',";
                    }

                    #endregion
                    if (fields == "")
                        return true;
                    fields = fields.Substring(0, fields.Length - 1);
                    values = values.Substring(0, values.Length - 1);
                    sqlString = "INSERT INTO [LookupTitles] (" + fields + ") VALUES (" + values + ") select @@identity";
                    if (sqlPars.Count == 0)
                    {
                        lt_Id = short.Parse(sqlEngine.NonQueryCommand(sqlString, sqlPars).ToString());
                        if (lt_Id <= 0)
                        	throw new Exception("Error in Add function, can not execute sql statement");
                    }
                    else
                        if (!sqlEngine.NonQueryCommand(sqlString, sqlPars))
                        throw new Exception("Error in Add function, can not execute sql statement");

                    #region Set old field variables

                    oldData.lt_Id = lt_Id;
                    oldData.lt_title = lt_title;
                    oldData.lt_title_ar = lt_title_ar;

                    #endregion

                    ResetChangesFlags();
                    if (!sqlEngine.GetTopRecordID("[LookupTitles]", "lt_Id", out df_lt_Id))
                        throw new Exception("Error in Add function, can't read id");
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool AddSqlCommands(ref ArrayList transactions, ref ArrayList parameters)
            {
                string sqlString;
                string values = "";
                string fields = "";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    if (lt_title_changed)
                    {
                        fields += "lt_title,";
                        values += "N'" + lt_title + "',";
                    }
                    if (lt_title_ar_changed)
                    {
                        fields += "lt_title_ar,";
                        values += "N'" + lt_title_ar + "',";
                    }

                    #endregion
                    if (fields == "")
                        return true;
                    fields = fields.Substring(0, fields.Length - 1);
                    values = values.Substring(0, values.Length - 1);
                    sqlString = "INSERT INTO [LookupTitles] (" + fields + ") VALUES (" + values + ")";
                    transactions.Add(sqlString);
                    parameters.Add(sqlPars);

                    #region Set old field variables

                    oldData.lt_Id = lt_Id;
                    oldData.lt_title = lt_title;
                    oldData.lt_title_ar = lt_title_ar;

                    #endregion

                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool Delete()
            {
                #region Condition(s)


                #endregion
                string sqlString = "DELETE FROM [LookupTitles] WHERE lt_Id='" + lt_Id + "' AND ";
                sqlString = sqlString.Substring(0, sqlString.Length - 5);
                try
                {
                    //lt_Id = short.Parse(sqlEngine.NonQueryCommand(sqlString, sqlPars).ToString());
                      //  if (lt_Id <= 0)
                        //	throw new Exception("Error in Add function, can not execute sql statement");
                    if (!sqlEngine.NonQueryCommand(sqlString))
                        throw new Exception("Error in Delete function");
                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool DeleteSqlCommands(ref ArrayList transactions, ref ArrayList parameters)
            {
                #region Value updates


                #endregion
                string sqlString = "DELETE FROM [LookupTitles] WHERE lt_Id='" + lt_Id + "' AND ";
                sqlString = sqlString.Substring(0, sqlString.Length - 5);
                try
                {
                    transactions.Add(sqlString);
                    parameters.Add(new ArrayList());
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool Update()
            {
                string sqlString = "UPDATE [LookupTitles] SET ";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    string values = "";
                    #region Lt_Id


                    #endregion
                    #region Lt_title

                    if (lt_title_changed)
                    {
                        if (df_lt_title == null)
                        {
                            values += "lt_title=null,";
                        }
                        else
                        {
                            values += "lt_title=N'" + df_lt_title + "',";
                        }
                    }

                    #endregion
                    #region Lt_title_ar

                    if (lt_title_ar_changed)
                    {
                        if (df_lt_title_ar == null)
                        {
                            values += "lt_title_ar=null,";
                        }
                        else
                        {
                            values += "lt_title_ar=N'" + df_lt_title_ar + "',";
                        }
                    }

                    #endregion
                    if (values == "")
                        return true;
                    sqlString += values;

                    #endregion
                    if (sqlString[sqlString.Length - 1] == ',')
                        sqlString = sqlString.Substring(0, sqlString.Length - 1);
                    string whereCondition = " WHERE ";
                    whereCondition += "lt_Id='" + df_lt_Id + "' AND ";
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                    sqlString += whereCondition;
                    if (sqlPars.Count == 0)
                    {
                        if (!sqlEngine.NonQueryCommand(sqlString))
                            throw new Exception("Error in Update function");
                    }
                    else
                        if (!sqlEngine.NonQueryCommand(sqlString, sqlPars))
                        throw new Exception("Error in Update function");
                    oldData.lt_Id = lt_Id;
                    oldData.lt_title = lt_title;
                    oldData.lt_title_ar = lt_title_ar;
                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool UpdateSqlCommands(ref ArrayList transactions, ref ArrayList parameters)
            {
                string sqlString = "UPDATE [LookupTitles] SET ";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    string values = "";
                    if (lt_title_changed)
                    {
                        if (df_lt_title == null)
                        {
                            values += "lt_title=null,";
                        }
                        else
                        {
                            values += "lt_title=N'" + df_lt_title + "',";
                        }
                    }
                    if (lt_title_ar_changed)
                    {
                        if (df_lt_title_ar == null)
                        {
                            values += "lt_title_ar=null,";
                        }
                        else
                        {
                            values += "lt_title_ar=N'" + df_lt_title_ar + "',";
                        }
                    }
                    if (values == "")
                        return true;
                    sqlString += values;

                    #endregion
                    if (sqlString[sqlString.Length - 1] == ',')
                        sqlString = sqlString.Substring(0, sqlString.Length - 1);
                    string whereCondition = " WHERE ";
                    whereCondition += "lt_Id='" + df_lt_Id + "' AND ";
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                    sqlString += whereCondition;
                    transactions.Add(sqlString);
                    parameters.Add(sqlPars);
                    oldData.lt_Id = lt_Id;
                    oldData.lt_title = lt_title;
                    oldData.lt_title_ar = lt_title_ar;
                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }

            #endregion
        }

        #endregion

        #region LookupValues

        [Serializable]
        public class ClsLookupValues
        {
            private string basicQueryString = "SELECT * FROM [LookupValues]";

            public ClsLookupValues() { }
            public ClsLookupValues(short lv_id)
            {
                this.lv_id = lv_id;
            }

            public ArrayList relationshipChecks = new ArrayList();

            public bool DependanciesExist(out bool dependancyExists)
            {
                dependancyExists = true;
                try
                {
                    foreach (string selectStatement in relationshipChecks)
                    {
                        if (!sqlEngine.DataExists(selectStatement, out dependancyExists))
                            return false;
                        if (dependancyExists)
                            return true;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }

            public override string ToString()
            {
                return "LookupValues";
            }


            public string BasicQueryString
            {
                get
                {
                    return basicQueryString;
                }
                set
                {
                    basicQueryString = value;
                }
            }

            #region Column Names

            public static class Column_Names
            {
                public static string lv_id
                {
                    get
                    {
                        return "lv_id";
                    }
                }
                public static string lv_lt_id
                {
                    get
                    {
                        return "lv_lt_id";
                    }
                }
                public static string lv_value
                {
                    get
                    {
                        return "lv_value";
                    }
                }
                public static string lv_value_ar
                {
                    get
                    {
                        return "lv_value_ar";
                    }
                }
            }

            #endregion

            #region Data Fields


            private short df_lv_id;
            public bool lv_id_changed = false;
            public short lv_id
            {
                get
                {
                    return df_lv_id;
                }
                set
                {
                    df_lv_id = value;
                    oldData.lv_id = value;
                }
            }

            private short df_lv_lt_id;
            public bool lv_lt_id_changed = false;
            public short lv_lt_id
            {
                get
                {
                    return df_lv_lt_id;
                }
                set
                {
                    df_lv_lt_id = value;
                    oldData.lv_lt_id = value;
                    lv_lt_id_changed = true;
                }
            }

            private string df_lv_value;
            public bool lv_value_changed = false;
            public string lv_value
            {
                get
                {
                    return df_lv_value;
                }
                set
                {
                    if (oldData.lv_value != value)
                    {
                        df_lv_value = value;
                        oldData.lv_value = value;
                        lv_value_changed = true;
                    }
                }
            }

            private string df_lv_value_ar;
            public bool lv_value_ar_changed = false;
            public string lv_value_ar
            {
                get
                {
                    return df_lv_value_ar;
                }
                set
                {
                    if (oldData.lv_value_ar != value)
                    {
                        df_lv_value_ar = value;
                        oldData.lv_value_ar = value;
                        lv_value_ar_changed = true;
                    }
                }
            }


            #endregion

            public void ResetChangesFlags()
            {
                lv_id_changed = false;
                lv_lt_id_changed = false;
                lv_value_changed = false;
                lv_value_ar_changed = false;
            }

            #region OldData Class

            [Serializable]
            private class OldData
            {
                public short lv_id = new short();
                public short lv_lt_id = new short();
                public string lv_value;
                public string lv_value_ar;
            }

            #endregion

            private OldData oldData = new OldData();

            #region Static Get Functions

            public static class Functions
            {
                public static bool GetRecord(string condition, out ClsLookupValues LookupValues)
                {
                    LookupValues = new ClsLookupValues();
                    string sqlString = "SELECT * FROM [LookupValues]";
                    sqlString += " WHERE " + condition;
                    try
                    {
                        SqlEngine sqlEngine = new SqlEngine(connectionString);
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        if (dr.Read())
                        {
                            if (!Convert.IsDBNull(dr["lv_id"]))
                            {
                                LookupValues.lv_id = Convert.ToInt16(dr["lv_id"].ToString());
                            }
                            else
                                LookupValues.lv_id = 0;
                            LookupValues.oldData.lv_id = LookupValues.lv_id;
                            if (!Convert.IsDBNull(dr["lv_lt_id"]))
                            {
                                LookupValues.lv_lt_id = Convert.ToInt16(dr["lv_lt_id"].ToString());
                            }
                            else
                                LookupValues.lv_lt_id = 0;
                            LookupValues.oldData.lv_lt_id = LookupValues.lv_lt_id;
                            if (!Convert.IsDBNull(dr["lv_value"]))
                            {
                                LookupValues.lv_value = Convert.ToString(dr["lv_value"].ToString());
                            }
                            else
                                LookupValues.lv_value = null;
                            LookupValues.oldData.lv_value = LookupValues.lv_value;
                            if (!Convert.IsDBNull(dr["lv_value_ar"]))
                            {
                                LookupValues.lv_value_ar = Convert.ToString(dr["lv_value_ar"].ToString());
                            }
                            else
                                LookupValues.lv_value_ar = null;
                            LookupValues.oldData.lv_value_ar = LookupValues.lv_value_ar;
                            LookupValues.ResetChangesFlags();
                        }
                        else
                            LookupValues = null;
                        dr.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (debugMode)
                            MessageBox.Show(ex.Message);
                        if (debugExceptionsMode)
                            throw ex;
                    }
                    LookupValues = null;
                    return false;
                }
                public static bool GetRecords(string condition, out ArrayList LookupValuesRecords)
                {
                    ClsLookupValues LookupValues;
                    LookupValuesRecords = new ArrayList();
                    string sqlString = "SELECT * FROM [LookupValues]";
                    sqlString += " WHERE " + condition;
                    try
                    {
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        while (dr.Read())
                        {
                            LookupValues = new ClsLookupValues();
                            if (!Convert.IsDBNull(dr["lv_id"]))
                            {
                                LookupValues.lv_id = Convert.ToInt16(dr["lv_id"].ToString());
                            }
                            else
                                LookupValues.lv_id = 0;
                            LookupValues.oldData.lv_id = LookupValues.lv_id;
                            if (!Convert.IsDBNull(dr["lv_lt_id"]))
                            {
                                LookupValues.lv_lt_id = Convert.ToInt16(dr["lv_lt_id"].ToString());
                            }
                            else
                                LookupValues.lv_lt_id = 0;
                            LookupValues.oldData.lv_lt_id = LookupValues.lv_lt_id;
                            if (!Convert.IsDBNull(dr["lv_value"]))
                            {
                                LookupValues.lv_value = Convert.ToString(dr["lv_value"].ToString());
                            }
                            else
                                LookupValues.lv_value = null;
                            LookupValues.oldData.lv_value = LookupValues.lv_value;
                            if (!Convert.IsDBNull(dr["lv_value_ar"]))
                            {
                                LookupValues.lv_value_ar = Convert.ToString(dr["lv_value_ar"].ToString());
                            }
                            else
                                LookupValues.lv_value_ar = null;
                            LookupValues.oldData.lv_value_ar = LookupValues.lv_value_ar;
                            LookupValues.ResetChangesFlags();
                            LookupValuesRecords.Add(LookupValues);
                        }
                        dr.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (debugMode)
                            MessageBox.Show(ex.Message);
                        if (debugExceptionsMode)
                            throw ex;
                    }
                    return false;
                }
                public static bool GetAll(out ArrayList LookupValuesRecords)
                {
                    ClsLookupValues LookupValues;
                    LookupValuesRecords = new ArrayList();
                    string sqlString = "SELECT * FROM [LookupValues]";
                    try
                    {
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        while (dr.Read())
                        {
                            LookupValues = new ClsLookupValues();
                            if (!Convert.IsDBNull(dr["lv_id"]))
                            {
                                LookupValues.lv_id = Convert.ToInt16(dr["lv_id"].ToString());
                            }
                            else
                                LookupValues.lv_id = 0;
                            LookupValues.oldData.lv_id = LookupValues.lv_id;
                            if (!Convert.IsDBNull(dr["lv_lt_id"]))
                            {
                                LookupValues.lv_lt_id = Convert.ToInt16(dr["lv_lt_id"].ToString());
                            }
                            else
                                LookupValues.lv_lt_id = 0;
                            LookupValues.oldData.lv_lt_id = LookupValues.lv_lt_id;
                            if (!Convert.IsDBNull(dr["lv_value"]))
                            {
                                LookupValues.lv_value = Convert.ToString(dr["lv_value"].ToString());
                            }
                            else
                                LookupValues.lv_value = null;
                            LookupValues.oldData.lv_value = LookupValues.lv_value;
                            if (!Convert.IsDBNull(dr["lv_value_ar"]))
                            {
                                LookupValues.lv_value_ar = Convert.ToString(dr["lv_value_ar"].ToString());
                            }
                            else
                                LookupValues.lv_value_ar = null;
                            LookupValues.oldData.lv_value_ar = LookupValues.lv_value_ar;
                            LookupValues.ResetChangesFlags();
                            LookupValuesRecords.Add(LookupValues);
                        }
                        dr.Close();
                        if (LookupValuesRecords.Count == 0)
                            LookupValues = null;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (debugMode)
                            MessageBox.Show(ex.Message);
                        if (debugExceptionsMode)
                            throw ex;
                    }
                    return false;
                }
            }

            #endregion

            #region Non-static Get Functions

            public bool GetRecord(SqlDataReader dr, out ClsLookupValues LookupValues)
            {
                LookupValues = new ClsLookupValues();
                try
                {
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["lv_id"]))
                        {
                            LookupValues.lv_id = Convert.ToInt16(dr["lv_id"].ToString());
                        }
                        else
                            LookupValues.lv_id = 0;
                        LookupValues.oldData.lv_id = LookupValues.lv_id;
                        if (!Convert.IsDBNull(dr["lv_lt_id"]))
                        {
                            LookupValues.lv_lt_id = Convert.ToInt16(dr["lv_lt_id"].ToString());
                        }
                        else
                            LookupValues.lv_lt_id = 0;
                        LookupValues.oldData.lv_lt_id = LookupValues.lv_lt_id;
                        if (!Convert.IsDBNull(dr["lv_value"]))
                        {
                            LookupValues.lv_value = Convert.ToString(dr["lv_value"].ToString());
                        }
                        else
                            LookupValues.lv_value = null;
                        LookupValues.oldData.lv_value = LookupValues.lv_value;
                        if (!Convert.IsDBNull(dr["lv_value_ar"]))
                        {
                            LookupValues.lv_value_ar = Convert.ToString(dr["lv_value_ar"].ToString());
                        }
                        else
                            LookupValues.lv_value_ar = null;
                        LookupValues.oldData.lv_value_ar = LookupValues.lv_value_ar;
                        LookupValues.ResetChangesFlags();
                    }
                    else
                        LookupValues = null;
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                LookupValues = null;
                return false;
            }
            public bool GetRecord(string condition, out ClsLookupValues LookupValues)
            {
                string sqlString = "SELECT * FROM [LookupValues]";
                sqlString += " WHERE " + condition;
                LookupValues = new ClsLookupValues();
                try
                {
                    SqlEngine sqlEngine = new SqlEngine(connectionString);
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["lv_id"]))
                        {
                            LookupValues.lv_id = Convert.ToInt16(dr["lv_id"].ToString());
                        }
                        else
                            LookupValues.lv_id = 0;
                        LookupValues.oldData.lv_id = LookupValues.lv_id;
                        if (!Convert.IsDBNull(dr["lv_lt_id"]))
                        {
                            LookupValues.lv_lt_id = Convert.ToInt16(dr["lv_lt_id"].ToString());
                        }
                        else
                            LookupValues.lv_lt_id = 0;
                        LookupValues.oldData.lv_lt_id = LookupValues.lv_lt_id;
                        if (!Convert.IsDBNull(dr["lv_value"]))
                        {
                            LookupValues.lv_value = Convert.ToString(dr["lv_value"].ToString());
                        }
                        else
                            LookupValues.lv_value = null;
                        LookupValues.oldData.lv_value = LookupValues.lv_value;
                        if (!Convert.IsDBNull(dr["lv_value_ar"]))
                        {
                            LookupValues.lv_value_ar = Convert.ToString(dr["lv_value_ar"].ToString());
                        }
                        else
                            LookupValues.lv_value_ar = null;
                        LookupValues.oldData.lv_value_ar = LookupValues.lv_value_ar;
                        LookupValues.ResetChangesFlags();
                    }
                    else
                        LookupValues = null;
                    dr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                LookupValues = null;
                return false;
            }
            public bool GetRecord()
            {
                try
                {
                    string whereCondition = " WHERE ";
                    whereCondition += "lv_id='" + df_lv_id + "' AND ";
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                    string sqlString = "SELECT * FROM [LookupValues]" + whereCondition;
                    try
                    {
                        SqlEngine sqlEngine = new SqlEngine(connectionString);
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        if (dr.Read())
                        {
                            if (!Convert.IsDBNull(dr["lv_id"]))
                            {
                                lv_id = Convert.ToInt16(dr["lv_id"].ToString());
                            }
                            else
                                lv_id = 0;
                            oldData.lv_id = lv_id;
                            if (!Convert.IsDBNull(dr["lv_lt_id"]))
                            {
                                lv_lt_id = Convert.ToInt16(dr["lv_lt_id"].ToString());
                            }
                            else
                                lv_lt_id = 0;
                            oldData.lv_lt_id = lv_lt_id;
                            if (!Convert.IsDBNull(dr["lv_value"]))
                            {
                                lv_value = Convert.ToString(dr["lv_value"].ToString());
                            }
                            else
                                lv_value = null;
                            oldData.lv_value = lv_value;
                            if (!Convert.IsDBNull(dr["lv_value_ar"]))
                            {
                                lv_value_ar = Convert.ToString(dr["lv_value_ar"].ToString());
                            }
                            else
                                lv_value_ar = null;
                            oldData.lv_value_ar = lv_value_ar;
                            ResetChangesFlags();
                        }
                        else
                            throw new Exception("Record not found");
                        dr.Close();
                        return true;
                    }
                    catch (Exception InnerEx)
                    {
                        if (debugMode)
                            MessageBox.Show(InnerEx.Message);
                        if (debugExceptionsMode)
                            throw InnerEx;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool GetRecord(out ClsLookupValues LookupValues)
            {
                string whereCondition = " WHERE ";
                whereCondition += "lv_id='" + df_lv_id + "' AND ";
                whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                LookupValues = new ClsLookupValues(df_lv_id);
                string sqlString = "SELECT * FROM [LookupValues]" + whereCondition;
                try
                {
                    SqlEngine sqlEngine = new SqlEngine(connectionString);
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["lv_id"]))
                        {
                            LookupValues.lv_id = Convert.ToInt16(dr["lv_id"].ToString());
                        }
                        else
                            LookupValues.lv_id = 0;
                        LookupValues.oldData.lv_id = LookupValues.lv_id;
                        if (!Convert.IsDBNull(dr["lv_lt_id"]))
                        {
                            LookupValues.lv_lt_id = Convert.ToInt16(dr["lv_lt_id"].ToString());
                        }
                        else
                            LookupValues.lv_lt_id = 0;
                        LookupValues.oldData.lv_lt_id = LookupValues.lv_lt_id;
                        if (!Convert.IsDBNull(dr["lv_value"]))
                        {
                            LookupValues.lv_value = Convert.ToString(dr["lv_value"].ToString());
                        }
                        else
                            LookupValues.lv_value = null;
                        LookupValues.oldData.lv_value = LookupValues.lv_value;
                        if (!Convert.IsDBNull(dr["lv_value_ar"]))
                        {
                            LookupValues.lv_value_ar = Convert.ToString(dr["lv_value_ar"].ToString());
                        }
                        else
                            LookupValues.lv_value_ar = null;
                        LookupValues.oldData.lv_value_ar = LookupValues.lv_value_ar;
                        LookupValues.ResetChangesFlags();
                    }
                    else
                        LookupValues = null;
                    dr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                LookupValues = null;
                return false;
            }
            public bool GetRecords(string condition, out ArrayList LookupValuesRecords)
            {
                ClsLookupValues LookupValues;
                LookupValuesRecords = new ArrayList();
                string sqlString = "SELECT * FROM [LookupValues]";
                sqlString += " WHERE " + condition;
                try
                {
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    while (dr.Read())
                    {
                        LookupValues = new ClsLookupValues();
                        if (!Convert.IsDBNull(dr["lv_id"]))
                        {
                            LookupValues.lv_id = Convert.ToInt16(dr["lv_id"].ToString());
                        }
                        else
                            LookupValues.lv_id = 0;
                        LookupValues.oldData.lv_id = LookupValues.lv_id;
                        if (!Convert.IsDBNull(dr["lv_lt_id"]))
                        {
                            LookupValues.lv_lt_id = Convert.ToInt16(dr["lv_lt_id"].ToString());
                        }
                        else
                            LookupValues.lv_lt_id = 0;
                        LookupValues.oldData.lv_lt_id = LookupValues.lv_lt_id;
                        if (!Convert.IsDBNull(dr["lv_value"]))
                        {
                            LookupValues.lv_value = Convert.ToString(dr["lv_value"].ToString());
                        }
                        else
                            LookupValues.lv_value = null;
                        LookupValues.oldData.lv_value = LookupValues.lv_value;
                        if (!Convert.IsDBNull(dr["lv_value_ar"]))
                        {
                            LookupValues.lv_value_ar = Convert.ToString(dr["lv_value_ar"].ToString());
                        }
                        else
                            LookupValues.lv_value_ar = null;
                        LookupValues.oldData.lv_value_ar = LookupValues.lv_value_ar;
                        LookupValues.ResetChangesFlags();
                        LookupValuesRecords.Add(LookupValues);
                    }
                    dr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool GetAll(out ArrayList LookupValuesRecords)
            {
                ClsLookupValues LookupValues;
                LookupValuesRecords = new ArrayList();
                string sqlString = "SELECT * FROM [LookupValues]";
                try
                {
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    while (dr.Read())
                    {
                        LookupValues = new ClsLookupValues();
                        if (!Convert.IsDBNull(dr["lv_id"]))
                        {
                            LookupValues.lv_id = Convert.ToInt16(dr["lv_id"].ToString());
                        }
                        else
                            LookupValues.lv_id = 0;
                        LookupValues.oldData.lv_id = LookupValues.lv_id;
                        if (!Convert.IsDBNull(dr["lv_lt_id"]))
                        {
                            LookupValues.lv_lt_id = Convert.ToInt16(dr["lv_lt_id"].ToString());
                        }
                        else
                            LookupValues.lv_lt_id = 0;
                        LookupValues.oldData.lv_lt_id = LookupValues.lv_lt_id;
                        if (!Convert.IsDBNull(dr["lv_value"]))
                        {
                            LookupValues.lv_value = Convert.ToString(dr["lv_value"].ToString());
                        }
                        else
                            LookupValues.lv_value = null;
                        LookupValues.oldData.lv_value = LookupValues.lv_value;
                        if (!Convert.IsDBNull(dr["lv_value_ar"]))
                        {
                            LookupValues.lv_value_ar = Convert.ToString(dr["lv_value_ar"].ToString());
                        }
                        else
                            LookupValues.lv_value_ar = null;
                        LookupValues.oldData.lv_value_ar = LookupValues.lv_value_ar;
                        LookupValues.ResetChangesFlags();
                        LookupValuesRecords.Add(LookupValues);
                    }
                    dr.Close();
                    if (LookupValuesRecords.Count == 0)
                        LookupValues = null;
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool GetNext(string colName, string cmpValue, out ClsLookupValues nextRecord)
            {
                return GetRecord(colName + ">'" + cmpValue + "' ORDER BY " + colName, out nextRecord);
            }
            public bool GetNext(string colName, string cmpValue, string sqlCondition, out ClsLookupValues nextRecord)
            {
                return GetRecord(colName + ">'" + cmpValue + "' AND " + sqlCondition + " ORDER BY " + colName, out nextRecord);
            }
            public bool GetPrevious(string colName, string cmpValue, out ClsLookupValues prevRecord)
            {
                return GetRecord(colName + "<'" + cmpValue + "' ORDER BY " + colName + " DESC", out prevRecord);
            }
            public bool GetPrevious(string colName, string cmpValue, string sqlCondition, out ClsLookupValues prevRecord)
            {
                return GetRecord(colName + "<'" + cmpValue + "' AND " + sqlCondition + " ORDER BY " + colName + " DESC", out prevRecord);
            }
            public bool GetFirst(string colName, out ClsLookupValues firstRecord)
            {
                firstRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [LookupValues] ORDER BY " + colName, out dr))
                    return false;
                if (!GetRecord(dr, out firstRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }
            public bool GetFirst(string colName, string sqlCondition, out ClsLookupValues firstRecord)
            {
                firstRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [LookupValues] WHERE " + sqlCondition
                    + " ORDER BY " + colName, out dr))
                    return false;
                if (!GetRecord(dr, out firstRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }
            public bool GetLast(string colName, out ClsLookupValues lastRecord)
            {
                lastRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [LookupValues] ORDER BY " + colName + " DESC", out dr))
                    return false;
                if (!GetRecord(dr, out lastRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }
            public bool GetLast(string colName, string sqlCondition, out ClsLookupValues lastRecord)
            {
                lastRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [LookupValues] WHERE " + sqlCondition
                    + " ORDER BY " + colName + " DESC", out dr))
                    return false;
                if (!GetRecord(dr, out lastRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }

            #endregion

            #region Row Operations


            public bool Add()
            {
                string sqlString;
                string values = "";
                string fields = "";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    if (lv_lt_id_changed)
                    {
                        fields += "lv_lt_id,";
                        values += "N'" + lv_lt_id + "',";
                    }
                    if (lv_value_changed)
                    {
                        fields += "lv_value,";
                        values += "N'" + lv_value + "',";
                    }
                    if (lv_value_ar_changed)
                    {
                        fields += "lv_value_ar,";
                        values += "N'" + lv_value_ar + "',";
                    }

                    #endregion
                    if (fields == "")
                        return true;
                    fields = fields.Substring(0, fields.Length - 1);
                    values = values.Substring(0, values.Length - 1);
                    sqlString = "INSERT INTO [LookupValues] (" + fields + ") VALUES (" + values + ") select @@identity";
                    if (sqlPars.Count == 0)
                    {
                        //lv_id = short.Parse(sqlEngine.ExecuteScalar(sqlString).ToString());
                        //if (lv_id <= 0)
                        //	throw new Exception("Error in Add function, can not execute sql statement");
                    }
                    else
                        if (!sqlEngine.NonQueryCommand(sqlString, sqlPars))
                        throw new Exception("Error in Add function, can not execute sql statement");

                    #region Set old field variables

                    oldData.lv_id = lv_id;
                    oldData.lv_lt_id = lv_lt_id;
                    oldData.lv_value = lv_value;
                    oldData.lv_value_ar = lv_value_ar;

                    #endregion

                    ResetChangesFlags();
                    if (!sqlEngine.GetTopRecordID("[LookupValues]", "lv_id", out df_lv_id))
                        throw new Exception("Error in Add function, can't read id");
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool AddSqlCommands(ref ArrayList transactions, ref ArrayList parameters)
            {
                string sqlString;
                string values = "";
                string fields = "";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    if (lv_lt_id_changed)
                    {
                        fields += "lv_lt_id,";
                        values += "N'" + lv_lt_id + "',";
                    }
                    if (lv_value_changed)
                    {
                        fields += "lv_value,";
                        values += "N'" + lv_value + "',";
                    }
                    if (lv_value_ar_changed)
                    {
                        fields += "lv_value_ar,";
                        values += "N'" + lv_value_ar + "',";
                    }

                    #endregion
                    if (fields == "")
                        return true;
                    fields = fields.Substring(0, fields.Length - 1);
                    values = values.Substring(0, values.Length - 1);
                    sqlString = "INSERT INTO [LookupValues] (" + fields + ") VALUES (" + values + ")";
                    transactions.Add(sqlString);
                    parameters.Add(sqlPars);

                    #region Set old field variables

                    oldData.lv_id = lv_id;
                    oldData.lv_lt_id = lv_lt_id;
                    oldData.lv_value = lv_value;
                    oldData.lv_value_ar = lv_value_ar;

                    #endregion

                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool Delete()
            {
                #region Condition(s)


                #endregion
                string sqlString = "DELETE FROM [LookupValues] WHERE lv_id='" + lv_id + "' AND ";
                sqlString = sqlString.Substring(0, sqlString.Length - 5);
                try
                {
                    if (!sqlEngine.NonQueryCommand(sqlString))
                        throw new Exception("Error in Delete function");
                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool DeleteSqlCommands(ref ArrayList transactions, ref ArrayList parameters)
            {
                #region Value updates


                #endregion
                string sqlString = "DELETE FROM [LookupValues] WHERE lv_id='" + lv_id + "' AND ";
                sqlString = sqlString.Substring(0, sqlString.Length - 5);
                try
                {
                    transactions.Add(sqlString);
                    parameters.Add(new ArrayList());
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool Update()
            {
                string sqlString = "UPDATE [LookupValues] SET ";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    string values = "";
                    #region Lv_id


                    #endregion
                    #region Lv_lt_id

                    if (lv_lt_id_changed)
                    {
                        if (df_lv_lt_id == null)
                        {
                            values += "lv_lt_id=null,";
                        }
                        else
                        {
                            values += "lv_lt_id=N'" + df_lv_lt_id + "',";
                        }
                    }

                    #endregion
                    #region Lv_value

                    if (lv_value_changed)
                    {
                        if (df_lv_value == null)
                        {
                            values += "lv_value=null,";
                        }
                        else
                        {
                            values += "lv_value=N'" + df_lv_value + "',";
                        }
                    }

                    #endregion
                    #region Lv_value_ar

                    if (lv_value_ar_changed)
                    {
                        if (df_lv_value_ar == null)
                        {
                            values += "lv_value_ar=null,";
                        }
                        else
                        {
                            values += "lv_value_ar=N'" + df_lv_value_ar + "',";
                        }
                    }

                    #endregion
                    if (values == "")
                        return true;
                    sqlString += values;

                    #endregion
                    if (sqlString[sqlString.Length - 1] == ',')
                        sqlString = sqlString.Substring(0, sqlString.Length - 1);
                    string whereCondition = " WHERE ";
                    whereCondition += "lv_id='" + df_lv_id + "' AND ";
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                    sqlString += whereCondition;
                    if (sqlPars.Count == 0)
                    {
                        if (!sqlEngine.NonQueryCommand(sqlString))
                            throw new Exception("Error in Update function");
                    }
                    else
                        if (!sqlEngine.NonQueryCommand(sqlString, sqlPars))
                        throw new Exception("Error in Update function");
                    oldData.lv_id = lv_id;
                    oldData.lv_lt_id = lv_lt_id;
                    oldData.lv_value = lv_value;
                    oldData.lv_value_ar = lv_value_ar;
                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool UpdateSqlCommands(ref ArrayList transactions, ref ArrayList parameters)
            {
                string sqlString = "UPDATE [LookupValues] SET ";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    string values = "";
                    if (lv_lt_id_changed)
                    {
                        if (df_lv_lt_id == null)
                        {
                            values += "lv_lt_id=null,";
                        }
                        else
                        {
                            values += "lv_lt_id=N'" + df_lv_lt_id + "',";
                        }
                    }
                    if (lv_value_changed)
                    {
                        if (df_lv_value == null)
                        {
                            values += "lv_value=null,";
                        }
                        else
                        {
                            values += "lv_value=N'" + df_lv_value + "',";
                        }
                    }
                    if (lv_value_ar_changed)
                    {
                        if (df_lv_value_ar == null)
                        {
                            values += "lv_value_ar=null,";
                        }
                        else
                        {
                            values += "lv_value_ar=N'" + df_lv_value_ar + "',";
                        }
                    }
                    if (values == "")
                        return true;
                    sqlString += values;

                    #endregion
                    if (sqlString[sqlString.Length - 1] == ',')
                        sqlString = sqlString.Substring(0, sqlString.Length - 1);
                    string whereCondition = " WHERE ";
                    whereCondition += "lv_id='" + df_lv_id + "' AND ";
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                    sqlString += whereCondition;
                    transactions.Add(sqlString);
                    parameters.Add(sqlPars);
                    oldData.lv_id = lv_id;
                    oldData.lv_lt_id = lv_lt_id;
                    oldData.lv_value = lv_value;
                    oldData.lv_value_ar = lv_value_ar;
                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }

            #endregion
        }

        #endregion

        #region Pages

        [Serializable]
        public class ClsPages
        {
            private string basicQueryString = "SELECT * FROM [Pages]";

            public ClsPages() { }
            public ClsPages(int Page_id)
            {
                this.Page_id = Page_id;
            }

            public ArrayList relationshipChecks = new ArrayList();

            public bool DependanciesExist(out bool dependancyExists)
            {
                dependancyExists = true;
                try
                {
                    foreach (string selectStatement in relationshipChecks)
                    {
                        if (!sqlEngine.DataExists(selectStatement, out dependancyExists))
                            return false;
                        if (dependancyExists)
                            return true;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }

            public override string ToString()
            {
                return "Pages";
            }


            public string BasicQueryString
            {
                get
                {
                    return basicQueryString;
                }
                set
                {
                    basicQueryString = value;
                }
            }

            #region Column Names

            public static class Column_Names
            {
                public static string Page_id
                {
                    get
                    {
                        return "Page_id";
                    }
                }
                public static string Page_name
                {
                    get
                    {
                        return "Page_name";
                    }
                }
                public static string Page_status
                {
                    get
                    {
                        return "Page_status";
                    }
                }
                public static string Page_creation_date
                {
                    get
                    {
                        return "Page_creation_date";
                    }
                }
                public static string Page_modification_date
                {
                    get
                    {
                        return "Page_modification_date";
                    }
                }
                public static string Page_creation_user
                {
                    get
                    {
                        return "Page_creation_user";
                    }
                }
                public static string Page_modification_user
                {
                    get
                    {
                        return "Page_modification_user";
                    }
                }
                public static string Page_type
                {
                    get
                    {
                        return "Page_type";
                    }
                }
            }

            #endregion

            #region Data Fields


            private int df_Page_id;
            public bool Page_id_changed = false;
            public int Page_id
            {
                get
                {
                    return df_Page_id;
                }
                set
                {
                    df_Page_id = value;
                    oldData.Page_id = value;
                }
            }

            private string df_Page_name;
            public bool Page_name_changed = false;
            public string Page_name
            {
                get
                {
                    return df_Page_name;
                }
                set
                {
                    if (oldData.Page_name != value)
                    {
                        df_Page_name = value;
                        oldData.Page_name = value;
                        Page_name_changed = true;
                    }
                }
            }

            private short df_Page_status;
            public bool Page_status_changed = false;
            public short Page_status
            {
                get
                {
                    return df_Page_status;
                }
                set
                {
                    df_Page_status = value;
                    oldData.Page_status = value;
                    Page_status_changed = true;
                }
            }

            private DateTime df_Page_creation_date;
            public bool Page_creation_date_changed = false;
            public DateTime Page_creation_date
            {
                get
                {
                    return df_Page_creation_date;
                }
                set
                {
                    if (oldData.Page_creation_date != value)
                    {
                        df_Page_creation_date = value;
                        oldData.Page_creation_date = value;
                        Page_creation_date_changed = true;
                    }
                }
            }

            private DateTime df_Page_modification_date;
            public bool Page_modification_date_changed = false;
            public DateTime Page_modification_date
            {
                get
                {
                    return df_Page_modification_date;
                }
                set
                {
                    if (oldData.Page_modification_date != value)
                    {
                        df_Page_modification_date = value;
                        oldData.Page_modification_date = value;
                        Page_modification_date_changed = true;
                    }
                }
            }

            private int df_Page_creation_user;
            public bool Page_creation_user_changed = false;
            public int Page_creation_user
            {
                get
                {
                    return df_Page_creation_user;
                }
                set
                {
                    df_Page_creation_user = value;
                    oldData.Page_creation_user = value;
                    Page_creation_user_changed = true;
                }
            }

            private int df_Page_modification_user;
            public bool Page_modification_user_changed = false;
            public int Page_modification_user
            {
                get
                {
                    return df_Page_modification_user;
                }
                set
                {
                    df_Page_modification_user = value;
                    oldData.Page_modification_user = value;
                    Page_modification_user_changed = true;
                }
            }

            private short df_Page_type;
            public bool Page_type_changed = false;
            public short Page_type
            {
                get
                {
                    return df_Page_type;
                }
                set
                {
                    df_Page_type = value;
                    oldData.Page_type = value;
                    Page_type_changed = true;
                }
            }


            #endregion

            public void ResetChangesFlags()
            {
                Page_id_changed = false;
                Page_name_changed = false;
                Page_status_changed = false;
                Page_creation_date_changed = false;
                Page_modification_date_changed = false;
                Page_creation_user_changed = false;
                Page_modification_user_changed = false;
                Page_type_changed = false;
            }

            #region OldData Class

            [Serializable]
            private class OldData
            {
                public int Page_id = new int();
                public string Page_name;
                public short Page_status = new short();
                public DateTime Page_creation_date = new DateTime();
                public DateTime Page_modification_date = new DateTime();
                public int Page_creation_user = new int();
                public int Page_modification_user = new int();
                public short Page_type = new short();
            }

            #endregion

            private OldData oldData = new OldData();

            #region Static Get Functions

            public static class Functions
            {
                public static bool GetRecord(string condition, out ClsPages Pages)
                {
                    Pages = new ClsPages();
                    string sqlString = "SELECT * FROM [Pages]";
                    sqlString += " WHERE " + condition;
                    try
                    {
                        SqlEngine sqlEngine = new SqlEngine(connectionString);
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        if (dr.Read())
                        {
                            if (!Convert.IsDBNull(dr["Page_id"]))
                            {
                                Pages.Page_id = Convert.ToInt32(dr["Page_id"].ToString());
                            }
                            else
                                Pages.Page_id = 0;
                            Pages.oldData.Page_id = Pages.Page_id;
                            if (!Convert.IsDBNull(dr["Page_name"]))
                            {
                                Pages.Page_name = Convert.ToString(dr["Page_name"].ToString());
                            }
                            else
                                Pages.Page_name = null;
                            Pages.oldData.Page_name = Pages.Page_name;
                            if (!Convert.IsDBNull(dr["Page_status"]))
                            {
                                Pages.Page_status = Convert.ToInt16(dr["Page_status"].ToString());
                            }
                            else
                                Pages.Page_status = 0;
                            Pages.oldData.Page_status = Pages.Page_status;
                            if (!Convert.IsDBNull(dr["Page_creation_date"]))
                            {
                                Pages.Page_creation_date = Convert.ToDateTime(dr["Page_creation_date"].ToString());
                            }
                            else
                                Pages.Page_creation_date = new DateTime();
                            Pages.oldData.Page_creation_date = Pages.Page_creation_date;
                            if (!Convert.IsDBNull(dr["Page_modification_date"]))
                            {
                                Pages.Page_modification_date = Convert.ToDateTime(dr["Page_modification_date"].ToString());
                            }
                            else
                                Pages.Page_modification_date = new DateTime();
                            Pages.oldData.Page_modification_date = Pages.Page_modification_date;
                            if (!Convert.IsDBNull(dr["Page_creation_user"]))
                            {
                                Pages.Page_creation_user = Convert.ToInt32(dr["Page_creation_user"].ToString());
                            }
                            else
                                Pages.Page_creation_user = 0;
                            Pages.oldData.Page_creation_user = Pages.Page_creation_user;
                            if (!Convert.IsDBNull(dr["Page_modification_user"]))
                            {
                                Pages.Page_modification_user = Convert.ToInt32(dr["Page_modification_user"].ToString());
                            }
                            else
                                Pages.Page_modification_user = 0;
                            Pages.oldData.Page_modification_user = Pages.Page_modification_user;
                            if (!Convert.IsDBNull(dr["Page_type"]))
                            {
                                Pages.Page_type = Convert.ToInt16(dr["Page_type"].ToString());
                            }
                            else
                                Pages.Page_type = 0;
                            Pages.oldData.Page_type = Pages.Page_type;
                            Pages.ResetChangesFlags();
                        }
                        else
                            Pages = null;
                        dr.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (debugMode)
                            MessageBox.Show(ex.Message);
                        if (debugExceptionsMode)
                            throw ex;
                    }
                    Pages = null;
                    return false;
                }
                public static bool GetRecords(string condition, out ArrayList PagesRecords)
                {
                    ClsPages Pages;
                    PagesRecords = new ArrayList();
                    string sqlString = "SELECT * FROM [Pages]";
                    sqlString += " WHERE " + condition;
                    try
                    {
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        while (dr.Read())
                        {
                            Pages = new ClsPages();
                            if (!Convert.IsDBNull(dr["Page_id"]))
                            {
                                Pages.Page_id = Convert.ToInt32(dr["Page_id"].ToString());
                            }
                            else
                                Pages.Page_id = 0;
                            Pages.oldData.Page_id = Pages.Page_id;
                            if (!Convert.IsDBNull(dr["Page_name"]))
                            {
                                Pages.Page_name = Convert.ToString(dr["Page_name"].ToString());
                            }
                            else
                                Pages.Page_name = null;
                            Pages.oldData.Page_name = Pages.Page_name;
                            if (!Convert.IsDBNull(dr["Page_status"]))
                            {
                                Pages.Page_status = Convert.ToInt16(dr["Page_status"].ToString());
                            }
                            else
                                Pages.Page_status = 0;
                            Pages.oldData.Page_status = Pages.Page_status;
                            if (!Convert.IsDBNull(dr["Page_creation_date"]))
                            {
                                Pages.Page_creation_date = Convert.ToDateTime(dr["Page_creation_date"].ToString());
                            }
                            else
                                Pages.Page_creation_date = new DateTime();
                            Pages.oldData.Page_creation_date = Pages.Page_creation_date;
                            if (!Convert.IsDBNull(dr["Page_modification_date"]))
                            {
                                Pages.Page_modification_date = Convert.ToDateTime(dr["Page_modification_date"].ToString());
                            }
                            else
                                Pages.Page_modification_date = new DateTime();
                            Pages.oldData.Page_modification_date = Pages.Page_modification_date;
                            if (!Convert.IsDBNull(dr["Page_creation_user"]))
                            {
                                Pages.Page_creation_user = Convert.ToInt32(dr["Page_creation_user"].ToString());
                            }
                            else
                                Pages.Page_creation_user = 0;
                            Pages.oldData.Page_creation_user = Pages.Page_creation_user;
                            if (!Convert.IsDBNull(dr["Page_modification_user"]))
                            {
                                Pages.Page_modification_user = Convert.ToInt32(dr["Page_modification_user"].ToString());
                            }
                            else
                                Pages.Page_modification_user = 0;
                            Pages.oldData.Page_modification_user = Pages.Page_modification_user;
                            if (!Convert.IsDBNull(dr["Page_type"]))
                            {
                                Pages.Page_type = Convert.ToInt16(dr["Page_type"].ToString());
                            }
                            else
                                Pages.Page_type = 0;
                            Pages.oldData.Page_type = Pages.Page_type;
                            Pages.ResetChangesFlags();
                            PagesRecords.Add(Pages);
                        }
                        dr.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (debugMode)
                            MessageBox.Show(ex.Message);
                        if (debugExceptionsMode)
                            throw ex;
                    }
                    return false;
                }
                public static bool GetAll(out ArrayList PagesRecords)
                {
                    ClsPages Pages;
                    PagesRecords = new ArrayList();
                    string sqlString = "SELECT * FROM [Pages]";
                    try
                    {
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        while (dr.Read())
                        {
                            Pages = new ClsPages();
                            if (!Convert.IsDBNull(dr["Page_id"]))
                            {
                                Pages.Page_id = Convert.ToInt32(dr["Page_id"].ToString());
                            }
                            else
                                Pages.Page_id = 0;
                            Pages.oldData.Page_id = Pages.Page_id;
                            if (!Convert.IsDBNull(dr["Page_name"]))
                            {
                                Pages.Page_name = Convert.ToString(dr["Page_name"].ToString());
                            }
                            else
                                Pages.Page_name = null;
                            Pages.oldData.Page_name = Pages.Page_name;
                            if (!Convert.IsDBNull(dr["Page_status"]))
                            {
                                Pages.Page_status = Convert.ToInt16(dr["Page_status"].ToString());
                            }
                            else
                                Pages.Page_status = 0;
                            Pages.oldData.Page_status = Pages.Page_status;
                            if (!Convert.IsDBNull(dr["Page_creation_date"]))
                            {
                                Pages.Page_creation_date = Convert.ToDateTime(dr["Page_creation_date"].ToString());
                            }
                            else
                                Pages.Page_creation_date = new DateTime();
                            Pages.oldData.Page_creation_date = Pages.Page_creation_date;
                            if (!Convert.IsDBNull(dr["Page_modification_date"]))
                            {
                                Pages.Page_modification_date = Convert.ToDateTime(dr["Page_modification_date"].ToString());
                            }
                            else
                                Pages.Page_modification_date = new DateTime();
                            Pages.oldData.Page_modification_date = Pages.Page_modification_date;
                            if (!Convert.IsDBNull(dr["Page_creation_user"]))
                            {
                                Pages.Page_creation_user = Convert.ToInt32(dr["Page_creation_user"].ToString());
                            }
                            else
                                Pages.Page_creation_user = 0;
                            Pages.oldData.Page_creation_user = Pages.Page_creation_user;
                            if (!Convert.IsDBNull(dr["Page_modification_user"]))
                            {
                                Pages.Page_modification_user = Convert.ToInt32(dr["Page_modification_user"].ToString());
                            }
                            else
                                Pages.Page_modification_user = 0;
                            Pages.oldData.Page_modification_user = Pages.Page_modification_user;
                            if (!Convert.IsDBNull(dr["Page_type"]))
                            {
                                Pages.Page_type = Convert.ToInt16(dr["Page_type"].ToString());
                            }
                            else
                                Pages.Page_type = 0;
                            Pages.oldData.Page_type = Pages.Page_type;
                            Pages.ResetChangesFlags();
                            PagesRecords.Add(Pages);
                        }
                        dr.Close();
                        if (PagesRecords.Count == 0)
                            Pages = null;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (debugMode)
                            MessageBox.Show(ex.Message);
                        if (debugExceptionsMode)
                            throw ex;
                    }
                    return false;
                }
            }

            #endregion

            #region Non-static Get Functions

            public bool GetRecord(SqlDataReader dr, out ClsPages Pages)
            {
                Pages = new ClsPages();
                try
                {
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["Page_id"]))
                        {
                            Pages.Page_id = Convert.ToInt32(dr["Page_id"].ToString());
                        }
                        else
                            Pages.Page_id = 0;
                        Pages.oldData.Page_id = Pages.Page_id;
                        if (!Convert.IsDBNull(dr["Page_name"]))
                        {
                            Pages.Page_name = Convert.ToString(dr["Page_name"].ToString());
                        }
                        else
                            Pages.Page_name = null;
                        Pages.oldData.Page_name = Pages.Page_name;
                        if (!Convert.IsDBNull(dr["Page_status"]))
                        {
                            Pages.Page_status = Convert.ToInt16(dr["Page_status"].ToString());
                        }
                        else
                            Pages.Page_status = 0;
                        Pages.oldData.Page_status = Pages.Page_status;
                        if (!Convert.IsDBNull(dr["Page_creation_date"]))
                        {
                            Pages.Page_creation_date = Convert.ToDateTime(dr["Page_creation_date"].ToString());
                        }
                        else
                            Pages.Page_creation_date = new DateTime();
                        Pages.oldData.Page_creation_date = Pages.Page_creation_date;
                        if (!Convert.IsDBNull(dr["Page_modification_date"]))
                        {
                            Pages.Page_modification_date = Convert.ToDateTime(dr["Page_modification_date"].ToString());
                        }
                        else
                            Pages.Page_modification_date = new DateTime();
                        Pages.oldData.Page_modification_date = Pages.Page_modification_date;
                        if (!Convert.IsDBNull(dr["Page_creation_user"]))
                        {
                            Pages.Page_creation_user = Convert.ToInt32(dr["Page_creation_user"].ToString());
                        }
                        else
                            Pages.Page_creation_user = 0;
                        Pages.oldData.Page_creation_user = Pages.Page_creation_user;
                        if (!Convert.IsDBNull(dr["Page_modification_user"]))
                        {
                            Pages.Page_modification_user = Convert.ToInt32(dr["Page_modification_user"].ToString());
                        }
                        else
                            Pages.Page_modification_user = 0;
                        Pages.oldData.Page_modification_user = Pages.Page_modification_user;
                        if (!Convert.IsDBNull(dr["Page_type"]))
                        {
                            Pages.Page_type = Convert.ToInt16(dr["Page_type"].ToString());
                        }
                        else
                            Pages.Page_type = 0;
                        Pages.oldData.Page_type = Pages.Page_type;
                        Pages.ResetChangesFlags();
                    }
                    else
                        Pages = null;
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                Pages = null;
                return false;
            }
            public bool GetRecord(string condition, out ClsPages Pages)
            {
                string sqlString = "SELECT * FROM [Pages]";
                sqlString += " WHERE " + condition;
                Pages = new ClsPages();
                try
                {
                    SqlEngine sqlEngine = new SqlEngine(connectionString);
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["Page_id"]))
                        {
                            Pages.Page_id = Convert.ToInt32(dr["Page_id"].ToString());
                        }
                        else
                            Pages.Page_id = 0;
                        Pages.oldData.Page_id = Pages.Page_id;
                        if (!Convert.IsDBNull(dr["Page_name"]))
                        {
                            Pages.Page_name = Convert.ToString(dr["Page_name"].ToString());
                        }
                        else
                            Pages.Page_name = null;
                        Pages.oldData.Page_name = Pages.Page_name;
                        if (!Convert.IsDBNull(dr["Page_status"]))
                        {
                            Pages.Page_status = Convert.ToInt16(dr["Page_status"].ToString());
                        }
                        else
                            Pages.Page_status = 0;
                        Pages.oldData.Page_status = Pages.Page_status;
                        if (!Convert.IsDBNull(dr["Page_creation_date"]))
                        {
                            Pages.Page_creation_date = Convert.ToDateTime(dr["Page_creation_date"].ToString());
                        }
                        else
                            Pages.Page_creation_date = new DateTime();
                        Pages.oldData.Page_creation_date = Pages.Page_creation_date;
                        if (!Convert.IsDBNull(dr["Page_modification_date"]))
                        {
                            Pages.Page_modification_date = Convert.ToDateTime(dr["Page_modification_date"].ToString());
                        }
                        else
                            Pages.Page_modification_date = new DateTime();
                        Pages.oldData.Page_modification_date = Pages.Page_modification_date;
                        if (!Convert.IsDBNull(dr["Page_creation_user"]))
                        {
                            Pages.Page_creation_user = Convert.ToInt32(dr["Page_creation_user"].ToString());
                        }
                        else
                            Pages.Page_creation_user = 0;
                        Pages.oldData.Page_creation_user = Pages.Page_creation_user;
                        if (!Convert.IsDBNull(dr["Page_modification_user"]))
                        {
                            Pages.Page_modification_user = Convert.ToInt32(dr["Page_modification_user"].ToString());
                        }
                        else
                            Pages.Page_modification_user = 0;
                        Pages.oldData.Page_modification_user = Pages.Page_modification_user;
                        if (!Convert.IsDBNull(dr["Page_type"]))
                        {
                            Pages.Page_type = Convert.ToInt16(dr["Page_type"].ToString());
                        }
                        else
                            Pages.Page_type = 0;
                        Pages.oldData.Page_type = Pages.Page_type;
                        Pages.ResetChangesFlags();
                    }
                    else
                        Pages = null;
                    dr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                Pages = null;
                return false;
            }
            public bool GetRecord()
            {
                try
                {
                    string whereCondition = " WHERE ";
                    whereCondition += "Page_id='" + df_Page_id + "' AND ";
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                    string sqlString = "SELECT * FROM [Pages]" + whereCondition;
                    try
                    {
                        SqlEngine sqlEngine = new SqlEngine(connectionString);
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        if (dr.Read())
                        {
                            if (!Convert.IsDBNull(dr["Page_id"]))
                            {
                                Page_id = Convert.ToInt32(dr["Page_id"].ToString());
                            }
                            else
                                Page_id = 0;
                            oldData.Page_id = Page_id;
                            if (!Convert.IsDBNull(dr["Page_name"]))
                            {
                                Page_name = Convert.ToString(dr["Page_name"].ToString());
                            }
                            else
                                Page_name = null;
                            oldData.Page_name = Page_name;
                            if (!Convert.IsDBNull(dr["Page_status"]))
                            {
                                Page_status = Convert.ToInt16(dr["Page_status"].ToString());
                            }
                            else
                                Page_status = 0;
                            oldData.Page_status = Page_status;
                            if (!Convert.IsDBNull(dr["Page_creation_date"]))
                            {
                                Page_creation_date = Convert.ToDateTime(dr["Page_creation_date"].ToString());
                            }
                            else
                                Page_creation_date = new DateTime();
                            oldData.Page_creation_date = Page_creation_date;
                            if (!Convert.IsDBNull(dr["Page_modification_date"]))
                            {
                                Page_modification_date = Convert.ToDateTime(dr["Page_modification_date"].ToString());
                            }
                            else
                                Page_modification_date = new DateTime();
                            oldData.Page_modification_date = Page_modification_date;
                            if (!Convert.IsDBNull(dr["Page_creation_user"]))
                            {
                                Page_creation_user = Convert.ToInt32(dr["Page_creation_user"].ToString());
                            }
                            else
                                Page_creation_user = 0;
                            oldData.Page_creation_user = Page_creation_user;
                            if (!Convert.IsDBNull(dr["Page_modification_user"]))
                            {
                                Page_modification_user = Convert.ToInt32(dr["Page_modification_user"].ToString());
                            }
                            else
                                Page_modification_user = 0;
                            oldData.Page_modification_user = Page_modification_user;
                            if (!Convert.IsDBNull(dr["Page_type"]))
                            {
                                Page_type = Convert.ToInt16(dr["Page_type"].ToString());
                            }
                            else
                                Page_type = 0;
                            oldData.Page_type = Page_type;
                            ResetChangesFlags();
                        }
                        else
                            throw new Exception("Record not found");
                        dr.Close();
                        return true;
                    }
                    catch (Exception InnerEx)
                    {
                        if (debugMode)
                            MessageBox.Show(InnerEx.Message);
                        if (debugExceptionsMode)
                            throw InnerEx;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool GetRecord(out ClsPages Pages)
            {
                string whereCondition = " WHERE ";
                whereCondition += "Page_id='" + df_Page_id + "' AND ";
                whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                Pages = new ClsPages(df_Page_id);
                string sqlString = "SELECT * FROM [Pages]" + whereCondition;
                try
                {
                    SqlEngine sqlEngine = new SqlEngine(connectionString);
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["Page_id"]))
                        {
                            Pages.Page_id = Convert.ToInt32(dr["Page_id"].ToString());
                        }
                        else
                            Pages.Page_id = 0;
                        Pages.oldData.Page_id = Pages.Page_id;
                        if (!Convert.IsDBNull(dr["Page_name"]))
                        {
                            Pages.Page_name = Convert.ToString(dr["Page_name"].ToString());
                        }
                        else
                            Pages.Page_name = null;
                        Pages.oldData.Page_name = Pages.Page_name;
                        if (!Convert.IsDBNull(dr["Page_status"]))
                        {
                            Pages.Page_status = Convert.ToInt16(dr["Page_status"].ToString());
                        }
                        else
                            Pages.Page_status = 0;
                        Pages.oldData.Page_status = Pages.Page_status;
                        if (!Convert.IsDBNull(dr["Page_creation_date"]))
                        {
                            Pages.Page_creation_date = Convert.ToDateTime(dr["Page_creation_date"].ToString());
                        }
                        else
                            Pages.Page_creation_date = new DateTime();
                        Pages.oldData.Page_creation_date = Pages.Page_creation_date;
                        if (!Convert.IsDBNull(dr["Page_modification_date"]))
                        {
                            Pages.Page_modification_date = Convert.ToDateTime(dr["Page_modification_date"].ToString());
                        }
                        else
                            Pages.Page_modification_date = new DateTime();
                        Pages.oldData.Page_modification_date = Pages.Page_modification_date;
                        if (!Convert.IsDBNull(dr["Page_creation_user"]))
                        {
                            Pages.Page_creation_user = Convert.ToInt32(dr["Page_creation_user"].ToString());
                        }
                        else
                            Pages.Page_creation_user = 0;
                        Pages.oldData.Page_creation_user = Pages.Page_creation_user;
                        if (!Convert.IsDBNull(dr["Page_modification_user"]))
                        {
                            Pages.Page_modification_user = Convert.ToInt32(dr["Page_modification_user"].ToString());
                        }
                        else
                            Pages.Page_modification_user = 0;
                        Pages.oldData.Page_modification_user = Pages.Page_modification_user;
                        if (!Convert.IsDBNull(dr["Page_type"]))
                        {
                            Pages.Page_type = Convert.ToInt16(dr["Page_type"].ToString());
                        }
                        else
                            Pages.Page_type = 0;
                        Pages.oldData.Page_type = Pages.Page_type;
                        Pages.ResetChangesFlags();
                    }
                    else
                        Pages = null;
                    dr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                Pages = null;
                return false;
            }
            public bool GetRecords(string condition, out ArrayList PagesRecords)
            {
                ClsPages Pages;
                PagesRecords = new ArrayList();
                string sqlString = "SELECT * FROM [Pages]";
                sqlString += " WHERE " + condition;
                try
                {
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    while (dr.Read())
                    {
                        Pages = new ClsPages();
                        if (!Convert.IsDBNull(dr["Page_id"]))
                        {
                            Pages.Page_id = Convert.ToInt32(dr["Page_id"].ToString());
                        }
                        else
                            Pages.Page_id = 0;
                        Pages.oldData.Page_id = Pages.Page_id;
                        if (!Convert.IsDBNull(dr["Page_name"]))
                        {
                            Pages.Page_name = Convert.ToString(dr["Page_name"].ToString());
                        }
                        else
                            Pages.Page_name = null;
                        Pages.oldData.Page_name = Pages.Page_name;
                        if (!Convert.IsDBNull(dr["Page_status"]))
                        {
                            Pages.Page_status = Convert.ToInt16(dr["Page_status"].ToString());
                        }
                        else
                            Pages.Page_status = 0;
                        Pages.oldData.Page_status = Pages.Page_status;
                        if (!Convert.IsDBNull(dr["Page_creation_date"]))
                        {
                            Pages.Page_creation_date = Convert.ToDateTime(dr["Page_creation_date"].ToString());
                        }
                        else
                            Pages.Page_creation_date = new DateTime();
                        Pages.oldData.Page_creation_date = Pages.Page_creation_date;
                        if (!Convert.IsDBNull(dr["Page_modification_date"]))
                        {
                            Pages.Page_modification_date = Convert.ToDateTime(dr["Page_modification_date"].ToString());
                        }
                        else
                            Pages.Page_modification_date = new DateTime();
                        Pages.oldData.Page_modification_date = Pages.Page_modification_date;
                        if (!Convert.IsDBNull(dr["Page_creation_user"]))
                        {
                            Pages.Page_creation_user = Convert.ToInt32(dr["Page_creation_user"].ToString());
                        }
                        else
                            Pages.Page_creation_user = 0;
                        Pages.oldData.Page_creation_user = Pages.Page_creation_user;
                        if (!Convert.IsDBNull(dr["Page_modification_user"]))
                        {
                            Pages.Page_modification_user = Convert.ToInt32(dr["Page_modification_user"].ToString());
                        }
                        else
                            Pages.Page_modification_user = 0;
                        Pages.oldData.Page_modification_user = Pages.Page_modification_user;
                        if (!Convert.IsDBNull(dr["Page_type"]))
                        {
                            Pages.Page_type = Convert.ToInt16(dr["Page_type"].ToString());
                        }
                        else
                            Pages.Page_type = 0;
                        Pages.oldData.Page_type = Pages.Page_type;
                        Pages.ResetChangesFlags();
                        PagesRecords.Add(Pages);
                    }
                    dr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool GetAll(out ArrayList PagesRecords)
            {
                ClsPages Pages;
                PagesRecords = new ArrayList();
                string sqlString = "SELECT * FROM [Pages]";
                try
                {
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    while (dr.Read())
                    {
                        Pages = new ClsPages();
                        if (!Convert.IsDBNull(dr["Page_id"]))
                        {
                            Pages.Page_id = Convert.ToInt32(dr["Page_id"].ToString());
                        }
                        else
                            Pages.Page_id = 0;
                        Pages.oldData.Page_id = Pages.Page_id;
                        if (!Convert.IsDBNull(dr["Page_name"]))
                        {
                            Pages.Page_name = Convert.ToString(dr["Page_name"].ToString());
                        }
                        else
                            Pages.Page_name = null;
                        Pages.oldData.Page_name = Pages.Page_name;
                        if (!Convert.IsDBNull(dr["Page_status"]))
                        {
                            Pages.Page_status = Convert.ToInt16(dr["Page_status"].ToString());
                        }
                        else
                            Pages.Page_status = 0;
                        Pages.oldData.Page_status = Pages.Page_status;
                        if (!Convert.IsDBNull(dr["Page_creation_date"]))
                        {
                            Pages.Page_creation_date = Convert.ToDateTime(dr["Page_creation_date"].ToString());
                        }
                        else
                            Pages.Page_creation_date = new DateTime();
                        Pages.oldData.Page_creation_date = Pages.Page_creation_date;
                        if (!Convert.IsDBNull(dr["Page_modification_date"]))
                        {
                            Pages.Page_modification_date = Convert.ToDateTime(dr["Page_modification_date"].ToString());
                        }
                        else
                            Pages.Page_modification_date = new DateTime();
                        Pages.oldData.Page_modification_date = Pages.Page_modification_date;
                        if (!Convert.IsDBNull(dr["Page_creation_user"]))
                        {
                            Pages.Page_creation_user = Convert.ToInt32(dr["Page_creation_user"].ToString());
                        }
                        else
                            Pages.Page_creation_user = 0;
                        Pages.oldData.Page_creation_user = Pages.Page_creation_user;
                        if (!Convert.IsDBNull(dr["Page_modification_user"]))
                        {
                            Pages.Page_modification_user = Convert.ToInt32(dr["Page_modification_user"].ToString());
                        }
                        else
                            Pages.Page_modification_user = 0;
                        Pages.oldData.Page_modification_user = Pages.Page_modification_user;
                        if (!Convert.IsDBNull(dr["Page_type"]))
                        {
                            Pages.Page_type = Convert.ToInt16(dr["Page_type"].ToString());
                        }
                        else
                            Pages.Page_type = 0;
                        Pages.oldData.Page_type = Pages.Page_type;
                        Pages.ResetChangesFlags();
                        PagesRecords.Add(Pages);
                    }
                    dr.Close();
                    if (PagesRecords.Count == 0)
                        Pages = null;
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool GetNext(string colName, string cmpValue, out ClsPages nextRecord)
            {
                return GetRecord(colName + ">'" + cmpValue + "' ORDER BY " + colName, out nextRecord);
            }
            public bool GetNext(string colName, string cmpValue, string sqlCondition, out ClsPages nextRecord)
            {
                return GetRecord(colName + ">'" + cmpValue + "' AND " + sqlCondition + " ORDER BY " + colName, out nextRecord);
            }
            public bool GetPrevious(string colName, string cmpValue, out ClsPages prevRecord)
            {
                return GetRecord(colName + "<'" + cmpValue + "' ORDER BY " + colName + " DESC", out prevRecord);
            }
            public bool GetPrevious(string colName, string cmpValue, string sqlCondition, out ClsPages prevRecord)
            {
                return GetRecord(colName + "<'" + cmpValue + "' AND " + sqlCondition + " ORDER BY " + colName + " DESC", out prevRecord);
            }
            public bool GetFirst(string colName, out ClsPages firstRecord)
            {
                firstRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [Pages] ORDER BY " + colName, out dr))
                    return false;
                if (!GetRecord(dr, out firstRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }
            public bool GetFirst(string colName, string sqlCondition, out ClsPages firstRecord)
            {
                firstRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [Pages] WHERE " + sqlCondition
                    + " ORDER BY " + colName, out dr))
                    return false;
                if (!GetRecord(dr, out firstRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }
            public bool GetLast(string colName, out ClsPages lastRecord)
            {
                lastRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [Pages] ORDER BY " + colName + " DESC", out dr))
                    return false;
                if (!GetRecord(dr, out lastRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }
            public bool GetLast(string colName, string sqlCondition, out ClsPages lastRecord)
            {
                lastRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [Pages] WHERE " + sqlCondition
                    + " ORDER BY " + colName + " DESC", out dr))
                    return false;
                if (!GetRecord(dr, out lastRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }

            #endregion

            #region Row Operations


            public bool Add()
            {
                string sqlString;
                string values = "";
                string fields = "";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    if (Page_name_changed)
                    {
                        fields += "Page_name,";
                        values += "N'" + Page_name + "',";
                    }
                    if (Page_status_changed)
                    {
                        fields += "Page_status,";
                        values += "N'" + Page_status + "',";
                    }
                    if (Page_creation_date_changed)
                    {
                        fields += "Page_creation_date,";
                        values += "N'" + Page_creation_date + "',";
                    }
                    if (Page_modification_date_changed)
                    {
                        fields += "Page_modification_date,";
                        values += "N'" + Page_modification_date + "',";
                    }
                    if (Page_creation_user_changed)
                    {
                        fields += "Page_creation_user,";
                        values += "N'" + Page_creation_user + "',";
                    }
                    if (Page_modification_user_changed)
                    {
                        fields += "Page_modification_user,";
                        values += "N'" + Page_modification_user + "',";
                    }
                    if (Page_type_changed)
                    {
                        fields += "Page_type,";
                        values += "N'" + Page_type + "',";
                    }

                    #endregion
                    if (fields == "")
                        return true;
                    fields = fields.Substring(0, fields.Length - 1);
                    values = values.Substring(0, values.Length - 1);
                    sqlString = "INSERT INTO [Pages] (" + fields + ") VALUES (" + values + ") select @@identity";
                    if (sqlPars.Count == 0)
                    {
                        //Page_id = short.Parse(sqlEngine.ExecuteScalar(sqlString).ToString());
                        //if (Page_id <= 0)
                        //    throw new Exception("Error in Add function, can not execute sql statement");
                    }
                    else
                        if (!sqlEngine.NonQueryCommand(sqlString, sqlPars))
                        throw new Exception("Error in Add function, can not execute sql statement");

                    #region Set old field variables

                    oldData.Page_id = Page_id;
                    oldData.Page_name = Page_name;
                    oldData.Page_status = Page_status;
                    oldData.Page_creation_date = Page_creation_date;
                    oldData.Page_modification_date = Page_modification_date;
                    oldData.Page_creation_user = Page_creation_user;
                    oldData.Page_modification_user = Page_modification_user;
                    oldData.Page_type = Page_type;

                    #endregion

                    ResetChangesFlags();
                    if (!sqlEngine.GetTopRecordID("[Pages]", "Page_id", out df_Page_id))
                        throw new Exception("Error in Add function, can't read id");
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool AddSqlCommands(ref ArrayList transactions, ref ArrayList parameters)
            {
                string sqlString;
                string values = "";
                string fields = "";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    if (Page_name_changed)
                    {
                        fields += "Page_name,";
                        values += "N'" + Page_name + "',";
                    }
                    if (Page_status_changed)
                    {
                        fields += "Page_status,";
                        values += "N'" + Page_status + "',";
                    }
                    if (Page_creation_date_changed)
                    {
                        fields += "Page_creation_date,";
                        values += "N'" + Page_creation_date + "',";
                    }
                    if (Page_modification_date_changed)
                    {
                        fields += "Page_modification_date,";
                        values += "N'" + Page_modification_date + "',";
                    }
                    if (Page_creation_user_changed)
                    {
                        fields += "Page_creation_user,";
                        values += "N'" + Page_creation_user + "',";
                    }
                    if (Page_modification_user_changed)
                    {
                        fields += "Page_modification_user,";
                        values += "N'" + Page_modification_user + "',";
                    }
                    if (Page_type_changed)
                    {
                        fields += "Page_type,";
                        values += "N'" + Page_type + "',";
                    }

                    #endregion
                    if (fields == "")
                        return true;
                    fields = fields.Substring(0, fields.Length - 1);
                    values = values.Substring(0, values.Length - 1);
                    sqlString = "INSERT INTO [Pages] (" + fields + ") VALUES (" + values + ")";
                    transactions.Add(sqlString);
                    parameters.Add(sqlPars);

                    #region Set old field variables

                    oldData.Page_id = Page_id;
                    oldData.Page_name = Page_name;
                    oldData.Page_status = Page_status;
                    oldData.Page_creation_date = Page_creation_date;
                    oldData.Page_modification_date = Page_modification_date;
                    oldData.Page_creation_user = Page_creation_user;
                    oldData.Page_modification_user = Page_modification_user;
                    oldData.Page_type = Page_type;

                    #endregion

                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool Delete()
            {
                #region Condition(s)


                #endregion
                string sqlString = "DELETE FROM [Pages] WHERE Page_id='" + Page_id + "' AND ";
                sqlString = sqlString.Substring(0, sqlString.Length - 5);
                try
                {
                    if (!sqlEngine.NonQueryCommand(sqlString))
                        throw new Exception("Error in Delete function");
                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool DeleteSqlCommands(ref ArrayList transactions, ref ArrayList parameters)
            {
                #region Value updates


                #endregion
                string sqlString = "DELETE FROM [Pages] WHERE Page_id='" + Page_id + "' AND ";
                sqlString = sqlString.Substring(0, sqlString.Length - 5);
                try
                {
                    transactions.Add(sqlString);
                    parameters.Add(new ArrayList());
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool Update()
            {
                string sqlString = "UPDATE [Pages] SET ";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    string values = "";
                    #region Page_id


                    #endregion
                    #region Page_name

                    if (Page_name_changed)
                    {
                        if (df_Page_name == null)
                        {
                            values += "Page_name=null,";
                        }
                        else
                        {
                            values += "Page_name=N'" + df_Page_name + "',";
                        }
                    }

                    #endregion
                    #region Page_status

                    if (Page_status_changed)
                    {
                        if (df_Page_status == null)
                        {
                            values += "Page_status=null,";
                        }
                        else
                        {
                            values += "Page_status=N'" + df_Page_status + "',";
                        }
                    }

                    #endregion
                    #region Page_creation_date

                    if (Page_creation_date_changed)
                    {
                        if (df_Page_creation_date == null)
                        {
                            values += "Page_creation_date=null,";
                        }
                        else
                        {
                            values += "Page_creation_date=N'" + df_Page_creation_date + "',";
                        }
                    }

                    #endregion
                    #region Page_modification_date

                    if (Page_modification_date_changed)
                    {
                        if (df_Page_modification_date == null)
                        {
                            values += "Page_modification_date=null,";
                        }
                        else
                        {
                            values += "Page_modification_date=N'" + df_Page_modification_date + "',";
                        }
                    }

                    #endregion
                    #region Page_creation_user

                    if (Page_creation_user_changed)
                    {
                        if (df_Page_creation_user == null)
                        {
                            values += "Page_creation_user=null,";
                        }
                        else
                        {
                            values += "Page_creation_user=N'" + df_Page_creation_user + "',";
                        }
                    }

                    #endregion
                    #region Page_modification_user

                    if (Page_modification_user_changed)
                    {
                        if (df_Page_modification_user == null)
                        {
                            values += "Page_modification_user=null,";
                        }
                        else
                        {
                            values += "Page_modification_user=N'" + df_Page_modification_user + "',";
                        }
                    }

                    #endregion
                    #region Page_type

                    if (Page_type_changed)
                    {
                        if (df_Page_type == null)
                        {
                            values += "Page_type=null,";
                        }
                        else
                        {
                            values += "Page_type=N'" + df_Page_type + "',";
                        }
                    }

                    #endregion
                    if (values == "")
                        return true;
                    sqlString += values;

                    #endregion
                    if (sqlString[sqlString.Length - 1] == ',')
                        sqlString = sqlString.Substring(0, sqlString.Length - 1);
                    string whereCondition = " WHERE ";
                    whereCondition += "Page_id='" + df_Page_id + "' AND ";
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                    sqlString += whereCondition;
                    if (sqlPars.Count == 0)
                    {
                        if (!sqlEngine.NonQueryCommand(sqlString))
                            throw new Exception("Error in Update function");
                    }
                    else
                        if (!sqlEngine.NonQueryCommand(sqlString, sqlPars))
                        throw new Exception("Error in Update function");
                    oldData.Page_id = Page_id;
                    oldData.Page_name = Page_name;
                    oldData.Page_status = Page_status;
                    oldData.Page_creation_date = Page_creation_date;
                    oldData.Page_modification_date = Page_modification_date;
                    oldData.Page_creation_user = Page_creation_user;
                    oldData.Page_modification_user = Page_modification_user;
                    oldData.Page_type = Page_type;
                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool UpdateSqlCommands(ref ArrayList transactions, ref ArrayList parameters)
            {
                string sqlString = "UPDATE [Pages] SET ";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    string values = "";
                    if (Page_name_changed)
                    {
                        if (df_Page_name == null)
                        {
                            values += "Page_name=null,";
                        }
                        else
                        {
                            values += "Page_name=N'" + df_Page_name + "',";
                        }
                    }
                    if (Page_status_changed)
                    {
                        if (df_Page_status == null)
                        {
                            values += "Page_status=null,";
                        }
                        else
                        {
                            values += "Page_status=N'" + df_Page_status + "',";
                        }
                    }
                    if (Page_creation_date_changed)
                    {
                        if (df_Page_creation_date == null)
                        {
                            values += "Page_creation_date=null,";
                        }
                        else
                        {
                            values += "Page_creation_date=N'" + df_Page_creation_date + "',";
                        }
                    }
                    if (Page_modification_date_changed)
                    {
                        if (df_Page_modification_date == null)
                        {
                            values += "Page_modification_date=null,";
                        }
                        else
                        {
                            values += "Page_modification_date=N'" + df_Page_modification_date + "',";
                        }
                    }
                    if (Page_creation_user_changed)
                    {
                        if (df_Page_creation_user == null)
                        {
                            values += "Page_creation_user=null,";
                        }
                        else
                        {
                            values += "Page_creation_user=N'" + df_Page_creation_user + "',";
                        }
                    }
                    if (Page_modification_user_changed)
                    {
                        if (df_Page_modification_user == null)
                        {
                            values += "Page_modification_user=null,";
                        }
                        else
                        {
                            values += "Page_modification_user=N'" + df_Page_modification_user + "',";
                        }
                    }
                    if (Page_type_changed)
                    {
                        if (df_Page_type == null)
                        {
                            values += "Page_type=null,";
                        }
                        else
                        {
                            values += "Page_type=N'" + df_Page_type + "',";
                        }
                    }
                    if (values == "")
                        return true;
                    sqlString += values;

                    #endregion
                    if (sqlString[sqlString.Length - 1] == ',')
                        sqlString = sqlString.Substring(0, sqlString.Length - 1);
                    string whereCondition = " WHERE ";
                    whereCondition += "Page_id='" + df_Page_id + "' AND ";
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                    sqlString += whereCondition;
                    transactions.Add(sqlString);
                    parameters.Add(sqlPars);
                    oldData.Page_id = Page_id;
                    oldData.Page_name = Page_name;
                    oldData.Page_status = Page_status;
                    oldData.Page_creation_date = Page_creation_date;
                    oldData.Page_modification_date = Page_modification_date;
                    oldData.Page_creation_user = Page_creation_user;
                    oldData.Page_modification_user = Page_modification_user;
                    oldData.Page_type = Page_type;
                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }

            #endregion
        }

        #endregion

        #region PagesContents

        [Serializable]
        public class ClsPagesContents
        {
            private string basicQueryString = "SELECT * FROM [PagesContents]";

            public ClsPagesContents() { }
            public ClsPagesContents(int Pc_id)
            {
                this.Pc_id = Pc_id;
            }

            public ArrayList relationshipChecks = new ArrayList();

            public bool DependanciesExist(out bool dependancyExists)
            {
                dependancyExists = true;
                try
                {
                    foreach (string selectStatement in relationshipChecks)
                    {
                        if (!sqlEngine.DataExists(selectStatement, out dependancyExists))
                            return false;
                        if (dependancyExists)
                            return true;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }

            public override string ToString()
            {
                return "PagesContents";
            }


            public string BasicQueryString
            {
                get
                {
                    return basicQueryString;
                }
                set
                {
                    basicQueryString = value;
                }
            }

            #region Column Names

            public static class Column_Names
            {
                public static string Pc_id
                {
                    get
                    {
                        return "Pc_id";
                    }
                }
                public static string Pc_page_id
                {
                    get
                    {
                        return "Pc_page_id";
                    }
                }
                public static string Pc_name
                {
                    get
                    {
                        return "Pc_name";
                    }
                }
                public static string Pc_Content
                {
                    get
                    {
                        return "Pc_Content";
                    }
                }
                public static string Pc_Status
                {
                    get
                    {
                        return "Pc_Status";
                    }
                }
                public static string Pc_creation_date
                {
                    get
                    {
                        return "Pc_creation_date";
                    }
                }
                public static string Pc_modification_date
                {
                    get
                    {
                        return "Pc_modification_date";
                    }
                }
                public static string Pc_creation_user
                {
                    get
                    {
                        return "Pc_creation_user";
                    }
                }
                public static string Pc_modification_User
                {
                    get
                    {
                        return "Pc_modification_User";
                    }
                }
            }

            #endregion

            #region Data Fields


            private int df_Pc_id;
            public bool Pc_id_changed = false;
            public int Pc_id
            {
                get
                {
                    return df_Pc_id;
                }
                set
                {
                    df_Pc_id = value;
                    oldData.Pc_id = value;
                }
            }

            private int df_Pc_page_id;
            public bool Pc_page_id_changed = false;
            public int Pc_page_id
            {
                get
                {
                    return df_Pc_page_id;
                }
                set
                {
                    df_Pc_page_id = value;
                    oldData.Pc_page_id = value;
                    Pc_page_id_changed = true;
                }
            }

            private string df_Pc_name;
            public bool Pc_name_changed = false;
            public string Pc_name
            {
                get
                {
                    return df_Pc_name;
                }
                set
                {
                    if (oldData.Pc_name != value)
                    {
                        df_Pc_name = value;
                        oldData.Pc_name = value;
                        Pc_name_changed = true;
                    }
                }
            }

            private string df_Pc_Content;
            public bool Pc_Content_changed = false;
            public string Pc_Content
            {
                get
                {
                    return df_Pc_Content;
                }
                set
                {
                    if (oldData.Pc_Content != value)
                    {
                        df_Pc_Content = value;
                        oldData.Pc_Content = value;
                        Pc_Content_changed = true;
                    }
                }
            }

            private short df_Pc_Status;
            public bool Pc_Status_changed = false;
            public short Pc_Status
            {
                get
                {
                    return df_Pc_Status;
                }
                set
                {
                    df_Pc_Status = value;
                    oldData.Pc_Status = value;
                    Pc_Status_changed = true;
                }
            }

            private DateTime df_Pc_creation_date;
            public bool Pc_creation_date_changed = false;
            public DateTime Pc_creation_date
            {
                get
                {
                    return df_Pc_creation_date;
                }
                set
                {
                    if (oldData.Pc_creation_date != value)
                    {
                        df_Pc_creation_date = value;
                        oldData.Pc_creation_date = value;
                        Pc_creation_date_changed = true;
                    }
                }
            }

            private DateTime df_Pc_modification_date;
            public bool Pc_modification_date_changed = false;
            public DateTime Pc_modification_date
            {
                get
                {
                    return df_Pc_modification_date;
                }
                set
                {
                    if (oldData.Pc_modification_date != value)
                    {
                        df_Pc_modification_date = value;
                        oldData.Pc_modification_date = value;
                        Pc_modification_date_changed = true;
                    }
                }
            }

            private int df_Pc_creation_user;
            public bool Pc_creation_user_changed = false;
            public int Pc_creation_user
            {
                get
                {
                    return df_Pc_creation_user;
                }
                set
                {
                    df_Pc_creation_user = value;
                    oldData.Pc_creation_user = value;
                    Pc_creation_user_changed = true;
                }
            }

            private int df_Pc_modification_User;
            public bool Pc_modification_User_changed = false;
            public int Pc_modification_User
            {
                get
                {
                    return df_Pc_modification_User;
                }
                set
                {
                    df_Pc_modification_User = value;
                    oldData.Pc_modification_User = value;
                    Pc_modification_User_changed = true;
                }
            }


            #endregion

            public void ResetChangesFlags()
            {
                Pc_id_changed = false;
                Pc_page_id_changed = false;
                Pc_name_changed = false;
                Pc_Content_changed = false;
                Pc_Status_changed = false;
                Pc_creation_date_changed = false;
                Pc_modification_date_changed = false;
                Pc_creation_user_changed = false;
                Pc_modification_User_changed = false;
            }

            #region OldData Class

            [Serializable]
            private class OldData
            {
                public int Pc_id = new int();
                public int Pc_page_id = new int();
                public string Pc_name;
                public string Pc_Content;
                public short Pc_Status = new short();
                public DateTime Pc_creation_date = new DateTime();
                public DateTime Pc_modification_date = new DateTime();
                public int Pc_creation_user = new int();
                public int Pc_modification_User = new int();
            }

            #endregion

            private OldData oldData = new OldData();

            #region Static Get Functions

            public static class Functions
            {
                public static bool GetRecord(string condition, out ClsPagesContents PagesContents)
                {
                    PagesContents = new ClsPagesContents();
                    string sqlString = "SELECT * FROM [PagesContents]";
                    sqlString += " WHERE " + condition;
                    try
                    {
                        SqlEngine sqlEngine = new SqlEngine(connectionString);
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        if (dr.Read())
                        {
                            if (!Convert.IsDBNull(dr["Pc_id"]))
                            {
                                PagesContents.Pc_id = Convert.ToInt32(dr["Pc_id"].ToString());
                            }
                            else
                                PagesContents.Pc_id = 0;
                            PagesContents.oldData.Pc_id = PagesContents.Pc_id;
                            if (!Convert.IsDBNull(dr["Pc_page_id"]))
                            {
                                PagesContents.Pc_page_id = Convert.ToInt32(dr["Pc_page_id"].ToString());
                            }
                            else
                                PagesContents.Pc_page_id = 0;
                            PagesContents.oldData.Pc_page_id = PagesContents.Pc_page_id;
                            if (!Convert.IsDBNull(dr["Pc_name"]))
                            {
                                PagesContents.Pc_name = Convert.ToString(dr["Pc_name"].ToString());
                            }
                            else
                                PagesContents.Pc_name = null;
                            PagesContents.oldData.Pc_name = PagesContents.Pc_name;
                            if (!Convert.IsDBNull(dr["Pc_Content"]))
                            {
                                PagesContents.Pc_Content = Convert.ToString(dr["Pc_Content"].ToString());
                            }
                            else
                                PagesContents.Pc_Content = null;
                            PagesContents.oldData.Pc_Content = PagesContents.Pc_Content;
                            if (!Convert.IsDBNull(dr["Pc_Status"]))
                            {
                                PagesContents.Pc_Status = Convert.ToInt16(dr["Pc_Status"].ToString());
                            }
                            else
                                PagesContents.Pc_Status = 0;
                            PagesContents.oldData.Pc_Status = PagesContents.Pc_Status;
                            if (!Convert.IsDBNull(dr["Pc_creation_date"]))
                            {
                                PagesContents.Pc_creation_date = Convert.ToDateTime(dr["Pc_creation_date"].ToString());
                            }
                            else
                                PagesContents.Pc_creation_date = new DateTime();
                            PagesContents.oldData.Pc_creation_date = PagesContents.Pc_creation_date;
                            if (!Convert.IsDBNull(dr["Pc_modification_date"]))
                            {
                                PagesContents.Pc_modification_date = Convert.ToDateTime(dr["Pc_modification_date"].ToString());
                            }
                            else
                                PagesContents.Pc_modification_date = new DateTime();
                            PagesContents.oldData.Pc_modification_date = PagesContents.Pc_modification_date;
                            if (!Convert.IsDBNull(dr["Pc_creation_user"]))
                            {
                                PagesContents.Pc_creation_user = Convert.ToInt32(dr["Pc_creation_user"].ToString());
                            }
                            else
                                PagesContents.Pc_creation_user = 0;
                            PagesContents.oldData.Pc_creation_user = PagesContents.Pc_creation_user;
                            if (!Convert.IsDBNull(dr["Pc_modification_User"]))
                            {
                                PagesContents.Pc_modification_User = Convert.ToInt32(dr["Pc_modification_User"].ToString());
                            }
                            else
                                PagesContents.Pc_modification_User = 0;
                            PagesContents.oldData.Pc_modification_User = PagesContents.Pc_modification_User;
                            PagesContents.ResetChangesFlags();
                        }
                        else
                            PagesContents = null;
                        dr.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (debugMode)
                            MessageBox.Show(ex.Message);
                        if (debugExceptionsMode)
                            throw ex;
                    }
                    PagesContents = null;
                    return false;
                }
                public static bool GetRecords(string condition, out ArrayList PagesContentsRecords)
                {
                    ClsPagesContents PagesContents;
                    PagesContentsRecords = new ArrayList();
                    string sqlString = "SELECT * FROM [PagesContents]";
                    sqlString += " WHERE " + condition;
                    try
                    {
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        while (dr.Read())
                        {
                            PagesContents = new ClsPagesContents();
                            if (!Convert.IsDBNull(dr["Pc_id"]))
                            {
                                PagesContents.Pc_id = Convert.ToInt32(dr["Pc_id"].ToString());
                            }
                            else
                                PagesContents.Pc_id = 0;
                            PagesContents.oldData.Pc_id = PagesContents.Pc_id;
                            if (!Convert.IsDBNull(dr["Pc_page_id"]))
                            {
                                PagesContents.Pc_page_id = Convert.ToInt32(dr["Pc_page_id"].ToString());
                            }
                            else
                                PagesContents.Pc_page_id = 0;
                            PagesContents.oldData.Pc_page_id = PagesContents.Pc_page_id;
                            if (!Convert.IsDBNull(dr["Pc_name"]))
                            {
                                PagesContents.Pc_name = Convert.ToString(dr["Pc_name"].ToString());
                            }
                            else
                                PagesContents.Pc_name = null;
                            PagesContents.oldData.Pc_name = PagesContents.Pc_name;
                            if (!Convert.IsDBNull(dr["Pc_Content"]))
                            {
                                PagesContents.Pc_Content = Convert.ToString(dr["Pc_Content"].ToString());
                            }
                            else
                                PagesContents.Pc_Content = null;
                            PagesContents.oldData.Pc_Content = PagesContents.Pc_Content;
                            if (!Convert.IsDBNull(dr["Pc_Status"]))
                            {
                                PagesContents.Pc_Status = Convert.ToInt16(dr["Pc_Status"].ToString());
                            }
                            else
                                PagesContents.Pc_Status = 0;
                            PagesContents.oldData.Pc_Status = PagesContents.Pc_Status;
                            if (!Convert.IsDBNull(dr["Pc_creation_date"]))
                            {
                                PagesContents.Pc_creation_date = Convert.ToDateTime(dr["Pc_creation_date"].ToString());
                            }
                            else
                                PagesContents.Pc_creation_date = new DateTime();
                            PagesContents.oldData.Pc_creation_date = PagesContents.Pc_creation_date;
                            if (!Convert.IsDBNull(dr["Pc_modification_date"]))
                            {
                                PagesContents.Pc_modification_date = Convert.ToDateTime(dr["Pc_modification_date"].ToString());
                            }
                            else
                                PagesContents.Pc_modification_date = new DateTime();
                            PagesContents.oldData.Pc_modification_date = PagesContents.Pc_modification_date;
                            if (!Convert.IsDBNull(dr["Pc_creation_user"]))
                            {
                                PagesContents.Pc_creation_user = Convert.ToInt32(dr["Pc_creation_user"].ToString());
                            }
                            else
                                PagesContents.Pc_creation_user = 0;
                            PagesContents.oldData.Pc_creation_user = PagesContents.Pc_creation_user;
                            if (!Convert.IsDBNull(dr["Pc_modification_User"]))
                            {
                                PagesContents.Pc_modification_User = Convert.ToInt32(dr["Pc_modification_User"].ToString());
                            }
                            else
                                PagesContents.Pc_modification_User = 0;
                            PagesContents.oldData.Pc_modification_User = PagesContents.Pc_modification_User;
                            PagesContents.ResetChangesFlags();
                            PagesContentsRecords.Add(PagesContents);
                        }
                        dr.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (debugMode)
                            MessageBox.Show(ex.Message);
                        if (debugExceptionsMode)
                            throw ex;
                    }
                    return false;
                }
                public static bool GetAll(out ArrayList PagesContentsRecords)
                {
                    ClsPagesContents PagesContents;
                    PagesContentsRecords = new ArrayList();
                    string sqlString = "SELECT * FROM [PagesContents]";
                    try
                    {
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        while (dr.Read())
                        {
                            PagesContents = new ClsPagesContents();
                            if (!Convert.IsDBNull(dr["Pc_id"]))
                            {
                                PagesContents.Pc_id = Convert.ToInt32(dr["Pc_id"].ToString());
                            }
                            else
                                PagesContents.Pc_id = 0;
                            PagesContents.oldData.Pc_id = PagesContents.Pc_id;
                            if (!Convert.IsDBNull(dr["Pc_page_id"]))
                            {
                                PagesContents.Pc_page_id = Convert.ToInt32(dr["Pc_page_id"].ToString());
                            }
                            else
                                PagesContents.Pc_page_id = 0;
                            PagesContents.oldData.Pc_page_id = PagesContents.Pc_page_id;
                            if (!Convert.IsDBNull(dr["Pc_name"]))
                            {
                                PagesContents.Pc_name = Convert.ToString(dr["Pc_name"].ToString());
                            }
                            else
                                PagesContents.Pc_name = null;
                            PagesContents.oldData.Pc_name = PagesContents.Pc_name;
                            if (!Convert.IsDBNull(dr["Pc_Content"]))
                            {
                                PagesContents.Pc_Content = Convert.ToString(dr["Pc_Content"].ToString());
                            }
                            else
                                PagesContents.Pc_Content = null;
                            PagesContents.oldData.Pc_Content = PagesContents.Pc_Content;
                            if (!Convert.IsDBNull(dr["Pc_Status"]))
                            {
                                PagesContents.Pc_Status = Convert.ToInt16(dr["Pc_Status"].ToString());
                            }
                            else
                                PagesContents.Pc_Status = 0;
                            PagesContents.oldData.Pc_Status = PagesContents.Pc_Status;
                            if (!Convert.IsDBNull(dr["Pc_creation_date"]))
                            {
                                PagesContents.Pc_creation_date = Convert.ToDateTime(dr["Pc_creation_date"].ToString());
                            }
                            else
                                PagesContents.Pc_creation_date = new DateTime();
                            PagesContents.oldData.Pc_creation_date = PagesContents.Pc_creation_date;
                            if (!Convert.IsDBNull(dr["Pc_modification_date"]))
                            {
                                PagesContents.Pc_modification_date = Convert.ToDateTime(dr["Pc_modification_date"].ToString());
                            }
                            else
                                PagesContents.Pc_modification_date = new DateTime();
                            PagesContents.oldData.Pc_modification_date = PagesContents.Pc_modification_date;
                            if (!Convert.IsDBNull(dr["Pc_creation_user"]))
                            {
                                PagesContents.Pc_creation_user = Convert.ToInt32(dr["Pc_creation_user"].ToString());
                            }
                            else
                                PagesContents.Pc_creation_user = 0;
                            PagesContents.oldData.Pc_creation_user = PagesContents.Pc_creation_user;
                            if (!Convert.IsDBNull(dr["Pc_modification_User"]))
                            {
                                PagesContents.Pc_modification_User = Convert.ToInt32(dr["Pc_modification_User"].ToString());
                            }
                            else
                                PagesContents.Pc_modification_User = 0;
                            PagesContents.oldData.Pc_modification_User = PagesContents.Pc_modification_User;
                            PagesContents.ResetChangesFlags();
                            PagesContentsRecords.Add(PagesContents);
                        }
                        dr.Close();
                        if (PagesContentsRecords.Count == 0)
                            PagesContents = null;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (debugMode)
                            MessageBox.Show(ex.Message);
                        if (debugExceptionsMode)
                            throw ex;
                    }
                    return false;
                }
            }

            #endregion

            #region Non-static Get Functions

            public bool GetRecord(SqlDataReader dr, out ClsPagesContents PagesContents)
            {
                PagesContents = new ClsPagesContents();
                try
                {
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["Pc_id"]))
                        {
                            PagesContents.Pc_id = Convert.ToInt32(dr["Pc_id"].ToString());
                        }
                        else
                            PagesContents.Pc_id = 0;
                        PagesContents.oldData.Pc_id = PagesContents.Pc_id;
                        if (!Convert.IsDBNull(dr["Pc_page_id"]))
                        {
                            PagesContents.Pc_page_id = Convert.ToInt32(dr["Pc_page_id"].ToString());
                        }
                        else
                            PagesContents.Pc_page_id = 0;
                        PagesContents.oldData.Pc_page_id = PagesContents.Pc_page_id;
                        if (!Convert.IsDBNull(dr["Pc_name"]))
                        {
                            PagesContents.Pc_name = Convert.ToString(dr["Pc_name"].ToString());
                        }
                        else
                            PagesContents.Pc_name = null;
                        PagesContents.oldData.Pc_name = PagesContents.Pc_name;
                        if (!Convert.IsDBNull(dr["Pc_Content"]))
                        {
                            PagesContents.Pc_Content = Convert.ToString(dr["Pc_Content"].ToString());
                        }
                        else
                            PagesContents.Pc_Content = null;
                        PagesContents.oldData.Pc_Content = PagesContents.Pc_Content;
                        if (!Convert.IsDBNull(dr["Pc_Status"]))
                        {
                            PagesContents.Pc_Status = Convert.ToInt16(dr["Pc_Status"].ToString());
                        }
                        else
                            PagesContents.Pc_Status = 0;
                        PagesContents.oldData.Pc_Status = PagesContents.Pc_Status;
                        if (!Convert.IsDBNull(dr["Pc_creation_date"]))
                        {
                            PagesContents.Pc_creation_date = Convert.ToDateTime(dr["Pc_creation_date"].ToString());
                        }
                        else
                            PagesContents.Pc_creation_date = new DateTime();
                        PagesContents.oldData.Pc_creation_date = PagesContents.Pc_creation_date;
                        if (!Convert.IsDBNull(dr["Pc_modification_date"]))
                        {
                            PagesContents.Pc_modification_date = Convert.ToDateTime(dr["Pc_modification_date"].ToString());
                        }
                        else
                            PagesContents.Pc_modification_date = new DateTime();
                        PagesContents.oldData.Pc_modification_date = PagesContents.Pc_modification_date;
                        if (!Convert.IsDBNull(dr["Pc_creation_user"]))
                        {
                            PagesContents.Pc_creation_user = Convert.ToInt32(dr["Pc_creation_user"].ToString());
                        }
                        else
                            PagesContents.Pc_creation_user = 0;
                        PagesContents.oldData.Pc_creation_user = PagesContents.Pc_creation_user;
                        if (!Convert.IsDBNull(dr["Pc_modification_User"]))
                        {
                            PagesContents.Pc_modification_User = Convert.ToInt32(dr["Pc_modification_User"].ToString());
                        }
                        else
                            PagesContents.Pc_modification_User = 0;
                        PagesContents.oldData.Pc_modification_User = PagesContents.Pc_modification_User;
                        PagesContents.ResetChangesFlags();
                    }
                    else
                        PagesContents = null;
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                PagesContents = null;
                return false;
            }
            public bool GetRecord(string condition, out ClsPagesContents PagesContents)
            {
                string sqlString = "SELECT * FROM [PagesContents]";
                sqlString += " WHERE " + condition;
                PagesContents = new ClsPagesContents();
                try
                {
                    SqlEngine sqlEngine = new SqlEngine(connectionString);
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["Pc_id"]))
                        {
                            PagesContents.Pc_id = Convert.ToInt32(dr["Pc_id"].ToString());
                        }
                        else
                            PagesContents.Pc_id = 0;
                        PagesContents.oldData.Pc_id = PagesContents.Pc_id;
                        if (!Convert.IsDBNull(dr["Pc_page_id"]))
                        {
                            PagesContents.Pc_page_id = Convert.ToInt32(dr["Pc_page_id"].ToString());
                        }
                        else
                            PagesContents.Pc_page_id = 0;
                        PagesContents.oldData.Pc_page_id = PagesContents.Pc_page_id;
                        if (!Convert.IsDBNull(dr["Pc_name"]))
                        {
                            PagesContents.Pc_name = Convert.ToString(dr["Pc_name"].ToString());
                        }
                        else
                            PagesContents.Pc_name = null;
                        PagesContents.oldData.Pc_name = PagesContents.Pc_name;
                        if (!Convert.IsDBNull(dr["Pc_Content"]))
                        {
                            PagesContents.Pc_Content = Convert.ToString(dr["Pc_Content"].ToString());
                        }
                        else
                            PagesContents.Pc_Content = null;
                        PagesContents.oldData.Pc_Content = PagesContents.Pc_Content;
                        if (!Convert.IsDBNull(dr["Pc_Status"]))
                        {
                            PagesContents.Pc_Status = Convert.ToInt16(dr["Pc_Status"].ToString());
                        }
                        else
                            PagesContents.Pc_Status = 0;
                        PagesContents.oldData.Pc_Status = PagesContents.Pc_Status;
                        if (!Convert.IsDBNull(dr["Pc_creation_date"]))
                        {
                            PagesContents.Pc_creation_date = Convert.ToDateTime(dr["Pc_creation_date"].ToString());
                        }
                        else
                            PagesContents.Pc_creation_date = new DateTime();
                        PagesContents.oldData.Pc_creation_date = PagesContents.Pc_creation_date;
                        if (!Convert.IsDBNull(dr["Pc_modification_date"]))
                        {
                            PagesContents.Pc_modification_date = Convert.ToDateTime(dr["Pc_modification_date"].ToString());
                        }
                        else
                            PagesContents.Pc_modification_date = new DateTime();
                        PagesContents.oldData.Pc_modification_date = PagesContents.Pc_modification_date;
                        if (!Convert.IsDBNull(dr["Pc_creation_user"]))
                        {
                            PagesContents.Pc_creation_user = Convert.ToInt32(dr["Pc_creation_user"].ToString());
                        }
                        else
                            PagesContents.Pc_creation_user = 0;
                        PagesContents.oldData.Pc_creation_user = PagesContents.Pc_creation_user;
                        if (!Convert.IsDBNull(dr["Pc_modification_User"]))
                        {
                            PagesContents.Pc_modification_User = Convert.ToInt32(dr["Pc_modification_User"].ToString());
                        }
                        else
                            PagesContents.Pc_modification_User = 0;
                        PagesContents.oldData.Pc_modification_User = PagesContents.Pc_modification_User;
                        PagesContents.ResetChangesFlags();
                    }
                    else
                        PagesContents = null;
                    dr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                PagesContents = null;
                return false;
            }
            public bool GetRecord()
            {
                try
                {
                    string whereCondition = " WHERE ";
                    whereCondition += "Pc_id='" + df_Pc_id + "' AND ";
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                    string sqlString = "SELECT * FROM [PagesContents]" + whereCondition;
                    try
                    {
                        SqlEngine sqlEngine = new SqlEngine(connectionString);
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        if (dr.Read())
                        {
                            if (!Convert.IsDBNull(dr["Pc_id"]))
                            {
                                Pc_id = Convert.ToInt32(dr["Pc_id"].ToString());
                            }
                            else
                                Pc_id = 0;
                            oldData.Pc_id = Pc_id;
                            if (!Convert.IsDBNull(dr["Pc_page_id"]))
                            {
                                Pc_page_id = Convert.ToInt32(dr["Pc_page_id"].ToString());
                            }
                            else
                                Pc_page_id = 0;
                            oldData.Pc_page_id = Pc_page_id;
                            if (!Convert.IsDBNull(dr["Pc_name"]))
                            {
                                Pc_name = Convert.ToString(dr["Pc_name"].ToString());
                            }
                            else
                                Pc_name = null;
                            oldData.Pc_name = Pc_name;
                            if (!Convert.IsDBNull(dr["Pc_Content"]))
                            {
                                Pc_Content = Convert.ToString(dr["Pc_Content"].ToString());
                            }
                            else
                                Pc_Content = null;
                            oldData.Pc_Content = Pc_Content;
                            if (!Convert.IsDBNull(dr["Pc_Status"]))
                            {
                                Pc_Status = Convert.ToInt16(dr["Pc_Status"].ToString());
                            }
                            else
                                Pc_Status = 0;
                            oldData.Pc_Status = Pc_Status;
                            if (!Convert.IsDBNull(dr["Pc_creation_date"]))
                            {
                                Pc_creation_date = Convert.ToDateTime(dr["Pc_creation_date"].ToString());
                            }
                            else
                                Pc_creation_date = new DateTime();
                            oldData.Pc_creation_date = Pc_creation_date;
                            if (!Convert.IsDBNull(dr["Pc_modification_date"]))
                            {
                                Pc_modification_date = Convert.ToDateTime(dr["Pc_modification_date"].ToString());
                            }
                            else
                                Pc_modification_date = new DateTime();
                            oldData.Pc_modification_date = Pc_modification_date;
                            if (!Convert.IsDBNull(dr["Pc_creation_user"]))
                            {
                                Pc_creation_user = Convert.ToInt32(dr["Pc_creation_user"].ToString());
                            }
                            else
                                Pc_creation_user = 0;
                            oldData.Pc_creation_user = Pc_creation_user;
                            if (!Convert.IsDBNull(dr["Pc_modification_User"]))
                            {
                                Pc_modification_User = Convert.ToInt32(dr["Pc_modification_User"].ToString());
                            }
                            else
                                Pc_modification_User = 0;
                            oldData.Pc_modification_User = Pc_modification_User;
                            ResetChangesFlags();
                        }
                        else
                            throw new Exception("Record not found");
                        dr.Close();
                        return true;
                    }
                    catch (Exception InnerEx)
                    {
                        if (debugMode)
                            MessageBox.Show(InnerEx.Message);
                        if (debugExceptionsMode)
                            throw InnerEx;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool GetRecord(out ClsPagesContents PagesContents)
            {
                string whereCondition = " WHERE ";
                whereCondition += "Pc_id='" + df_Pc_id + "' AND ";
                whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                PagesContents = new ClsPagesContents(df_Pc_id);
                string sqlString = "SELECT * FROM [PagesContents]" + whereCondition;
                try
                {
                    SqlEngine sqlEngine = new SqlEngine(connectionString);
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["Pc_id"]))
                        {
                            PagesContents.Pc_id = Convert.ToInt32(dr["Pc_id"].ToString());
                        }
                        else
                            PagesContents.Pc_id = 0;
                        PagesContents.oldData.Pc_id = PagesContents.Pc_id;
                        if (!Convert.IsDBNull(dr["Pc_page_id"]))
                        {
                            PagesContents.Pc_page_id = Convert.ToInt32(dr["Pc_page_id"].ToString());
                        }
                        else
                            PagesContents.Pc_page_id = 0;
                        PagesContents.oldData.Pc_page_id = PagesContents.Pc_page_id;
                        if (!Convert.IsDBNull(dr["Pc_name"]))
                        {
                            PagesContents.Pc_name = Convert.ToString(dr["Pc_name"].ToString());
                        }
                        else
                            PagesContents.Pc_name = null;
                        PagesContents.oldData.Pc_name = PagesContents.Pc_name;
                        if (!Convert.IsDBNull(dr["Pc_Content"]))
                        {
                            PagesContents.Pc_Content = Convert.ToString(dr["Pc_Content"].ToString());
                        }
                        else
                            PagesContents.Pc_Content = null;
                        PagesContents.oldData.Pc_Content = PagesContents.Pc_Content;
                        if (!Convert.IsDBNull(dr["Pc_Status"]))
                        {
                            PagesContents.Pc_Status = Convert.ToInt16(dr["Pc_Status"].ToString());
                        }
                        else
                            PagesContents.Pc_Status = 0;
                        PagesContents.oldData.Pc_Status = PagesContents.Pc_Status;
                        if (!Convert.IsDBNull(dr["Pc_creation_date"]))
                        {
                            PagesContents.Pc_creation_date = Convert.ToDateTime(dr["Pc_creation_date"].ToString());
                        }
                        else
                            PagesContents.Pc_creation_date = new DateTime();
                        PagesContents.oldData.Pc_creation_date = PagesContents.Pc_creation_date;
                        if (!Convert.IsDBNull(dr["Pc_modification_date"]))
                        {
                            PagesContents.Pc_modification_date = Convert.ToDateTime(dr["Pc_modification_date"].ToString());
                        }
                        else
                            PagesContents.Pc_modification_date = new DateTime();
                        PagesContents.oldData.Pc_modification_date = PagesContents.Pc_modification_date;
                        if (!Convert.IsDBNull(dr["Pc_creation_user"]))
                        {
                            PagesContents.Pc_creation_user = Convert.ToInt32(dr["Pc_creation_user"].ToString());
                        }
                        else
                            PagesContents.Pc_creation_user = 0;
                        PagesContents.oldData.Pc_creation_user = PagesContents.Pc_creation_user;
                        if (!Convert.IsDBNull(dr["Pc_modification_User"]))
                        {
                            PagesContents.Pc_modification_User = Convert.ToInt32(dr["Pc_modification_User"].ToString());
                        }
                        else
                            PagesContents.Pc_modification_User = 0;
                        PagesContents.oldData.Pc_modification_User = PagesContents.Pc_modification_User;
                        PagesContents.ResetChangesFlags();
                    }
                    else
                        PagesContents = null;
                    dr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                PagesContents = null;
                return false;
            }
            public bool GetRecords(string condition, out ArrayList PagesContentsRecords)
            {
                ClsPagesContents PagesContents;
                PagesContentsRecords = new ArrayList();
                string sqlString = "SELECT * FROM [PagesContents]";
                sqlString += " WHERE " + condition;
                try
                {
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    while (dr.Read())
                    {
                        PagesContents = new ClsPagesContents();
                        if (!Convert.IsDBNull(dr["Pc_id"]))
                        {
                            PagesContents.Pc_id = Convert.ToInt32(dr["Pc_id"].ToString());
                        }
                        else
                            PagesContents.Pc_id = 0;
                        PagesContents.oldData.Pc_id = PagesContents.Pc_id;
                        if (!Convert.IsDBNull(dr["Pc_page_id"]))
                        {
                            PagesContents.Pc_page_id = Convert.ToInt32(dr["Pc_page_id"].ToString());
                        }
                        else
                            PagesContents.Pc_page_id = 0;
                        PagesContents.oldData.Pc_page_id = PagesContents.Pc_page_id;
                        if (!Convert.IsDBNull(dr["Pc_name"]))
                        {
                            PagesContents.Pc_name = Convert.ToString(dr["Pc_name"].ToString());
                        }
                        else
                            PagesContents.Pc_name = null;
                        PagesContents.oldData.Pc_name = PagesContents.Pc_name;
                        if (!Convert.IsDBNull(dr["Pc_Content"]))
                        {
                            PagesContents.Pc_Content = Convert.ToString(dr["Pc_Content"].ToString());
                        }
                        else
                            PagesContents.Pc_Content = null;
                        PagesContents.oldData.Pc_Content = PagesContents.Pc_Content;
                        if (!Convert.IsDBNull(dr["Pc_Status"]))
                        {
                            PagesContents.Pc_Status = Convert.ToInt16(dr["Pc_Status"].ToString());
                        }
                        else
                            PagesContents.Pc_Status = 0;
                        PagesContents.oldData.Pc_Status = PagesContents.Pc_Status;
                        if (!Convert.IsDBNull(dr["Pc_creation_date"]))
                        {
                            PagesContents.Pc_creation_date = Convert.ToDateTime(dr["Pc_creation_date"].ToString());
                        }
                        else
                            PagesContents.Pc_creation_date = new DateTime();
                        PagesContents.oldData.Pc_creation_date = PagesContents.Pc_creation_date;
                        if (!Convert.IsDBNull(dr["Pc_modification_date"]))
                        {
                            PagesContents.Pc_modification_date = Convert.ToDateTime(dr["Pc_modification_date"].ToString());
                        }
                        else
                            PagesContents.Pc_modification_date = new DateTime();
                        PagesContents.oldData.Pc_modification_date = PagesContents.Pc_modification_date;
                        if (!Convert.IsDBNull(dr["Pc_creation_user"]))
                        {
                            PagesContents.Pc_creation_user = Convert.ToInt32(dr["Pc_creation_user"].ToString());
                        }
                        else
                            PagesContents.Pc_creation_user = 0;
                        PagesContents.oldData.Pc_creation_user = PagesContents.Pc_creation_user;
                        if (!Convert.IsDBNull(dr["Pc_modification_User"]))
                        {
                            PagesContents.Pc_modification_User = Convert.ToInt32(dr["Pc_modification_User"].ToString());
                        }
                        else
                            PagesContents.Pc_modification_User = 0;
                        PagesContents.oldData.Pc_modification_User = PagesContents.Pc_modification_User;
                        PagesContents.ResetChangesFlags();
                        PagesContentsRecords.Add(PagesContents);
                    }
                    dr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool GetAll(out ArrayList PagesContentsRecords)
            {
                ClsPagesContents PagesContents;
                PagesContentsRecords = new ArrayList();
                string sqlString = "SELECT * FROM [PagesContents]";
                try
                {
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    while (dr.Read())
                    {
                        PagesContents = new ClsPagesContents();
                        if (!Convert.IsDBNull(dr["Pc_id"]))
                        {
                            PagesContents.Pc_id = Convert.ToInt32(dr["Pc_id"].ToString());
                        }
                        else
                            PagesContents.Pc_id = 0;
                        PagesContents.oldData.Pc_id = PagesContents.Pc_id;
                        if (!Convert.IsDBNull(dr["Pc_page_id"]))
                        {
                            PagesContents.Pc_page_id = Convert.ToInt32(dr["Pc_page_id"].ToString());
                        }
                        else
                            PagesContents.Pc_page_id = 0;
                        PagesContents.oldData.Pc_page_id = PagesContents.Pc_page_id;
                        if (!Convert.IsDBNull(dr["Pc_name"]))
                        {
                            PagesContents.Pc_name = Convert.ToString(dr["Pc_name"].ToString());
                        }
                        else
                            PagesContents.Pc_name = null;
                        PagesContents.oldData.Pc_name = PagesContents.Pc_name;
                        if (!Convert.IsDBNull(dr["Pc_Content"]))
                        {
                            PagesContents.Pc_Content = Convert.ToString(dr["Pc_Content"].ToString());
                        }
                        else
                            PagesContents.Pc_Content = null;
                        PagesContents.oldData.Pc_Content = PagesContents.Pc_Content;
                        if (!Convert.IsDBNull(dr["Pc_Status"]))
                        {
                            PagesContents.Pc_Status = Convert.ToInt16(dr["Pc_Status"].ToString());
                        }
                        else
                            PagesContents.Pc_Status = 0;
                        PagesContents.oldData.Pc_Status = PagesContents.Pc_Status;
                        if (!Convert.IsDBNull(dr["Pc_creation_date"]))
                        {
                            PagesContents.Pc_creation_date = Convert.ToDateTime(dr["Pc_creation_date"].ToString());
                        }
                        else
                            PagesContents.Pc_creation_date = new DateTime();
                        PagesContents.oldData.Pc_creation_date = PagesContents.Pc_creation_date;
                        if (!Convert.IsDBNull(dr["Pc_modification_date"]))
                        {
                            PagesContents.Pc_modification_date = Convert.ToDateTime(dr["Pc_modification_date"].ToString());
                        }
                        else
                            PagesContents.Pc_modification_date = new DateTime();
                        PagesContents.oldData.Pc_modification_date = PagesContents.Pc_modification_date;
                        if (!Convert.IsDBNull(dr["Pc_creation_user"]))
                        {
                            PagesContents.Pc_creation_user = Convert.ToInt32(dr["Pc_creation_user"].ToString());
                        }
                        else
                            PagesContents.Pc_creation_user = 0;
                        PagesContents.oldData.Pc_creation_user = PagesContents.Pc_creation_user;
                        if (!Convert.IsDBNull(dr["Pc_modification_User"]))
                        {
                            PagesContents.Pc_modification_User = Convert.ToInt32(dr["Pc_modification_User"].ToString());
                        }
                        else
                            PagesContents.Pc_modification_User = 0;
                        PagesContents.oldData.Pc_modification_User = PagesContents.Pc_modification_User;
                        PagesContents.ResetChangesFlags();
                        PagesContentsRecords.Add(PagesContents);
                    }
                    dr.Close();
                    if (PagesContentsRecords.Count == 0)
                        PagesContents = null;
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool GetNext(string colName, string cmpValue, out ClsPagesContents nextRecord)
            {
                return GetRecord(colName + ">'" + cmpValue + "' ORDER BY " + colName, out nextRecord);
            }
            public bool GetNext(string colName, string cmpValue, string sqlCondition, out ClsPagesContents nextRecord)
            {
                return GetRecord(colName + ">'" + cmpValue + "' AND " + sqlCondition + " ORDER BY " + colName, out nextRecord);
            }
            public bool GetPrevious(string colName, string cmpValue, out ClsPagesContents prevRecord)
            {
                return GetRecord(colName + "<'" + cmpValue + "' ORDER BY " + colName + " DESC", out prevRecord);
            }
            public bool GetPrevious(string colName, string cmpValue, string sqlCondition, out ClsPagesContents prevRecord)
            {
                return GetRecord(colName + "<'" + cmpValue + "' AND " + sqlCondition + " ORDER BY " + colName + " DESC", out prevRecord);
            }
            public bool GetFirst(string colName, out ClsPagesContents firstRecord)
            {
                firstRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [PagesContents] ORDER BY " + colName, out dr))
                    return false;
                if (!GetRecord(dr, out firstRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }
            public bool GetFirst(string colName, string sqlCondition, out ClsPagesContents firstRecord)
            {
                firstRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [PagesContents] WHERE " + sqlCondition
                    + " ORDER BY " + colName, out dr))
                    return false;
                if (!GetRecord(dr, out firstRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }
            public bool GetLast(string colName, out ClsPagesContents lastRecord)
            {
                lastRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [PagesContents] ORDER BY " + colName + " DESC", out dr))
                    return false;
                if (!GetRecord(dr, out lastRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }
            public bool GetLast(string colName, string sqlCondition, out ClsPagesContents lastRecord)
            {
                lastRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [PagesContents] WHERE " + sqlCondition
                    + " ORDER BY " + colName + " DESC", out dr))
                    return false;
                if (!GetRecord(dr, out lastRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }

            #endregion

            #region Row Operations


            public bool Add()
            {
                string sqlString;
                string values = "";
                string fields = "";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    if (Pc_page_id_changed)
                    {
                        fields += "Pc_page_id,";
                        values += "N'" + Pc_page_id + "',";
                    }
                    if (Pc_name_changed)
                    {
                        fields += "Pc_name,";
                        values += "N'" + Pc_name + "',";
                    }
                    if (Pc_Content_changed)
                    {
                        fields += "Pc_Content,";
                        values += "N'" + Pc_Content + "',";
                    }
                    if (Pc_Status_changed)
                    {
                        fields += "Pc_Status,";
                        values += "N'" + Pc_Status + "',";
                    }
                    if (Pc_creation_date_changed)
                    {
                        fields += "Pc_creation_date,";
                        values += "N'" + Pc_creation_date + "',";
                    }
                    if (Pc_modification_date_changed)
                    {
                        fields += "Pc_modification_date,";
                        values += "N'" + Pc_modification_date + "',";
                    }
                    if (Pc_creation_user_changed)
                    {
                        fields += "Pc_creation_user,";
                        values += "N'" + Pc_creation_user + "',";
                    }
                    if (Pc_modification_User_changed)
                    {
                        fields += "Pc_modification_User,";
                        values += "N'" + Pc_modification_User + "',";
                    }

                    #endregion
                    if (fields == "")
                        return true;
                    fields = fields.Substring(0, fields.Length - 1);
                    values = values.Substring(0, values.Length - 1);
                    sqlString = "INSERT INTO [PagesContents] (" + fields + ") VALUES (" + values + ") select @@identity";
                    if (sqlPars.Count == 0)
                    {
                        //Pc_id = short.Parse(sqlEngine.ExecuteScalar(sqlString).ToString());
                        //if (Pc_id <= 0)
                        //	throw new Exception("Error in Add function, can not execute sql statement");
                    }
                    else
                        if (!sqlEngine.NonQueryCommand(sqlString, sqlPars))
                        throw new Exception("Error in Add function, can not execute sql statement");

                    #region Set old field variables

                    oldData.Pc_id = Pc_id;
                    oldData.Pc_page_id = Pc_page_id;
                    oldData.Pc_name = Pc_name;
                    oldData.Pc_Content = Pc_Content;
                    oldData.Pc_Status = Pc_Status;
                    oldData.Pc_creation_date = Pc_creation_date;
                    oldData.Pc_modification_date = Pc_modification_date;
                    oldData.Pc_creation_user = Pc_creation_user;
                    oldData.Pc_modification_User = Pc_modification_User;

                    #endregion

                    ResetChangesFlags();
                    if (!sqlEngine.GetTopRecordID("[PagesContents]", "Pc_id", out df_Pc_id))
                        throw new Exception("Error in Add function, can't read id");
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool AddSqlCommands(ref ArrayList transactions, ref ArrayList parameters)
            {
                string sqlString;
                string values = "";
                string fields = "";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    if (Pc_page_id_changed)
                    {
                        fields += "Pc_page_id,";
                        values += "N'" + Pc_page_id + "',";
                    }
                    if (Pc_name_changed)
                    {
                        fields += "Pc_name,";
                        values += "N'" + Pc_name + "',";
                    }
                    if (Pc_Content_changed)
                    {
                        fields += "Pc_Content,";
                        values += "N'" + Pc_Content + "',";
                    }
                    if (Pc_Status_changed)
                    {
                        fields += "Pc_Status,";
                        values += "N'" + Pc_Status + "',";
                    }
                    if (Pc_creation_date_changed)
                    {
                        fields += "Pc_creation_date,";
                        values += "N'" + Pc_creation_date + "',";
                    }
                    if (Pc_modification_date_changed)
                    {
                        fields += "Pc_modification_date,";
                        values += "N'" + Pc_modification_date + "',";
                    }
                    if (Pc_creation_user_changed)
                    {
                        fields += "Pc_creation_user,";
                        values += "N'" + Pc_creation_user + "',";
                    }
                    if (Pc_modification_User_changed)
                    {
                        fields += "Pc_modification_User,";
                        values += "N'" + Pc_modification_User + "',";
                    }

                    #endregion
                    if (fields == "")
                        return true;
                    fields = fields.Substring(0, fields.Length - 1);
                    values = values.Substring(0, values.Length - 1);
                    sqlString = "INSERT INTO [PagesContents] (" + fields + ") VALUES (" + values + ")";
                    transactions.Add(sqlString);
                    parameters.Add(sqlPars);

                    #region Set old field variables

                    oldData.Pc_id = Pc_id;
                    oldData.Pc_page_id = Pc_page_id;
                    oldData.Pc_name = Pc_name;
                    oldData.Pc_Content = Pc_Content;
                    oldData.Pc_Status = Pc_Status;
                    oldData.Pc_creation_date = Pc_creation_date;
                    oldData.Pc_modification_date = Pc_modification_date;
                    oldData.Pc_creation_user = Pc_creation_user;
                    oldData.Pc_modification_User = Pc_modification_User;

                    #endregion

                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool Delete()
            {
                #region Condition(s)


                #endregion
                string sqlString = "DELETE FROM [PagesContents] WHERE Pc_id='" + Pc_id + "' AND ";
                sqlString = sqlString.Substring(0, sqlString.Length - 5);
                try
                {
                    if (!sqlEngine.NonQueryCommand(sqlString))
                        throw new Exception("Error in Delete function");
                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool DeleteSqlCommands(ref ArrayList transactions, ref ArrayList parameters)
            {
                #region Value updates


                #endregion
                string sqlString = "DELETE FROM [PagesContents] WHERE Pc_id='" + Pc_id + "' AND ";
                sqlString = sqlString.Substring(0, sqlString.Length - 5);
                try
                {
                    transactions.Add(sqlString);
                    parameters.Add(new ArrayList());
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool Update()
            {
                string sqlString = "UPDATE [PagesContents] SET ";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    string values = "";
                    #region Pc_id


                    #endregion
                    #region Pc_page_id

                    if (Pc_page_id_changed)
                    {
                        if (df_Pc_page_id == null)
                        {
                            values += "Pc_page_id=null,";
                        }
                        else
                        {
                            values += "Pc_page_id=N'" + df_Pc_page_id + "',";
                        }
                    }

                    #endregion
                    #region Pc_name

                    if (Pc_name_changed)
                    {
                        if (df_Pc_name == null)
                        {
                            values += "Pc_name=null,";
                        }
                        else
                        {
                            values += "Pc_name=N'" + df_Pc_name + "',";
                        }
                    }

                    #endregion
                    #region Pc_Content

                    if (Pc_Content_changed)
                    {
                        if (df_Pc_Content == null)
                        {
                            values += "Pc_Content=null,";
                        }
                        else
                        {
                            values += "Pc_Content=N'" + df_Pc_Content + "',";
                        }
                    }

                    #endregion
                    #region Pc_Status

                    if (Pc_Status_changed)
                    {
                        if (df_Pc_Status == null)
                        {
                            values += "Pc_Status=null,";
                        }
                        else
                        {
                            values += "Pc_Status=N'" + df_Pc_Status + "',";
                        }
                    }

                    #endregion
                    #region Pc_creation_date

                    if (Pc_creation_date_changed)
                    {
                        if (df_Pc_creation_date == null)
                        {
                            values += "Pc_creation_date=null,";
                        }
                        else
                        {
                            values += "Pc_creation_date=N'" + df_Pc_creation_date + "',";
                        }
                    }

                    #endregion
                    #region Pc_modification_date

                    if (Pc_modification_date_changed)
                    {
                        if (df_Pc_modification_date == null)
                        {
                            values += "Pc_modification_date=null,";
                        }
                        else
                        {
                            values += "Pc_modification_date=N'" + df_Pc_modification_date + "',";
                        }
                    }

                    #endregion
                    #region Pc_creation_user

                    if (Pc_creation_user_changed)
                    {
                        if (df_Pc_creation_user == null)
                        {
                            values += "Pc_creation_user=null,";
                        }
                        else
                        {
                            values += "Pc_creation_user=N'" + df_Pc_creation_user + "',";
                        }
                    }

                    #endregion
                    #region Pc_modification_User

                    if (Pc_modification_User_changed)
                    {
                        if (df_Pc_modification_User == null)
                        {
                            values += "Pc_modification_User=null,";
                        }
                        else
                        {
                            values += "Pc_modification_User=N'" + df_Pc_modification_User + "',";
                        }
                    }

                    #endregion
                    if (values == "")
                        return true;
                    sqlString += values;

                    #endregion
                    if (sqlString[sqlString.Length - 1] == ',')
                        sqlString = sqlString.Substring(0, sqlString.Length - 1);
                    string whereCondition = " WHERE ";
                    whereCondition += "Pc_id='" + df_Pc_id + "' AND ";
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                    sqlString += whereCondition;
                    if (sqlPars.Count == 0)
                    {
                        if (!sqlEngine.NonQueryCommand(sqlString))
                            throw new Exception("Error in Update function");
                    }
                    else
                        if (!sqlEngine.NonQueryCommand(sqlString, sqlPars))
                        throw new Exception("Error in Update function");
                    oldData.Pc_id = Pc_id;
                    oldData.Pc_page_id = Pc_page_id;
                    oldData.Pc_name = Pc_name;
                    oldData.Pc_Content = Pc_Content;
                    oldData.Pc_Status = Pc_Status;
                    oldData.Pc_creation_date = Pc_creation_date;
                    oldData.Pc_modification_date = Pc_modification_date;
                    oldData.Pc_creation_user = Pc_creation_user;
                    oldData.Pc_modification_User = Pc_modification_User;
                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool UpdateSqlCommands(ref ArrayList transactions, ref ArrayList parameters)
            {
                string sqlString = "UPDATE [PagesContents] SET ";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    string values = "";
                    if (Pc_page_id_changed)
                    {
                        if (df_Pc_page_id == null)
                        {
                            values += "Pc_page_id=null,";
                        }
                        else
                        {
                            values += "Pc_page_id=N'" + df_Pc_page_id + "',";
                        }
                    }
                    if (Pc_name_changed)
                    {
                        if (df_Pc_name == null)
                        {
                            values += "Pc_name=null,";
                        }
                        else
                        {
                            values += "Pc_name=N'" + df_Pc_name + "',";
                        }
                    }
                    if (Pc_Content_changed)
                    {
                        if (df_Pc_Content == null)
                        {
                            values += "Pc_Content=null,";
                        }
                        else
                        {
                            values += "Pc_Content=N'" + df_Pc_Content + "',";
                        }
                    }
                    if (Pc_Status_changed)
                    {
                        if (df_Pc_Status == null)
                        {
                            values += "Pc_Status=null,";
                        }
                        else
                        {
                            values += "Pc_Status=N'" + df_Pc_Status + "',";
                        }
                    }
                    if (Pc_creation_date_changed)
                    {
                        if (df_Pc_creation_date == null)
                        {
                            values += "Pc_creation_date=null,";
                        }
                        else
                        {
                            values += "Pc_creation_date=N'" + df_Pc_creation_date + "',";
                        }
                    }
                    if (Pc_modification_date_changed)
                    {
                        if (df_Pc_modification_date == null)
                        {
                            values += "Pc_modification_date=null,";
                        }
                        else
                        {
                            values += "Pc_modification_date=N'" + df_Pc_modification_date + "',";
                        }
                    }
                    if (Pc_creation_user_changed)
                    {
                        if (df_Pc_creation_user == null)
                        {
                            values += "Pc_creation_user=null,";
                        }
                        else
                        {
                            values += "Pc_creation_user=N'" + df_Pc_creation_user + "',";
                        }
                    }
                    if (Pc_modification_User_changed)
                    {
                        if (df_Pc_modification_User == null)
                        {
                            values += "Pc_modification_User=null,";
                        }
                        else
                        {
                            values += "Pc_modification_User=N'" + df_Pc_modification_User + "',";
                        }
                    }
                    if (values == "")
                        return true;
                    sqlString += values;

                    #endregion
                    if (sqlString[sqlString.Length - 1] == ',')
                        sqlString = sqlString.Substring(0, sqlString.Length - 1);
                    string whereCondition = " WHERE ";
                    whereCondition += "Pc_id='" + df_Pc_id + "' AND ";
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                    sqlString += whereCondition;
                    transactions.Add(sqlString);
                    parameters.Add(sqlPars);
                    oldData.Pc_id = Pc_id;
                    oldData.Pc_page_id = Pc_page_id;
                    oldData.Pc_name = Pc_name;
                    oldData.Pc_Content = Pc_Content;
                    oldData.Pc_Status = Pc_Status;
                    oldData.Pc_creation_date = Pc_creation_date;
                    oldData.Pc_modification_date = Pc_modification_date;
                    oldData.Pc_creation_user = Pc_creation_user;
                    oldData.Pc_modification_User = Pc_modification_User;
                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }

            #endregion
        }

        #endregion

        #region Users

        [Serializable]
        public class ClsUsers
        {
            private string basicQueryString = "SELECT * FROM [Users]";

            public ClsUsers() { }
            public ClsUsers(int Usr_id)
            {
                this.Usr_id = Usr_id;
            }

            public ArrayList relationshipChecks = new ArrayList();

            public bool DependanciesExist(out bool dependancyExists)
            {
                dependancyExists = true;
                try
                {
                    foreach (string selectStatement in relationshipChecks)
                    {
                        if (!sqlEngine.DataExists(selectStatement, out dependancyExists))
                            return false;
                        if (dependancyExists)
                            return true;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }

            public override string ToString()
            {
                return "Users";
            }


            public string BasicQueryString
            {
                get
                {
                    return basicQueryString;
                }
                set
                {
                    basicQueryString = value;
                }
            }

            #region Column Names

            public static class Column_Names
            {
                public static string Usr_id
                {
                    get
                    {
                        return "Usr_id";
                    }
                }
                public static string Usr_username
                {
                    get
                    {
                        return "Usr_username";
                    }
                }
                public static string Usr_password
                {
                    get
                    {
                        return "Usr_password";
                    }
                }
                public static string Usr_email
                {
                    get
                    {
                        return "Usr_email";
                    }
                }
                public static string Usr_creation_date
                {
                    get
                    {
                        return "Usr_creation_date";
                    }
                }
                public static string Usr_status
                {
                    get
                    {
                        return "Usr_status";
                    }
                }
                public static string Usr_last_valid_login
                {
                    get
                    {
                        return "Usr_last_valid_login";
                    }
                }
                public static string Usr_last_invalid_login
                {
                    get
                    {
                        return "Usr_last_invalid_login";
                    }
                }
            }

            #endregion

            #region Data Fields


            private int df_Usr_id;
            public bool Usr_id_changed = false;
            public int Usr_id
            {
                get
                {
                    return df_Usr_id;
                }
                set
                {
                    df_Usr_id = value;
                    oldData.Usr_id = value;
                }
            }

            private string df_Usr_username;
            public bool Usr_username_changed = false;
            public string Usr_username
            {
                get
                {
                    return df_Usr_username;
                }
                set
                {
                    if (oldData.Usr_username != value)
                    {
                        df_Usr_username = value;
                        oldData.Usr_username = value;
                        Usr_username_changed = true;
                    }
                }
            }

            private string df_Usr_password;
            public bool Usr_password_changed = false;
            public string Usr_password
            {
                get
                {
                    return df_Usr_password;
                }
                set
                {
                    if (oldData.Usr_password != value)
                    {
                        df_Usr_password = value;
                        oldData.Usr_password = value;
                        Usr_password_changed = true;
                    }
                }
            }

            private string df_Usr_email;
            public bool Usr_email_changed = false;
            public string Usr_email
            {
                get
                {
                    return df_Usr_email;
                }
                set
                {
                    if (oldData.Usr_email != value)
                    {
                        df_Usr_email = value;
                        oldData.Usr_email = value;
                        Usr_email_changed = true;
                    }
                }
            }

            private DateTime df_Usr_creation_date;
            public bool Usr_creation_date_changed = false;
            public DateTime Usr_creation_date
            {
                get
                {
                    return df_Usr_creation_date;
                }
                set
                {
                    if (oldData.Usr_creation_date != value)
                    {
                        df_Usr_creation_date = value;
                        oldData.Usr_creation_date = value;
                        Usr_creation_date_changed = true;
                    }
                }
            }

            private short df_Usr_status;
            public bool Usr_status_changed = false;
            public short Usr_status
            {
                get
                {
                    return df_Usr_status;
                }
                set
                {
                    df_Usr_status = value;
                    oldData.Usr_status = value;
                    Usr_status_changed = true;
                }
            }

            private DateTime? df_Usr_last_valid_login;
            public bool Usr_last_valid_login_changed = false;
            public DateTime? Usr_last_valid_login
            {
                get
                {
                    return df_Usr_last_valid_login;
                }
                set
                {
                    if (oldData.Usr_last_valid_login != value)
                    {
                        df_Usr_last_valid_login = value;
                        oldData.Usr_last_valid_login = value;
                        Usr_last_valid_login_changed = true;
                    }
                }
            }

            private DateTime? df_Usr_last_invalid_login;
            public bool Usr_last_invalid_login_changed = false;
            public DateTime? Usr_last_invalid_login
            {
                get
                {
                    return df_Usr_last_invalid_login;
                }
                set
                {
                    if (oldData.Usr_last_invalid_login != value)
                    {
                        df_Usr_last_invalid_login = value;
                        oldData.Usr_last_invalid_login = value;
                        Usr_last_invalid_login_changed = true;
                    }
                }
            }


            #endregion

            public void ResetChangesFlags()
            {
                Usr_id_changed = false;
                Usr_username_changed = false;
                Usr_password_changed = false;
                Usr_email_changed = false;
                Usr_creation_date_changed = false;
                Usr_status_changed = false;
                Usr_last_valid_login_changed = false;
                Usr_last_invalid_login_changed = false;
            }

            #region OldData Class

            [Serializable]
            private class OldData
            {
                public int Usr_id = new int();
                public string Usr_username;
                public string Usr_password;
                public string Usr_email;
                public DateTime Usr_creation_date = new DateTime();
                public short Usr_status = new short();
                public DateTime? Usr_last_valid_login = new DateTime?();
                public DateTime? Usr_last_invalid_login = new DateTime?();
            }

            #endregion

            private OldData oldData = new OldData();

            #region Static Get Functions

            public static class Functions
            {
                public static bool GetRecord(string condition, out ClsUsers Users)
                {
                    Users = new ClsUsers();
                    string sqlString = "SELECT * FROM [Users]";
                    sqlString += " WHERE " + condition;
                    try
                    {
                        SqlEngine sqlEngine = new SqlEngine(connectionString);
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        if (dr.Read())
                        {
                            if (!Convert.IsDBNull(dr["Usr_id"]))
                            {
                                Users.Usr_id = Convert.ToInt32(dr["Usr_id"].ToString());
                            }
                            else
                                Users.Usr_id = 0;
                            Users.oldData.Usr_id = Users.Usr_id;
                            if (!Convert.IsDBNull(dr["Usr_username"]))
                            {
                                Users.Usr_username = Convert.ToString(dr["Usr_username"].ToString());
                            }
                            else
                                Users.Usr_username = null;
                            Users.oldData.Usr_username = Users.Usr_username;
                            if (!Convert.IsDBNull(dr["Usr_password"]))
                            {
                                Users.Usr_password = Convert.ToString(dr["Usr_password"].ToString());
                            }
                            else
                                Users.Usr_password = null;
                            Users.oldData.Usr_password = Users.Usr_password;
                            if (!Convert.IsDBNull(dr["Usr_email"]))
                            {
                                Users.Usr_email = Convert.ToString(dr["Usr_email"].ToString());
                            }
                            else
                                Users.Usr_email = null;
                            Users.oldData.Usr_email = Users.Usr_email;
                            if (!Convert.IsDBNull(dr["Usr_creation_date"]))
                            {
                                Users.Usr_creation_date = Convert.ToDateTime(dr["Usr_creation_date"].ToString());
                            }
                            else
                                Users.Usr_creation_date = new DateTime();
                            Users.oldData.Usr_creation_date = Users.Usr_creation_date;
                            if (!Convert.IsDBNull(dr["Usr_status"]))
                            {
                                Users.Usr_status = Convert.ToInt16(dr["Usr_status"].ToString());
                            }
                            else
                                Users.Usr_status = 0;
                            Users.oldData.Usr_status = Users.Usr_status;
                            if (!Convert.IsDBNull(dr["Usr_last_valid_login"]))
                            {
                                Users.Usr_last_valid_login = Convert.ToDateTime(dr["Usr_last_valid_login"].ToString());
                            }
                            else
                                Users.Usr_last_valid_login = null;
                            Users.oldData.Usr_last_valid_login = Users.Usr_last_valid_login;
                            if (!Convert.IsDBNull(dr["Usr_last_invalid_login"]))
                            {
                                Users.Usr_last_invalid_login = Convert.ToDateTime(dr["Usr_last_invalid_login"].ToString());
                            }
                            else
                                Users.Usr_last_invalid_login = null;
                            Users.oldData.Usr_last_invalid_login = Users.Usr_last_invalid_login;
                            Users.ResetChangesFlags();
                        }
                        else
                            Users = null;
                        dr.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (debugMode)
                            MessageBox.Show(ex.Message);
                        if (debugExceptionsMode)
                            throw ex;
                    }
                    Users = null;
                    return false;
                }
                public static bool GetRecords(string condition, out ArrayList UsersRecords)
                {
                    ClsUsers Users;
                    UsersRecords = new ArrayList();
                    string sqlString = "SELECT * FROM [Users]";
                    sqlString += " WHERE " + condition;
                    try
                    {
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        while (dr.Read())
                        {
                            Users = new ClsUsers();
                            if (!Convert.IsDBNull(dr["Usr_id"]))
                            {
                                Users.Usr_id = Convert.ToInt32(dr["Usr_id"].ToString());
                            }
                            else
                                Users.Usr_id = 0;
                            Users.oldData.Usr_id = Users.Usr_id;
                            if (!Convert.IsDBNull(dr["Usr_username"]))
                            {
                                Users.Usr_username = Convert.ToString(dr["Usr_username"].ToString());
                            }
                            else
                                Users.Usr_username = null;
                            Users.oldData.Usr_username = Users.Usr_username;
                            if (!Convert.IsDBNull(dr["Usr_password"]))
                            {
                                Users.Usr_password = Convert.ToString(dr["Usr_password"].ToString());
                            }
                            else
                                Users.Usr_password = null;
                            Users.oldData.Usr_password = Users.Usr_password;
                            if (!Convert.IsDBNull(dr["Usr_email"]))
                            {
                                Users.Usr_email = Convert.ToString(dr["Usr_email"].ToString());
                            }
                            else
                                Users.Usr_email = null;
                            Users.oldData.Usr_email = Users.Usr_email;
                            if (!Convert.IsDBNull(dr["Usr_creation_date"]))
                            {
                                Users.Usr_creation_date = Convert.ToDateTime(dr["Usr_creation_date"].ToString());
                            }
                            else
                                Users.Usr_creation_date = new DateTime();
                            Users.oldData.Usr_creation_date = Users.Usr_creation_date;
                            if (!Convert.IsDBNull(dr["Usr_status"]))
                            {
                                Users.Usr_status = Convert.ToInt16(dr["Usr_status"].ToString());
                            }
                            else
                                Users.Usr_status = 0;
                            Users.oldData.Usr_status = Users.Usr_status;
                            if (!Convert.IsDBNull(dr["Usr_last_valid_login"]))
                            {
                                Users.Usr_last_valid_login = Convert.ToDateTime(dr["Usr_last_valid_login"].ToString());
                            }
                            else
                                Users.Usr_last_valid_login = null;
                            Users.oldData.Usr_last_valid_login = Users.Usr_last_valid_login;
                            if (!Convert.IsDBNull(dr["Usr_last_invalid_login"]))
                            {
                                Users.Usr_last_invalid_login = Convert.ToDateTime(dr["Usr_last_invalid_login"].ToString());
                            }
                            else
                                Users.Usr_last_invalid_login = null;
                            Users.oldData.Usr_last_invalid_login = Users.Usr_last_invalid_login;
                            Users.ResetChangesFlags();
                            UsersRecords.Add(Users);
                        }
                        dr.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (debugMode)
                            MessageBox.Show(ex.Message);
                        if (debugExceptionsMode)
                            throw ex;
                    }
                    return false;
                }
                public static bool GetAll(out ArrayList UsersRecords)
                {
                    ClsUsers Users;
                    UsersRecords = new ArrayList();
                    string sqlString = "SELECT * FROM [Users]";
                    try
                    {
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        while (dr.Read())
                        {
                            Users = new ClsUsers();
                            if (!Convert.IsDBNull(dr["Usr_id"]))
                            {
                                Users.Usr_id = Convert.ToInt32(dr["Usr_id"].ToString());
                            }
                            else
                                Users.Usr_id = 0;
                            Users.oldData.Usr_id = Users.Usr_id;
                            if (!Convert.IsDBNull(dr["Usr_username"]))
                            {
                                Users.Usr_username = Convert.ToString(dr["Usr_username"].ToString());
                            }
                            else
                                Users.Usr_username = null;
                            Users.oldData.Usr_username = Users.Usr_username;
                            if (!Convert.IsDBNull(dr["Usr_password"]))
                            {
                                Users.Usr_password = Convert.ToString(dr["Usr_password"].ToString());
                            }
                            else
                                Users.Usr_password = null;
                            Users.oldData.Usr_password = Users.Usr_password;
                            if (!Convert.IsDBNull(dr["Usr_email"]))
                            {
                                Users.Usr_email = Convert.ToString(dr["Usr_email"].ToString());
                            }
                            else
                                Users.Usr_email = null;
                            Users.oldData.Usr_email = Users.Usr_email;
                            if (!Convert.IsDBNull(dr["Usr_creation_date"]))
                            {
                                Users.Usr_creation_date = Convert.ToDateTime(dr["Usr_creation_date"].ToString());
                            }
                            else
                                Users.Usr_creation_date = new DateTime();
                            Users.oldData.Usr_creation_date = Users.Usr_creation_date;
                            if (!Convert.IsDBNull(dr["Usr_status"]))
                            {
                                Users.Usr_status = Convert.ToInt16(dr["Usr_status"].ToString());
                            }
                            else
                                Users.Usr_status = 0;
                            Users.oldData.Usr_status = Users.Usr_status;
                            if (!Convert.IsDBNull(dr["Usr_last_valid_login"]))
                            {
                                Users.Usr_last_valid_login = Convert.ToDateTime(dr["Usr_last_valid_login"].ToString());
                            }
                            else
                                Users.Usr_last_valid_login = null;
                            Users.oldData.Usr_last_valid_login = Users.Usr_last_valid_login;
                            if (!Convert.IsDBNull(dr["Usr_last_invalid_login"]))
                            {
                                Users.Usr_last_invalid_login = Convert.ToDateTime(dr["Usr_last_invalid_login"].ToString());
                            }
                            else
                                Users.Usr_last_invalid_login = null;
                            Users.oldData.Usr_last_invalid_login = Users.Usr_last_invalid_login;
                            Users.ResetChangesFlags();
                            UsersRecords.Add(Users);
                        }
                        dr.Close();
                        if (UsersRecords.Count == 0)
                            Users = null;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        if (debugMode)
                            MessageBox.Show(ex.Message);
                        if (debugExceptionsMode)
                            throw ex;
                    }
                    return false;
                }
            }

            #endregion

            #region Non-static Get Functions

            public bool GetRecord(SqlDataReader dr, out ClsUsers Users)
            {
                Users = new ClsUsers();
                try
                {
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["Usr_id"]))
                        {
                            Users.Usr_id = Convert.ToInt32(dr["Usr_id"].ToString());
                        }
                        else
                            Users.Usr_id = 0;
                        Users.oldData.Usr_id = Users.Usr_id;
                        if (!Convert.IsDBNull(dr["Usr_username"]))
                        {
                            Users.Usr_username = Convert.ToString(dr["Usr_username"].ToString());
                        }
                        else
                            Users.Usr_username = null;
                        Users.oldData.Usr_username = Users.Usr_username;
                        if (!Convert.IsDBNull(dr["Usr_password"]))
                        {
                            Users.Usr_password = Convert.ToString(dr["Usr_password"].ToString());
                        }
                        else
                            Users.Usr_password = null;
                        Users.oldData.Usr_password = Users.Usr_password;
                        if (!Convert.IsDBNull(dr["Usr_email"]))
                        {
                            Users.Usr_email = Convert.ToString(dr["Usr_email"].ToString());
                        }
                        else
                            Users.Usr_email = null;
                        Users.oldData.Usr_email = Users.Usr_email;
                        if (!Convert.IsDBNull(dr["Usr_creation_date"]))
                        {
                            Users.Usr_creation_date = Convert.ToDateTime(dr["Usr_creation_date"].ToString());
                        }
                        else
                            Users.Usr_creation_date = new DateTime();
                        Users.oldData.Usr_creation_date = Users.Usr_creation_date;
                        if (!Convert.IsDBNull(dr["Usr_status"]))
                        {
                            Users.Usr_status = Convert.ToInt16(dr["Usr_status"].ToString());
                        }
                        else
                            Users.Usr_status = 0;
                        Users.oldData.Usr_status = Users.Usr_status;
                        if (!Convert.IsDBNull(dr["Usr_last_valid_login"]))
                        {
                            Users.Usr_last_valid_login = Convert.ToDateTime(dr["Usr_last_valid_login"].ToString());
                        }
                        else
                            Users.Usr_last_valid_login = null;
                        Users.oldData.Usr_last_valid_login = Users.Usr_last_valid_login;
                        if (!Convert.IsDBNull(dr["Usr_last_invalid_login"]))
                        {
                            Users.Usr_last_invalid_login = Convert.ToDateTime(dr["Usr_last_invalid_login"].ToString());
                        }
                        else
                            Users.Usr_last_invalid_login = null;
                        Users.oldData.Usr_last_invalid_login = Users.Usr_last_invalid_login;
                        Users.ResetChangesFlags();
                    }
                    else
                        Users = null;
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                Users = null;
                return false;
            }
            public bool GetRecord(string condition, out ClsUsers Users)
            {
                string sqlString = "SELECT * FROM [Users]";
                sqlString += " WHERE " + condition;
                Users = new ClsUsers();
                try
                {
                    SqlEngine sqlEngine = new SqlEngine(connectionString);
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["Usr_id"]))
                        {
                            Users.Usr_id = Convert.ToInt32(dr["Usr_id"].ToString());
                        }
                        else
                            Users.Usr_id = 0;
                        Users.oldData.Usr_id = Users.Usr_id;
                        if (!Convert.IsDBNull(dr["Usr_username"]))
                        {
                            Users.Usr_username = Convert.ToString(dr["Usr_username"].ToString());
                        }
                        else
                            Users.Usr_username = null;
                        Users.oldData.Usr_username = Users.Usr_username;
                        if (!Convert.IsDBNull(dr["Usr_password"]))
                        {
                            Users.Usr_password = Convert.ToString(dr["Usr_password"].ToString());
                        }
                        else
                            Users.Usr_password = null;
                        Users.oldData.Usr_password = Users.Usr_password;
                        if (!Convert.IsDBNull(dr["Usr_email"]))
                        {
                            Users.Usr_email = Convert.ToString(dr["Usr_email"].ToString());
                        }
                        else
                            Users.Usr_email = null;
                        Users.oldData.Usr_email = Users.Usr_email;
                        if (!Convert.IsDBNull(dr["Usr_creation_date"]))
                        {
                            Users.Usr_creation_date = Convert.ToDateTime(dr["Usr_creation_date"].ToString());
                        }
                        else
                            Users.Usr_creation_date = new DateTime();
                        Users.oldData.Usr_creation_date = Users.Usr_creation_date;
                        if (!Convert.IsDBNull(dr["Usr_status"]))
                        {
                            Users.Usr_status = Convert.ToInt16(dr["Usr_status"].ToString());
                        }
                        else
                            Users.Usr_status = 0;
                        Users.oldData.Usr_status = Users.Usr_status;
                        if (!Convert.IsDBNull(dr["Usr_last_valid_login"]))
                        {
                            Users.Usr_last_valid_login = Convert.ToDateTime(dr["Usr_last_valid_login"].ToString());
                        }
                        else
                            Users.Usr_last_valid_login = null;
                        Users.oldData.Usr_last_valid_login = Users.Usr_last_valid_login;
                        if (!Convert.IsDBNull(dr["Usr_last_invalid_login"]))
                        {
                            Users.Usr_last_invalid_login = Convert.ToDateTime(dr["Usr_last_invalid_login"].ToString());
                        }
                        else
                            Users.Usr_last_invalid_login = null;
                        Users.oldData.Usr_last_invalid_login = Users.Usr_last_invalid_login;
                        Users.ResetChangesFlags();
                    }
                    else
                        Users = null;
                    dr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                Users = null;
                return false;
            }
            public bool GetRecord()
            {
                try
                {
                    string whereCondition = " WHERE ";
                    whereCondition += "Usr_id='" + df_Usr_id + "' AND ";
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                    string sqlString = "SELECT * FROM [Users]" + whereCondition;
                    try
                    {
                        SqlEngine sqlEngine = new SqlEngine(connectionString);
                        SqlDataReader dr;
                        if (!sqlEngine.ReadData(sqlString, out dr))
                            throw new Exception("Error in Get function");
                        if (dr.Read())
                        {
                            if (!Convert.IsDBNull(dr["Usr_id"]))
                            {
                                Usr_id = Convert.ToInt32(dr["Usr_id"].ToString());
                            }
                            else
                                Usr_id = 0;
                            oldData.Usr_id = Usr_id;
                            if (!Convert.IsDBNull(dr["Usr_username"]))
                            {
                                Usr_username = Convert.ToString(dr["Usr_username"].ToString());
                            }
                            else
                                Usr_username = null;
                            oldData.Usr_username = Usr_username;
                            if (!Convert.IsDBNull(dr["Usr_password"]))
                            {
                                Usr_password = Convert.ToString(dr["Usr_password"].ToString());
                            }
                            else
                                Usr_password = null;
                            oldData.Usr_password = Usr_password;
                            if (!Convert.IsDBNull(dr["Usr_email"]))
                            {
                                Usr_email = Convert.ToString(dr["Usr_email"].ToString());
                            }
                            else
                                Usr_email = null;
                            oldData.Usr_email = Usr_email;
                            if (!Convert.IsDBNull(dr["Usr_creation_date"]))
                            {
                                Usr_creation_date = Convert.ToDateTime(dr["Usr_creation_date"].ToString());
                            }
                            else
                                Usr_creation_date = new DateTime();
                            oldData.Usr_creation_date = Usr_creation_date;
                            if (!Convert.IsDBNull(dr["Usr_status"]))
                            {
                                Usr_status = Convert.ToInt16(dr["Usr_status"].ToString());
                            }
                            else
                                Usr_status = 0;
                            oldData.Usr_status = Usr_status;
                            if (!Convert.IsDBNull(dr["Usr_last_valid_login"]))
                            {
                                Usr_last_valid_login = Convert.ToDateTime(dr["Usr_last_valid_login"].ToString());
                            }
                            else
                                Usr_last_valid_login = null;
                            oldData.Usr_last_valid_login = Usr_last_valid_login;
                            if (!Convert.IsDBNull(dr["Usr_last_invalid_login"]))
                            {
                                Usr_last_invalid_login = Convert.ToDateTime(dr["Usr_last_invalid_login"].ToString());
                            }
                            else
                                Usr_last_invalid_login = null;
                            oldData.Usr_last_invalid_login = Usr_last_invalid_login;
                            ResetChangesFlags();
                        }
                        else
                            throw new Exception("Record not found");
                        dr.Close();
                        return true;
                    }
                    catch (Exception InnerEx)
                    {
                        if (debugMode)
                            MessageBox.Show(InnerEx.Message);
                        if (debugExceptionsMode)
                            throw InnerEx;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool GetRecord(out ClsUsers Users)
            {
                string whereCondition = " WHERE ";
                whereCondition += "Usr_id='" + df_Usr_id + "' AND ";
                whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                Users = new ClsUsers(df_Usr_id);
                string sqlString = "SELECT * FROM [Users]" + whereCondition;
                try
                {
                    SqlEngine sqlEngine = new SqlEngine(connectionString);
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    if (dr.Read())
                    {
                        if (!Convert.IsDBNull(dr["Usr_id"]))
                        {
                            Users.Usr_id = Convert.ToInt32(dr["Usr_id"].ToString());
                        }
                        else
                            Users.Usr_id = 0;
                        Users.oldData.Usr_id = Users.Usr_id;
                        if (!Convert.IsDBNull(dr["Usr_username"]))
                        {
                            Users.Usr_username = Convert.ToString(dr["Usr_username"].ToString());
                        }
                        else
                            Users.Usr_username = null;
                        Users.oldData.Usr_username = Users.Usr_username;
                        if (!Convert.IsDBNull(dr["Usr_password"]))
                        {
                            Users.Usr_password = Convert.ToString(dr["Usr_password"].ToString());
                        }
                        else
                            Users.Usr_password = null;
                        Users.oldData.Usr_password = Users.Usr_password;
                        if (!Convert.IsDBNull(dr["Usr_email"]))
                        {
                            Users.Usr_email = Convert.ToString(dr["Usr_email"].ToString());
                        }
                        else
                            Users.Usr_email = null;
                        Users.oldData.Usr_email = Users.Usr_email;
                        if (!Convert.IsDBNull(dr["Usr_creation_date"]))
                        {
                            Users.Usr_creation_date = Convert.ToDateTime(dr["Usr_creation_date"].ToString());
                        }
                        else
                            Users.Usr_creation_date = new DateTime();
                        Users.oldData.Usr_creation_date = Users.Usr_creation_date;
                        if (!Convert.IsDBNull(dr["Usr_status"]))
                        {
                            Users.Usr_status = Convert.ToInt16(dr["Usr_status"].ToString());
                        }
                        else
                            Users.Usr_status = 0;
                        Users.oldData.Usr_status = Users.Usr_status;
                        if (!Convert.IsDBNull(dr["Usr_last_valid_login"]))
                        {
                            Users.Usr_last_valid_login = Convert.ToDateTime(dr["Usr_last_valid_login"].ToString());
                        }
                        else
                            Users.Usr_last_valid_login = null;
                        Users.oldData.Usr_last_valid_login = Users.Usr_last_valid_login;
                        if (!Convert.IsDBNull(dr["Usr_last_invalid_login"]))
                        {
                            Users.Usr_last_invalid_login = Convert.ToDateTime(dr["Usr_last_invalid_login"].ToString());
                        }
                        else
                            Users.Usr_last_invalid_login = null;
                        Users.oldData.Usr_last_invalid_login = Users.Usr_last_invalid_login;
                        Users.ResetChangesFlags();
                    }
                    else
                        Users = null;
                    dr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                Users = null;
                return false;
            }
            public bool GetRecords(string condition, out ArrayList UsersRecords)
            {
                ClsUsers Users;
                UsersRecords = new ArrayList();
                string sqlString = "SELECT * FROM [Users]";
                sqlString += " WHERE " + condition;
                try
                {
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    while (dr.Read())
                    {
                        Users = new ClsUsers();
                        if (!Convert.IsDBNull(dr["Usr_id"]))
                        {
                            Users.Usr_id = Convert.ToInt32(dr["Usr_id"].ToString());
                        }
                        else
                            Users.Usr_id = 0;
                        Users.oldData.Usr_id = Users.Usr_id;
                        if (!Convert.IsDBNull(dr["Usr_username"]))
                        {
                            Users.Usr_username = Convert.ToString(dr["Usr_username"].ToString());
                        }
                        else
                            Users.Usr_username = null;
                        Users.oldData.Usr_username = Users.Usr_username;
                        if (!Convert.IsDBNull(dr["Usr_password"]))
                        {
                            Users.Usr_password = Convert.ToString(dr["Usr_password"].ToString());
                        }
                        else
                            Users.Usr_password = null;
                        Users.oldData.Usr_password = Users.Usr_password;
                        if (!Convert.IsDBNull(dr["Usr_email"]))
                        {
                            Users.Usr_email = Convert.ToString(dr["Usr_email"].ToString());
                        }
                        else
                            Users.Usr_email = null;
                        Users.oldData.Usr_email = Users.Usr_email;
                        if (!Convert.IsDBNull(dr["Usr_creation_date"]))
                        {
                            Users.Usr_creation_date = Convert.ToDateTime(dr["Usr_creation_date"].ToString());
                        }
                        else
                            Users.Usr_creation_date = new DateTime();
                        Users.oldData.Usr_creation_date = Users.Usr_creation_date;
                        if (!Convert.IsDBNull(dr["Usr_status"]))
                        {
                            Users.Usr_status = Convert.ToInt16(dr["Usr_status"].ToString());
                        }
                        else
                            Users.Usr_status = 0;
                        Users.oldData.Usr_status = Users.Usr_status;
                        if (!Convert.IsDBNull(dr["Usr_last_valid_login"]))
                        {
                            Users.Usr_last_valid_login = Convert.ToDateTime(dr["Usr_last_valid_login"].ToString());
                        }
                        else
                            Users.Usr_last_valid_login = null;
                        Users.oldData.Usr_last_valid_login = Users.Usr_last_valid_login;
                        if (!Convert.IsDBNull(dr["Usr_last_invalid_login"]))
                        {
                            Users.Usr_last_invalid_login = Convert.ToDateTime(dr["Usr_last_invalid_login"].ToString());
                        }
                        else
                            Users.Usr_last_invalid_login = null;
                        Users.oldData.Usr_last_invalid_login = Users.Usr_last_invalid_login;
                        Users.ResetChangesFlags();
                        UsersRecords.Add(Users);
                    }
                    dr.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool GetAll(out ArrayList UsersRecords)
            {
                ClsUsers Users;
                UsersRecords = new ArrayList();
                string sqlString = "SELECT * FROM [Users]";
                try
                {
                    SqlDataReader dr;
                    if (!sqlEngine.ReadData(sqlString, out dr))
                        throw new Exception("Error in Get function");
                    while (dr.Read())
                    {
                        Users = new ClsUsers();
                        if (!Convert.IsDBNull(dr["Usr_id"]))
                        {
                            Users.Usr_id = Convert.ToInt32(dr["Usr_id"].ToString());
                        }
                        else
                            Users.Usr_id = 0;
                        Users.oldData.Usr_id = Users.Usr_id;
                        if (!Convert.IsDBNull(dr["Usr_username"]))
                        {
                            Users.Usr_username = Convert.ToString(dr["Usr_username"].ToString());
                        }
                        else
                            Users.Usr_username = null;
                        Users.oldData.Usr_username = Users.Usr_username;
                        if (!Convert.IsDBNull(dr["Usr_password"]))
                        {
                            Users.Usr_password = Convert.ToString(dr["Usr_password"].ToString());
                        }
                        else
                            Users.Usr_password = null;
                        Users.oldData.Usr_password = Users.Usr_password;
                        if (!Convert.IsDBNull(dr["Usr_email"]))
                        {
                            Users.Usr_email = Convert.ToString(dr["Usr_email"].ToString());
                        }
                        else
                            Users.Usr_email = null;
                        Users.oldData.Usr_email = Users.Usr_email;
                        if (!Convert.IsDBNull(dr["Usr_creation_date"]))
                        {
                            Users.Usr_creation_date = Convert.ToDateTime(dr["Usr_creation_date"].ToString());
                        }
                        else
                            Users.Usr_creation_date = new DateTime();
                        Users.oldData.Usr_creation_date = Users.Usr_creation_date;
                        if (!Convert.IsDBNull(dr["Usr_status"]))
                        {
                            Users.Usr_status = Convert.ToInt16(dr["Usr_status"].ToString());
                        }
                        else
                            Users.Usr_status = 0;
                        Users.oldData.Usr_status = Users.Usr_status;
                        if (!Convert.IsDBNull(dr["Usr_last_valid_login"]))
                        {
                            Users.Usr_last_valid_login = Convert.ToDateTime(dr["Usr_last_valid_login"].ToString());
                        }
                        else
                            Users.Usr_last_valid_login = null;
                        Users.oldData.Usr_last_valid_login = Users.Usr_last_valid_login;
                        if (!Convert.IsDBNull(dr["Usr_last_invalid_login"]))
                        {
                            Users.Usr_last_invalid_login = Convert.ToDateTime(dr["Usr_last_invalid_login"].ToString());
                        }
                        else
                            Users.Usr_last_invalid_login = null;
                        Users.oldData.Usr_last_invalid_login = Users.Usr_last_invalid_login;
                        Users.ResetChangesFlags();
                        UsersRecords.Add(Users);
                    }
                    dr.Close();
                    if (UsersRecords.Count == 0)
                        Users = null;
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool GetNext(string colName, string cmpValue, out ClsUsers nextRecord)
            {
                return GetRecord(colName + ">'" + cmpValue + "' ORDER BY " + colName, out nextRecord);
            }
            public bool GetNext(string colName, string cmpValue, string sqlCondition, out ClsUsers nextRecord)
            {
                return GetRecord(colName + ">'" + cmpValue + "' AND " + sqlCondition + " ORDER BY " + colName, out nextRecord);
            }
            public bool GetPrevious(string colName, string cmpValue, out ClsUsers prevRecord)
            {
                return GetRecord(colName + "<'" + cmpValue + "' ORDER BY " + colName + " DESC", out prevRecord);
            }
            public bool GetPrevious(string colName, string cmpValue, string sqlCondition, out ClsUsers prevRecord)
            {
                return GetRecord(colName + "<'" + cmpValue + "' AND " + sqlCondition + " ORDER BY " + colName + " DESC", out prevRecord);
            }
            public bool GetFirst(string colName, out ClsUsers firstRecord)
            {
                firstRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [Users] ORDER BY " + colName, out dr))
                    return false;
                if (!GetRecord(dr, out firstRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }
            public bool GetFirst(string colName, string sqlCondition, out ClsUsers firstRecord)
            {
                firstRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [Users] WHERE " + sqlCondition
                                        + " ORDER BY " + colName, out dr))
                    return false;
                if (!GetRecord(dr, out firstRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }
            public bool GetLast(string colName, out ClsUsers lastRecord)
            {
                lastRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [Users] ORDER BY " + colName + " DESC", out dr))
                    return false;
                if (!GetRecord(dr, out lastRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }
            public bool GetLast(string colName, string sqlCondition, out ClsUsers lastRecord)
            {
                lastRecord = null;
                SqlDataReader dr;
                if (!sqlEngine.ReadData("SELECT * FROM [Users] WHERE " + sqlCondition
                                        + " ORDER BY " + colName + " DESC", out dr))
                    return false;
                if (!GetRecord(dr, out lastRecord))
                    throw new Exception("Error in Get function");
                dr.Close();
                return true;
            }

            #endregion

            #region Row Operations


            public bool Add()
            {
                string sqlString;
                string values = "";
                string fields = "";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    if (Usr_username_changed)
                    {
                        fields += "Usr_username,";
                        values += "N'" + Usr_username + "',";
                    }
                    if (Usr_password_changed)
                    {
                        fields += "Usr_password,";
                        values += "N'" + Usr_password + "',";
                    }
                    if (Usr_email_changed)
                    {
                        fields += "Usr_email,";
                        values += "N'" + Usr_email + "',";
                    }
                    if (Usr_creation_date_changed)
                    {
                        fields += "Usr_creation_date,";
                        values += "N'" + Usr_creation_date + "',";
                    }
                    if (Usr_status_changed)
                    {
                        fields += "Usr_status,";
                        values += "N'" + Usr_status + "',";
                    }
                    if (Usr_last_valid_login_changed)
                    {
                        fields += "Usr_last_valid_login,";
                        values += "N'" + Usr_last_valid_login + "',";
                    }
                    if (Usr_last_invalid_login_changed)
                    {
                        fields += "Usr_last_invalid_login,";
                        values += "N'" + Usr_last_invalid_login + "',";
                    }

                    #endregion
                    if (fields == "")
                        return true;
                    fields = fields.Substring(0, fields.Length - 1);
                    values = values.Substring(0, values.Length - 1);
                    sqlString = "INSERT INTO [Users] (" + fields + ") VALUES (" + values + ") select @@identity";
                    if (sqlPars.Count == 0)
                    {
                        
                    }
                    else
                    if (!sqlEngine.NonQueryCommand(sqlString, sqlPars))
                        throw new Exception("Error in Add function, can not execute sql statement");

                    #region Set old field variables

                    oldData.Usr_id = Usr_id;
                    oldData.Usr_username = Usr_username;
                    oldData.Usr_password = Usr_password;
                    oldData.Usr_email = Usr_email;
                    oldData.Usr_creation_date = Usr_creation_date;
                    oldData.Usr_status = Usr_status;
                    oldData.Usr_last_valid_login = Usr_last_valid_login;
                    oldData.Usr_last_invalid_login = Usr_last_invalid_login;

                    #endregion

                    ResetChangesFlags();
                    if (!sqlEngine.GetTopRecordID("[Users]", "Usr_id", out df_Usr_id))
                        throw new Exception("Error in Add function, can't read id");
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool AddSqlCommands(ref ArrayList transactions, ref ArrayList parameters)
            {
                string sqlString;
                string values = "";
                string fields = "";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    if (Usr_username_changed)
                    {
                        fields += "Usr_username,";
                        values += "N'" + Usr_username + "',";
                    }
                    if (Usr_password_changed)
                    {
                        fields += "Usr_password,";
                        values += "N'" + Usr_password + "',";
                    }
                    if (Usr_email_changed)
                    {
                        fields += "Usr_email,";
                        values += "N'" + Usr_email + "',";
                    }
                    if (Usr_creation_date_changed)
                    {
                        fields += "Usr_creation_date,";
                        values += "N'" + Usr_creation_date + "',";
                    }
                    if (Usr_status_changed)
                    {
                        fields += "Usr_status,";
                        values += "N'" + Usr_status + "',";
                    }
                    if (Usr_last_valid_login_changed)
                    {
                        fields += "Usr_last_valid_login,";
                        values += "N'" + Usr_last_valid_login + "',";
                    }
                    if (Usr_last_invalid_login_changed)
                    {
                        fields += "Usr_last_invalid_login,";
                        values += "N'" + Usr_last_invalid_login + "',";
                    }

                    #endregion
                    if (fields == "")
                        return true;
                    fields = fields.Substring(0, fields.Length - 1);
                    values = values.Substring(0, values.Length - 1);
                    sqlString = "INSERT INTO [Users] (" + fields + ") VALUES (" + values + ")";
                    transactions.Add(sqlString);
                    parameters.Add(sqlPars);

                    #region Set old field variables

                    oldData.Usr_id = Usr_id;
                    oldData.Usr_username = Usr_username;
                    oldData.Usr_password = Usr_password;
                    oldData.Usr_email = Usr_email;
                    oldData.Usr_creation_date = Usr_creation_date;
                    oldData.Usr_status = Usr_status;
                    oldData.Usr_last_valid_login = Usr_last_valid_login;
                    oldData.Usr_last_invalid_login = Usr_last_invalid_login;

                    #endregion

                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool Delete()
            {
                #region Condition(s)


                #endregion
                string sqlString = "DELETE FROM [Users] WHERE Usr_id='" + Usr_id + "' AND ";
                sqlString = sqlString.Substring(0, sqlString.Length - 5);
                try
                {
                    if (!sqlEngine.NonQueryCommand(sqlString))
                        throw new Exception("Error in Delete function");
                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool DeleteSqlCommands(ref ArrayList transactions, ref ArrayList parameters)
            {
                #region Value updates


                #endregion
                string sqlString = "DELETE FROM [Users] WHERE Usr_id='" + Usr_id + "' AND ";
                sqlString = sqlString.Substring(0, sqlString.Length - 5);
                try
                {
                    transactions.Add(sqlString);
                    parameters.Add(new ArrayList());
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool Update()
            {
                string sqlString = "UPDATE [Users] SET ";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    string values = "";
                    #region Usr_id


                    #endregion
                    #region Usr_username

                    if (Usr_username_changed)
                    {
                        if (df_Usr_username == null)
                        {
                            values += "Usr_username=null,";
                        }
                        else
                        {
                            values += "Usr_username=N'" + df_Usr_username + "',";
                        }
                    }

                    #endregion
                    #region Usr_password

                    if (Usr_password_changed)
                    {
                        if (df_Usr_password == null)
                        {
                            values += "Usr_password=null,";
                        }
                        else
                        {
                            values += "Usr_password=N'" + df_Usr_password + "',";
                        }
                    }

                    #endregion
                    #region Usr_email

                    if (Usr_email_changed)
                    {
                        if (df_Usr_email == null)
                        {
                            values += "Usr_email=null,";
                        }
                        else
                        {
                            values += "Usr_email=N'" + df_Usr_email + "',";
                        }
                    }

                    #endregion
                    #region Usr_creation_date

                    if (Usr_creation_date_changed)
                    {
                        if (df_Usr_creation_date == null)
                        {
                            values += "Usr_creation_date=null,";
                        }
                        else
                        {
                            values += "Usr_creation_date=N'" + df_Usr_creation_date + "',";
                        }
                    }

                    #endregion
                    #region Usr_status

                    if (Usr_status_changed)
                    {
                        if (df_Usr_status == null)
                        {
                            values += "Usr_status=null,";
                        }
                        else
                        {
                            values += "Usr_status=N'" + df_Usr_status + "',";
                        }
                    }

                    #endregion
                    #region Usr_last_valid_login

                    if (Usr_last_valid_login_changed)
                    {
                        if (df_Usr_last_valid_login == null)
                        {
                            values += "Usr_last_valid_login=null,";
                        }
                        else
                        {
                            values += "Usr_last_valid_login=N'" + df_Usr_last_valid_login + "',";
                        }
                    }

                    #endregion
                    #region Usr_last_invalid_login

                    if (Usr_last_invalid_login_changed)
                    {
                        if (df_Usr_last_invalid_login == null)
                        {
                            values += "Usr_last_invalid_login=null,";
                        }
                        else
                        {
                            values += "Usr_last_invalid_login=N'" + df_Usr_last_invalid_login + "',";
                        }
                    }

                    #endregion
                    if (values == "")
                        return true;
                    sqlString += values;

                    #endregion
                    if (sqlString[sqlString.Length - 1] == ',')
                        sqlString = sqlString.Substring(0, sqlString.Length - 1);
                    string whereCondition = " WHERE ";
                    whereCondition += "Usr_id='" + df_Usr_id + "' AND ";
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                    sqlString += whereCondition;
                    if (sqlPars.Count == 0)
                    {
                        if (!sqlEngine.NonQueryCommand(sqlString))
                            throw new Exception("Error in Update function");
                    }
                    else
                    if (!sqlEngine.NonQueryCommand(sqlString, sqlPars))
                        throw new Exception("Error in Update function");
                    oldData.Usr_id = Usr_id;
                    oldData.Usr_username = Usr_username;
                    oldData.Usr_password = Usr_password;
                    oldData.Usr_email = Usr_email;
                    oldData.Usr_creation_date = Usr_creation_date;
                    oldData.Usr_status = Usr_status;
                    oldData.Usr_last_valid_login = Usr_last_valid_login;
                    oldData.Usr_last_invalid_login = Usr_last_invalid_login;
                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }
            public bool UpdateSqlCommands(ref ArrayList transactions, ref ArrayList parameters)
            {
                string sqlString = "UPDATE [Users] SET ";
                SqlParameter sqlPar;
                ArrayList sqlPars = new ArrayList();
                MemoryStream memStream = new MemoryStream();
                byte[] imgBin;
                try
                {
                    #region Value updates

                    string values = "";
                    if (Usr_username_changed)
                    {
                        if (df_Usr_username == null)
                        {
                            values += "Usr_username=null,";
                        }
                        else
                        {
                            values += "Usr_username=N'" + df_Usr_username + "',";
                        }
                    }
                    if (Usr_password_changed)
                    {
                        if (df_Usr_password == null)
                        {
                            values += "Usr_password=null,";
                        }
                        else
                        {
                            values += "Usr_password=N'" + df_Usr_password + "',";
                        }
                    }
                    if (Usr_email_changed)
                    {
                        if (df_Usr_email == null)
                        {
                            values += "Usr_email=null,";
                        }
                        else
                        {
                            values += "Usr_email=N'" + df_Usr_email + "',";
                        }
                    }
                    if (Usr_creation_date_changed)
                    {
                        if (df_Usr_creation_date == null)
                        {
                            values += "Usr_creation_date=null,";
                        }
                        else
                        {
                            values += "Usr_creation_date=N'" + df_Usr_creation_date + "',";
                        }
                    }
                    if (Usr_status_changed)
                    {
                        if (df_Usr_status == null)
                        {
                            values += "Usr_status=null,";
                        }
                        else
                        {
                            values += "Usr_status=N'" + df_Usr_status + "',";
                        }
                    }
                    if (Usr_last_valid_login_changed)
                    {
                        if (df_Usr_last_valid_login == null)
                        {
                            values += "Usr_last_valid_login=null,";
                        }
                        else
                        {
                            values += "Usr_last_valid_login=N'" + df_Usr_last_valid_login + "',";
                        }
                    }
                    if (Usr_last_invalid_login_changed)
                    {
                        if (df_Usr_last_invalid_login == null)
                        {
                            values += "Usr_last_invalid_login=null,";
                        }
                        else
                        {
                            values += "Usr_last_invalid_login=N'" + df_Usr_last_invalid_login + "',";
                        }
                    }
                    if (values == "")
                        return true;
                    sqlString += values;

                    #endregion
                    if (sqlString[sqlString.Length - 1] == ',')
                        sqlString = sqlString.Substring(0, sqlString.Length - 1);
                    string whereCondition = " WHERE ";
                    whereCondition += "Usr_id='" + df_Usr_id + "' AND ";
                    whereCondition = whereCondition.Substring(0, whereCondition.Length - 5);
                    sqlString += whereCondition;
                    transactions.Add(sqlString);
                    parameters.Add(sqlPars);
                    oldData.Usr_id = Usr_id;
                    oldData.Usr_username = Usr_username;
                    oldData.Usr_password = Usr_password;
                    oldData.Usr_email = Usr_email;
                    oldData.Usr_creation_date = Usr_creation_date;
                    oldData.Usr_status = Usr_status;
                    oldData.Usr_last_valid_login = Usr_last_valid_login;
                    oldData.Usr_last_invalid_login = Usr_last_invalid_login;
                    ResetChangesFlags();
                    return true;
                }
                catch (Exception ex)
                {
                    if (debugMode)
                        MessageBox.Show(ex.Message);
                    if (debugExceptionsMode)
                        throw ex;
                }
                return false;
            }

            #endregion
        }

        #endregion


        #endregion
    }
}