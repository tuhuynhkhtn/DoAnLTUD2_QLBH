//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace V1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
    
        public int CatID { get; set; }
        public string CatName { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
}
