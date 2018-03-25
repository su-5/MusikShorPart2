using System;

namespace DAL.Core.DAL_Core
{
    public class DbFactory : Disposable, IDbFactory
    {
        MusicDataBaseEntities _dbContext;
        public MusicDataBaseEntities Init()
        {
            return _dbContext ?? (_dbContext = new MusicDataBaseEntities ());
        }

        protected override void DisposeCore()
        {
            _dbContext?.Dispose();
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
