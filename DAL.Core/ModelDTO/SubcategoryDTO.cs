namespace DAL.Core.ModelDTO
{
    public class SubcategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoriesId { get; set; }

        public virtual Category Category { get; set; }
    }
}