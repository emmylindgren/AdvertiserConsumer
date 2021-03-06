using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertSystem.Models
{
    [Table("Tbl_Ads")]
    public class AdModel
    {
        [Key]
        public int Ads_Id { get; set; }
        [Required]
        public string Ads_Title { get; set; } = string.Empty;
        [Required]
        public string Ads_Content { get; set; } = string.Empty;
        [Required]
        public int Ads_ProductPrice { get; set; }
        public int Ads_Price { get; set; }
        public AnnonsorerModel? Ads_Annonsor { get; set; }
    }
}
