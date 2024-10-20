
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Template.Api.Extensions;
using Template.Api.Middleware;
using Template.Command;
using Template.Command.Database;
using Template.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.ConfigureResponseCaching();

/// User, Token
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();

string? connectionString = builder.Configuration.GetConnectionString("TemplateDatabase");
builder.Services.AddDbContext(connectionString!);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplication();


builder.ConfigureSwagger();


builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new DefaultInfrastructureModule(builder.Environment.EnvironmentName == "Development"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapDefaultControllerRoute();


app.UseResponseCaching();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<TokenProcessingMiddleware>();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider
        .GetRequiredService<DataBaseContext>();

    if (app.Environment.IsDevelopment())
    {
        await dbContext.Database.MigrateAsync();
    }
}

app.Run();
