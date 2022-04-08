using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertSystem.Models
{
    [Table("Tbl_Companies")]
    public class CompanyModel
    {
        [Key]
        public int Co_OrgId { get; set; }

        [Required]
        public string Co_Name { get; set; } = string.Empty;
        [Required]
        public int Co_Telephone { get; set; }
        [Required]
        public string Co_BillStreet { get; set; } = string.Empty;
        [Required]
        public int Co_BillPostalCode { get; set; }
        [Required]
        public string Co_BillCity{ get; set; } = string.Empty;
        [Required]
        public string Co_Steet { get; set; } = string.Empty;
        [Required]
        public int Co_PostalCode { get; set; }
        [Required]
        public string Co_City { get;set; } = string.Empty;
    }
}
