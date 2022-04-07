using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertSystem.Models
{
    [Table("Tbl_Companies")]
    public class CompanyModel
    {
        [Key]
        public int Co_OrgId { get; set; }

        public string Co_Name { get; set; } = string.Empty;

        public int Co_Telephone { get; set; }

        public AddressModel Co_Address { get; set; }

        public AddressModel Co_BillingAddress { get; set; }
    }
}
