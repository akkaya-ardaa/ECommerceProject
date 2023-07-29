using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Business.Messaging.Concrete.RabbitMQ;
using Core.Messaging.Abstract;
using Core.Messaging.Concrete.RabbitMQ;
using RabbitMQ.Client;

namespace WebUI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddControllers();
        builder.Host.ConfigureContainer<ContainerBuilder>(c =>
        {
            c.RegisterModule(new AutofacBusinessModule());
        });
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Services.AddSingleton<IMessageSender, RabbitMQMessageSender>();

        builder.Services.AddHostedService<RabbitMQProductConsumer>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.MapControllers();
        app.UseRouting();

        app.UseAuthorization();
        
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}

