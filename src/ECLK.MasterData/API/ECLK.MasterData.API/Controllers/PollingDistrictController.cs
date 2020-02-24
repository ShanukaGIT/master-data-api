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
		/// Get polling division for the given ID
		/// </summary>
		/// <param name="adminDistrictID"></param>
		/// <returns></returns>
        [HttpGet]
		public object Get(int pollingDivisionID, int revisionID)
        {
			List<KeyValuePair<string, object>> parameters =  new List<KeyValuePair<string, object>>();

			parameters.Add(new KeyValuePair<string, object>("@pdivid", pollingDivisionID));
			parameters.Add(new KeyValuePair<string, object>("@revid", revisionID));

           return this._repository.Get("spPollingDistrictByRevIDPDivID", parameters);
        }

    }
}