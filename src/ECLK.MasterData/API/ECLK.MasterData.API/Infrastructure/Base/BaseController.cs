using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECLK.MasterData.API.Infrastructure.Repositeries.MasterDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECLK.MasterData.API.Infrastructure.Base
{
	public class BaseController<T> : ControllerBase
	{
		#region  Members

		protected readonly IDBRepository							_repository;
		protected readonly ILogger<T>								_logger;

		#endregion

		#region Constructor
		
		/// <summary>
		/// Loads controller with the db repository 
		/// </summary>
		/// <param name="repository">DB Repository instance</param>
		public BaseController (IDBRepository repository)
		{
			this._repository = repository;
		}
		
		/// <summary>
		/// Loads controller with the db repository and the logger
		/// </summary>
		/// <param name="repository">DB Repository instance</param>
		/// <param name="logger">Logger instance</param>
		public BaseController (IDBRepository repository, ILogger<T> logger)
		{
			this._repository = repository;
			this._logger = logger;
		}

		#endregion
	}
}
