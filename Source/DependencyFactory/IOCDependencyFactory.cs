using Entities;
using Microsoft.Practices.Unity;
using ServiceInterfaces;
using Services;

namespace IOCFactory
{
    public static class IOCDependencyFactory
    {
        private static IUnityContainer _container;

        /// <summary>
        /// Public reference to the unity container which will 
        /// allow the ability to register instrances or take 
        /// other actions on the container.
        /// </summary>
        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
            private set
            {
                _container = value;
            }
        }

        /// <summary>
        /// Static constructor for DependencyFactory which will 
        /// initialize the unity container.
        /// </summary>
        static IOCDependencyFactory()
        {
            var container = new UnityContainer();

            //if you have multiple class constructor you need to define the constructor(new injectionconstructor) you need for creating instance of the type you are going to register.

            InjectionFactory factory = new InjectionFactory(x => x.Resolve<AccountingService>());
            container.RegisterType<AccountingService>(new ContainerControlledLifetimeManager());
            container.RegisterType<IService>("Service", factory);
            container.RegisterType<IAccountingService>("AccountingService", factory);

            container.RegisterType<IService, BillingService>("BillingService", new ContainerControlledLifetimeManager());
            container.RegisterType<IService, PaymentService>("PaymentService", new ContainerControlledLifetimeManager());
            container.RegisterType<IAccounting, Accounting>("Accounting", new ContainerControlledLifetimeManager());
            
            _container = container;
        }

        /// <summary>
        /// Resolves the type parameter T to an instance of the appropriate type.
        /// </summary>
        /// <typeparam name="T">Type of object to return</typeparam>
        public static T Resolve<T>()
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }

        public static T Resolve<T>(string registrationTypeName)
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T), registrationTypeName))
            {
                ret = Container.Resolve<T>(registrationTypeName);
            }

            return ret;
        }

    }
}
