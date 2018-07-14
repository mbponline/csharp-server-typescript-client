using System;
using System.Collections.Generic;
using WebMatrix.Data;
using WebMatrix.Data.StronglyTyped;

namespace Tools.Modules.Common.Database
{

    internal class DatabaseOperations
    {
        private WebMatrix.Data.Database db;

        public DatabaseOperations(string dialect, string connectionString)
        {
            var provider = "";
            switch (dialect)
            {
                case "MSSQL":
                    provider = "System.Data.SqlClient";
                    break;
                case "MYSQL":
                    provider = "MySql.Data.MySqlClient";
                    break;
                default:
                    throw new ArgumentException("Unknown dialect");
            }
            this.db = WebMatrix.Data.Database.OpenConnectionString(connectionString, provider);
        }

        public IEnumerable<T> Query<T>(string queryText, params object[] args)
        {
            var rows = db.Query<T>(queryText, args);
            return rows;
        }

    }

}