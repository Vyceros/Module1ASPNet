using ITStepRazorApp.Data;
using ITStepRazorApp.Data.Model;
using ITStepRazorApp.Services.Implementations;
using ITStepRazorApp.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITStepRazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            

            builder.Services.AddRazorPages();
            builder.Services.AddScoped<IEmailSender, SendEmail>();
            // Add Authentication
            builder.Services.AddAuthentication()
                .AddBearerToken(IdentityConstants.BearerScheme);

            builder.Services.AddAuthorizationBuilder();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "test";
                options.ClientSecret = "test";
            });

            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
