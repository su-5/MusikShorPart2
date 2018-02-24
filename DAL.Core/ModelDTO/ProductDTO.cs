using System;

namespace DAL.Core.ModelDTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int PictureId { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public int NumberStringId { get; set; }
        public decimal Price { get; set; }
        public int NumberProduct { get; set; }
        public DateTime DateManufacture { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public DateTime DateDelete { get; set; }
        public int SubcategoriesId { get; set; }

        public Brand Brand { get; set; }
        public Country Country { get; set; }
        public NumberString NumberString { get; set; }
        public Picture Picture { get; set; }
        public Subcategory Subcategory { get; set; }
        
    }
}