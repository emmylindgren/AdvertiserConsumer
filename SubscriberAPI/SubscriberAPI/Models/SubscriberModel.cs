
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SubscriberAPI.Models
{
    [Table("Tbl_Subscribers")]
    public class SubscriberModel
    {
        [Key]
        public int Su_Id { get; set; }

        public string Su_FirstName { get; set; } = string.Empty;

        public string Su_LastName { get; set; } = string.Empty;

        public long Su_PersonId { get; set; }

        public string Su_Street { get; set; } = string.Empty;

        public int Su_PostalCode { get; set; }

        public string Su_City { get; set; } = string.Empty;

    }

}
