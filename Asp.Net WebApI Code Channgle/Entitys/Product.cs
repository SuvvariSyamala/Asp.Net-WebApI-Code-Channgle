using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Net_WebApI_Code_Channgle.Entitys
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        [Column("Username", TypeName = "varchar")]
        public string? Name { get; set; }
        [Required]
        public double Price { get; set; }

        [ForeignKey(nameof(SuppilerId))] 
        public  int SuppilerId { get; set; }  
        
        public User Suppiler { get; set; }  
    }
}
