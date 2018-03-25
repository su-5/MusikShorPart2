using DAL.Core.GenericRepositoryModel.Interfaces;

namespace DAL.Core.DAL_Core
{
    public interface IDALFactory
    {
        IProductDAL Product { get; }
        IBrandDAL Brand { get; }
        ICountryDAL Country { get; }
        INumberStringDAL NumberString { get; }
        ISubcategoryDAL Subcategory { get; }
        ICategoryDAL Category { get; }
        IUserDAL User { get; }
    }
}