using Microsoft.EntityFrameworkCore;
using Vaajak.Infrastructure.IdentityConfig;
using Vaajak.Persistence.Contexts;
using Vaajak.Application.Extensions;
using Vaajak.Infrastructure.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var connectionString = builder.Configuration.GetConnectionString("SqlServer");
//builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddIdentityService(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.UseAuthorization();

app.Run();
