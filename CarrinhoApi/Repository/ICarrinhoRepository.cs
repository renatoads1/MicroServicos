using CarrinhoApi.DTO;

namespace CarrinhoApi.Repository
{
    public interface ICarrinhoRepository
    {
        Task<CarrinhoDTO> FindCarrinhoByUserId(string userId);
        Task<CarrinhoDTO> UpdateCarrinho(CarrinhoDTO carrinho);
        Task<bool> RemoveCarrinho(long userId);
        Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> RemoveCoupon(string userId);
        Task<bool> LimpaCarrinho(string userId);
        //Task<bool> Checkout(Model.DTO.CarrinhoCheckoutDTO carrinhoCheckout);
    }
}
