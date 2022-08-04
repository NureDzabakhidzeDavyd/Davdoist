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

            services.AddTransient<BLL.Interfaces.IBlTaskServicer, BLL.TaskBL>();
            services.AddTransient<BLL.Interfaces.IBlFolderServicer, BLL.FolderBL>();
        }

        public void Configure(IApplicationBuilder app)
        {         

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Folder}/{action=Index}/{id?}");
            });
        }
    }
}
