using CarrinhoApi.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarrinhoApi.DTO
{
    public class CarrinhoCabecaDTO
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string CuponCode { get; set; }

    }
}
