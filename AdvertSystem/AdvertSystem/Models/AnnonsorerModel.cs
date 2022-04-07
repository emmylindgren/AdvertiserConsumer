using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertSystem.Models
{
    [Table("Tbl_Annonsorer")]
    public class AnnonsorerModel
    {
        [Key]
        public int An_Id { get; set; }

        public int An_SubId { get; set; }

        public CompanyModel An_CoId { get; set; }

    }
}
