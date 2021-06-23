using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(RalphCMS.Areas.Identity.IdentityHostingStartup))]
namespace RalphCMS.Areas.Identity
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