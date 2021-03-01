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
    class SQL : IDisposable
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

        public static DataTable getTableInfo(string query)
        {
            using (MySqlConnection connection = new MySqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                MySqlCommand queryExecute = new MySqlCommand(query, connection);
                DataTable ass = new DataTable();
                ass.Load(queryExecute.ExecuteReader());
                connection.Close();
                return ass;
            }

        }


        public void Dispose()
        {
            Console.WriteLine("Disposable");
        }
    }
}
