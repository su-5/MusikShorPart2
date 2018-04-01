namespace DAL.Core.ModelDTO
{
   public class CartDto : ProductDTO
   {
       public bool SelectProductForCart { get; set; } = true;
       public int SelectNumber { get; set; } = 1;
    }
}
