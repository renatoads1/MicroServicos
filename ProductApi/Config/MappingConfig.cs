using AutoMapper;

namespace ProductApi.Config
{
    public class MappingConfig
    {
        public MappingConfig() { }
        public static MapperConfiguration RegisterMaps()
        {
            var mappingconfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DTO.ProductDTO, Model.Product>();
                cfg.CreateMap<Model.Product, DTO.ProductDTO>();
            });
            return mappingconfig;
        }
    }
}
