using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AccountManager.Models
{
    public class OnlineAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}

        [Required(ErrorMessage="Account Name cannot be empty")]
        [StringLength(100)]
        public string Name {get;set;}

        [Required(ErrorMessage="User Name should be specified")]
        [StringLength(50)]
        public string UserId {get;set;}

        [Required(ErrorMessage="Password must be specified")]
        [StringLength(50)]
        public string Password {get;set;}

        [StringLength(500)]
        [MaxLength(500)]
        public string Notes { get;set;}
    }
}