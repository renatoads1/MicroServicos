namespace CarrinhoApi.Model
{
    public class Carrinho
    {
        public CarrinhoCabeca CarrinhoCabeca { get; set; }
        public IEnumerable<CarrinhoDetalhe> CarrinhoDetalhes { get; set; }
    }
}
