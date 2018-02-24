using DAL.Core.GenericRepositoryModel.Interfaces;

namespace DAL.Core.DAL_Core
{
    public interface IDALFactory
    {
        IProductDAL Product { get; }
    }
}