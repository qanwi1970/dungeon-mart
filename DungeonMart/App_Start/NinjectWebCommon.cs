using System;
using System.Reflection;
using System.Web;
using DungeonMart;
using DungeonMart.Data.DAL;
using DungeonMart.Data.Interfaces;
using DungeonMart.Data.Repositories;
using DungeonMart.Services;
using DungeonMart.Services.Interfaces;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace DungeonMart
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
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
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Bind<IFeatService>().To<FeatService>();
            kernel.Bind<IFeatRepository>().To<FeatRepository>();
            kernel.Bind<IMonsterService>().To<MonsterService>();
            kernel.Bind<IMonsterRepository>().To<MonsterRepository>();
            kernel.Bind<ICharacterClassRepository>().To<CharacterClassRepository>();
            kernel.Bind<ICharacterClassService>().To<CharacterClassService>();
            kernel.Bind<IClassProgressionRepository>().To<ClassProgressionRepository>();
            kernel.Bind<IClassLevelService>().To<ClassLevelService>();
            kernel.Bind<IDomainRepository>().To<DomainRepository>();
            kernel.Bind<IDomainService>().To<DomainService>();
            kernel.Bind<IEquipmentRepository>().To<EquipmentRepository>();
            kernel.Bind<IEquipmentService>().To<EquipmentService>();
            kernel.Bind<IItemService>().To<ItemService>();
            kernel.Bind<IItemRepository>().To<ItemRepository>();
            kernel.Bind<IPowerService>().To<PowerService>();
            kernel.Bind<IPowerRepository>().To<PowerRepository>();
            kernel.Bind<ISkillRepository>().To<SkillRepository>();
            kernel.Bind<ISkillService>().To<SkillService>();
            kernel.Bind<ISpellRepository>().To<SpellRepository>();
            kernel.Bind<ISpellService>().To<SpellService>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InThreadScope();
            kernel.Bind<IDungeonMartContext>().To<DungeonMartContext>();
            // doesn't seem to work
            //kernel.Bind(x =>
            //{
            //    x.FromThisAssembly() // Scans currently assembly
            //        .SelectAllClasses() // Retrieve all non-abstract classes
            //        .BindDefaultInterface(); // Binds the default interface to them;
            //});
        }
    }
}
