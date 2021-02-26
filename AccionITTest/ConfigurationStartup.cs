using AccionaIT;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AccionITTest
{
    public class ConfigurationStartup: Startup
    {
        public ConfigurationStartup(IConfiguration configuration) : base(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true).Build())
        {
        }

        public void ConfigureServices1(IServiceCollection services)
        {
        }
    }
}
