using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System;

namespace Server.Models.Utils.DAL.Common
{

	internal static class DatabaseOperations
	{
		// connectionString = @"Data Source=.\SQLEXPRESS2008;Initial Catalog=QualityControlDb04;Integrated Security=True;MultipleActiveResultSets=True", "System.Data.SqlClient"
		public static IEnumerable<dynamic> ExecuteQuery1(string queryText, Dialect dialect, string connectionString)
		{
			return ExecuteQuery<dynamic>(queryText, dialect, connectionString);
		}

		public static IEnumerable<T> ExecuteQuery<T>(string queryText, Dialect dialect, string connectionString)
		{
			var rows = Enumerable.Empty<T>();
			switch (dialect)
			{
				case Dialect.SQL2012:
				case Dialect.SQL2014:
					using (var sqlConnection = new SqlConnection(connectionString))
					{
						sqlConnection.Open();
						rows = sqlConnection.Query<T>(queryText);
						sqlConnection.Close();
					}
					break;
				case Dialect.MYSQL:
					using (var sqlConnection = new MySqlConnection(connectionString))
					{
						sqlConnection.Open();
						rows = sqlConnection.Query<T>(queryText);
						sqlConnection.Close();
					}
					break;
				default:
					break;
			}

			return rows;
		}

		public static IEnumerable<Dto> ExecuteQuery(string queryText, Dialect dialect, string connectionString)
		{
			var dtos = new List<Dto>();
			switch (dialect)
			{
				case Dialect.SQL2012:
				case Dialect.SQL2014:
					// Not developed yet.
					throw new NotImplementedException();
				case Dialect.MYSQL:
					using (var sqlConnection = new MySqlConnection(connectionString))
					{
						MySqlDataReader rdr = null;
						try
						{
							sqlConnection.Open();
							var cmd = new MySqlCommand(queryText, sqlConnection);
							rdr = cmd.ExecuteReader();
							while (rdr.Read())
							{
								//var row = Enumerable.Range(0, rdr.FieldCount).ToDictionary(rdr.GetName, rdr.GetValue);
								//var row = Enumerable.Range(0, rdr.FieldCount).ToDictionary(i => rdr.GetName(i), i => rdr.GetValue(i));
								var dto = new Dto();
								for (int i = 0; i < rdr.FieldCount; i++)
								{
									dto.Add(rdr.GetName(i), rdr.GetValue(i));
								}
								dtos.Add(dto);
							}
						}
						finally
						{
							if (rdr != null)
							{
								rdr.Close();
							}

							if (sqlConnection != null)
							{
								sqlConnection.Close();
							}
						}
					}
					break;
				default:
					break;
			}

			return dtos;
		}


		public static int CountQuery(string queryText, Dialect dialect, string connectionString)
		{
			var countRows = default(long);
			switch (dialect)
			{
				case Dialect.SQL2012:
				case Dialect.SQL2014:
					using (var sqlConnection = new SqlConnection(connectionString))
					{
						sqlConnection.Open();
						var rows = sqlConnection.Query(queryText).ToList();
						countRows = rows[0].count;
						sqlConnection.Close();
					}
					break;
				case Dialect.MYSQL:
					using (var sqlConnection = new MySqlConnection(connectionString))
					{
						sqlConnection.Open();
						var rows = sqlConnection.Query(queryText).ToList();
						countRows = rows[0].count;
						sqlConnection.Close();
					}
					break;
				default:
					break;
			}
			return (int)countRows;
		}

		public static dynamic CudQuery(string queryText, Dialect dialect, string connectionString)
		{
			dynamic result = null;
			switch (dialect)
			{
				case Dialect.SQL2012:
				case Dialect.SQL2014:
					using (var sqlConnection = new SqlConnection(connectionString))
					{
						sqlConnection.Open();
						result = sqlConnection.Query(queryText).First();
						sqlConnection.Close();
					}
					break;
				case Dialect.MYSQL:
					using (var sqlConnection = new MySqlConnection(connectionString))
					{
						sqlConnection.Open();
						result = sqlConnection.Query(queryText).First();
						sqlConnection.Close();
					}
					break;
				default:
					break;
			}
			return result;
		}
	}

}