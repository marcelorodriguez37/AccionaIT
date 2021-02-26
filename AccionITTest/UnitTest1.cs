using Application;
using Dominio.DTOs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.IO;

namespace AccionITTest
{
    public class Tests
    {
        public ILogger<ProvinceService> _logger;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Login()
        {
            var ProviderService = new ProvinceService(_logger);
            LoginRQDto login = new LoginRQDto()
            {
                User = "AccionaIT",
                Password = "admin"
            };
            var res = ProviderService.Login(login);
            Assert.IsNotNull(res,"No se pudo loguear el usuario");
        }
    }
}