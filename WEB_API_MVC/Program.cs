using System.Net.Http.Headers;
using WEB_API_MVC.Services;
using WEB_API_MVC.Services.IServices;

namespace WEB_API_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAutoMapper(typeof(MappingConfig));
          
            builder.Services.AddHttpClient("MagicAPI", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ServiceUrls:VillaAPI"]);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            });
            builder.Services.AddScoped<IVillaService, VillaService>();
            builder.Services.AddScoped<IVillaNumberService, VillaNumberService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
             
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
