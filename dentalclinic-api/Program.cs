using dentalclinic.Common.Model.Domain;
using dentalclinic.Common.Services;
using dentalclinic.Domain.Repository;
using dentalclinic_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 
var dentalDbconnectionString = builder.Configuration.GetConnectionString("DentalDB");
builder.Services.AddDbContext<DentalDBContext>(x => x.UseSqlServer(dentalDbconnectionString));
var identityDbconnectionString = builder.Configuration.GetConnectionString("UserIdentityDB");
//builder.Services.AddDbContext<UserIdentityDbContext>(x => x.UseSqlServer(identityDbconnectionString));
//builder.Services.AddDbContext<DentalContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:DentalDB"]));
// For Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DentalDBContext>()
    .AddDefaultTokenProviders();

builder.Services.AddCors();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDentalDBContext, DentalDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());
app.UseAuthorization();

app.MapControllers();

app.Run();
