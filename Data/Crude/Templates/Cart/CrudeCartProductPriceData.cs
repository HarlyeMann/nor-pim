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

    [Serializable()]
    public partial class CrudeCartProductPriceData {
        
        public System.Guid CartProductPriceId { get; set; }
        
        public System.Guid FinancialCurrencyId { get; set; }
        
        public decimal Amount { get; set; }
        
        public string StateRcd { get; set; }
        
        public System.Guid UserId { get; set; }
        
        public System.DateTime DateTime { get; set; }
        
        public System.Guid ProductId { get; set; }
        
        // fetch by Primary key into current object
        // parameters:
        //   cartProductPriceId: primary key of table cart_product_price
        public void FetchByCartProductPriceId(System.Guid cartProductPriceId) {
            // create query
            // this will be ansi sql and parameterized
            // parameterized queries are a good way of preventing sql injection and to make sure the query plan is pre-compiled
            string sql = @" select top 1 cart_product_price_id, financial_currency_id, amount, state_rcd, user_id, date_time, product_id
                            from [cart_product_price]
                            where cart_product_price_id = @cart_product_price_id";

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
                    command.Parameters.Add("@cart_product_price_id",SqlDbType.UniqueIdentifier).Value = cartProductPriceId;

                    // execute and read one row, close connection
                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                    // populate serializable class if row was found
                    if (reader.Read())
                        Populate(reader);
                }
            }
        }
        
        // fetch by Primary key into new class instance
        public static CrudeCartProductPriceData GetByCartProductPriceId(System.Guid cartProductPriceId) {
            string sql = @" select top 1 cart_product_price_id, financial_currency_id, amount, state_rcd, user_id, date_time, product_id
                            from [cart_product_price]
                            where cart_product_price_id = @cart_product_price_id";

            var ret = new CrudeCartProductPriceData();

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@cart_product_price_id",SqlDbType.UniqueIdentifier).Value = cartProductPriceId;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                    // populate serialized class if row was found
                    if (reader.Read())
                        ret.Populate(reader);
                }
            }

            return ret;
        }
        
        // fetch by Foreign key into new List of class instances
        public static List<CrudeCartProductPriceData> FetchByFinancialCurrencyId(System.Guid financialCurrencyId) {
            var dataList = new List<CrudeCartProductPriceData>();

            string sql = @" select cart_product_price_id, financial_currency_id, amount, state_rcd, user_id, date_time, product_id
                            from [cart_product_price]
                            where financial_currency_id = @financial_currency_id
                              ";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@financial_currency_id", SqlDbType.UniqueIdentifier).Value = financialCurrencyId;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeCartProductPriceData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch by Foreign key into new List of class instances
        public static List<CrudeCartProductPriceData> FetchByUserId(System.Guid userId) {
            var dataList = new List<CrudeCartProductPriceData>();

            string sql = @" select cart_product_price_id, financial_currency_id, amount, state_rcd, user_id, date_time, product_id
                            from [cart_product_price]
                            where user_id = @user_id
                              ";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@user_id", SqlDbType.UniqueIdentifier).Value = userId;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeCartProductPriceData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch by Foreign key into new List of class instances
        public static List<CrudeCartProductPriceData> FetchByProductId(System.Guid productId) {
            var dataList = new List<CrudeCartProductPriceData>();

            string sql = @" select cart_product_price_id, financial_currency_id, amount, state_rcd, user_id, date_time, product_id
                            from [cart_product_price]
                            where product_id = @product_id
                              ";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@product_id", SqlDbType.UniqueIdentifier).Value = productId;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeCartProductPriceData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch by Foreign key into new List of class instances
        public static List<CrudeCartProductPriceData> FetchByStateRcd(string stateRcd) {
            var dataList = new List<CrudeCartProductPriceData>();

            string sql = @" select cart_product_price_id, financial_currency_id, amount, state_rcd, user_id, date_time, product_id
                            from [cart_product_price]
                            where state_rcd = @state_rcd
                              ";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@state_rcd", SqlDbType.NVarChar).Value = stateRcd.Replace("'","''");

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeCartProductPriceData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch all from table into new List of class instances
        public static List<CrudeCartProductPriceData> FetchAll() {
            var dataList = new List<CrudeCartProductPriceData>();

            string sql = @" select cart_product_price_id, financial_currency_id, amount, state_rcd, user_id, date_time, product_id
                            from [cart_product_price]";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeCartProductPriceData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch all from table into new List of class instances, with a limit on number of returned rows and order by columns
        public static List<CrudeCartProductPriceData> FetchAllWithLimit(int limit) {
            var dataList = new List<CrudeCartProductPriceData>();

            string sql = @" select top " + limit.ToString() + @" cart_product_price_id, financial_currency_id, amount, state_rcd, user_id, date_time, product_id
                            from [cart_product_price]";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeCartProductPriceData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch all from table into new List of class instances, only populating specific columns , with a limit on number of returned rows and order by columns starting at a specific row
        public static List<CrudeCartProductPriceData> FetchAllWithLimitAndOffset(int limit, int offset) {
            var dataList = new List<CrudeCartProductPriceData>();

            string sql = @" select cart_product_price_id, financial_currency_id, amount, state_rcd, user_id, date_time, product_id
                            from [cart_product_price]";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    int count = 0;

                    while (reader.Read()) {
                        if ((count >= offset) && (count <= offset + limit)) {
                            var data = new CrudeCartProductPriceData();
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
            string sql = @" select count(*) as count from [cart_product_price]";

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
        public static List<CrudeCartProductPriceData> FetchWithFilter(System.Guid cartProductPriceId, System.Guid financialCurrencyId, decimal amount, string stateRcd, System.Guid userId, System.DateTime dateTime, System.Guid productId) {
            var dataList = new List<CrudeCartProductPriceData>();

            string sql = @" select cart_product_price_id, financial_currency_id, amount, state_rcd, user_id, date_time, product_id
                            from [cart_product_price]
                            where 1 = 1";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    if (cartProductPriceId != Guid.Empty) {
                        sql += "  and cart_product_price_id = @cart_product_price_id";
                        command.Parameters.Add("@cart_product_price_id", SqlDbType.UniqueIdentifier).Value = cartProductPriceId;
                    }
                    if (financialCurrencyId != Guid.Empty) {
                        sql += "  and financial_currency_id = @financial_currency_id";
                        command.Parameters.Add("@financial_currency_id", SqlDbType.UniqueIdentifier).Value = financialCurrencyId;
                    }
                    if (amount != 0) {
                        sql += "  and amount = @amount";
                        command.Parameters.Add("@amount", SqlDbType.Decimal).Value = amount;
                    }
                    if (!string.IsNullOrEmpty(stateRcd)) {
                        sql += "  and state_rcd like '%' + @state_rcd + '%'";
                        command.Parameters.Add("@state_rcd", SqlDbType.NVarChar).Value = stateRcd.Replace("'","''");
                    }
                    if (userId != Guid.Empty) {
                        sql += "  and user_id = @user_id";
                        command.Parameters.Add("@user_id", SqlDbType.UniqueIdentifier).Value = userId;
                    }
                    if (dateTime != DateTime.MinValue) {
                        sql += "  and date_time = @date_time";
                        command.Parameters.Add("@date_time", SqlDbType.DateTime).Value = dateTime;
                    }
                    if (productId != Guid.Empty) {
                        sql += "  and product_id = @product_id";
                        command.Parameters.Add("@product_id", SqlDbType.UniqueIdentifier).Value = productId;
                    }
                    command.CommandText = sql;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeCartProductPriceData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // read all columns out and populate object members
        public void Populate(IDataReader reader) {
            if (reader["cart_product_price_id"] != System.DBNull.Value) CartProductPriceId = (System.Guid) reader["cart_product_price_id"];
            if (reader["financial_currency_id"] != System.DBNull.Value) FinancialCurrencyId = (System.Guid) reader["financial_currency_id"];
            if (reader["amount"] != System.DBNull.Value) Amount = (System.Decimal) reader["amount"];
            if (reader["state_rcd"] != System.DBNull.Value) StateRcd = (System.String) reader["state_rcd"];
            if (reader["user_id"] != System.DBNull.Value) UserId = (System.Guid) reader["user_id"];
            if (reader["date_time"] != System.DBNull.Value) DateTime = (System.DateTime) reader["date_time"];
            if (reader["product_id"] != System.DBNull.Value) ProductId = (System.Guid) reader["product_id"];
        }
        
        // insert all object members as a new row in table
        public void Insert() {

            if (CartProductPriceId == Guid.Empty)
                CartProductPriceId = Guid.NewGuid();

            string sql = "insert into [cart_product_price] (cart_product_price_id, financial_currency_id, amount, state_rcd, user_id, date_time, product_id)";
            sql += "            values (@cart_product_price_id, @financial_currency_id, @amount, @state_rcd, @user_id, @date_time, @product_id)";

            // open standard connection
            using (var connection = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                connection.Open();

                using (var command = new SqlCommand(sql, connection)) {
                    command.Parameters.Add("@cart_product_price_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)CartProductPriceId;
                    command.Parameters.Add("@financial_currency_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)FinancialCurrencyId;
                    command.Parameters.Add("@amount",SqlDbType.Decimal).Value = (System.Decimal)Amount;
                    command.Parameters.Add("@state_rcd",SqlDbType.NVarChar).Value = (System.String)StateRcd;
                    command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                    command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                    command.Parameters.Add("@product_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)ProductId;
                    command.ExecuteNonQuery();
                }
            }
        }
        
        // insert all object members as a new row in table, in a transaction
        // the transaction and or connection state is not changed in any way other than what SqlClient does to it.
        // it is the callers responsibility to commit or rollback the transaction
        public void Insert(SqlConnection connection, SqlTransaction transaction) {

            if (CartProductPriceId == Guid.Empty)
                CartProductPriceId = Guid.NewGuid();

            string sql = "insert into [cart_product_price] (cart_product_price_id, financial_currency_id, amount, state_rcd, user_id, date_time, product_id)";
            sql += "            values (@cart_product_price_id, @financial_currency_id, @amount, @state_rcd, @user_id, @date_time, @product_id)";

            // use passed in connection
            // transaction scope etc is determined by caller
            // there are no result from this action, SqlClient will raise an exception in case
            using (SqlCommand command = new SqlCommand(sql, connection, transaction)) {
                command.Parameters.Add("@cart_product_price_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)CartProductPriceId;
                command.Parameters.Add("@financial_currency_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)FinancialCurrencyId;
                command.Parameters.Add("@amount",SqlDbType.Decimal).Value = (System.Decimal)Amount;
                command.Parameters.Add("@state_rcd",SqlDbType.NVarChar).Value = (System.String)StateRcd;
                command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                command.Parameters.Add("@product_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)ProductId;
                command.ExecuteNonQuery();
            }
        }
        
        // update all object members on a row in table based on primary key
        public void Update() {
            string sql = @" update [cart_product_price] set
                 cart_product_price_id = @cart_product_price_id
                ,financial_currency_id = @financial_currency_id
                ,amount = @amount
                ,state_rcd = @state_rcd
                ,user_id = @user_id
                ,date_time = @date_time
                ,product_id = @product_id
            where cart_product_price_id = @cart_product_price_id";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    command.Parameters.Add("@cart_product_price_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)CartProductPriceId;
                    command.Parameters.Add("@financial_currency_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)FinancialCurrencyId;
                    command.Parameters.Add("@amount",SqlDbType.Decimal).Value = (System.Decimal)Amount;
                    command.Parameters.Add("@state_rcd",SqlDbType.NVarChar).Value = (System.String)StateRcd;
                    command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                    command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                    command.Parameters.Add("@product_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)ProductId;
                    command.ExecuteNonQuery();
                }
            }
        }
        
        // update all object members on a row in table based on primary key, on a transaction
        public void Update(SqlConnection connection, SqlTransaction transaction) {
            string sql = @" update [cart_product_price] set
                 cart_product_price_id = @cart_product_price_id
                ,financial_currency_id = @financial_currency_id
                ,amount = @amount
                ,state_rcd = @state_rcd
                ,user_id = @user_id
                ,date_time = @date_time
                ,product_id = @product_id
            where cart_product_price_id = @cart_product_price_id";

            // open standard connection
            using (SqlCommand command = new SqlCommand(sql, connection, transaction)) {
                command.Parameters.Add("@cart_product_price_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)CartProductPriceId;
                command.Parameters.Add("@financial_currency_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)FinancialCurrencyId;
                command.Parameters.Add("@amount",SqlDbType.Decimal).Value = (System.Decimal)Amount;
                command.Parameters.Add("@state_rcd",SqlDbType.NVarChar).Value = (System.String)StateRcd;
                command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                command.Parameters.Add("@product_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)ProductId;
                command.ExecuteNonQuery();
            }
        }
        
        // delete a row in table based on primary key
        public static void Delete(System.Guid cartProductPriceId) {
            string sql = @" delete [cart_product_price] 
                where cart_product_price_id = @cart_product_price_id";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@cart_product_price_id",SqlDbType.UniqueIdentifier).Value = cartProductPriceId;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
