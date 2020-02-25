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
    public class PollingStationController : BaseController<PollingStationController>
    {
		#region Constructor

		public PollingStationController (IDBRepository repository) : base(repository)
		{

		}

		#endregion

        // GET: api/PollingStation/2/20
		/// <summary>
		/// Get polling stations for the given revision ID and polling district ID
		/// </summary>
		/// <remarks>
		/// - Provides a full table information of the polling stations by polling district ID .
		/// - Empty list if not available.
		/// </remarks>
		/// <param name="revisionID">Revision ID</param>
		/// <param name="pollingDistrictID">Polling district ID</param>
		/// <returns></returns>
		[HttpGet("{revisionID}/{pollingDistrictID}")]		
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public object Get(int pollingDistrictID, int revisionID)
        {
			List<KeyValuePair<string, object>> parameters =  new List<KeyValuePair<string, object>>();

			parameters.Add(new KeyValuePair<string, object>("@revid", revisionID));
			parameters.Add(new KeyValuePair<string, object>("@pdid", pollingDistrictID));

           return this._repository.Get("spPSByPDID", parameters);
        }
    }
}