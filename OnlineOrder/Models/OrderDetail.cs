//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineOrder.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public Nullable<int> SizeId { get; set; }
        public Nullable<int> FramesId { get; set; }
        public int Quantity { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> UpdatedAt { get; set; }
    
        public virtual Frame Frame { get; set; }
        public virtual Order Order { get; set; }
        public virtual Size Size { get; set; }
    }
}
