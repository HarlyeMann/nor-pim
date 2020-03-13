﻿/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 3/13/2020 10:45:45 AM
  Template: sql2x.CrudeDotNetCoreGenerator.CrudeDataAccessLayer
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace SolutionNorSolutionPim.BusinessLogicLayer {
    
    
    public partial class ClientEventTypeRef {
        
        public const string Created = "CRA";
        
        public const string IntroductionMailConfirmed = "IMC";
        
        public const string Inactivated = "INA";
        
        public const string PackageMailSent = "PMS";
        
        public const string PackageOrdered = "POD";
        
        public const string PackageSiteViewed = "PSV";
        
        public const string SentIntroductionMail = "SIM";
    }
    
    //[Serializable()]
    public partial class CrudeClientEventTypeRefData {
        
        public string ClientEventTypeRcd { get; set; } //;
        
        public string ClientEventTypeName { get; set; } //;
        
        public string ClientEventTypeDescription { get; set; } //;
        
        public bool ActiveFlag { get; set; } //;
        
        public int SortOrder { get; set; } //;
        
        public System.Guid UserId { get; set; } //;
        
        public System.DateTime DateTime { get; set; } //;
        
        public void FetchByClientEventTypeRcd(string clientEventTypeRcd) {
            string sql = @" select top 1 client_event_type_rcd, client_event_type_name, client_event_type_description, active_flag, sort_order, user_id, date_time
                            from [client_event_type_ref]
                            where client_event_type_rcd = @client_event_type_rcd
                            order by client_event_type_name";

            // open standard connection
            using (var conn = new SqlConnection(Conn.ConnectionString)) {
                conn.Open();
                // dirty read
                conn.BeginTransaction(IsolationLevel.ReadUncommitted).Commit();

                using (var command = new SqlCommand(sql, conn)) {
                    // add all parameters
                    command.Parameters.Add("@client_event_type_rcd",SqlDbType.NVarChar).Value = clientEventTypeRcd;

                    // execute and read one row, close connection
                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                    // populate serializable class if row was found
                    if (reader.Read())
                        Populate(reader);
                }
            }
        }
        
        public static CrudeClientEventTypeRefData GetByClientEventTypeRcd(string clientEventTypeRcd) {
            string sql = @" select top 1 client_event_type_rcd, client_event_type_name, client_event_type_description, active_flag, sort_order, user_id, date_time
                            from [client_event_type_ref]
                            where client_event_type_rcd = @client_event_type_rcd
                            order by client_event_type_name";

            var ret = new CrudeClientEventTypeRefData();
            // open standard connection
            using (var conn = new SqlConnection(Conn.ConnectionString)) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@client_event_type_rcd",SqlDbType.NVarChar).Value = clientEventTypeRcd;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                    if (reader.Read())
                        ret.Populate(reader);
                }
            }
            return ret;
        }
        
        public static List<CrudeClientEventTypeRefData> FetchByUserId(System.Guid userId) {
            var dataList = new List<CrudeClientEventTypeRefData>();

            string sql = @" select client_event_type_rcd, client_event_type_name, client_event_type_description, active_flag, sort_order, user_id, date_time
                            from [client_event_type_ref]
                            where user_id = @user_id
                              
                            order by client_event_type_name";

            // open standard connection
            using (var conn = new SqlConnection(Conn.ConnectionString)) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@user_id", SqlDbType.UniqueIdentifier).Value = userId;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeClientEventTypeRefData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        public void FetchByClientEventTypeName(string clientEventTypeName) {
            string sql = @" select top 1 client_event_type_rcd, client_event_type_name, client_event_type_description, active_flag, sort_order, user_id, date_time
                            from [client_event_type_ref]
                            where client_event_type_name like '%' + @clientEventTypeName + '%'
                              ";

            // open standard connection
            using (var conn = new SqlConnection(Conn.ConnectionString)) {
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.Add("@clientEventTypeName",SqlDbType.NVarChar).Value = clientEventTypeName;

                IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                    Populate(reader);
            }
        }
        
        public static List<CrudeClientEventTypeRefData> FetchAll() {
            var dataList = new List<CrudeClientEventTypeRefData>();

            string sql = @" select client_event_type_rcd, client_event_type_name, client_event_type_description, active_flag, sort_order, user_id, date_time
                            from [client_event_type_ref]
                            order by client_event_type_name";

            // open standard connection
            using (var conn = new SqlConnection(Conn.ConnectionString)) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeClientEventTypeRefData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        public static List<CrudeClientEventTypeRefData> FetchAllWithLimit(int limit) {
            var dataList = new List<CrudeClientEventTypeRefData>();

            string sql = @" select top " + limit.ToString() + @" client_event_type_rcd, client_event_type_name, client_event_type_description, active_flag, sort_order, user_id, date_time
                            from [client_event_type_ref]
                            order by client_event_type_name";

            // open standard connection
            using (var conn = new SqlConnection(Conn.ConnectionString)) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeClientEventTypeRefData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        public static List<CrudeClientEventTypeRefData> FetchAllWithLimitAndOffset(int limit, int offset) {
            var dataList = new List<CrudeClientEventTypeRefData>();

            string sql = @" select client_event_type_rcd, client_event_type_name, client_event_type_description, active_flag, sort_order, user_id, date_time
                            from [client_event_type_ref]
                            order by client_event_type_name";

            // open standard connection
            using (var conn = new SqlConnection(Conn.ConnectionString)) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    int count = 0;

                    while (reader.Read()) {
                        if ((count >= offset) && (count <= offset + limit)) {
                            var data = new CrudeClientEventTypeRefData();
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
        
        public static int FetchAllCount() {
            string sql = @" select count(*) as count from [client_event_type_ref]";

            // open standard connection
            using (var conn = new SqlConnection(Conn.ConnectionString)) {
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
        
        public static List<CrudeClientEventTypeRefData> FetchWithFilter(string clientEventTypeRcd, string clientEventTypeName, string clientEventTypeDescription, bool activeFlag, int sortOrder, System.Guid userId, System.DateTime dateTime) {
            var dataList = new List<CrudeClientEventTypeRefData>();

            string sql = @" select client_event_type_rcd, client_event_type_name, client_event_type_description, active_flag, sort_order, user_id, date_time
                            from [client_event_type_ref]
                            where 1 = 1";

            // open standard connection
            using (var conn = new SqlConnection(Conn.ConnectionString)) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    if (!string.IsNullOrEmpty(clientEventTypeRcd)) {
                        sql += "  and client_event_type_rcd like '%' + @client_event_type_rcd + '%'";
                        command.Parameters.Add("@client_event_type_rcd", SqlDbType.NVarChar).Value = clientEventTypeRcd.Replace("'","''");
                    }
                    if (!string.IsNullOrEmpty(clientEventTypeName)) {
                        sql += "  and client_event_type_name like '%' + @client_event_type_name + '%'";
                        command.Parameters.Add("@client_event_type_name", SqlDbType.NVarChar).Value = clientEventTypeName.Replace("'","''");
                    }
                    if (!string.IsNullOrEmpty(clientEventTypeDescription)) {
                        sql += "  and client_event_type_description like '%' + @client_event_type_description + '%'";
                        command.Parameters.Add("@client_event_type_description", SqlDbType.NVarChar).Value = clientEventTypeDescription.Replace("'","''");
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
                    sql += " order by client_event_type_name";

                    command.CommandText = sql;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeClientEventTypeRefData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        public void Populate(IDataReader reader) {
            if (reader["client_event_type_rcd"] != System.DBNull.Value) ClientEventTypeRcd = (System.String) reader["client_event_type_rcd"];
            if (reader["client_event_type_name"] != System.DBNull.Value) ClientEventTypeName = (System.String) reader["client_event_type_name"];
            if (reader["client_event_type_description"] != System.DBNull.Value) ClientEventTypeDescription = (System.String) reader["client_event_type_description"];
            if (reader["active_flag"] != System.DBNull.Value) ActiveFlag = (System.Boolean) reader["active_flag"];
            if (reader["sort_order"] != System.DBNull.Value) SortOrder = (System.Int32) reader["sort_order"];
            if (reader["user_id"] != System.DBNull.Value) UserId = (System.Guid) reader["user_id"];
            if (reader["date_time"] != System.DBNull.Value) DateTime = (System.DateTime) reader["date_time"];
        }
        
        public void Insert() {

            string sql = "insert into [client_event_type_ref] (client_event_type_rcd, client_event_type_name, client_event_type_description, active_flag, sort_order, user_id, date_time)";
            sql += "            values (@client_event_type_rcd, @client_event_type_name, @client_event_type_description, @active_flag, @sort_order, @user_id, @date_time)";

            // open standard connection
            using (var connection = new SqlConnection(Conn.ConnectionString)) {
                connection.Open();

                using (var command = new SqlCommand(sql, connection)) {
                    command.Parameters.Add("@client_event_type_rcd",SqlDbType.NVarChar).Value = (System.String)ClientEventTypeRcd;
                    command.Parameters.Add("@client_event_type_name",SqlDbType.NVarChar).Value = (System.String)ClientEventTypeName;
                    command.Parameters.Add("@client_event_type_description",SqlDbType.NVarChar).Value = (String.IsNullOrEmpty(ClientEventTypeDescription)) ? (object)DBNull.Value : (System.String)ClientEventTypeDescription;
                    command.Parameters.Add("@active_flag",SqlDbType.Bit).Value = (System.Boolean)ActiveFlag;
                    command.Parameters.Add("@sort_order",SqlDbType.Int).Value = (System.Int32)SortOrder;
                    command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                    command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void Insert(SqlConnection connection, SqlTransaction transaction) {

            string sql = "insert into [client_event_type_ref] (client_event_type_rcd, client_event_type_name, client_event_type_description, active_flag, sort_order, user_id, date_time)";
            sql += "            values (@client_event_type_rcd, @client_event_type_name, @client_event_type_description, @active_flag, @sort_order, @user_id, @date_time)";

            // open standard connection
            using (SqlCommand command = new SqlCommand(sql, connection, transaction)) {
                command.Parameters.Add("@client_event_type_rcd",SqlDbType.NVarChar).Value = (System.String)ClientEventTypeRcd;
                command.Parameters.Add("@client_event_type_name",SqlDbType.NVarChar).Value = (System.String)ClientEventTypeName;
                command.Parameters.Add("@client_event_type_description",SqlDbType.NVarChar).Value = (String.IsNullOrEmpty(ClientEventTypeDescription)) ? (object)DBNull.Value : (System.String)ClientEventTypeDescription;
                command.Parameters.Add("@active_flag",SqlDbType.Bit).Value = (System.Boolean)ActiveFlag;
                command.Parameters.Add("@sort_order",SqlDbType.Int).Value = (System.Int32)SortOrder;
                command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                command.ExecuteNonQuery();
            }
        }
        
        public void Update() {
            string sql = @" update [client_event_type_ref] set
                 client_event_type_rcd = @client_event_type_rcd
                ,client_event_type_name = @client_event_type_name
                ,client_event_type_description = @client_event_type_description
                ,active_flag = @active_flag
                ,sort_order = @sort_order
                ,user_id = @user_id
                ,date_time = @date_time
            where client_event_type_rcd = @client_event_type_rcd";

            // open standard connection
            using (var conn = new SqlConnection(Conn.ConnectionString)) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    command.Parameters.Add("@client_event_type_rcd",SqlDbType.NVarChar).Value = (System.String)ClientEventTypeRcd;
                    command.Parameters.Add("@client_event_type_name",SqlDbType.NVarChar).Value = (System.String)ClientEventTypeName;
                    command.Parameters.Add("@client_event_type_description",SqlDbType.NVarChar).Value = (String.IsNullOrEmpty(ClientEventTypeDescription)) ? (object)DBNull.Value : (System.String)ClientEventTypeDescription;
                    command.Parameters.Add("@active_flag",SqlDbType.Bit).Value = (System.Boolean)ActiveFlag;
                    command.Parameters.Add("@sort_order",SqlDbType.Int).Value = (System.Int32)SortOrder;
                    command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                    command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void Update(SqlConnection connection, SqlTransaction transaction) {
            string sql = @" update [client_event_type_ref] set
                 client_event_type_rcd = @client_event_type_rcd
                ,client_event_type_name = @client_event_type_name
                ,client_event_type_description = @client_event_type_description
                ,active_flag = @active_flag
                ,sort_order = @sort_order
                ,user_id = @user_id
                ,date_time = @date_time
            where client_event_type_rcd = @client_event_type_rcd";

            // open standard connection
            using (SqlCommand command = new SqlCommand(sql, connection, transaction)) {
                command.Parameters.Add("@client_event_type_rcd",SqlDbType.NVarChar).Value = (System.String)ClientEventTypeRcd;
                command.Parameters.Add("@client_event_type_name",SqlDbType.NVarChar).Value = (System.String)ClientEventTypeName;
                command.Parameters.Add("@client_event_type_description",SqlDbType.NVarChar).Value = (String.IsNullOrEmpty(ClientEventTypeDescription)) ? (object)DBNull.Value : (System.String)ClientEventTypeDescription;
                command.Parameters.Add("@active_flag",SqlDbType.Bit).Value = (System.Boolean)ActiveFlag;
                command.Parameters.Add("@sort_order",SqlDbType.Int).Value = (System.Int32)SortOrder;
                command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                command.ExecuteNonQuery();
            }
        }
        
        public static void Delete(string clientEventTypeRcd) {
            string sql = @" delete [client_event_type_ref] 
                where client_event_type_rcd = @client_event_type_rcd";

            // open standard connection
            using (var conn = new SqlConnection(Conn.ConnectionString)) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@client_event_type_rcd",SqlDbType.NVarChar).Value = clientEventTypeRcd;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
