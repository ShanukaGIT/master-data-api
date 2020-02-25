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
		/// <remarks>
		/// - Provides a full table information of the election districts.
		/// - Empty list if not available.
		/// </remarks>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public object Get()
        {
			return this._repository.Get("spElectionDistrictAll");
        }

        // GET: api/ElectionDistrict/5
		/// <summary>
		/// Get election district for the given admin district ID
		/// </summary>
		/// <remarks>
		/// - Provides a full table information of the election districts by admin district ID.
		/// - Empty list if not available.
		/// </remarks>
		/// <param name="adminDistrictID"></param>
		/// <returns></returns>
        [HttpGet("{adminDistrictID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public object Get(int adminDistrictID)
        {
			List<KeyValuePair<string, object>> parameters =  new List<KeyValuePair<string, object>>();

			parameters.Add(new KeyValuePair<string, object>("@adisid", adminDistrictID));

           return this._repository.Get("spEDisByADisID", parameters);
        }
    }
}