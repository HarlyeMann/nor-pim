﻿/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 7/21/2020 9:15:54 AM
  From Machine: DESKTOP-517I8BU
  Template: sql2x.GenerateDataAccessLayerV0.UsingDotNetFramework
*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;

// Data Access Layer
// the DataAccessLayer is the first layer that has access to data coming from
//  sql server after being streamed over a net or internal process
// links:
//   https://en.wikipedia.org/wiki/Data_access_layer: data access layer
namespace SolutionNorSolutionPim.DataAccessLayer {

    public partial class ClientIdentifierTypeRef {
        
        public const string EmployeeNumber = "ENR";
        
        public const string PassportNumber = "PNR";
    }
    
    // this class serves as a data access layer between c# and sql server
    // it is serializable in order to speed up processing between the data access and business layers
    // this class start with an identical representation of client_identifier_type_ref's columns
    //  formatted to follow C# casing guidelines ( Pascal casing )
    // links:
    //   https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/: serialization
    [Serializable()]
    public partial class CrudeClientIdentifierTypeRefData {
        
        public string ClientIdentifierTypeRcd { get; set; }
        
        public string ClientIdentifierTypeName { get; set; }
        
        public string ClientIdentifierTypeDescription { get; set; }
        
        public bool ActiveFlag { get; set; }
        
        public int SortOrder { get; set; }
        
        public System.Guid UserId { get; set; }
        
        public System.DateTime DateTime { get; set; }
        
        // fetch by Primary key into current object
        // links:
        //   https://en.wikipedia.org/wiki/Create,_read,_update_and_delete: crud definition
        // parameters:
        //   clientIdentifierTypeRcd: primary key of table client_identifier_type_ref
        public void FetchByClientIdentifierTypeRcd(string clientIdentifierTypeRcd) {
            // create query against client_identifier_type_ref
            // this will be ansi sql and parameterized
            // parameterized queries are a good way of preventing sql injection
            //   and to make sure the query plan is pre-compiled
            string sql = @" select top 1 client_identifier_type_rcd, client_identifier_type_name, client_identifier_type_description, active_flag, sort_order, user_id, date_time
                            from [client_identifier_type_ref]
                            where client_identifier_type_rcd = @client_identifier_type_rcd
                            order by client_identifier_type_name";

            // open standard connection
            // the connection is found in web.config
            // the connection is closed upon completion of the reader
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                // dirty read
                // starting a transaction seems to be the only way of doing a dirty read
                // a dirty read means a row is read even if it is marked
                //   as locked by another database transaction
                conn.BeginTransaction(IsolationLevel.ReadUncommitted).Commit();

                using (var command = new SqlCommand(sql, conn)) {
                    // add primary key
                    // this primary key will be used together with the prepared ansi sql statement
                    command.Parameters.Add("@client_identifier_type_rcd",SqlDbType.NVarChar).Value = clientIdentifierTypeRcd;

                    // execute and read one row, close connection
                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                    // populate serializable class if row was found
                    if (reader.Read())
                        Populate(reader);
                }
            }
        }
        
        // fetch by Primary key into new class instance
        public static CrudeClientIdentifierTypeRefData GetByClientIdentifierTypeRcd(string clientIdentifierTypeRcd) {
            string sql = @" select top 1 client_identifier_type_rcd, client_identifier_type_name, client_identifier_type_description, active_flag, sort_order, user_id, date_time
                            from [client_identifier_type_ref]
                            where client_identifier_type_rcd = @client_identifier_type_rcd
                            order by client_identifier_type_name";

            var ret = new CrudeClientIdentifierTypeRefData();

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@client_identifier_type_rcd",SqlDbType.NVarChar).Value = clientIdentifierTypeRcd;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                    // populate serialized class if row was found
                    if (reader.Read())
                        ret.Populate(reader);
                }
            }

            return ret;
        }
        
        // fetch by Foreign key into new List of class instances
        public static List<CrudeClientIdentifierTypeRefData> FetchByUserId(System.Guid userId) {
            var dataList = new List<CrudeClientIdentifierTypeRefData>();

            string sql = @" select client_identifier_type_rcd, client_identifier_type_name, client_identifier_type_description, active_flag, sort_order, user_id, date_time
                            from [client_identifier_type_ref]
                            where user_id = @user_id
                              
                            order by client_identifier_type_name";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@user_id", SqlDbType.UniqueIdentifier).Value = userId;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeClientIdentifierTypeRefData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch by Picker Member into new class instance
        public void FetchByClientIdentifierTypeName(string clientIdentifierTypeName) {
            string sql = @" select top 1 client_identifier_type_rcd, client_identifier_type_name, client_identifier_type_description, active_flag, sort_order, user_id, date_time
                            from [client_identifier_type_ref]
                            where client_identifier_type_name like '%' + @clientIdentifierTypeName + '%'
                              ";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.Add("@clientIdentifierTypeName",SqlDbType.NVarChar).Value = clientIdentifierTypeName;

                IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                    Populate(reader);
            }
        }
        
        // fetch all from table into new List of class instances
        public static List<CrudeClientIdentifierTypeRefData> FetchAll() {
            var dataList = new List<CrudeClientIdentifierTypeRefData>();

            string sql = @" select client_identifier_type_rcd, client_identifier_type_name, client_identifier_type_description, active_flag, sort_order, user_id, date_time
                            from [client_identifier_type_ref]
                            order by client_identifier_type_name";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeClientIdentifierTypeRefData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch all from table into new List of class instances, with a limit on number of returned rows and order by columns
        public static List<CrudeClientIdentifierTypeRefData> FetchAllWithLimit(int limit) {
            var dataList = new List<CrudeClientIdentifierTypeRefData>();

            string sql = @" select top " + limit.ToString() + @" client_identifier_type_rcd, client_identifier_type_name, client_identifier_type_description, active_flag, sort_order, user_id, date_time
                            from [client_identifier_type_ref]
                            order by client_identifier_type_name";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeClientIdentifierTypeRefData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch all from table into new List of class instances, only populating specific columns , with a limit on number of returned rows and order by columns starting at a specific row
        public static List<CrudeClientIdentifierTypeRefData> FetchAllWithLimitAndOffset(int limit, int offset) {
            var dataList = new List<CrudeClientIdentifierTypeRefData>();

            string sql = @" select client_identifier_type_rcd, client_identifier_type_name, client_identifier_type_description, active_flag, sort_order, user_id, date_time
                            from [client_identifier_type_ref]
                            order by client_identifier_type_name";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    int count = 0;

                    while (reader.Read()) {
                        if ((count >= offset) && (count <= offset + limit)) {
                            var data = new CrudeClientIdentifierTypeRefData();
                            data.Populate(reader);
                            dataList.Add(data);
                        }
                        count++;
                        if (count > limit + offset) break;
                    }
                }
                
                return dataList;
            }
        }
        
        // get a count of rows in table
        public static int FetchAllCount() {
            string sql = @" select count(*) as count from [client_identifier_type_ref]";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                int count = 0;

                using (var command = new SqlCommand(sql, conn)) {
                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                    reader.Read();
                    count = (System.Int32) reader["count"];
                }

                return count;
            }
        }
        
        // fetch all from table into new List of class instances, filtered by any column
        public static List<CrudeClientIdentifierTypeRefData> FetchWithFilter(string clientIdentifierTypeRcd, string clientIdentifierTypeName, string clientIdentifierTypeDescription, bool activeFlag, int sortOrder, System.Guid userId, System.DateTime dateTime) {
            var dataList = new List<CrudeClientIdentifierTypeRefData>();

            string sql = @" select client_identifier_type_rcd, client_identifier_type_name, client_identifier_type_description, active_flag, sort_order, user_id, date_time
                            from [client_identifier_type_ref]
                            where 1 = 1";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    if (!string.IsNullOrEmpty(clientIdentifierTypeRcd)) {
                        sql += "  and client_identifier_type_rcd like '%' + @client_identifier_type_rcd + '%'";
                        command.Parameters.Add("@client_identifier_type_rcd", SqlDbType.NVarChar).Value = clientIdentifierTypeRcd.Replace("'","''");
                    }
                    if (!string.IsNullOrEmpty(clientIdentifierTypeName)) {
                        sql += "  and client_identifier_type_name like '%' + @client_identifier_type_name + '%'";
                        command.Parameters.Add("@client_identifier_type_name", SqlDbType.NVarChar).Value = clientIdentifierTypeName.Replace("'","''");
                    }
                    if (!string.IsNullOrEmpty(clientIdentifierTypeDescription)) {
                        sql += "  and client_identifier_type_description like '%' + @client_identifier_type_description + '%'";
                        command.Parameters.Add("@client_identifier_type_description", SqlDbType.NVarChar).Value = clientIdentifierTypeDescription.Replace("'","''");
                    }
                    if (activeFlag != false) {
                        sql += "  and active_flag = @active_flag";
                        command.Parameters.Add("@active_flag", SqlDbType.Bit).Value = activeFlag;
                    }
                    if (sortOrder != 0) {
                        sql += "  and sort_order = @sort_order";
                        command.Parameters.Add("@sort_order", SqlDbType.Int).Value = sortOrder;
                    }
                    if (userId != Guid.Empty) {
                        sql += "  and user_id = @user_id";
                        command.Parameters.Add("@user_id", SqlDbType.UniqueIdentifier).Value = userId;
                    }
                    if (dateTime != DateTime.MinValue) {
                        sql += "  and date_time = @date_time";
                        command.Parameters.Add("@date_time", SqlDbType.DateTime).Value = dateTime;
                    }
                    sql += " order by client_identifier_type_name";

                    command.CommandText = sql;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeClientIdentifierTypeRefData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // read all columns out and populate object members
        public void Populate(IDataReader reader) {
            if (reader["client_identifier_type_rcd"] != System.DBNull.Value) ClientIdentifierTypeRcd = (System.String) reader["client_identifier_type_rcd"];
            if (reader["client_identifier_type_name"] != System.DBNull.Value) ClientIdentifierTypeName = (System.String) reader["client_identifier_type_name"];
            if (reader["client_identifier_type_description"] != System.DBNull.Value) ClientIdentifierTypeDescription = (System.String) reader["client_identifier_type_description"];
            if (reader["active_flag"] != System.DBNull.Value) ActiveFlag = (System.Boolean) reader["active_flag"];
            if (reader["sort_order"] != System.DBNull.Value) SortOrder = (System.Int32) reader["sort_order"];
            if (reader["user_id"] != System.DBNull.Value) UserId = (System.Guid) reader["user_id"];
            if (reader["date_time"] != System.DBNull.Value) DateTime = (System.DateTime) reader["date_time"];
        }
        
        // insert all object members as a new row in table
        public void Insert() {

            string sql = "insert into [client_identifier_type_ref] (client_identifier_type_rcd, client_identifier_type_name, client_identifier_type_description, active_flag, sort_order, user_id, date_time)";
            sql += "            values (@client_identifier_type_rcd, @client_identifier_type_name, @client_identifier_type_description, @active_flag, @sort_order, @user_id, @date_time)";

            // open standard connection
            using (var connection = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                connection.Open();

                using (var command = new SqlCommand(sql, connection)) {
                    command.Parameters.Add("@client_identifier_type_rcd",SqlDbType.NVarChar).Value = (System.String)ClientIdentifierTypeRcd;
                    command.Parameters.Add("@client_identifier_type_name",SqlDbType.NVarChar).Value = (System.String)ClientIdentifierTypeName;
                    command.Parameters.Add("@client_identifier_type_description",SqlDbType.NVarChar).Value = (String.IsNullOrEmpty(ClientIdentifierTypeDescription)) ? (object)DBNull.Value : (System.String)ClientIdentifierTypeDescription;
                    command.Parameters.Add("@active_flag",SqlDbType.Bit).Value = (System.Boolean)ActiveFlag;
                    command.Parameters.Add("@sort_order",SqlDbType.Int).Value = (System.Int32)SortOrder;
                    command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                    command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                    command.ExecuteNonQuery();
                }
            }
        }
        
        // insert all object members as a new row in table, in a transaction
        // the transaction and or connection state is not changed in any way other than what SqlClient does to it.
        // it is the callers responsibility to commit or rollback the transaction
        public void Insert(SqlConnection connection, SqlTransaction transaction) {

            string sql = "insert into [client_identifier_type_ref] (client_identifier_type_rcd, client_identifier_type_name, client_identifier_type_description, active_flag, sort_order, user_id, date_time)";
            sql += "            values (@client_identifier_type_rcd, @client_identifier_type_name, @client_identifier_type_description, @active_flag, @sort_order, @user_id, @date_time)";

            // use passed in connection
            // transaction scope etc is determined by caller
            // there are no result from this action, SqlClient will raise an exception in case
            using (SqlCommand command = new SqlCommand(sql, connection, transaction)) {
                command.Parameters.Add("@client_identifier_type_rcd",SqlDbType.NVarChar).Value = (System.String)ClientIdentifierTypeRcd;
                command.Parameters.Add("@client_identifier_type_name",SqlDbType.NVarChar).Value = (System.String)ClientIdentifierTypeName;
                command.Parameters.Add("@client_identifier_type_description",SqlDbType.NVarChar).Value = (String.IsNullOrEmpty(ClientIdentifierTypeDescription)) ? (object)DBNull.Value : (System.String)ClientIdentifierTypeDescription;
                command.Parameters.Add("@active_flag",SqlDbType.Bit).Value = (System.Boolean)ActiveFlag;
                command.Parameters.Add("@sort_order",SqlDbType.Int).Value = (System.Int32)SortOrder;
                command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                command.ExecuteNonQuery();
            }
        }
        
        // update all object members on a row in table based on primary key
        public void Update() {
            string sql = @" update [client_identifier_type_ref] set
                 client_identifier_type_rcd = @client_identifier_type_rcd
                ,client_identifier_type_name = @client_identifier_type_name
                ,client_identifier_type_description = @client_identifier_type_description
                ,active_flag = @active_flag
                ,sort_order = @sort_order
                ,user_id = @user_id
                ,date_time = @date_time
            where client_identifier_type_rcd = @client_identifier_type_rcd";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    command.Parameters.Add("@client_identifier_type_rcd",SqlDbType.NVarChar).Value = (System.String)ClientIdentifierTypeRcd;
                    command.Parameters.Add("@client_identifier_type_name",SqlDbType.NVarChar).Value = (System.String)ClientIdentifierTypeName;
                    command.Parameters.Add("@client_identifier_type_description",SqlDbType.NVarChar).Value = (String.IsNullOrEmpty(ClientIdentifierTypeDescription)) ? (object)DBNull.Value : (System.String)ClientIdentifierTypeDescription;
                    command.Parameters.Add("@active_flag",SqlDbType.Bit).Value = (System.Boolean)ActiveFlag;
                    command.Parameters.Add("@sort_order",SqlDbType.Int).Value = (System.Int32)SortOrder;
                    command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                    command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                    command.ExecuteNonQuery();
                }
            }
        }
        
        // update all object members on a row in table based on primary key, on a transaction
        public void Update(SqlConnection connection, SqlTransaction transaction) {
            string sql = @" update [client_identifier_type_ref] set
                 client_identifier_type_rcd = @client_identifier_type_rcd
                ,client_identifier_type_name = @client_identifier_type_name
                ,client_identifier_type_description = @client_identifier_type_description
                ,active_flag = @active_flag
                ,sort_order = @sort_order
                ,user_id = @user_id
                ,date_time = @date_time
            where client_identifier_type_rcd = @client_identifier_type_rcd";

            // open standard connection
            using (SqlCommand command = new SqlCommand(sql, connection, transaction)) {
                command.Parameters.Add("@client_identifier_type_rcd",SqlDbType.NVarChar).Value = (System.String)ClientIdentifierTypeRcd;
                command.Parameters.Add("@client_identifier_type_name",SqlDbType.NVarChar).Value = (System.String)ClientIdentifierTypeName;
                command.Parameters.Add("@client_identifier_type_description",SqlDbType.NVarChar).Value = (String.IsNullOrEmpty(ClientIdentifierTypeDescription)) ? (object)DBNull.Value : (System.String)ClientIdentifierTypeDescription;
                command.Parameters.Add("@active_flag",SqlDbType.Bit).Value = (System.Boolean)ActiveFlag;
                command.Parameters.Add("@sort_order",SqlDbType.Int).Value = (System.Int32)SortOrder;
                command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                command.ExecuteNonQuery();
            }
        }
        
        // delete a row in table based on primary key
        public static void Delete(string clientIdentifierTypeRcd) {
            string sql = @" delete [client_identifier_type_ref] 
                where client_identifier_type_rcd = @client_identifier_type_rcd";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@client_identifier_type_rcd",SqlDbType.NVarChar).Value = clientIdentifierTypeRcd;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
