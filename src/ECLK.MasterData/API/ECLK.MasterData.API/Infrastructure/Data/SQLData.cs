using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ECLK.MasterData.API.Infrastructure.Data
{
	public class SQLData
	{
		/// <summary>
		/// Converts the data table to the passed  Object modle list
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static List < T > ConvertToList < T > (DataTable dt) {  
			var columnNames = dt.Columns.Cast < DataColumn > ().Select(c => c.ColumnName.ToLower()).ToList();  
			var properties = typeof(T).GetProperties();  
			return dt.AsEnumerable().Select(row => {  
				var objT = Activator.CreateInstance < T > ();  
				foreach(var pro in properties) {  
					if (columnNames.Contains(pro.Name.ToLower())) {  
						try {  
							pro.SetValue(objT, row[pro.Name]);  
						} catch (Exception ex) {}  
					}  
				}  
				return objT;  
			}).ToList();  
		}

		/// <summary>
		/// Gets the data set
		/// </summary>
		/// <param name="_config"></param>
		/// <param name="storedProcedureName"></param>
		/// <param name="storedProcedureParameters"></param>
		/// <returns></returns>
		internal static DataSet GetDataSet (IConfiguration _config, string storedProcedureName, SqlParameter[] storedProcedureParameters)
		{
			DataSet				result	= new DataSet();

			// Get adapter 
			SqlDataAdapter		da		= GetAdapter(_config, storedProcedureName, storedProcedureParameters);
			
			//fill
			da.Fill(result);

			return result;
		} 


		/// <summary>
		/// Load the data to a data table for the given sp and parameters as a object
		/// </summary>
		/// <param name="storedProcedureName">Stored procedure for the adapter</param>
		/// <param name="storedProcedureParameters">Parameters for the stored procedure</param>
		/// <returns>Data table as json object</returns>
		internal static object GetDataTable (IConfiguration _config, string storedProcedureName, SqlParameter[] storedProcedureParameters)
		{
			DataTable result = new DataTable();

			// get the adapter
			SqlDataAdapter da = GetAdapter(_config, storedProcedureName, storedProcedureParameters);
			
			// load data to the table
			da.Fill(result);

			// return as a object serializing the data table 
			return result;
		} 

		/// <summary>
		/// Creates a sql adapter with the connection for the passed stored procedure and parameters 
		/// </summary>
		/// <param name="storedProcedureName">Stored procedure for the adapter</param>
		/// <param name="storedProcedureParameters">Parameters for the stored procedure</param>
		/// <returns>SQL Adapter</returns>
		private static SqlDataAdapter GetAdapter(IConfiguration _config, string storedProcedureName, SqlParameter[] storedProcedureParameters)
		{

			// Get the connection
			SqlConnection _connection					= new SqlConnection(_config.GetConnectionString("ConnectionString"));
			SqlDataAdapter _adapter						= new SqlDataAdapter(storedProcedureName, _connection);
			
			// set up connection settings 
			_adapter.SelectCommand.CommandTimeout		= 360;
			_adapter.SelectCommand.CommandType			= CommandType.StoredProcedure;

			// add parameters
			if(storedProcedureParameters != null)
			{
				for (int i = 0; i < storedProcedureParameters.Length; i++)
				{
					_adapter.SelectCommand.Parameters.Add(storedProcedureParameters[i]);
				}
			}

			return _adapter;
		}
	}
}
