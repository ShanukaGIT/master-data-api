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
    public class PollingDistrictController : BaseController<PollingDivisionController>
    {
		#region Constructor

		public PollingDistrictController (IDBRepository repository) : base(repository)
		{

		}

		#endregion
		
		/// <summary>
		/// Get polling districts for the given revision ID and polling division ID
		/// </summary>
		/// <remarks>
		/// - Provides a full table information of the polling districts by revision ID and division ID.
		/// - Empty list if not available.
		/// </remarks>
		/// <param name="revisionID">Revision ID for polling district</param>
		/// <param name="pollingDivisionID">Polling Division ID ID for polling district</param>
		/// <returns></returns>
        [HttpGet("{revisionID}/{pollingDivisionID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public object Get(int revisionID, int pollingDivisionID)
        {
			List<KeyValuePair<string, object>> parameters =  new List<KeyValuePair<string, object>>();

			parameters.Add(new KeyValuePair<string, object>("@pdivid", pollingDivisionID));
			parameters.Add(new KeyValuePair<string, object>("@revid", revisionID));

           return this._repository.Get("spPollingDistrictByRevIDPDivID", parameters);
        }

    }
}