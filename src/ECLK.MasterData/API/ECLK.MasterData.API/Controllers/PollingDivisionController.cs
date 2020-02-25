using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ECLK.MasterData.API.Infrastructure.Base;
using ECLK.MasterData.API.Infrastructure.Repositeries.MasterDB;
using Microsoft.AspNetCore.Mvc;

namespace ECLK.MasterData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollingDivisionController : BaseController<PollingDivisionController>
    {
		#region Constructor

		public PollingDivisionController (IDBRepository repository) : base(repository)
		{

		}

		#endregion

        /// <summary>
		/// List all polling divisions by election district ID
		/// </summary>
		/// <remarks>
		/// - Provides a full table information of the polling divisions election district ID.
		/// - Empty list if not available.
		/// </remarks>
		/// <param name="electionDistrictID">Election district ID</param>
		/// <returns></returns>
		[HttpGet("{electionDistrictID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public object Get(int electionDistrictID)
        {
			List<KeyValuePair<string, object>> parameters =  new List<KeyValuePair<string, object>>();

			parameters.Add(new KeyValuePair<string, object>("@edisid", electionDistrictID));

           return this._repository.Get("spPollingDivisionByEDisVR", parameters);
        }
    }
}