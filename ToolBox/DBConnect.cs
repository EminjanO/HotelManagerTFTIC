using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ToolDataBase
{
    public class DBConnect
    {
        private SqlConnection db;

        private string _ConnectionString;

        public string ConnectionString
        {
            get { return _ConnectionString; }
            private set { _ConnectionString = value; }
        }

        public DBConnect(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
            db = new SqlConnection(ConnectionString);
        }

        private SqlCommand CreateCommand(Command RequestSQL)
        {
            SqlCommand cmd = db.CreateCommand();

            cmd.CommandText = RequestSQL.Query;
            cmd.CommandType = CommandType.Text;

            foreach (KeyValuePair<string, object> param in RequestSQL.Params)
            {
                SqlParameter paramSQL = new SqlParameter(param.Key, param.Value);
                cmd.Parameters.Add(paramSQL);
            }

            return cmd;
        }
        private SqlCommand SPCreateCommand(Command RequestSQL)
        {
            SqlCommand cmd = db.CreateCommand();
            cmd.CommandText = RequestSQL.Query;
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (KeyValuePair<string, object> param in RequestSQL.Params)
            {
                SqlParameter paramSQL = new SqlParameter(param.Key, param.Value);
                cmd.Parameters.Add(paramSQL);
            }

            return cmd;
        }

        public int ExecuteNonQuery(Command RequestSQL)
        {
            SqlCommand cmd = CreateCommand(RequestSQL);

            try
            {
                db.Open();

                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
        public long getLastId(string query)
        {
            SqlCommand cmd = db.CreateCommand();
            cmd.CommandText = query;

            try
            {
                db.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                long id = 0;
                if (reader != null && reader.Read())
                {
                    id = reader.GetInt64(0);
                }
                reader.Close();

                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }

        public Data ExecuteScalar<Data>(Command RequestSQL)
        {
            SqlCommand cmd = CreateCommand(RequestSQL);

            try
            {
                db.Open();

                return (Data)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }

        public List<Dictionary<string, object>> ExecuteReader(Command RequestSQL)
        {
            SqlCommand cmd = CreateCommand(RequestSQL);

            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

            try
            {
                db.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dictionary<string, object> row = new Dictionary<string, object>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string key = reader.GetName(i);
                        object value = reader[i];

                        row.Add(key, value);
                    }

                    results.Add(row);
                }
                reader.Close();

                return results;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
        public List<Dictionary<string, object>> SPExecuteReader(Command RequestSQL)
        {
            SqlCommand cmd = SPCreateCommand(RequestSQL);

            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

            try
            {
                db.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dictionary<string, object> row = new Dictionary<string, object>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string key = reader.GetName(i);
                        object value = reader[i];

                        row.Add(key, value);
                    }

                    results.Add(row);
                }
                reader.Close();

                return results;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
    }
}
