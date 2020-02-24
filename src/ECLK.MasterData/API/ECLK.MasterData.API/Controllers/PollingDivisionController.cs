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
		
		
		// GET: api/PollingDivision
		/// <summary>
		/// List polling division
		/// </summary>
		/// <returns></returns>
		[HttpGet]
        public object Get()
        {
			return this._repository.Get("spPDivByADisID");
        }

        // GET: api/PollingDivision/5
		/// <summary>
		/// Get polling division for the given ID
		/// </summary>
		/// <param name="adminDistrictID"></param>
		/// <returns></returns>
        [HttpGet("{adminDistrictID}", Name = "GetPollingDivisionByAdminDistrictID")]
		public object Get(int adminDistrictID)
        {
			List<KeyValuePair<string, object>> parameters =  new List<KeyValuePair<string, object>>();

			parameters.Add(new KeyValuePair<string, object>("@edisid", adminDistrictID));

           return this._repository.Get("spPollingDivisionByEDisVR", parameters);
        }
    }
}