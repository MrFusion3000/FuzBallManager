//using AutoMapper;

//namespace Application.Mappers
//{
//    public class ManagerMapper
//    {
//        private static readonly Lazy<IMapper> Lazy = new(() =>
//        {
//            var config = new MapperConfiguration(cfg =>
//            {
//                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
//                cfg.AddProfile<ManagerMappingProfile>();
//            });
//            var mapper = config.CreateMapper();
//            return mapper;
//        });
//        public static IMapper Mapper => Lazy.Value;
//    }
//}
