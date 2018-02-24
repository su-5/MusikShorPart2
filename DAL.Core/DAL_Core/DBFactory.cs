using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Core.DAL_Core
{
    public class DbFactory : Disposable, IDbFactory
    {
        MusicDataBaseEntities dbContext;
        public MusicDataBaseEntities Init()
        {
            return dbContext ?? (dbContext = new MusicDataBaseEntities ());
        }

        protected override void DisposeCore()
        {
            dbContext?.Dispose();
        }
    }

    public class Disposable : IDisposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        // Ovveride this to dispose custom objects
        protected virtual void DisposeCore()
        {
        }
    }

}
