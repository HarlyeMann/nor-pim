﻿/*
  SQL2X Generated code based on a SQL Server Schema
  SQL2X Version: 1.0
  http://sql2x.org/
  Generated Date: 7/14/2020 11:35:24 AM
  From Machine: DESKTOP-517I8BU
  Template: sql2x.GenerateDataAccessLayerV0.UsingDotNetFramework
*/
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;

namespace SolutionNorSolutionPim.DataAccessLayer {

    public partial class ProductEntityTypeRef {
        
        public const string Product = "P";
        
        public const string ProductAttribute = "PA";
        
        public const string ProductCategory = "PC";
        
        public const string ProductDescription = "PD";
        
        public const string ProductIdentifier = "PID";
        
        public const string ProductInfo = "PI";
        
        public const string ProductSupplier = "PS";
    }
    
    [Serializable()]
    public partial class CrudeProductEntityTypeRefData {
        
        public string ProductEntityTypeRcd { get; set; }
        
        public string ProductEntityTypeName { get; set; }
        
        public System.Guid UserId { get; set; }
        
        public System.DateTime DateTime { get; set; }
        
        // fetch by Primary key into current object
        // parameters:
        //   productEntityTypeRcd: primary key of table product_entity_type_ref
        public void FetchByProductEntityTypeRcd(string productEntityTypeRcd) {
            // create query
            // this will be ansi sql and parameterized
            // parameterized queries are a good way of preventing sql injection and to make sure the query plan is pre-compiled
            string sql = @" select top 1 product_entity_type_rcd, product_entity_type_name, user_id, date_time
                            from [product_entity_type_ref]
                            where product_entity_type_rcd = @product_entity_type_rcd
                            order by product_entity_type_name";

            // open standard connection
            // the connection is found in web.config
            // the connection is closed upon completion of the reader
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                // dirty read
                // starting a transaction seems to be the only way of doing a dirty read
                // a dirty read means a row is read even if it is marked as locked by another transaction
                conn.BeginTransaction(IsolationLevel.ReadUncommitted).Commit();

                using (var command = new SqlCommand(sql, conn)) {
                    // add primary key
                    // this primary key will be used together with the prepared ansi sql statement
                    command.Parameters.Add("@product_entity_type_rcd",SqlDbType.NVarChar).Value = productEntityTypeRcd;

                    // execute and read one row, close connection
                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                    // populate serializable class if row was found
                    if (reader.Read())
                        Populate(reader);
                }
            }
        }
        
        // fetch by Primary key into new class instance
        public static CrudeProductEntityTypeRefData GetByProductEntityTypeRcd(string productEntityTypeRcd) {
            string sql = @" select top 1 product_entity_type_rcd, product_entity_type_name, user_id, date_time
                            from [product_entity_type_ref]
                            where product_entity_type_rcd = @product_entity_type_rcd
                            order by product_entity_type_name";

            var ret = new CrudeProductEntityTypeRefData();

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@product_entity_type_rcd",SqlDbType.NVarChar).Value = productEntityTypeRcd;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                    // populate serialized class if row was found
                    if (reader.Read())
                        ret.Populate(reader);
                }
            }

            return ret;
        }
        
        // fetch by Foreign key into new List of class instances
        public static List<CrudeProductEntityTypeRefData> FetchByUserId(System.Guid userId) {
            var dataList = new List<CrudeProductEntityTypeRefData>();

            string sql = @" select product_entity_type_rcd, product_entity_type_name, user_id, date_time
                            from [product_entity_type_ref]
                            where user_id = @user_id
                              
                            order by product_entity_type_name";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@user_id", SqlDbType.UniqueIdentifier).Value = userId;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeProductEntityTypeRefData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch by Picker Member into new class instance
        public void FetchByProductEntityTypeName(string productEntityTypeName) {
            string sql = @" select top 1 product_entity_type_rcd, product_entity_type_name, user_id, date_time
                            from [product_entity_type_ref]
                            where product_entity_type_name like '%' + @productEntityTypeName + '%'
                              ";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.Add("@productEntityTypeName",SqlDbType.NVarChar).Value = productEntityTypeName;

                IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                    Populate(reader);
            }
        }
        
        // fetch all from table into new List of class instances
        public static List<CrudeProductEntityTypeRefData> FetchAll() {
            var dataList = new List<CrudeProductEntityTypeRefData>();

            string sql = @" select product_entity_type_rcd, product_entity_type_name, user_id, date_time
                            from [product_entity_type_ref]
                            order by product_entity_type_name";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeProductEntityTypeRefData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch all from table into new List of class instances, with a limit on number of returned rows and order by columns
        public static List<CrudeProductEntityTypeRefData> FetchAllWithLimit(int limit) {
            var dataList = new List<CrudeProductEntityTypeRefData>();

            string sql = @" select top " + limit.ToString() + @" product_entity_type_rcd, product_entity_type_name, user_id, date_time
                            from [product_entity_type_ref]
                            order by product_entity_type_name";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeProductEntityTypeRefData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch all from table into new List of class instances, only populating specific columns , with a limit on number of returned rows and order by columns starting at a specific row
        public static List<CrudeProductEntityTypeRefData> FetchAllWithLimitAndOffset(int limit, int offset) {
            var dataList = new List<CrudeProductEntityTypeRefData>();

            string sql = @" select product_entity_type_rcd, product_entity_type_name, user_id, date_time
                            from [product_entity_type_ref]
                            order by product_entity_type_name";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    int count = 0;

                    while (reader.Read()) {
                        if ((count >= offset) && (count <= offset + limit)) {
                            var data = new CrudeProductEntityTypeRefData();
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
            string sql = @" select count(*) as count from [product_entity_type_ref]";

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
        public static List<CrudeProductEntityTypeRefData> FetchWithFilter(string productEntityTypeRcd, string productEntityTypeName, System.Guid userId, System.DateTime dateTime) {
            var dataList = new List<CrudeProductEntityTypeRefData>();

            string sql = @" select product_entity_type_rcd, product_entity_type_name, user_id, date_time
                            from [product_entity_type_ref]
                            where 1 = 1";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    if (!string.IsNullOrEmpty(productEntityTypeRcd)) {
                        sql += "  and product_entity_type_rcd like '%' + @product_entity_type_rcd + '%'";
                        command.Parameters.Add("@product_entity_type_rcd", SqlDbType.NVarChar).Value = productEntityTypeRcd.Replace("'","''");
                    }
                    if (!string.IsNullOrEmpty(productEntityTypeName)) {
                        sql += "  and product_entity_type_name like '%' + @product_entity_type_name + '%'";
                        command.Parameters.Add("@product_entity_type_name", SqlDbType.NVarChar).Value = productEntityTypeName.Replace("'","''");
                    }
                    if (userId != Guid.Empty) {
                        sql += "  and user_id = @user_id";
                        command.Parameters.Add("@user_id", SqlDbType.UniqueIdentifier).Value = userId;
                    }
                    if (dateTime != DateTime.MinValue) {
                        sql += "  and date_time = @date_time";
                        command.Parameters.Add("@date_time", SqlDbType.DateTime).Value = dateTime;
                    }
                    sql += " order by product_entity_type_name";

                    command.CommandText = sql;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeProductEntityTypeRefData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // read all columns out and populate object members
        public void Populate(IDataReader reader) {
            if (reader["product_entity_type_rcd"] != System.DBNull.Value) ProductEntityTypeRcd = (System.String) reader["product_entity_type_rcd"];
            if (reader["product_entity_type_name"] != System.DBNull.Value) ProductEntityTypeName = (System.String) reader["product_entity_type_name"];
            if (reader["user_id"] != System.DBNull.Value) UserId = (System.Guid) reader["user_id"];
            if (reader["date_time"] != System.DBNull.Value) DateTime = (System.DateTime) reader["date_time"];
        }
        
        // insert all object members as a new row in table
        public void Insert() {

            string sql = "insert into [product_entity_type_ref] (product_entity_type_rcd, product_entity_type_name, user_id, date_time)";
            sql += "            values (@product_entity_type_rcd, @product_entity_type_name, @user_id, @date_time)";

            // open standard connection
            using (var connection = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                connection.Open();

                using (var command = new SqlCommand(sql, connection)) {
                    command.Parameters.Add("@product_entity_type_rcd",SqlDbType.NVarChar).Value = (System.String)ProductEntityTypeRcd;
                    command.Parameters.Add("@product_entity_type_name",SqlDbType.NVarChar).Value = (System.String)ProductEntityTypeName;
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

            string sql = "insert into [product_entity_type_ref] (product_entity_type_rcd, product_entity_type_name, user_id, date_time)";
            sql += "            values (@product_entity_type_rcd, @product_entity_type_name, @user_id, @date_time)";

            // use passed in connection
            // transaction scope etc is determined by caller
            // there are no result from this action, SqlClient will raise an exception in case
            using (SqlCommand command = new SqlCommand(sql, connection, transaction)) {
                command.Parameters.Add("@product_entity_type_rcd",SqlDbType.NVarChar).Value = (System.String)ProductEntityTypeRcd;
                command.Parameters.Add("@product_entity_type_name",SqlDbType.NVarChar).Value = (System.String)ProductEntityTypeName;
                command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                command.ExecuteNonQuery();
            }
        }
        
        // update all object members on a row in table based on primary key
        public void Update() {
            string sql = @" update [product_entity_type_ref] set
                 product_entity_type_rcd = @product_entity_type_rcd
                ,product_entity_type_name = @product_entity_type_name
                ,user_id = @user_id
                ,date_time = @date_time
            where product_entity_type_rcd = @product_entity_type_rcd";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    command.Parameters.Add("@product_entity_type_rcd",SqlDbType.NVarChar).Value = (System.String)ProductEntityTypeRcd;
                    command.Parameters.Add("@product_entity_type_name",SqlDbType.NVarChar).Value = (System.String)ProductEntityTypeName;
                    command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                    command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                    command.ExecuteNonQuery();
                }
            }
        }
        
        // update all object members on a row in table based on primary key, on a transaction
        public void Update(SqlConnection connection, SqlTransaction transaction) {
            string sql = @" update [product_entity_type_ref] set
                 product_entity_type_rcd = @product_entity_type_rcd
                ,product_entity_type_name = @product_entity_type_name
                ,user_id = @user_id
                ,date_time = @date_time
            where product_entity_type_rcd = @product_entity_type_rcd";

            // open standard connection
            using (SqlCommand command = new SqlCommand(sql, connection, transaction)) {
                command.Parameters.Add("@product_entity_type_rcd",SqlDbType.NVarChar).Value = (System.String)ProductEntityTypeRcd;
                command.Parameters.Add("@product_entity_type_name",SqlDbType.NVarChar).Value = (System.String)ProductEntityTypeName;
                command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                command.ExecuteNonQuery();
            }
        }
        
        // delete a row in table based on primary key
        public static void Delete(string productEntityTypeRcd) {
            string sql = @" delete [product_entity_type_ref] 
                where product_entity_type_rcd = @product_entity_type_rcd";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@product_entity_type_rcd",SqlDbType.NVarChar).Value = productEntityTypeRcd;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
