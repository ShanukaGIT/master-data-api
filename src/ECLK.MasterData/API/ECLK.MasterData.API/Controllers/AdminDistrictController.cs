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
    public class AdminDistrictController : BaseController<AdminDistrictController>
    {
		#region Constructor

		public AdminDistrictController (IDBRepository repository) : base(repository)
		{

		}

		#endregion
		
		
		// GET: api/AdminDistrict
		/// <summary>
		/// List all admin districts
		/// </summary>
		/// <remarks>
		/// - Provides a full table information of the admin districts .
		/// - Empty list if not available.
		/// </remarks>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public object Get()
        {
			return this._repository.Get("spADis");
        }

        // GET: api/AdminDistrict/5
		/// <summary>
		/// Get admin district for the given district ID
		/// </summary>
		/// <remarks>
		/// - Provides a full table information of the admin districts .
		/// - Empty list if not available.
		/// </remarks>
		/// <param name="districtID">District ID to list Admin Districts By</param>
		/// <returns></returns>
        [HttpGet("{districtID}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public object Get(int districtID)
        {
           return this._repository.Get("spADisByID", districtID);
        }
    }
}