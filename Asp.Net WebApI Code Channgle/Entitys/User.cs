using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.Net_WebApI_Code_Channgle.Entitys
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        
        [Required]
        [StringLength(50)]
        [Column("Username", TypeName = "varchar")]

        public string? UserName { get; set; }
        [Required]
        [StringLength(100)]
        [Column("Email", TypeName = "varchar")]

        public string? Email { get; set; }

        [Required]
        [StringLength(10)]
        public string? Password { get; set; }
        [Required]
        [StringLength(10)]
        [Column("Role", TypeName = "varchar")]

        public string Role { get; set; }
    }
        
        
}
