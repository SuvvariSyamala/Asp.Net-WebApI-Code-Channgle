using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Net_WebApI_Code_Channgle.Entitys
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }

        [ForeignKey(nameof(ProductId))]   
        public int ProductId { get; set; }

        public Product Product { get; set; }    


        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; } 

        public User User { get; set; }  

    }
}
