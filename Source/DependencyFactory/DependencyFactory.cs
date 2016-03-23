using DataAccessLayer;
using Entities;
using Logger;
using Microsoft.Practices.Unity;
using ServiceInterfaces;

namespace IOCFactory
{
    public static class DependencyFactory
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
        static DependencyFactory()
        {
            var container = new UnityContainer();

            //if you have multiple class constructor you need to define the constructor(new injectionconstructor) you need for creating instance of the type you are going to register.

            //registering class with multiple Interface implementation 
            //InjectionFactory factory = new InjectionFactory(x => x.Resolve<classname>());
            //container.RegisterType<classname>(new ContainerControlledLifetimeManager());
            //container.RegisterType<Interface1>("registrationname1", factory);
            //container.RegisterType<Interface2>("registrationname2", factory);

            //transaction logger
            container.RegisterType<ITransactionLogger, TransactionLogger>("TransactionLogger", new ContainerControlledLifetimeManager());

            //entities
            container.RegisterType<IEmployeeInformation, EmployeeInformation>("EmployeeInformation", new ContainerControlledLifetimeManager());
            container.RegisterType<IEmployeeAddress, EmployeeAddress>("EmployeeAddress", new ContainerControlledLifetimeManager());
            container.RegisterType<IEmployementHistory, EmployementHistory>("EmployementHistory", new ContainerControlledLifetimeManager());
            container.RegisterType<IEducationalBackground, EducationalBackground>("EducationalBackground", new ContainerControlledLifetimeManager());
            container.RegisterType<ITestTable, TestTable>("TestTable", new ContainerControlledLifetimeManager());

            //DAL
            container.RegisterType<IDALSessionFactory, DALSessionFactory>("DALSessionFactory", new ContainerControlledLifetimeManager());
            var sessionFactory = container.Resolve<IDALSessionFactory>("DALSessionFactory"); //inject this to HibernateDAL constructor
            container.RegisterType<IHibernateDAL, HibernateDAL>("HibernateDAL",
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(sessionFactory)
                );

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
