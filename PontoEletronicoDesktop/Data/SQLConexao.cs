using PontoEletronicoDesktop.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PontoEletronicoDesktop.Data
{

    public class SQLConexao
    {
        #region SQLite
        private static SQLiteConnection SQLiteConnection;

        private static string ConnectionString;

        private static SQLiteConnection DbConnection()
        {
            var stringConnection = AppDomain.CurrentDomain.BaseDirectory;

            ConnectionString = string.Concat("Data Source =", stringConnection, "app.db;Version=3;");

            SQLiteConnection = new SQLiteConnection(ConnectionString);

            SQLiteConnection.Open();

            return SQLiteConnection;
        }

        public static async Task<bool> CriarBancoSQLiteAsync()
        {
            var stringConnection = AppDomain.CurrentDomain.BaseDirectory;

            ConnectionString = string.Concat(stringConnection, "app.db");

            if (!File.Exists(ConnectionString))
            {
                SQLiteConnection.CreateFile(@"app.db");

                return await CriarTabelaSQliteAsync();
            }

            return true;
        }

        public static async Task<bool> CriarTabelaSQliteAsync()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE [Cliente] ( " +
                                      "             [Id] int NOT NULL, " +
                                      "             [Nome] nvarchar(500) NULL, " +
                                      "             [Cep] nvarchar(500) NULL, " +
                                      "             [Logadouro] nvarchar(500) NULL, " +
                                      "             [Numero] nvarchar(500) NULL, " +
                                      "             [Bairro] nvarchar(500) NULL, " +
                                      "             [Cidade] nvarchar(500) NULL, " +
                                      "             [Pais] nvarchar(500) NULL, " +
                                      "             [Status] bit NOT NULL );";


                    var result = await cmd.ExecuteNonQueryAsync();

                    return Equals(result, 0) ? true : false;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region CRUD

        public static async Task<Cliente> ClientesAtivo()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    var result = new Cliente();

                    cmd.CommandText = "SELECT Id, Nome, Cep, Logadouro, Numero, Bairro, Cidade, Pais, Status FROM Cliente";

                    var reader = await cmd.ExecuteReaderAsync();

                    reader.Read();

                    if (reader.HasRows)
                    {
                        result.Id = reader.GetInt32(0);
                        result.Nome = reader.GetString(1);
                        result.Cep = reader.GetString(2);
                        result.Logadouro = reader.GetString(3);
                        result.Numero = reader.GetString(4);
                        result.Bairro = reader.GetString(5);
                        result.Cidade = reader.GetString(6);
                        result.Pais = reader.GetString(7);
                        result.Status = reader.GetBoolean(8);
                    }

                    return result;
                }
            }
            catch (Exception er)
            {
                var teste = er.Message;
                return null;
            }
        }

        public static Cliente ClientesAll()
        {
            //try
            //{
            //    using (var cmd = DbConnection().CreateCommand())
            //    {
            //        cmd.CommandText = "SELECT * FROM Cliente";

            //        da = new SQLiteDataAdapter(cmd.CommandText, DbConnection());

            //        var teste = new Cliente();

            //        var reader = cmd.ExecuteReader();

            //        if (reader.HasRows)
            //        {
            //            var Codigo = reader.GetInt32(0);
            //            var Nome = reader.GetString(1);
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            return null;
        }

        public static int ClienteAdd(Cliente cliente)
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    var ResultDelete = ClienteDelete(cliente.Id);

                    cmd.CommandText = "INSERT INTO Cliente " +
                                      " (Id, Nome, Cep, Logadouro, Numero, Bairro, Cidade, Pais, Status) " +
                                      "VALUES" +
                                      " (@Id, @Nome, @Cep, @Logadouro, @Numero, @Bairro, @Cidade, @Pais, @Status)";

                    cmd.Parameters.AddWithValue("@Id", cliente.Id);
                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@Cep", cliente.Cep);
                    cmd.Parameters.AddWithValue("@Logadouro", cliente.Logadouro);
                    cmd.Parameters.AddWithValue("@Numero", cliente.Numero);
                    cmd.Parameters.AddWithValue("@Bairro", cliente.Bairro);
                    cmd.Parameters.AddWithValue("@Cidade", cliente.Cidade);
                    cmd.Parameters.AddWithValue("@Pais", cliente.Pais);
                    cmd.Parameters.AddWithValue("@Status", cliente.Status);

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static int ClienteDelete(int Id)
        {
            try
            {
                using (var cmd = new SQLiteCommand(DbConnection()))
                {
                    cmd.CommandText = "DELETE FROM Cliente ";

                    //cmd.CommandText = "DELETE FROM Cliente Where Id=@Id";

                    //cmd.Parameters.AddWithValue("@Id", Id);

                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        #endregion
    }
}
