using CarrinhoApi.Model;
using CarrinhoApi.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarrinhoApi.DTO
{
    public class CarrinhoDetalheDTO
    {
        public long Id { get; set; }
        public long CarrinhoCabecaId { get; set; }
        public CarrinhoCabecaDTO CarrinhoCabeca { get; set; }
        public long ProductId { get; set; }
        public ProductDTO ProductDTO { get; set; }
        public int Count { get; set; }

    }
}
