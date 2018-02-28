using BLL.Core.BLL_Core.Mapping;
using static AutoMapper.Mapper;

namespace BLL.Core.BLL_Core
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            //Initialize(x => x.AddProfile<ProductMapper>());
            //Initialize(x => x.AddProfile<NumberStringMapper>());
            //Initialize(x => x.AddProfile<CountryMapper>());
            Initialize(x => x.AddProfile<BrandMapper>());
            //Initialize(x => x.AddProfile<SubcategoryMapper>());


        }
    }
}
