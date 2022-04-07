using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubscriberAPI.Models
{
    [Table("Tbl_Address")]
    public class AddressModel
    {
        [Key]
        public int Ad_Id { get; set; }
        public string Ad_Street { get; set; }

        public string Ad_City { get; set; }

        public int Ad_PostalCode { get; set; }


    }
}
