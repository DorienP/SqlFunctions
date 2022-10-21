using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SqlFunctions.Context;
using SqlFunctions.Interface;
using SqlFunctions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: FunctionsStartup(typeof(SqlFunctions.Startup))]
namespace SqlFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ClientContext>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();
        }
    }
}
