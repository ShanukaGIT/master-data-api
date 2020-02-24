using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECLK.MasterData.API.Infrastructure.Base;
using ECLK.MasterData.API.Infrastructure.Repositeries.MasterDB;
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
		/// List admin districts
		/// </summary>
		/// <returns></returns>
		[HttpGet]
        public object Get()
        {
			return this._repository.Get("spADis");
        }

        // GET: api/AdminDistrict/5
		/// <summary>
		/// Get admin district for the given ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
        [HttpGet("{districtID}", Name = "GetAdminDistrictByDistrictID")]
		public object Get(int districtID)
        {
           return this._repository.Get("spADisByID", districtID);
        }
    }
}