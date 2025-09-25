using AutoMapper;

namespace CarrinhoApi.Config
{
    public class MappingConfig
    {
        public MappingConfig() { }
        public static MapperConfiguration RegisterMaps()
        {
            var mappingconfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTO.ProductDTO, Model.Product>().ReverseMap();
                cfg.CreateMap<DTO.CarrinhoCabecaDTO, Model.CarrinhoCabeca>().ReverseMap();
                cfg.CreateMap<DTO.CarrinhoDetalheDTO, Model.CarrinhoDetalhe>().ReverseMap();
                cfg.CreateMap<DTO.CarrinhoDTO, Model.Carrinho>().ReverseMap();
                
            });
            return mappingconfig;
        }
    }
}
