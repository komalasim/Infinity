using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infinity.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public string UserAddress { get; set; }
        public string OrderDetails { get; set; } //String Format = ProductID-ProductName-Quantity
        public int TotalPrice { get; set; }
        public string Date { get; set; }
        public bool Status { get; set; }  //0 = Active, 1 = Delivered
    }
}