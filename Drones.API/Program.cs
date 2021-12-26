using Drones.Domain.IRepositories;
using Drones.Handler;
using Drones.Persistence;
using Drones.Repository;
using Drones.Repository.Common;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<DronesDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("default")));

builder.Services.Configure<IISOptions>(options =>
{
    options.AutomaticAuthentication = false;
    options.ForwardClientCertificate = false;
    options.ForwardClientCertificate = false;
});

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddScoped<IDronesDbContext, DronesDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IDroneRepository, DroneRepository>();
builder.Services.AddScoped<IDroneLoadRepository, DroneLoadRepository>();

builder.Services.AddScoped<IDroneRegistration, DroneRegistration>();
builder.Services.AddScoped<IDroneLoading, DroneLoading>();
builder.Services.AddScoped<IDroneBattery, DroneBattery>();
builder.Services.AddScoped<IAvailableDrones, AvailableDrones>();
builder.Services.AddScoped<IDroneCheckingLoads, DroneCheckingLoads>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
        c.RoutePrefix = string.Empty;
        c.DisplayRequestDuration();
    });
    app.UseSwagger();
}
else
{
    app.UseHsts();
}

app.UseAuthentication();
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseRouting();

//app.ConfigureCustomExceptionMiddleware();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapControllerRoute("default", "admin/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
});

app.MapControllers();

app.Run();