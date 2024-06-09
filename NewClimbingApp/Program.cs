using Microsoft.EntityFrameworkCore;
using NewClimbingApp.DataAccess;
using NewClimbingApp.ApplicationServices.API.Domain.Responses;
using NewClimbingApp.ApplicationServices.API.Mappings;
using NewClimbingApp.DataAccess.CQRS;
using FluentValidation.AspNetCore;
using FluentValidation;
using NewClimbingApp.ApplicationServices.API.Validators;
using Microsoft.AspNetCore.Mvc;
using NLog.Web;
using NLog;
using NewClimbingApp.DataAccess.Entities;
using Microsoft.AspNetCore.Authentication;
using Pharmacy.Authentication;
using Microsoft.AspNet.Identity;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
});
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssemblyContaining(typeof(AddUserRequestValidator));
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services.AddTransient<ICommandExecutor, CommandExecutor>();
builder.Services.AddTransient<IQueryExecutor, QueryExecutor>();
builder.Services.AddAutoMapper(typeof(RoutesProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ResponseBase<>).Assembly));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddDbContext<NewClimbingAppContext>(
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NewClimbingAppDataBaseConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();


app.MapControllers();

app.Run();
