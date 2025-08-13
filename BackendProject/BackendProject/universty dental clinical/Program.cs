using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using universty_dental_clinical.Helpers;
using universty_dental_clinical.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); 
builder.Services.AddDbContext<AppDBContext>
    (option=>option.UseSqlServer(builder.Configuration ["ConnectionStrings:ApiConStr1"]));
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
   // options =>
//{
  //  options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    //{
      //  Description = "Standard Authorization header using the bearer scheme(\"bearer {token}\")",
        //In = ParameterLocation.Header,
       // Name = "Authorization",
        //Type = SecuritySchemeType.ApiKey
   // });

   // options.OperationFilter<SecurityRequirementsOperationFilter>();
//} ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();
app.UseAuthentication();


app.MapControllers();

app.Run();
