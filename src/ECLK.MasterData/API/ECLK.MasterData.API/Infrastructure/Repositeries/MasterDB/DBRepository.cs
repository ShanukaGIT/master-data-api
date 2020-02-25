using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ECLK.MasterData.API.Infrastructure.Data;
using Microsoft.Extensions.Configuration;

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

			return SQLData.GetDataTable(this._config, storedProcedureName, parameters.ToArray());
		}

		/// <summary>
		/// Gets a single object of the passed model for the provided SP 
		/// </summary>
		/// <param name="storedProcedureName">Stored procedure to be invoked</param>
		/// <param name="sqlParameters">SP parameter list as a key value pair</param>
		/// <returns>Json object of the passed sp data</returns>
		public object Get(string storedProcedureName, List<KeyValuePair<string, object>> sqlParameters)
		{
			List<SqlParameter>		parameters		= new List<SqlParameter>();

			foreach (KeyValuePair<string, object> item in sqlParameters)
			{
				parameters.Add(new SqlParameter(item.Key, item.Value));
			}

			return SQLData.GetDataTable(this._config,storedProcedureName, parameters.ToArray());
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
			return SQLData.GetDataTable(this._config,storedProcedureName, null);
		}
		#endregion
	}
}
