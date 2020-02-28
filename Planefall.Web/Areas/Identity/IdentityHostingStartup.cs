using Microsoft.AspNetCore.Hosting;
using Planefall.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace Planefall.Areas.Identity
{
    using Microsoft.AspNetCore.Hosting;

    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}