//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace V1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categories
    {
        public Categories()
        {
            this.Products = new HashSet<Products>();
        }
    
        public int CatID { get; set; }
        public string CatName { get; set; }
    
        public virtual ICollection<Products> Products { get; set; }
    }
}
