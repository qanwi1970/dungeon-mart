using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;
using DungeonMart.Data.DAL;
using DungeonMart.Data.Repositories;
using NUnit.Framework;

namespace DungeonMart.Data.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected UnitOfWork UnitOfWork;
        protected DropCreateDatabaseAlways<DungeonMartContext> Initializer;
        protected DungeonMartContext Context;

        [SetUp]
        public void CommonSetup()
        {
            try
            {
                if (Initializer == null) Assert.Fail("Remember to set the Initializer in your ctor.");
                Database.SetInitializer(Initializer);
                var dbName = "DungeonMartTest-" + Guid.NewGuid();
                var connString = "data source=.;initial catalog=" + dbName +
                                 ";integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
                Context = new DungeonMartContext(connString);
                Context.Database.Initialize(true);
                UnitOfWork = new UnitOfWork(Context);
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb, ex);
                // Add the original exception as the innerException
            }
            catch (DataException ex)
            {
                var innerValidationException = ex.InnerException as DbEntityValidationException;
                if (innerValidationException != null)
                {
                    var sb = new StringBuilder();

                    foreach (var failure in innerValidationException.EntityValidationErrors)
                    {
                        sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                        foreach (var error in failure.ValidationErrors)
                        {
                            sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                            sb.AppendLine();
                        }
                    }

                    throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb, ex);
                    // Add the original exception as the innerException
                }
            }
        }

        [TearDown]
        public void CommonTeardown()
        {
            Context.Database.Delete();
        }
    }
}
