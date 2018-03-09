namespace BLL.Core.BLL_Core.Interface
{
    public interface IBLLFactory
    {
        IProductBLL ProductBll { get; }
        IBrandBLL BrandBll { get; }
        ICountryBLL CountryBll { get; }
        INumberStringBLL NumberStringBll { get; }
        ISubcategoryBLL SubcategoryBll { get; }
        ICategoryBLL CategoryBll { get; }
    }
}