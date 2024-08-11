using AutoMapper;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using PaparaFinalData.Context;
using PaparaProjectBusiness.Features.Commands.Users.CreateUser;
using PaparaProjectBusiness.Mapper;
using PaparaProjectBussiness.Notifications;
using PaparaProjectBussiness.RabbitMQ;
using PaparaProjectData.UnitOfWork;
using PaparaProjectSchema.Notification;
using System.Reflection;

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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
