using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.QLTS.Core;
using Demo.QLTS.Core.Entities;
using Demo.QLTS.Core.Interfaces.Repository;
using Demo.QLTS.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.QLTS.Api.Api
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseDemoController<TEntity> : ControllerBase
    {
        #region Field
        IBaseService<TEntity> _baseService;
        IBaseRepository<TEntity> _baseRepository;
        private ServiceResult service = new ServiceResult();
        #endregion

        #region Contructor
        public BaseDemoController(IBaseService<TEntity> baseService, IBaseRepository<TEntity> baseRepository)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
        }
        #endregion

        #region Method
        
        #endregion
    }
}
