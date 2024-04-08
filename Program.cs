using Microsoft.EntityFrameworkCore;

namespace SampleDockerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            var connectionString = builder.Configuration["CONNECTION_STRING"];
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(connectionString, o => o.EnableRetryOnFailure());
            });
            var app = builder.Build();

            Task.Delay(15000).Wait();
            using (var serviceScope = app.Services.CreateScope())
            {
                using (var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDBContext>())
                {
                    dbContext.Database.EnsureCreated();                
                }            
            }


                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Error");
                }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
