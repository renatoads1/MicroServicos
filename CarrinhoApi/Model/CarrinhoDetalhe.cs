using CarrinhoApi.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarrinhoApi.Model
{
    [Table("carrinho_detalhe")]
    public class CarrinhoDetalhe : BaseEntity
    {
        public long CarrinhoCabecaId { get; set; }
        [ForeignKey("carrinho_cabecaId")]
        public CarrinhoCabeca CarrinhoCabeca { get; set; }
        public long ProductId { get; set; }
        [ForeignKey("product_id")]
        public Product Product { get; set; }

        [Column("count")]
        public int Count { get; set; }

    }
}
