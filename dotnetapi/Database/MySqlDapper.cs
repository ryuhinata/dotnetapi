using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;

namespace dotnetapi.DataBase
{
    public class MySqlDapper
    {
        private readonly string _ServerName;
        public MySqlDapper()
        {
            _ServerName = "Server=localhost;Port=3306;Database=accountdb;Uid=renaldy.widjaja39;Pwd=renaldy150";
        }
        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            var sqlConnection = new MySqlConnection(_ServerName);
            using (var conn = sqlConnection)
            {
                return conn.Query<T>(sql, param);
            }
        }
        public void Execute(string sql, object param = null)
        {
            var sqlConnection = new MySqlConnection(_ServerName);
            using (var conn = sqlConnection)
            {
                conn.Execute(sql, param);
            }
        }
        public int ExecuteReturnId(string sql, object param = null)
        {
            var sqlConnection = new MySqlConnection(_ServerName);
            using (var conn = sqlConnection)
            {
                return conn.Query<int>(sql, param).Single();
            }
        }
    }
}