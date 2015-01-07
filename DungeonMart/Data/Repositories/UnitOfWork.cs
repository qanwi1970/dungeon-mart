using System;
using System.Data.Entity.Validation;
using System.Text;
using DungeonMart.Data.DAL;

namespace DungeonMart.Data.Repositories
{
    public interface IUnitOfWork
    {
        Guid SessionID { get; }
        IDungeonMartContext DbContext { get; }
        int Commit();
    }
    
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDungeonMartContext _context;

        public UnitOfWork(IDungeonMartContext context)
        {
            this.SessionID = Guid.NewGuid();
            _context = context;
        }

        public Guid SessionID { get; private set; }

        public IDungeonMartContext DbContext
        {
            get { return _context; }
        }

        public int Commit()
        {
            try
            {
                return _context.SaveChanges();
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
        }
    }
}
