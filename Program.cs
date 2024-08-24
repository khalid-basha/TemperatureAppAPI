using TemperatureApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<TemperatureContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TemperatureApi v1");
        c.RoutePrefix = string.Empty;  // This makes Swagger UI available at the app's root URL
    });
}

// app.UseStaticFiles();  
app.UseRouting();      // Add this line to enable routing
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();  // This maps attribute-routed controllers

app.MapControllerRoute(  // This maps convention-based controllers
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

