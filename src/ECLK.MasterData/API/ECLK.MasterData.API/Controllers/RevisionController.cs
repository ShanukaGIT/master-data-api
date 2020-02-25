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
    public class RevisionController : BaseController<RevisionController>
    {
		#region Constructor

		public RevisionController (IDBRepository repository) : base(repository)
		{
		}

		#endregion

        // GET: api/Revision
		/// <summary>
		/// List all  revisions
		/// </summary>
		/// <remarks>
		/// - Provides a full table information of the revisions.
		/// - Empty list if not available.
		/// </remarks>
		/// <returns></returns>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public object Get()
        {
            return this._repository.Get("spRev");
        }
    }
}