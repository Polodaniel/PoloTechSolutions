using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronicoDesktop.Data
{

    public class SQLConexao
    {
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

        public static void CriarBancoSQLite()
        {
            try
            {
                var stringConnection = AppDomain.CurrentDomain.BaseDirectory;

                ConnectionString = string.Concat(stringConnection, "app.db");

                if (!File.Exists(ConnectionString))
                {
                    SQLiteConnection.CreateFile(@"app.db");
                    CriarTabelaSQlite();
                }
            }
            catch
            {
                throw;
            }
        }

        public static void CriarTabelaSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE [Cliente] ( " +
                                      "             [Id] int NOT NULL, " +
                                      "             [Nome] nvarchar(500) NULL, " +
                                      "             [Endereco] nvarchar(500) NULL, " +
                                      "             [Logadouro] nvarchar(500) NULL, " +
                                      "             [Cidade] nvarchar(500) NULL, " +
                                      "             [Status] bit NOT NULL, " +
                                      "             [DtaAtualizacao] datetime2 NOT NULL, " +
                                      "             [UsuarioId] int NOT NULL, " +
                                      "             CONSTRAINT[PK_Cliente] PRIMARY KEY([Id]));";


                    var result = cmd.ExecuteNonQueryAsync();

                    var teste = result;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
