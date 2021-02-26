using Dominio.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IProvinceService
    {
        public LoginRSDto Login(LoginRQDto loginRq);
        public Task<ProvinceRSDto> ProvinceDate(string provinceName);
    }
}
