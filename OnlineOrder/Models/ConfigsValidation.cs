using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineOrder.Models
{
    public partial class ConfigsValidation
    {
        [Required]
        public string Image { get; set; }
        [Required]
        public string Key { get; set; }
        [Required]
        public string Data { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public Nullable<byte> Status { get; set; }
       
    }
    // Add this out of customerValidation class
    [MetadataType(typeof(ConfigsValidation))]
    // Note the partial keyword
    public partial class Config { }
}