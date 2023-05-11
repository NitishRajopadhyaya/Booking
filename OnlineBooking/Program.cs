using Core.Data;
using Core.Enum;
using Core.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.AreaViewLocationFormats.Clear();
    options.AreaViewLocationFormats.Add("/Identity/{2}/Views/{1}/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Admin/{2}/Views/{1}/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
});


builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationFormats.Add("/{0}.cshtml");
    });

IDatabaseFactory implementationInstance = DatabaseFactories.SetFactory(Dialect.SQLServer, builder.Configuration);
builder.Services.AddSingleton(implementationInstance);
builder.Services.RegisterCoreServices();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(30);
});
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
var app = builder.Build();



// Configure the HTTP request pipeline.
//HttpContextExtension.Configure(app.Services.GetRequiredService<IHttpContextAccessor>());

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapAreaControllerRoute(
    name: "Area",
    areaName: "Identity",
    pattern: "Identity/{controller=Account}/{action=Login}/{id?}");
app.MapAreaControllerRoute(
    name: "Area",
    areaName: "Admin",
    pattern: "Admin/{controller=Account}/{action=Login}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
