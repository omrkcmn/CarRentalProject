using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<CarManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<ColorManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<BrandManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<IRentalDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IRentalDal>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IRentalDal>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IRentalDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
