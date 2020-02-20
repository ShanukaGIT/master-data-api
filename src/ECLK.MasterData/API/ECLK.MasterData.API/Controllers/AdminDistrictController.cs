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
    public class AdminDistrictsController : BaseController<AdminDistrictsController>
    {
		#region Constructor

		public AdminDistrictsController (IDBRepository repository) : base(repository)
		{

		}

		#endregion

		// GET: api/AdminDistricts
		[HttpGet]
        public object Get()
        {
			return this._repository.Get("spADis");
        }

        // GET: api/AdminDistricts/5
        [HttpGet("{id}", Name = "Get")]
        public object Get(int id)
        {
           return this._repository.Get("spADis", id);
        }
    }
}