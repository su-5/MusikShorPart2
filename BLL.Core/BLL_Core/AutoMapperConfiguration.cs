using AutoMapper;
using BLL.Core.BLL_Core.Mapping;

namespace BLL.Core.BLL_Core
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<BrandMapper>();
                x.AddProfile<CountryMapper>();
                x.AddProfile<NumberStringMapper>();
                x.AddProfile<SubcategoryMapper>();
                x.AddProfile<CategoryMapper>();
                x.AddProfile<ProductMapper>();
                x.AddProfile<UserMapper>();
                x.AddProfile<CartMapper>();
                x.AddProfile<OrderMapper>();
            });
        }
    }
}


