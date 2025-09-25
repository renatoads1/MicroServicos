namespace CarrinhoApi.DTO
{
    public class CarrinhoDTO
    {
        public CarrinhoCabecaDTO CarrinhoCabeca { get; set; }
        public IEnumerable<CarrinhoDetalheDTO> CarrinhoDetalhes { get; set; }
    }
}
