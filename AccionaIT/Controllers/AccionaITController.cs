using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Dominio;
using Dominio.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccionaIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccionaITController : ControllerBase
    {
        readonly IProvinceService _providerService;
        public AccionaITController(IProvinceService providerService)
        {
            _providerService = providerService;
        }

        [HttpPost("[action]")]
        public LoginRSDto Login(LoginRQDto loginDate) {
            return _providerService.Login(loginDate);
        }
        
        [HttpGet("[action]")]
        public Task<ProvinceRSDto> ProvinceDate(string provinceName) {
            return _providerService.ProvinceDate(provinceName);
        }
    }
}
