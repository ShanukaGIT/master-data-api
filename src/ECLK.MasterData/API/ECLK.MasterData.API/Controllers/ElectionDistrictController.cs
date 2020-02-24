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
    public class ElectionDistrictController : BaseController<ElectionDistrictController>
    {
		#region Constructor

		public ElectionDistrictController (IDBRepository repository) : base(repository)
		{

		}

		#endregion
		
		
		// GET: api/ElectionDistrict
		/// <summary>
		/// List election districts
		/// </summary>
		/// <returns></returns>
		[HttpGet]
        public object Get()
        {
			return this._repository.Get("spElectionDistrictAll");
        }

        // GET: api/ElectionDistrict/5
		/// <summary>
		/// Get election district for the given ID
		/// </summary>
		/// <param name="adminDistrictID"></param>
		/// <returns></returns>
        [HttpGet("{adminDistrictID}", Name = "GetElectionDistrctByAdminDistrictID")]
		public object Get(int adminDistrictID)
        {
			List<KeyValuePair<string, object>> parameters =  new List<KeyValuePair<string, object>>();

			parameters.Add(new KeyValuePair<string, object>("@adisid", adminDistrictID));

           return this._repository.Get("spEDisByADisID", parameters);
        }
    }
}