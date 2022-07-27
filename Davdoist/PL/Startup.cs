using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PL
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddAutoMapper(typeof(BLL.AppMappingProfile));

            services.AddTransient<BLL.Interfaces.IBlTaskServicer, BLL.BL>();
            services.AddTransient<BLL.Interfaces.IBlFolderServicer, BLL.BL>();
        }

        public void Configure(IApplicationBuilder app)
        {         

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
