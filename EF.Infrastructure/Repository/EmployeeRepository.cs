using EF.Core.Entities;
using EF.Core.Interfaces;
using EF.Infrastructure.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Infrastructure.Repository
{
    public class EmployeeRepository : GenericRepository<EmployeeEntity>, IEmployeeRepository
    {
        private bool disposed = false;

        public EmployeeRepository(InterviewEntities context)
            : base(context)
        {

        }

        #region Dispose Function

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (Context != null)
                        Context.Dispose();
                }
                disposed = true;
            }
        }

        #endregion
    }
}
