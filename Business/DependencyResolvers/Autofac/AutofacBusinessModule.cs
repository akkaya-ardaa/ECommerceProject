using System;
using Autofac;
using Business.Services.Abstract;
using Business.Services.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Mongo;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<MediaManager>().As<IMediaService>().InstancePerLifetimeScope();

            builder.RegisterType<MCategoryDal>().As<ICategoryDal>().InstancePerLifetimeScope();
            builder.RegisterType<MMediaDal>().As<IMediaDal>().InstancePerLifetimeScope();
            builder.RegisterType<MProductDal>().As<IProductDal>().InstancePerLifetimeScope();
        }
    }
}

