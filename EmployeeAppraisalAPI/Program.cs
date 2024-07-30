using EmployeeAppraisalAPI.Configuration;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using static EmployeeAppraisalDataAccess.Dependencies;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
IServiceCollection services = builder.Services;

services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod();
                    });
});



ConfigureService(configuration, services);
services.AddBusinessServicesAPI();

services.AddControllers();
services.AddControllersWithViews();


services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddAuthentication();
services.AddAuthorization();


services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo() { Title = "Performance Appraisal API" });
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Example value = Bearer: token",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);

app.Run();
