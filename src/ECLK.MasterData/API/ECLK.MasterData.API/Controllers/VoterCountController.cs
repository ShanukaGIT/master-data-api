using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECLK.MasterData.API.Infrastructure.Base;
using ECLK.MasterData.API.Infrastructure.Repositeries.MasterDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECLK.MasterData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoterCountController : BaseController<VoterCountController>
    {
		#region Constructor

		public VoterCountController (IDBRepository repository) : base(repository)
		{

		}

		#endregion

		// GET: api/VoterCount/2/16/2/2/3
		/// <summary>
		/// Get voter count grouped by polling stations for the given revision ID, election district ID, polling division ID, polling district ID, polling station ID
		/// </summary>
		/// <remarks>
		/// - Provides a full table information of the polling stations voter count .
		/// - Empty list if not available.
		/// </remarks>
		/// <param name="revisionID">Revision ID</param>
		/// <param name="electionDistrictID">Election district ID, pass -1 for all</param>
		/// <param name="pollingDivisionID">Polling division ID, pass -1 for all</param>
		/// <param name="pollingDistrictID">Polling district ID, pass -1 for all</param>
		/// <param name="pollingStationID">Polling station ID, pass -1 for all</param>
		/// <returns></returns>
		[HttpGet("{revisionID}/{electionDistrictID}/{pollingDivisionID}/{pollingDistrictID}/{pollingStationID}")]		
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public object Get(int revisionID, 
							int electionDistrictID, 
							int pollingDivisionID, 
							int pollingDistrictID, 
							int pollingStationID)
        {
			List<KeyValuePair<string, object>> parameters =  new List<KeyValuePair<string, object>>();

			parameters.Add(new KeyValuePair<string, object>("@rev", revisionID));
			parameters.Add(new KeyValuePair<string, object>("@ecid", electionDistrictID));
			parameters.Add(new KeyValuePair<string, object>("@pdivid", pollingDivisionID));
			parameters.Add(new KeyValuePair<string, object>("@pdid", pollingDistrictID));
			parameters.Add(new KeyValuePair<string, object>("@psid", pollingStationID));
				

           return this._repository.Get("spVoterCountByPSIDALL", parameters);
        }

    }
}