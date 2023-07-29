using Autofac;
using Business.DependencyResolvers.Autofac;
using Business.Services.Abstract;

namespace TestUI;

class Program
{
    public static IContainer Container { get; set; }
    static void Main(string[] args)
    {
        Console.WriteLine("== Welcome to the ECommerceProject Demo ===");

        var builder = new ContainerBuilder();
        builder.RegisterModule(new AutofacBusinessModule());
        Container = builder.Build();

        var productService = Container.Resolve<IProductService>();
        Console.WriteLine(productService.GetProducts());
        Console.ReadKey();
    }
}

