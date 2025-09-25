using AutoMapper;
using CarrinhoApi.DTO;
using CarrinhoApi.Model;
using CarrinhoApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace CarrinhoApi.Repository
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly MysqlContext _context;
        private readonly IMapper _mapper;
        public CarrinhoRepository(MysqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public async Task<CarrinhoDTO> FindCarrinhoByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LimpaCarrinho(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCarrinho(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<CarrinhoDTO> UpdateCarrinho(CarrinhoDTO carrinhoDTO)
        {
            Carrinho carrinho = _mapper.Map<Carrinho>(carrinhoDTO);
            var produtos = await _context.Products.
                FirstOrDefaultAsync(
                    p => p.Id == carrinho.CarrinhoDetalhes.
                    FirstOrDefault().ProductId
                );
            if (produtos != null)
            {
                _context.Products.Add(carrinho.CarrinhoDetalhes.FirstOrDefault().Product);
                await _context.SaveChangesAsync();
            }

            var carrinhoCabeca = await _context.CarrinhoCabeca.
                AsNoTracking().
                FirstOrDefaultAsync(
                c => c.UserId == carrinho.CarrinhoCabeca.UserId
                );

            if (carrinhoCabeca == null)
            {
                await _context.CarrinhoCabeca.AddAsync(carrinho.CarrinhoCabeca);
                await _context.SaveChangesAsync();
                carrinho.CarrinhoDetalhes.FirstOrDefault().
                    CarrinhoCabecaId = carrinho.CarrinhoCabeca.Id;
                carrinho.CarrinhoDetalhes.FirstOrDefault().CarrinhoCabeca = null;
                await _context.CarrinhoDetalhe.
                    AddAsync(carrinho.CarrinhoDetalhes.FirstOrDefault());
                await _context.SaveChangesAsync();
            }
            else { 
                var carrinhoDetalhe = await _context.CarrinhoDetalhe.
                    AsNoTracking().
                    FirstOrDefaultAsync(
                    c => c.ProductId == carrinho.CarrinhoDetalhes.
                    FirstOrDefault().ProductId &&
                    c.CarrinhoCabecaId == carrinhoCabeca.Id
                    );
                if (carrinhoDetalhe == null)
                {
                    carrinho.CarrinhoDetalhes.FirstOrDefault().
                        CarrinhoCabecaId = carrinhoCabeca.Id;
                    carrinho.CarrinhoDetalhes.FirstOrDefault().CarrinhoCabeca = null;
                    await _context.CarrinhoDetalhe.
                        AddAsync(carrinho.CarrinhoDetalhes.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }
                else
                {
                    carrinhoDetalhe.Count += carrinho.CarrinhoDetalhes.
                        FirstOrDefault().Count;
                    carrinho.CarrinhoDetalhes.FirstOrDefault().Id = carrinhoDetalhe.Id;
                    carrinho.CarrinhoDetalhes.FirstOrDefault().CarrinhoCabecaId = carrinhoCabeca.Id;
                    carrinho.CarrinhoDetalhes.FirstOrDefault().CarrinhoCabeca = null;
                    _context.CarrinhoDetalhe.Update(carrinho.CarrinhoDetalhes.FirstOrDefault());
                    await _context.SaveChangesAsync();
                }

            }

                return _mapper.Map<CarrinhoDTO>(carrinho);
        }
    }
}
