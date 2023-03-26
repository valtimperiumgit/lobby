using Lobby.Api.GraphQL;
using Lobby.Api.Middleware;
using Lobby.Api.Options;
using Lobby.Data.EFCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

string connectionString = configuration.GetConnectionString("Database");

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddStackExchangeRedisCache(options =>
{
    string connection = builder.Configuration.GetConnectionString("Redis");
    
    options.Configuration = connection;
});

builder.Services.AddGraphQLServer()
    .AddQueryType<Queries>()
    .AddMutationType<Mutations>()
    .AddProjections()
    .AddFiltering();

builder
    .Services
    .Scan(
        selector => selector
            .FromAssemblies(
                Lobby.Data.AssemblyReference.Assembly,
                Lobby.Logic.AssemblyReference.Assembly,
                Lobby.Extensions.AssemblyReference.Assembly)
            .AddClasses(false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGraphQL();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();