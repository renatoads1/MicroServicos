using CarrinhoApi.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarrinhoApi.Model
{
    [Table("carrinho_cabeca")]
    public class CarrinhoCabeca:BaseEntity
    {
        [Column("user_id")]
        public string UserId { get; set; }
        [Column("cupon_code")]
        public string CuponCode { get; set; }

    }
}
