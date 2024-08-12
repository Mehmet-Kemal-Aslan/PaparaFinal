using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PaparaFinalData.Context;
using PaparaProjectBase.Models.Notification;
using PaparaProjectBase.Session;
using PaparaProjectBase.Token;
using PaparaProjectBusiness.Features.Commands.Users.CreateUser;
using PaparaProjectBusiness.Mapper;
using PaparaProjectBusiness.Token;
using PaparaProjectBussiness.Notifications;
using PaparaProjectBussiness.RabbitMQ;
using PaparaProjectData.UnitOfWork;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionStringMsSql = builder.Configuration.GetConnectionString("MsSqlConnection");
builder.Services.AddDbContext<PaparaProjectDbContext>(options =>
options.UseSqlServer(connectionStringMsSql));

builder.Services.AddHangfire(config => config.UseSqlServerStorage(builder.Configuration.GetConnectionString("MsSqlConnection")));
builder.Services.AddHangfireServer();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperConfig());
});
builder.Services.AddSingleton(config.CreateMapper());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateUserCommandHandler>());

builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("RabbitMQ"));
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
builder.Services.AddSingleton<IEmailQueuePublisher, EmailQueuePublisher>();
builder.Services.AddSingleton<IEmailQueueConsumer, EmailQueueConsumer>();
builder.Services.AddSingleton<INotificationService, NotificationService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ISessionContext, SessionContext>();
var jwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();
builder.Services.AddSingleton(jwtConfig);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtConfig.Issuer,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.Secret)),
        ValidAudience = jwtConfig.Audience,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromMinutes(2)
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Para Api Management", Version = "v1.0" });
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Para Management for IT Company",
        Description = "Enter JWT Bearer token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, new string[] { } }
    });
});

var app = builder.Build();

app.UseHangfireDashboard();
RecurringJob.AddOrUpdate<IEmailQueueConsumer>("email_queue", job => job.Start(), "*/5 * * * * *");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
