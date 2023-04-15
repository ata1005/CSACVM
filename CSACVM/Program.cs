using CSACVM.AccesoDatos.Data;
using CSACVM.AccesoDatos.Repositorio.IRepositorio;
using CSACVM.AccesoDatos.Repositorio;
using Microsoft.EntityFrameworkCore;
using CSACVM.Exceptions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using Serilog;
using CSACVM.AccesoDatos;
using Rotativa.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options2 => {
        options2.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options2.SlidingExpiration = true;
        options2.LoginPath = new PathString("/Login/Login"); //relative path requests will be redirected to when a user attempts to access a resource but has not been authenticated.
        options2.LogoutPath = new PathString("/Login/Logout"); //relative path requests will be redirected to when a user attempts to access a resource but does not pass any authorization policies for that resource.
    });

builder.Host.UseSerilog((hostContext, services, configuration) => configuration.ReadFrom.Configuration(hostContext.Configuration));
builder.Services.AddSession();
//builder.Services.AddDbContext<CSACVMContext>(options => options.UseSqlServer(
//   "server=(localdb)\\MSSQLLocalDB; Database=CSA_CVM;Trusted_Connection=True;MultipleActiveResultSets=True"));

builder.Services.AddDbContext<CSACVMContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddDbContext<CSACVMContext>(options => options.UseSqlServer(
//    builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IViewRenderService, ViewRenderService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else {
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
//app.UseSessionMiddleware();
app.UseExceptionHandlerMiddleware();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");
//https://localhost:7179http://localhost:5179
IWebHostEnvironment env = app.Environment;
RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)env);
app.Run();
