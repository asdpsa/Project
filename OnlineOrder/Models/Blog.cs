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
    
    public partial class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public Nullable<byte> Status { get; set; }
        public Nullable<int> VIEW { get; set; }
    }
}
