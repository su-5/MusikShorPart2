using System;
using System.Collections.Generic;

namespace DAL.Core.ModelDTO
{
   public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
