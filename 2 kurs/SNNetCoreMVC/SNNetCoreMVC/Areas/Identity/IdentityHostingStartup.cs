using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SNNetCoreMVC.Areas.Identity.Data;
using SNNetCoreMVC.Data;

[assembly: HostingStartup(typeof(SNNetCoreMVC.Areas.Identity.IdentityHostingStartup))]
namespace SNNetCoreMVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SNNetCoreMVCContext>(options =>
                    //options.UseSqlServer(
                    options.UseNpgsql(
                        context.Configuration.GetConnectionString("SNNetCoreMVCContextConnection")));

                services.AddDefaultIdentity<SNNetCoreMVCUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<SNNetCoreMVCContext>();
            });
        }
    }
}