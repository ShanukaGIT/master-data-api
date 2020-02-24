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

		[HttpGet]
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