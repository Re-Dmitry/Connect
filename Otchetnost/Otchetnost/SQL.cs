using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otchetnost
{
    class SQL : ISQL, IDisposable
    {
        public static readonly string CONNECTION_STRING =
                                        "Server=195.2.71.142;" +
                                        "User=guli;" +
                                        "database=otchentnost;" +
                                        "port=3306;" +
                                        "password=gg;";

        public static List<T> Select<T, U>(string sql, U param, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sql, param).ToList();

                return rows;
            }
        }

        public static void Insert<T>(string sql, T param, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                connection.Execute(sql, param);
            }
        }

        public async Task<List<T>> SelectAsync<T, U>(string sql, U param, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                var rows = await connection.QueryAsync<T>(sql, param);

                return rows.ToList();
            }
        }

        public Task InsertAsync<T>(string sql, T param, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                return connection.ExecuteAsync(sql, param);
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Disposable");
        }
    }
}
