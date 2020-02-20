using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ECLK.MasterData.API.Infrastructure.Repositeries.MasterDB
{
	/// <summary>
	/// DB Repository 
	/// </summary>
	public class DBRepository : IDBRepository
	{
		#region Members

		private readonly IConfiguration _config;

		#endregion

		#region Constructor

		public DBRepository(IConfiguration config)
		{
			_config = config;
		}

		#endregion

		#region Override

		/// <summary>
		/// Get the list of the passed model as a object for the provided SP
		/// </summary>
		/// <param name="storedProcedureName"> Stored procedure to be invoked</param>
		/// <returns>Json object of the passed sp data</returns>
		public object Get(string storedProcedureName)
		{
			List<object>			result			= new List<object>();

			object					objectContent	= this.GetDataTable(storedProcedureName);

			return this.GetDataTable(storedProcedureName);
		}

		/// <summary>
		/// Gets a single object of the passed model for the provided SP 
		/// </summary>
		/// <param name="storedProcedureName">Stored procedure to be invoked</param>
		/// <param name="ID">DB ID record</param>
		/// <returns>Json object of the passed sp data</returns>
		public object Get(string storedProcedureName, int ID)
		{
			List<SqlParameter>		parameters		= new List<SqlParameter>();

			parameters.Add(new SqlParameter("@id", ID));

			return this.GetDataTable(storedProcedureName, parameters.ToArray());
		}

		#endregion

		#region Utility

		/// <summary>
		/// Load the data to a data table for the given sp without parameters as a object
		/// </summary>
		/// <param name="storedProcedureName">Stored procedure for the adapter</param>
		/// <returns>Data table as json object</returns>
		private object GetDataTable (string storedProcedureName)
		{
			return GetDataTable(storedProcedureName, null);
		}

		/// <summary>
		/// Load the data to a data table for the given sp and parameters as a object
		/// </summary>
		/// <param name="storedProcedureName">Stored procedure for the adapter</param>
		/// <param name="storedProcedureParameters">Parameters for the stored procedure</param>
		/// <returns>Data table as json object</returns>
		private object GetDataTable (string storedProcedureName, SqlParameter[] storedProcedureParameters)
		{
			DataTable result = new DataTable();

			// get the adapter
			SqlDataAdapter da = this.GetAdapter(storedProcedureName, storedProcedureParameters);
			
			// load data to the table
			da.Fill(result);

			// return as a object serializing the data table 
			return JsonConvert.SerializeObject(result, Formatting.Indented);
		} 

		/// <summary>
		/// Creates a sql adapter with the connection for the passed stored procedure and parameters 
		/// </summary>
		/// <param name="storedProcedureName">Stored procedure for the adapter</param>
		/// <param name="storedProcedureParameters">Parameters for the stored procedure</param>
		/// <returns>SQL Adapter</returns>
		private SqlDataAdapter GetAdapter(string storedProcedureName, SqlParameter[] storedProcedureParameters)
		{

			// Get the connection
			SqlConnection _connection					= new SqlConnection(this._config.GetConnectionString("ConnectionString"));
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

		#endregion
	}
}
