using Serilog;
using notificacions_service;
using notificacions_service.Models.Configs;
using notificacions_service.Handlers;
using notificacions_service.Interfaces;
using notificacions_service.Interfaces.Services;
using notificacions_service.Services;
using notificacions_service.Dispatchers;
using notificacions_service.Consumers;
using System;
using notificacions_service.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using notificacions_service.Repositories;

IHost host = Host.CreateDefaultBuilder(args)
    .UseSerilog((context, services, loggerConfiguration) => loggerConfiguration
        .ReadFrom.Configuration(context.Configuration) // Lee la configuración de Serilog de appsettings.json
        .Enrich.FromLogContext())
    .ConfigureServices((context,services) =>
    {
        services.AddHostedService<Worker>();
        services.AddScoped<IKafkaConsumerFactory, KafkaConsumerFactory>();
        services.Configure<KafkaConsumerConfig>(context.Configuration.GetSection("KafkaConsumerConfig"));
        services.Configure<EmailConfig>(context.Configuration.GetSection("EmailConfig"));
        services.Configure<EmailTemplatesConfig>(context.Configuration.GetSection("EmailTemplatesConfig"));
        services.AddDbContext<MockContext>(options => options.UseSqlServer(context.Configuration.GetConnectionString("MockContext")));
        services.AddScoped<KafkaConsumer>();
        services.AddScoped<MessagesDispatcher>();
        services.AddScoped<NotificationRepository>();
        services.AddScoped<EmailRepository>();
        services.AddScoped<UserRepository>();
        services.AddScoped<EmailHandler>();
        services.AddScoped<IPushService, PushService>();
        services.AddScoped<PushHandler>();
        services.AddScoped<SmtpEmailService>();
    })
    .Build();

host.Run();

