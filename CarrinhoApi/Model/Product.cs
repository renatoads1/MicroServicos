using CarrinhoApi.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarrinhoApi.Model
{
    [Table("product")]
    public class Product
    {
        //gerar o id do banco em vez de usar identity
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("id")]
        public long Id { get; set; }
        
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Column("price")]
        [Required]
        [Range(1,1000)]
        public decimal Price { get; set; }
        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }
        [Column("category_name")]
        [StringLength(50)]
        public string CategoryName { get; set; }
        [Column("image_url")]
        [StringLength(300)]
        public string ImageUrl { get; set; }

    }
}
