using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace Saylor.DbLibary
{
    public class Sqlite3Helper
    {
        #region property

        public SQLiteConnection DBConnection { get; set; }

        #endregion

        #region Method
        public Sqlite3Helper(string dbPath)
        {
            InitConnection(dbPath);
        }

        public void InitConnection(string dbPath)
        {
            try
            {
                DBConnection = new SQLiteConnection(string.Format("Data Source={0};Version=3", dbPath));
                DBConnection.Open();
            }
            catch (Exception ex)
            {
               
            }
        }
        public int ExecuteNonQuery(string sql, SQLiteParameter[] parameters = null)
        {
            int affectedRows = 0;
            if (DBConnection != null && DBConnection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    DbTransaction transaction = DBConnection.BeginTransaction();
                    SQLiteCommand command = new SQLiteCommand(DBConnection);
                    command.CommandText = sql;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    affectedRows = command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                }
            }
            return affectedRows;
        }

        public DataTable GetDataTable(string sql, SQLiteParameter[] parameters = null) 
        {
            DataTable data = new DataTable();
            if (DBConnection != null && DBConnection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    SQLiteCommand command = new SQLiteCommand(sql, DBConnection);
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    adapter.Fill(data);
                }
                catch (Exception ex)
                {
                }
            }
            return data;
        }

        public object GetScalar(string sql, SQLiteParameter[] parameters=null)
        {
            object data = null;
            if (DBConnection != null && DBConnection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    SQLiteCommand command = new SQLiteCommand(sql, DBConnection);
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                   data = command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                }
            }
            return data;
        }
        #endregion



    }
}
