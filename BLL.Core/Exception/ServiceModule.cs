using Abp.Domain.Uow;
using Abp.EntityFramework.Uow;
using Ninject.Modules;

namespace BLL.Core.Exception
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;

        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EfUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
