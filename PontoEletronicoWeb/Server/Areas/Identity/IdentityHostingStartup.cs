using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PontoEletronicoWeb.Server.Data;
using PontoEletronicoWeb.Server.Models;

[assembly: HostingStartup(typeof(PontoEletronicoWeb.Server.Areas.Identity.IdentityHostingStartup))]
namespace PontoEletronicoWeb.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}