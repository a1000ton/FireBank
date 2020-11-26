[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(FireBank.WebApi.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(FireBank.WebApi.App_Start.NinjectWebCommon), "Stop")]

namespace FireBank.WebApi.App_Start
{
    using System;
    using System.Web;
    using FireBank.Domain.Interfaces.Repository;
    using FireBank.Domain.Interfaces.Service;
    using FireBank.Infra.Data.Repositories;
    using FireBank.Service.Services;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IBaseRepository<>)).To(typeof(BaseRepository<>));
            kernel.Bind<IBusinessAccountRepository>().To<BusinessAccountRepository>();
            kernel.Bind<IStudentAccountRepository>().To<StudentAccountRepository>();
            kernel.Bind<IGiroAccountRepository>().To<GiroAccountRepository>();
            kernel.Bind<ITransactionRepository>().To<TransactionRepository>();

            kernel.Bind(typeof(IBaseService<>)).To(typeof(BaseService<>));
            //kernel.Bind<IAccountService>().To<AccountService>();
            kernel.Bind<ITransactionService>().To<TransactionService>();
        }
    }
}