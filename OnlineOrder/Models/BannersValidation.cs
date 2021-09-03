using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineOrder.Models
{
    public class BannersValidation
    {
        public string Image { get; set; }
        [Required]
        public Nullable<byte> Sort { get; set; }
        [Required]
        public string Description { get; set; }
    }
    // Add this out of customerValidation class
    [MetadataType(typeof(BannersValidation))]
    // Note the partial keyword
    public partial class Banner { }
}