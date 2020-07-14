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
    public partial class CrudeFinancialCurrencyData {
        
        public System.Guid FinancialCurrencyId { get; set; }
        
        public string FinancialCurrencyTypeRcd { get; set; }
        
        public string FinancialCurrencyAgainstFinancialCurrencyTypeRcd { get; set; }
        
        public System.Guid UserId { get; set; }
        
        public System.DateTime DateTime { get; set; }
        
        public System.DateTime ValidFromDateTime { get; set; }
        
        public System.DateTime ValidUntilDateTime { get; set; }
        
        public decimal Amount { get; set; }
        
        public decimal EqualsAmount { get; set; }
        
        public int DecimalCount { get; set; }
        
        public string FinancialCurrencyTypeCode { get; set; }
        
        public string FinancialCurrencyTypeName { get; set; }
        
        // fetch by Primary key into current object
        // parameters:
        //   financialCurrencyId: primary key of table financial_currency
        public void FetchByFinancialCurrencyId(System.Guid financialCurrencyId) {
            // create query
            // this will be ansi sql and parameterized
            // parameterized queries are a good way of preventing sql injection and to make sure the query plan is pre-compiled
            string sql = @" select top 1 financial_currency_id, financial_currency_type_rcd, financial_currency_against_financial_currency_type_rcd, user_id, date_time, valid_from_date_time, valid_until_date_time, amount, equals_amount, decimal_count, financial_currency_type_code, financial_currency_type_name
                            from [financial_currency]
                            where financial_currency_id = @financial_currency_id
                            order by financial_currency_type_name";

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
                    command.Parameters.Add("@financial_currency_id",SqlDbType.UniqueIdentifier).Value = financialCurrencyId;

                    // execute and read one row, close connection
                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                    // populate serializable class if row was found
                    if (reader.Read())
                        Populate(reader);
                }
            }
        }
        
        // fetch by Primary key into new class instance
        public static CrudeFinancialCurrencyData GetByFinancialCurrencyId(System.Guid financialCurrencyId) {
            string sql = @" select top 1 financial_currency_id, financial_currency_type_rcd, financial_currency_against_financial_currency_type_rcd, user_id, date_time, valid_from_date_time, valid_until_date_time, amount, equals_amount, decimal_count, financial_currency_type_code, financial_currency_type_name
                            from [financial_currency]
                            where financial_currency_id = @financial_currency_id
                            order by financial_currency_type_name";

            var ret = new CrudeFinancialCurrencyData();

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@financial_currency_id",SqlDbType.UniqueIdentifier).Value = financialCurrencyId;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                    // populate serialized class if row was found
                    if (reader.Read())
                        ret.Populate(reader);
                }
            }

            return ret;
        }
        
        // fetch by Foreign key into new List of class instances
        public static List<CrudeFinancialCurrencyData> FetchByUserId(System.Guid userId) {
            var dataList = new List<CrudeFinancialCurrencyData>();

            string sql = @" select financial_currency_id, financial_currency_type_rcd, financial_currency_against_financial_currency_type_rcd, user_id, date_time, valid_from_date_time, valid_until_date_time, amount, equals_amount, decimal_count, financial_currency_type_code, financial_currency_type_name
                            from [financial_currency]
                            where user_id = @user_id
                              
                            order by financial_currency_type_name";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@user_id", SqlDbType.UniqueIdentifier).Value = userId;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeFinancialCurrencyData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch by Foreign key into new List of class instances
        public static List<CrudeFinancialCurrencyData> FetchByFinancialCurrencyTypeRcd(string financialCurrencyTypeRcd) {
            var dataList = new List<CrudeFinancialCurrencyData>();

            string sql = @" select financial_currency_id, financial_currency_type_rcd, financial_currency_against_financial_currency_type_rcd, user_id, date_time, valid_from_date_time, valid_until_date_time, amount, equals_amount, decimal_count, financial_currency_type_code, financial_currency_type_name
                            from [financial_currency]
                            where financial_currency_type_rcd = @financial_currency_type_rcd
                              
                            order by financial_currency_type_name";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@financial_currency_type_rcd", SqlDbType.NVarChar).Value = financialCurrencyTypeRcd.Replace("'","''");

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeFinancialCurrencyData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch by Foreign key into new List of class instances
        public static List<CrudeFinancialCurrencyData> FetchByFinancialCurrencyAgainstFinancialCurrencyTypeRcd(string financialCurrencyAgainstFinancialCurrencyTypeRcd) {
            var dataList = new List<CrudeFinancialCurrencyData>();

            string sql = @" select financial_currency_id, financial_currency_type_rcd, financial_currency_against_financial_currency_type_rcd, user_id, date_time, valid_from_date_time, valid_until_date_time, amount, equals_amount, decimal_count, financial_currency_type_code, financial_currency_type_name
                            from [financial_currency]
                            where financial_currency_against_financial_currency_type_rcd = @financial_currency_against_financial_currency_type_rcd
                              
                            order by financial_currency_type_name";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@financial_currency_against_financial_currency_type_rcd", SqlDbType.NVarChar).Value = financialCurrencyAgainstFinancialCurrencyTypeRcd.Replace("'","''");

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeFinancialCurrencyData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch by Picker Member into new class instance
        public void FetchByFinancialCurrencyTypeName(string financialCurrencyTypeName) {
            string sql = @" select top 1 financial_currency_id, financial_currency_type_rcd, financial_currency_against_financial_currency_type_rcd, user_id, date_time, valid_from_date_time, valid_until_date_time, amount, equals_amount, decimal_count, financial_currency_type_code, financial_currency_type_name
                            from [financial_currency]
                            where financial_currency_type_name like '%' + @financialCurrencyTypeName + '%'
                              ";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.Add("@financialCurrencyTypeName",SqlDbType.NVarChar).Value = financialCurrencyTypeName;

                IDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                    Populate(reader);
            }
        }
        
        // fetch all from table into new List of class instances
        public static List<CrudeFinancialCurrencyData> FetchAll() {
            var dataList = new List<CrudeFinancialCurrencyData>();

            string sql = @" select financial_currency_id, financial_currency_type_rcd, financial_currency_against_financial_currency_type_rcd, user_id, date_time, valid_from_date_time, valid_until_date_time, amount, equals_amount, decimal_count, financial_currency_type_code, financial_currency_type_name
                            from [financial_currency]
                            order by financial_currency_type_name";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeFinancialCurrencyData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch all from table into new List of class instances, with a limit on number of returned rows and order by columns
        public static List<CrudeFinancialCurrencyData> FetchAllWithLimit(int limit) {
            var dataList = new List<CrudeFinancialCurrencyData>();

            string sql = @" select top " + limit.ToString() + @" financial_currency_id, financial_currency_type_rcd, financial_currency_against_financial_currency_type_rcd, user_id, date_time, valid_from_date_time, valid_until_date_time, amount, equals_amount, decimal_count, financial_currency_type_code, financial_currency_type_name
                            from [financial_currency]
                            order by financial_currency_type_name";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeFinancialCurrencyData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // fetch all from table into new List of class instances, only populating specific columns , with a limit on number of returned rows and order by columns starting at a specific row
        public static List<CrudeFinancialCurrencyData> FetchAllWithLimitAndOffset(int limit, int offset) {
            var dataList = new List<CrudeFinancialCurrencyData>();

            string sql = @" select financial_currency_id, financial_currency_type_rcd, financial_currency_against_financial_currency_type_rcd, user_id, date_time, valid_from_date_time, valid_until_date_time, amount, equals_amount, decimal_count, financial_currency_type_code, financial_currency_type_name
                            from [financial_currency]
                            order by financial_currency_type_name";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    int count = 0;

                    while (reader.Read()) {
                        if ((count >= offset) && (count <= offset + limit)) {
                            var data = new CrudeFinancialCurrencyData();
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
            string sql = @" select count(*) as count from [financial_currency]";

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
        public static List<CrudeFinancialCurrencyData> FetchWithFilter(System.Guid financialCurrencyId, string financialCurrencyTypeRcd, string financialCurrencyAgainstFinancialCurrencyTypeRcd, System.Guid userId, System.DateTime dateTime, System.DateTime validFromDateTime, System.DateTime validUntilDateTime, decimal amount, decimal equalsAmount, int decimalCount, string financialCurrencyTypeCode, string financialCurrencyTypeName) {
            var dataList = new List<CrudeFinancialCurrencyData>();

            string sql = @" select financial_currency_id, financial_currency_type_rcd, financial_currency_against_financial_currency_type_rcd, user_id, date_time, valid_from_date_time, valid_until_date_time, amount, equals_amount, decimal_count, financial_currency_type_code, financial_currency_type_name
                            from [financial_currency]
                            where 1 = 1";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    if (financialCurrencyId != Guid.Empty) {
                        sql += "  and financial_currency_id = @financial_currency_id";
                        command.Parameters.Add("@financial_currency_id", SqlDbType.UniqueIdentifier).Value = financialCurrencyId;
                    }
                    if (!string.IsNullOrEmpty(financialCurrencyTypeRcd)) {
                        sql += "  and financial_currency_type_rcd like '%' + @financial_currency_type_rcd + '%'";
                        command.Parameters.Add("@financial_currency_type_rcd", SqlDbType.NVarChar).Value = financialCurrencyTypeRcd.Replace("'","''");
                    }
                    if (!string.IsNullOrEmpty(financialCurrencyAgainstFinancialCurrencyTypeRcd)) {
                        sql += "  and financial_currency_against_financial_currency_type_rcd like '%' + @financial_currency_against_financial_currency_type_rcd + '%'";
                        command.Parameters.Add("@financial_currency_against_financial_currency_type_rcd", SqlDbType.NVarChar).Value = financialCurrencyAgainstFinancialCurrencyTypeRcd.Replace("'","''");
                    }
                    if (userId != Guid.Empty) {
                        sql += "  and user_id = @user_id";
                        command.Parameters.Add("@user_id", SqlDbType.UniqueIdentifier).Value = userId;
                    }
                    if (dateTime != DateTime.MinValue) {
                        sql += "  and date_time = @date_time";
                        command.Parameters.Add("@date_time", SqlDbType.DateTime).Value = dateTime;
                    }
                    if (validFromDateTime != DateTime.MinValue) {
                        sql += "  and valid_from_date_time = @valid_from_date_time";
                        command.Parameters.Add("@valid_from_date_time", SqlDbType.DateTime).Value = validFromDateTime;
                    }
                    if (validUntilDateTime != DateTime.MinValue) {
                        sql += "  and valid_until_date_time = @valid_until_date_time";
                        command.Parameters.Add("@valid_until_date_time", SqlDbType.DateTime).Value = validUntilDateTime;
                    }
                    if (amount != 0) {
                        sql += "  and amount = @amount";
                        command.Parameters.Add("@amount", SqlDbType.Decimal).Value = amount;
                    }
                    if (equalsAmount != 0) {
                        sql += "  and equals_amount = @equals_amount";
                        command.Parameters.Add("@equals_amount", SqlDbType.Decimal).Value = equalsAmount;
                    }
                    if (decimalCount != 0) {
                        sql += "  and decimal_count = @decimal_count";
                        command.Parameters.Add("@decimal_count", SqlDbType.Int).Value = decimalCount;
                    }
                    if (!string.IsNullOrEmpty(financialCurrencyTypeCode)) {
                        sql += "  and financial_currency_type_code like '%' + @financial_currency_type_code + '%'";
                        command.Parameters.Add("@financial_currency_type_code", SqlDbType.NVarChar).Value = financialCurrencyTypeCode.Replace("'","''");
                    }
                    if (!string.IsNullOrEmpty(financialCurrencyTypeName)) {
                        sql += "  and financial_currency_type_name like '%' + @financial_currency_type_name + '%'";
                        command.Parameters.Add("@financial_currency_type_name", SqlDbType.NVarChar).Value = financialCurrencyTypeName.Replace("'","''");
                    }
                    sql += " order by financial_currency_type_name";

                    command.CommandText = sql;

                    IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult);

                    while (reader.Read()) {
                        var data = new CrudeFinancialCurrencyData();
                        data.Populate(reader);
                        dataList.Add(data);
                    }
                }
                
                return dataList;
            }
        }
        
        // read all columns out and populate object members
        public void Populate(IDataReader reader) {
            if (reader["financial_currency_id"] != System.DBNull.Value) FinancialCurrencyId = (System.Guid) reader["financial_currency_id"];
            if (reader["financial_currency_type_rcd"] != System.DBNull.Value) FinancialCurrencyTypeRcd = (System.String) reader["financial_currency_type_rcd"];
            if (reader["financial_currency_against_financial_currency_type_rcd"] != System.DBNull.Value) FinancialCurrencyAgainstFinancialCurrencyTypeRcd = (System.String) reader["financial_currency_against_financial_currency_type_rcd"];
            if (reader["user_id"] != System.DBNull.Value) UserId = (System.Guid) reader["user_id"];
            if (reader["date_time"] != System.DBNull.Value) DateTime = (System.DateTime) reader["date_time"];
            if (reader["valid_from_date_time"] != System.DBNull.Value) ValidFromDateTime = (System.DateTime) reader["valid_from_date_time"];
            if (reader["valid_until_date_time"] != System.DBNull.Value) ValidUntilDateTime = (System.DateTime) reader["valid_until_date_time"];
            if (reader["amount"] != System.DBNull.Value) Amount = (System.Decimal) reader["amount"];
            if (reader["equals_amount"] != System.DBNull.Value) EqualsAmount = (System.Decimal) reader["equals_amount"];
            if (reader["decimal_count"] != System.DBNull.Value) DecimalCount = (System.Int32) reader["decimal_count"];
            if (reader["financial_currency_type_code"] != System.DBNull.Value) FinancialCurrencyTypeCode = (System.String) reader["financial_currency_type_code"];
            if (reader["financial_currency_type_name"] != System.DBNull.Value) FinancialCurrencyTypeName = (System.String) reader["financial_currency_type_name"];
        }
        
        // insert all object members as a new row in table
        public void Insert() {

            if (FinancialCurrencyId == Guid.Empty)
                FinancialCurrencyId = Guid.NewGuid();

            string sql = "insert into [financial_currency] (financial_currency_id, financial_currency_type_rcd, financial_currency_against_financial_currency_type_rcd, user_id, date_time, valid_from_date_time, valid_until_date_time, amount, equals_amount, decimal_count, financial_currency_type_code, financial_currency_type_name)";
            sql += "            values (@financial_currency_id, @financial_currency_type_rcd, @financial_currency_against_financial_currency_type_rcd, @user_id, @date_time, @valid_from_date_time, @valid_until_date_time, @amount, @equals_amount, @decimal_count, @financial_currency_type_code, @financial_currency_type_name)";

            // open standard connection
            using (var connection = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                connection.Open();

                using (var command = new SqlCommand(sql, connection)) {
                    command.Parameters.Add("@financial_currency_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)FinancialCurrencyId;
                    command.Parameters.Add("@financial_currency_type_rcd",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyTypeRcd;
                    command.Parameters.Add("@financial_currency_against_financial_currency_type_rcd",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyAgainstFinancialCurrencyTypeRcd;
                    command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                    command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                    command.Parameters.Add("@valid_from_date_time",SqlDbType.DateTime).Value = (System.DateTime)ValidFromDateTime;
                    command.Parameters.Add("@valid_until_date_time",SqlDbType.DateTime).Value = (ValidUntilDateTime == DateTime.MinValue ? (object)DBNull.Value : (System.DateTime)ValidUntilDateTime);
                    command.Parameters.Add("@amount",SqlDbType.Decimal).Value = (System.Decimal)Amount;
                    command.Parameters.Add("@equals_amount",SqlDbType.Decimal).Value = (System.Decimal)EqualsAmount;
                    command.Parameters.Add("@decimal_count",SqlDbType.Int).Value = (System.Int32)DecimalCount;
                    command.Parameters.Add("@financial_currency_type_code",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyTypeCode;
                    command.Parameters.Add("@financial_currency_type_name",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyTypeName;
                    command.ExecuteNonQuery();
                }
            }
        }
        
        // insert all object members as a new row in table, in a transaction
        // the transaction and or connection state is not changed in any way other than what SqlClient does to it.
        // it is the callers responsibility to commit or rollback the transaction
        public void Insert(SqlConnection connection, SqlTransaction transaction) {

            if (FinancialCurrencyId == Guid.Empty)
                FinancialCurrencyId = Guid.NewGuid();

            string sql = "insert into [financial_currency] (financial_currency_id, financial_currency_type_rcd, financial_currency_against_financial_currency_type_rcd, user_id, date_time, valid_from_date_time, valid_until_date_time, amount, equals_amount, decimal_count, financial_currency_type_code, financial_currency_type_name)";
            sql += "            values (@financial_currency_id, @financial_currency_type_rcd, @financial_currency_against_financial_currency_type_rcd, @user_id, @date_time, @valid_from_date_time, @valid_until_date_time, @amount, @equals_amount, @decimal_count, @financial_currency_type_code, @financial_currency_type_name)";

            // use passed in connection
            // transaction scope etc is determined by caller
            // there are no result from this action, SqlClient will raise an exception in case
            using (SqlCommand command = new SqlCommand(sql, connection, transaction)) {
                command.Parameters.Add("@financial_currency_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)FinancialCurrencyId;
                command.Parameters.Add("@financial_currency_type_rcd",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyTypeRcd;
                command.Parameters.Add("@financial_currency_against_financial_currency_type_rcd",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyAgainstFinancialCurrencyTypeRcd;
                command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                command.Parameters.Add("@valid_from_date_time",SqlDbType.DateTime).Value = (System.DateTime)ValidFromDateTime;
                command.Parameters.Add("@valid_until_date_time",SqlDbType.DateTime).Value = (ValidUntilDateTime == DateTime.MinValue ? (object)DBNull.Value : (System.DateTime)ValidUntilDateTime);
                command.Parameters.Add("@amount",SqlDbType.Decimal).Value = (System.Decimal)Amount;
                command.Parameters.Add("@equals_amount",SqlDbType.Decimal).Value = (System.Decimal)EqualsAmount;
                command.Parameters.Add("@decimal_count",SqlDbType.Int).Value = (System.Int32)DecimalCount;
                command.Parameters.Add("@financial_currency_type_code",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyTypeCode;
                command.Parameters.Add("@financial_currency_type_name",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyTypeName;
                command.ExecuteNonQuery();
            }
        }
        
        // update all object members on a row in table based on primary key
        public void Update() {
            string sql = @" update [financial_currency] set
                 financial_currency_id = @financial_currency_id
                ,financial_currency_type_rcd = @financial_currency_type_rcd
                ,financial_currency_against_financial_currency_type_rcd = @financial_currency_against_financial_currency_type_rcd
                ,user_id = @user_id
                ,date_time = @date_time
                ,valid_from_date_time = @valid_from_date_time
                ,valid_until_date_time = @valid_until_date_time
                ,amount = @amount
                ,equals_amount = @equals_amount
                ,decimal_count = @decimal_count
                ,financial_currency_type_code = @financial_currency_type_code
                ,financial_currency_type_name = @financial_currency_type_name
            where financial_currency_id = @financial_currency_id";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {

                    command.Parameters.Add("@financial_currency_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)FinancialCurrencyId;
                    command.Parameters.Add("@financial_currency_type_rcd",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyTypeRcd;
                    command.Parameters.Add("@financial_currency_against_financial_currency_type_rcd",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyAgainstFinancialCurrencyTypeRcd;
                    command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                    command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                    command.Parameters.Add("@valid_from_date_time",SqlDbType.DateTime).Value = (System.DateTime)ValidFromDateTime;
                    command.Parameters.Add("@valid_until_date_time",SqlDbType.DateTime).Value = (ValidUntilDateTime == DateTime.MinValue ? (object)DBNull.Value : (System.DateTime)ValidUntilDateTime);
                    command.Parameters.Add("@amount",SqlDbType.Decimal).Value = (System.Decimal)Amount;
                    command.Parameters.Add("@equals_amount",SqlDbType.Decimal).Value = (System.Decimal)EqualsAmount;
                    command.Parameters.Add("@decimal_count",SqlDbType.Int).Value = (System.Int32)DecimalCount;
                    command.Parameters.Add("@financial_currency_type_code",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyTypeCode;
                    command.Parameters.Add("@financial_currency_type_name",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyTypeName;
                    command.ExecuteNonQuery();
                }
            }
        }
        
        // update all object members on a row in table based on primary key, on a transaction
        public void Update(SqlConnection connection, SqlTransaction transaction) {
            string sql = @" update [financial_currency] set
                 financial_currency_id = @financial_currency_id
                ,financial_currency_type_rcd = @financial_currency_type_rcd
                ,financial_currency_against_financial_currency_type_rcd = @financial_currency_against_financial_currency_type_rcd
                ,user_id = @user_id
                ,date_time = @date_time
                ,valid_from_date_time = @valid_from_date_time
                ,valid_until_date_time = @valid_until_date_time
                ,amount = @amount
                ,equals_amount = @equals_amount
                ,decimal_count = @decimal_count
                ,financial_currency_type_code = @financial_currency_type_code
                ,financial_currency_type_name = @financial_currency_type_name
            where financial_currency_id = @financial_currency_id";

            // open standard connection
            using (SqlCommand command = new SqlCommand(sql, connection, transaction)) {
                command.Parameters.Add("@financial_currency_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)FinancialCurrencyId;
                command.Parameters.Add("@financial_currency_type_rcd",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyTypeRcd;
                command.Parameters.Add("@financial_currency_against_financial_currency_type_rcd",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyAgainstFinancialCurrencyTypeRcd;
                command.Parameters.Add("@user_id",SqlDbType.UniqueIdentifier).Value = (System.Guid)UserId;
                command.Parameters.Add("@date_time",SqlDbType.DateTime).Value = (System.DateTime)DateTime;
                command.Parameters.Add("@valid_from_date_time",SqlDbType.DateTime).Value = (System.DateTime)ValidFromDateTime;
                command.Parameters.Add("@valid_until_date_time",SqlDbType.DateTime).Value = (ValidUntilDateTime == DateTime.MinValue ? (object)DBNull.Value : (System.DateTime)ValidUntilDateTime);
                command.Parameters.Add("@amount",SqlDbType.Decimal).Value = (System.Decimal)Amount;
                command.Parameters.Add("@equals_amount",SqlDbType.Decimal).Value = (System.Decimal)EqualsAmount;
                command.Parameters.Add("@decimal_count",SqlDbType.Int).Value = (System.Int32)DecimalCount;
                command.Parameters.Add("@financial_currency_type_code",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyTypeCode;
                command.Parameters.Add("@financial_currency_type_name",SqlDbType.NVarChar).Value = (System.String)FinancialCurrencyTypeName;
                command.ExecuteNonQuery();
            }
        }
        
        // delete a row in table based on primary key
        public static void Delete(System.Guid financialCurrencyId) {
            string sql = @" delete [financial_currency] 
                where financial_currency_id = @financial_currency_id";

            // open standard connection
            using (var conn = new SqlConnection(ConfigurationManager.AppSettings["Conn"])) {
                conn.Open();

                using (var command = new SqlCommand(sql, conn)) {
                    command.Parameters.Add("@financial_currency_id",SqlDbType.UniqueIdentifier).Value = financialCurrencyId;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
