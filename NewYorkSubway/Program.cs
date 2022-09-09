global using FastEndpoints;
using FastEndpoints.Swagger;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MediatR;
using NewYorkSubway.Application;
using NewYorkSubway.Infrastructure;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NewYorkSubway.Common;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);
var cnn = builder.Configuration.GetConnectionString("RdsConnection");
var appcnn = builder.Configuration.GetConnectionString("AppConfig");
builder.Host
    .ConfigureAppConfiguration(builder =>
    {
        builder.AddAzureAppConfiguration(appcnn, false);
    })
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(cb =>
    {
        cb.RegisterModule(new ApplicationModule());
        cb.RegisterModule(new InfrastructureModule(builder.Configuration));
    });

builder.Services.AddFastEndpoints();
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.Authority = "https://cognito-idp.us-east-1.amazonaws.com/us-east-1_8pXaKoy2L";
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false
    };
});
builder.Services.AddSwaggerDoc();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "api";
});
//app.UseHttpsRedirection();
app.UseOpenApi();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUi3(s => s.ConfigureDefaults());
}


app.Run();