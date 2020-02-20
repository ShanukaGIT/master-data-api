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
    public class DesignationController : BaseController<DesignationController>
    {
		#region Constructor

		public DesignationController (IDBRepository repository) : base(repository)
		{
		}

		#endregion

        // GET: api/Designation
        [HttpGet]
        public object Get()
        {
            return this._repository.Get("spDesigationList");
        }
    }
}