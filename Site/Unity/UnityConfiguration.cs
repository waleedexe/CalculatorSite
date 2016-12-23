using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Services.Interfaces;
using Services;

namespace Site.Unity
{
    public static class UnityConfiguration
    {
        private static IUnityContainer _container = null;

        public static IUnityContainer GetConfiguredContainer()
        {
            if (_container == null)
            {
                _container = new UnityContainer();
                ConfigureContainer();
            }
            return _container;
        }
        public static UnityResolver GetResolver()
        {
            return new UnityResolver(GetConfiguredContainer());
        }

        private static void ConfigureContainer()
        {
            _container.RegisterType<ICalculator, LoggingCalculator>(new InjectionConstructor(
                new ResolvedParameter<Calculator>(), new ResolvedParameter<ILogWriter>()));
            _container.RegisterType<IDataValidator, NumberValidator>();
            _container.RegisterType<ILogWriter, FileLogger>();
            _container.RegisterType<ILogReader, FileLogger>();
        }

    }
}