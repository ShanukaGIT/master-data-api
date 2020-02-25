using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ECLK.MasterData.API.Infrastructure.Repositeries.MasterDB
{
	/// <summary>
	/// DB Repository interface
	/// </summary>
	public interface IDBRepository
	{
		/// <summary>
		/// Get the list of the passed model as a object for the provided SP
		/// </summary>
		/// <param name="storedProcedureName"> Stored procedure to be invoked</param>
		/// <returns>Json object of the passed sp data</returns>
		object Get(string storedProcedureName);

		/// <summary>
		/// Gets a single object of the passed model for the provided SP 
		/// </summary>
		/// <param name="storedProcedureName">Stored procedure to be invoked</param>
		/// <param name="ID">DB ID record</param>
		/// <returns>Json object of the passed sp data</returns>
		object Get(string storedProcedureName, int ID);

		/// <summary>
		/// Gets a single object of the passed model for the provided SP and its given parameters 
		/// </summary>
		/// <param name="storedProcedureName">Stored procedure to be invoked</param>
		/// <param name="sqlParameters">SQL parameters for the db</param>
		/// <returns>Json object of the passed sp data</returns>
		object Get(string storedProcedureName, List<KeyValuePair<string, object>> sqlParameters);
	}
}
