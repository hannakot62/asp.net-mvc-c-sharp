using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pic5.Data
{
    public class MySqlDataAccess
    {
        private readonly string _connectionString;

        public MySqlDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<T> LoadData<T>(string sql, object parameters = null)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        public void SaveData<T>(string sql, T parameters)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(sql, parameters);
            }
        }

        public void UpdateData<T>(string sql, T parameters)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(sql, parameters);
            }
        }

        public void DeleteData<T>(string sql, T parameters)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(sql, parameters);
            }
        }


    }

}
