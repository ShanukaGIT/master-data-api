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

        // GET: api/PollingDivision/5
		/// <summary>
		/// Get polling division for the given ID
		/// </summary>
		/// <param name="adminDistrictID"></param>
		/// <returns></returns>
        [HttpGet]
		public object Get(int pollingDistrictID, int revisionID)
        {
			List<KeyValuePair<string, object>> parameters =  new List<KeyValuePair<string, object>>();

			parameters.Add(new KeyValuePair<string, object>("@revid", revisionID));
			parameters.Add(new KeyValuePair<string, object>("@pdid", pollingDistrictID));

           return this._repository.Get("spPSByPDID", parameters);
        }
    }
}