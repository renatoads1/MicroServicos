using AutoMapper;
using CarrinhoApi.DTO;
using CarrinhoApi.Model;
using CarrinhoApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace CarrinhoApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MysqlContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(MysqlContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProductDTO> Create(ProductDTO product)
        {
            Product prod = _mapper.Map<Product>(product);
            _context.Products.Add(prod);
            _context.SaveChanges();
            return _mapper.Map<ProductDTO>(prod);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                ProductDTO product = await _context.Products.Where(p => p.Id == id)
                .FirstAsync()
                .ContinueWith(task => _mapper.Map<ProductDTO>(task.Result));
                if (product == null) return false;
                Product prod = _mapper.Map<Product>(product);

                var local = _context.Products.Local.FirstOrDefault(p => p.Id == id);
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }

                _context.Products.Remove(prod);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Exists(long id)
        {
            ProductDTO product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id)
            .ContinueWith(task => _mapper.Map<ProductDTO>(task.Result));
            if (product == null) return false;
            return true;
        }

        public async Task<IEnumerable<ProductDTO>> FindAll()
        {
            List<ProductDTO> products = await _context.Products.AsNoTracking().ToListAsync()
                .ContinueWith(task => _mapper.Map<List<ProductDTO>>(task.Result));
            return products;
        }

        public async Task<ProductDTO> FindById(long id)
        {
            ProductDTO product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id)
                .ContinueWith(task => _mapper.Map<ProductDTO>(task.Result));
            return product;
        }

        public async Task<ProductDTO> Update(ProductDTO product)
        {
            Product prod = _mapper.Map<Product>(product);
            _context.Products.Update(prod);
            _context.SaveChanges();
            return _mapper.Map<ProductDTO>(prod);
        }
    }
}
