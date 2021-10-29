using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
