using DotNetCore.AspNetCore;
using Bliss.API.Configurations;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
    builder => builder
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());
});

builder.Services.AddHealthChecks();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddResponseCompression();

builder.Services.AddControllers().AddJsonOptions().AddAuthorizationPolicy();

builder.Services.AddDatabaseConfiguration();
builder.Services.AddDependencyInjectionConfiguration();
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseHsts();
}

app.UseException();
app.UseResponseCompression();
app.UseRouting();
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.MapHealthChecks("/healthz");
//app.UseAuthentication();
//app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
