using SistemaIndustrial.DependencyInjection;
using SistemaIndustrial.Repositories.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin();
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//string pgsqlStr = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<SisIndContext>((DbContextOptionsBuilder options) => options.UseNpgsql(pgsqlStr));
builder.Services.UseSisIndDataContext(builder.Configuration);
builder.Services.ServicesInjection(disableHanFire: false);
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<SisIndContext>();
    context.Database.Migrate();
}

app.Run();
