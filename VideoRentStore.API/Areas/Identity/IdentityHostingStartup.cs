using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoRentStore.API.Areas.Identity.Data;
using VideoRentStore.API.Models;

[assembly: HostingStartup(typeof(VideoRentStore.API.Areas.Identity.IdentityHostingStartup))]
namespace VideoRentStore.API.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>()
                    .AddEntityFrameworkStores<IdentityContext>();
            });
        }
    }
}