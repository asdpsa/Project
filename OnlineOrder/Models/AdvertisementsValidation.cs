using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineOrder.Models
{
    public class AdvertisementsValidation
    {
        public string Image { get; set; }
        [Required]
        public string Key { get; set; }
        [Required]
        public string Description { get; set; }
    }
    // Add this out of customerValidation class
    [MetadataType(typeof(AdvertisementsValidation))]
    // Note the partial keyword
    public partial class Advertisement { }
}