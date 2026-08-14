using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Core.Entities
{
    [Table("PRODUCTS")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quntity { get; set; }
        public string? BatchNo { get; set; }    
        public DateOnly? ManfactureDate { get; set; }
        public decimal Rate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get;set; }
    }
}
